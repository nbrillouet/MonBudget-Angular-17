using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class PosteService : IPosteService
    {
        private readonly IMapper _mapper;
        private readonly IPosteRepository _posteRepository;

        public PosteService(
            IMapper mapper,
            IPosteRepository posteRepository
        )
        {
            _mapper = mapper;
            _posteRepository = posteRepository;

        }

        public Poste GetById(int idPoste)
        {
            return _posteRepository.GetById(idPoste);
        }

        public List<Select> GetAllSelect()
        {
            var postes = _posteRepository.GetAll();

            return _mapper.Map<List<Select>>(postes);
        }
    }

}
