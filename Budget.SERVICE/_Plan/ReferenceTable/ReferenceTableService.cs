using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class ReferenceTableService : IReferenceTableService
    {
        private readonly IMapper _mapper;
        private readonly IReferenceTableRepository _referenceTableRepository;

        public ReferenceTableService(
            IMapper mapper,
            IReferenceTableRepository referenceTableRepository
        )
        {
            _mapper = mapper;
            _referenceTableRepository = referenceTableRepository;

        }

        public List<ReferenceTable> GetAll()
        {
            return _referenceTableRepository.GetAll();
        }
    }

}
