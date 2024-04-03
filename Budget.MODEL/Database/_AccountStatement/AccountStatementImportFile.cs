using Budget.MODEL.Enum;
using System;

namespace Budget.MODEL.Database
{
    public class AccountStatementImportFile
    {
        public int Id { get; set; }

        public int IdImport { get; set; }
        public AccountStatementImport AccountStatementImport { get; set; }

        public int? IdAccount { get; set; }
        public Account Account { get; set; }

        public DateTime? DateOperation { get; set; }
        public string LabelAs { get; set; }

        public int? IdOperationMethod { get; set; }
        public OperationMethod OperationMethod { get; set; }

        public int? IdOperation { get; set; }
        public Operation Operation { get; set; }

        public int? IdOperationDetail { get; set; }
        public OperationDetail OperationDetail { get; set; }

        public int? IdOperationType { get; set; }
        public OperationType OperationType { get; set; }

        public int? IdOperationTypeFamily { get; set; }
        public OperationTypeFamily OperationTypeFamily { get; set; }

        public int? IdMovement { get; set; }
        public Movement Movement { get; set; }

        public int? IdState { get; set; }
        public StateAsif State { get; set; }

        public string Reference { get; set; }
        public DateTime? DateIntegration { get; set; }
        public double? AmountOperation { get; set; }
        public DateTime DateImport { get; set; }
        public string LabelAsWork { get; set; }
        public bool IsDuplicated { get; set; }
        
        public string OdOperationKeyword { get; set; }
        public string OdPlaceKeyword { get; set; }
        public string OdOperationLabel { get; set; }
        public string OdPlaceLabel { get; set; }

        public AccountStatementImportFile()
        {

        }
    }
       
}
