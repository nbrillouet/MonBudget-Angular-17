using AutoMapper;
using Budget.DATA.Repositories;
using Budget.HELPER;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public class AsSoldeService : IAsSoldeService
    {
        private readonly IMapper _mapper;
        private readonly IAccountStatementRepository _accountStatementRepository;
        //private readonly IAccountService _accountService;
        public AsSoldeService(
            IMapper mapper,
            IAccountStatementRepository accountStatementRepository

            //IAccountService accountService

            )
        {
            _mapper = mapper;
            _accountStatementRepository = accountStatementRepository;

            //_accountService = accountService;
        }

        public SoldeDto GetSolde(int? idUser, int? idAccount, DateTime dateMin, DateTime dateMax, bool isWithITransfer)
        {
            return _accountStatementRepository.GetSolde(idUser, idAccount, dateMin, dateMax, isWithITransfer);
        }

        public Solde GetSolde(FilterAsMainSelected filter)
        {
            var date = Convert.ToDateTime($"01/{filter.MonthYear.Month.Id}/{filter.MonthYear.Year}");
            var dateMin = DateHelper.GetFirstDayOfMonth(date);
            var dateMax = DateHelper.GetLastDayOfMonth(date);
            SoldeDto soldeDto = GetSolde(filter.User.Id, filter.IdAccount, dateMin, dateMax, filter.IsWithITransfer);
            Solde solde = _mapper.Map<Solde>(soldeDto);
            //solde.Account = _accountService.GetSelectById(filter.IdAccount.Value);
            solde.DateMax = dateMax;

            //solde.Account = _referentialService.AccountService.GetSelectById(filter.IdAccount.Value);
            return solde;
        }

    }
}
