using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class AssetService : IAssetService
    {
        private readonly IMapper _mapper;
        private readonly IAssetRepository _assetRepository;
        private readonly ISelectService _selectService;

        public AssetService(
            IAssetRepository assetRepository,
            ISelectService selectService,
            IMapper mapper
            )
        {
            _assetRepository = assetRepository;
            _selectService = selectService;
            _mapper = mapper;
        }


        public List<SelectCode> GetSelectList(EnumAssetFamily enumAssetFamily)
        {
            //var selectList = _selectService.GetSelectList(enumAssetFamily);
            var assets = _assetRepository.GetList(enumAssetFamily);
            //selectList.AddRange(_mapper.Map<IEnumerable<SelectDto>>(selectList).ToList());

            return _mapper.Map<List<SelectCode>>(assets);
        }

        public SelectCode GetSelect(EnumAsset enumAsset)
        {
            var asset = _assetRepository.GetById((int)enumAsset);

            return _mapper.Map<SelectCode>(asset);
        }

    }

}
