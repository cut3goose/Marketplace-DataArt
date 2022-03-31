using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Domain.Services
{
    public class MetaService : IMetaService
    {
        private readonly IMetaRepository _metaRepository;
        private readonly IMapper _mapper;

        public MetaService(IMetaRepository metaRepository, IMapper mapper)
        {
            _metaRepository = metaRepository;
            _mapper = mapper;
        }

        public async Task<MetaModel> CreateMetaAsync(MetaCreateModel metaCreateModel)
        {
            var meta = _mapper.Map<Meta>(metaCreateModel);

            await _metaRepository.AddAsync(meta);

            return _mapper.Map<MetaModel>(meta);
        }

        public async Task<MetaListModel> GetMetaForProductAsync(int productId)
        {
            var meta = await _metaRepository.GetMetaForProductAsync(productId);

            if (meta == null)
                return null;

            return new MetaListModel
            {
                Metas = _mapper.Map<IEnumerable<MetaModel>>(meta)
            };
        }

        public async Task<bool> UpdateMetaAsync(MetaUpdateModel metaUpdateModel)
        {
            var meta = await _metaRepository.GetByIdAsync(metaUpdateModel.Id);

            if (meta == null)
                return false;

            _mapper.Map(metaUpdateModel, meta);
            await _metaRepository.UpdateAsync(meta);

            return true;
        }

        public async Task<bool> DeleteMetaAsync(int metaId)
        {
            var product = await _metaRepository.GetByIdAsync(metaId);

            if (product == null)
                return false;

            await _metaRepository.DeleteAsync(product);

            return true;
        }
    }
}
