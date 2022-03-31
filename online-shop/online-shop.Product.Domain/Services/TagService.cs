using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Domain.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagModel> CreateTagAsync(TagCreateModel tagCreateModel)
        {
            var tag = _mapper.Map<Tag>(tagCreateModel);

            await _tagRepository.AddAsync(tag);

            return _mapper.Map<TagModel>(tag);
        }

        public async Task<TagListModel> GetTagsByProductAsync(int productId)
        {
            var tags = await _tagRepository.GetTagsByProductAsync(productId);

            return new TagListModel
            {
                Tags = _mapper.Map<IEnumerable<TagModel>>(tags)
            };
        }

        public async Task<bool> UpdateTagAsync(TagUpdateModel tagUpdateModel)
        {
            var tag = await _tagRepository.GetByIdAsync(tagUpdateModel.Id);

            if (tag == null)
                return false;

            _mapper.Map(tagUpdateModel, tag);
            await _tagRepository.UpdateAsync(tag);

            return true;
        }

        public async Task<bool> DeleteTagAsync(int tagId)
        {
            var tag = await _tagRepository.GetByIdAsync(tagId);

            if (tag == null)
                return false;

            await _tagRepository.DeleteAsync(tag);

            return true;
        }
    }
}
