using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    public class AccountStatement
    {
        public int Id { get; set; }

        public int IdImport { get; set; }
        public AccountStatementImport AccountStatementImport { get; set; }
        public int IdAccount { get; set; }
        public Account Account { get; set; }
        public int IdOperationMethod { get; set; }
        public OperationMethod OperationMethod { get; set; }
        public int IdOperation { get; set; }
        public Operation Operation { get; set; }
        public int IdOperationDetail { get; set; }
        public OperationDetail OperationDetail { get; set; }
        public int IdOperationType { get; set; }
        public OperationType OperationType { get; set; }
        public int IdOperationTypeFamily { get; set; }
        public OperationTypeFamily OperationTypeFamily { get; set; }
        public int IdMovement { get; set; }
        public Movement Movement { get; set; }


        public DateTime? DateOperation { get; set; }
        public string LabelAs { get; set; }
        public string Reference { get; set; }
        public DateTime? DateIntegration { get; set; }
        public double AmountOperation { get; set; }
        public DateTime DateImport { get; set; }

        public int? IdAccountStatementIt { get; set; }
        public int? IdAccountIt { get; set; }

    }
}
