using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;

namespace Budget.MODEL.Filter
{


    public class FilterAsifTableSelected: FilterTableSelected
    {
        public UserForGroupDto User { get; set; }
        public int? IdImport { get; set; }
        public int? IndexTabAsifState { get; set; }
        public Select Account { get; set; }
        public Select State { get; set; }
        public string AsiBankAgencyLabel { get; set; }
        public DateTime? AsiDateImport { get; set; }

        public List<Select> OperationMethod { get; set; }
        public List<Select> OperationTypeFamily { get; set; }
        public List<Select> OperationType { get; set; }
        public List<Select> Operation { get; set; }
        public FilterDateRange DateIntegration { get; set; }
        public FilterNumberRange AmountOperation { get; set; }

        public FilterAsifTableSelected()
        {
            this.EnumFilterTableSelectedType = EnumFilterTableSelectedType.ASIF;
        }

    }

    public class FilterAsifTableSelection
    {
        //public string AsiBankAgencyLabel { get; set; }
        //public DateTime AsiDateImport { get; set; }
        public List<Select> Account { get; set; }
        public List<Select> State { get; set; }

        public List<Select> OperationMethod { get; set; }
        public List<SelectGroupDto> OperationTypeFamily { get; set; }
        public List<SelectGroupDto> OperationType { get; set; }
        public List<Select> Operation { get; set; }


        public FilterAsifTableSelection()
        {
            //Selected = new FilterAsifTableSelected();
        }
    }

    //public class FilterAsifDetail
    //{
    //    public int? IdAsif { get; set; }
    //    public UserForGroupDto User { get; set; }
    //}

    public class FilterAsifForDetail: FilterAsForDetail
    {

    }

    //public class FilterAccountStatementImportFile : Pagination
    //{
    //    public int? IdImport { get; set; }
    //    public int? IdAccount { get; set; }
    //    public int? IdAsifState { get; set; }
    //}
}
