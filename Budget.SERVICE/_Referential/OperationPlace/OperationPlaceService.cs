using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public class OperationPlaceService : IOperationPlaceService
    {
        private readonly IMapper _mapper;
        private readonly IOperationPlaceRepository _operationPlaceRepository;

        public OperationPlaceService(
            IOperationPlaceRepository operationPlaceRepository,
            IMapper mapper
            )
        {
            _operationPlaceRepository = operationPlaceRepository;
            _mapper = mapper;
        }

        public List<SelectCode> GetSelectListRestrict()
        {
            var operationPlaces = _operationPlaceRepository.GetSelectListRestrict();

            return _mapper.Map<List<SelectCode>>(operationPlaces);
        }

        public SelectCode GetSelectById(int id)
        {
            var operationPlace = _operationPlaceRepository.GetById(id);
            return _mapper.Map<SelectCode>(operationPlace);
        }

    }
}
