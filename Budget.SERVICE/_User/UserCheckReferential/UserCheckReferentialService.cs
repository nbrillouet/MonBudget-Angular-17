using Budget.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class UserCheckReferentialService : IUserCheckReferentialService
    {
        private readonly IUserCustomOtfRepository _userCustomOtfRepository;
        
        public UserCheckReferentialService(
            IUserCustomOtfRepository userCustomOtfRepository
            )
        {
            _userCustomOtfRepository = userCustomOtfRepository;
        }

        public bool HasOtf(int idOtf)
        {
            return _userCustomOtfRepository.HasOtf(idOtf);
        }


    }
}
