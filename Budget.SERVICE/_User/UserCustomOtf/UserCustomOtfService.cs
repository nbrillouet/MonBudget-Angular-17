using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class UserCustomOtfService : IUserCustomOtfService
    {
        private readonly IUserCustomOtfRepository _userCustomOtfRepository;
        private readonly IMapper _mapper;

        public UserCustomOtfService(
            IUserCustomOtfRepository userAsCustomOtfRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _userCustomOtfRepository = userAsCustomOtfRepository;
        }

        private List<UserCustomOtf> Get(int idUser, int? idAccount)
        {

            var otfs = _userCustomOtfRepository.Get(idUser, idAccount);
            return otfs;

        }

        public List<Select> GetOperationTypeFamilySelect (int idUser,int? idAccount)
        {
            var otfs = _userCustomOtfRepository.GetOperationTypeFamilySelect(idUser, idAccount);
            return _mapper.Map<List<Select>>(otfs);

        }

        //TODO IN TRAN
        public bool Update(AsChartEvolutionCustomOtfFilterSelected filter)
        {
            //Suppression des items pour l'utilisateur et le le compte
            var userCustomOtfs = Get(filter.User.Id, filter.IdAccount);
            foreach(var userCustomOtf in userCustomOtfs)
            {
                _userCustomOtfRepository.Delete(userCustomOtf);
            }

            
            //Ajout des items de la liste en parametre
            foreach (var otf in filter.OperationTypeFamilies)
            {
                UserCustomOtf userCustomOtf = new UserCustomOtf
                {
                    Id = 0,
                    IdAccount = filter.IdAccount,
                    IdUser = filter.User.Id,
                    IdOperationTypeFamily = otf.Id
                };

                _userCustomOtfRepository.Create(userCustomOtf);
            }

            return true;
        }
    }
}
