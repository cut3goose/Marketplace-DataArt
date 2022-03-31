using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Contracts.Product.Enums;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;
using OnlineShop.Product.Domain.Utils;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Domain.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public PhotoService(
            IPhotoRepository photoRepository,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _photoRepository = photoRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PhotoListModel> AddPhotoAsync(PhotoCreateModel photoCreateModel)
        {
            var photo = _mapper.Map<Photo>(photoCreateModel);
            var originalImage = photo.File;

            var photos = new List<Photo>();
            var imageHelper = new ImageHelper();

            var photoSmall = new Photo
            {
                Size = PhotoSize.Small,
                File = imageHelper.ResizeImage(originalImage, new Size(200, 200))
            };
            photos.Add(photoSmall);

            var photoMedium = new Photo
            {
                Size = PhotoSize.Medium,
                File = imageHelper.ResizeImage(originalImage, new Size(500, 500))
            };
            photos.Add(photoMedium);

            var photoLarge = new Photo
            {
                Size = PhotoSize.Large,
                File = imageHelper.ResizeImage(originalImage, new Size(1000, 1000))
            };
            photos.Add(photoLarge);

            var photosResponse = await _photoRepository.AddPhotosAsync(photos);

            return new PhotoListModel
            {
                Photos = _mapper.Map<IEnumerable<PhotoModel>>(photosResponse)
            };
        }

        public async Task<PhotoModel> GetPhotoAsync(int photoId)
        {
            var photo = await _photoRepository.GetByIdAsync(photoId);

            if (photo == null)
                return null;

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task<byte[]> GetPhotoFileAsync(int photoId)
        {
            var photo = await _photoRepository.GetByIdAsync(photoId);

            if (photo == null)
                return null;

            return photo.File;
        }

        public async Task<PhotoListModel> GetPhotosByProductAsync(int productId)
        {
            var photos = await _photoRepository.GetPhotosByProductAsync(productId);

            return new PhotoListModel
            {
                Photos = _mapper.Map<IEnumerable<PhotoModel>>(photos)
            };
        }

        public async Task<PhotoModel> GetPhotoByCategoryAsync(int categoryId)
        {
            var photo = await _photoRepository.GetPhotoByCategoryAsync(categoryId);

            if (photo == null)
                return null;

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task<bool> SetPhotosForProductAsync(int productId, int[] photoIds)
        {
            var product = _productRepository.GetByIdAsync(productId);

            if (product == null)
                return false;

            foreach (var photoId in photoIds)
            {
                var photo = _photoRepository.GetByIdAsync(photoId);

                if (photo == null)
                    return false;
            }

            await _photoRepository.SetPhotosForProductAsync(productId, photoIds);

            return true;
        }

        public async Task<bool> SetPhotoForCategoryAsync(int categoryId, int photoId)
        {
            var product = _categoryRepository.GetByIdAsync(categoryId);
            var photo = _photoRepository.GetByIdAsync(photoId);

            if (product == null || photo == null)
                return false;

            await _photoRepository.SetPhotoForCategoryAsync(categoryId, photoId);

            return true;
        }

        public async Task<bool> UpdatePhotoAsync(PhotoUpdateModel photoUpdateModel)
        {
            var photo = await _photoRepository.GetByIdAsync(photoUpdateModel.Id);

            if (photo == null)
                return false;

            _mapper.Map(photoUpdateModel, photo);
            await _photoRepository.UpdateAsync(photo);

            return true;
        }

        public async Task<bool> DeletePhotoAsync(int photoId)
        {
            var photo = await _photoRepository.GetByIdAsync(photoId);

            if (photo == null)
                return false;

            await _photoRepository.DeleteAsync(photo);

            return true;
        }
    }
}
