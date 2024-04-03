using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    [Table("OPERATION_TRANSVERSE_ASIF", Schema = "as")]
    public class OperationTransverseAsif
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_OPERATION_TRANSVERSE")]
        public int IdOperationTransverse { get; set; }
        [ForeignKey("IdOperationTransverse")]
        public OperationTransverse OperationTransverse { get; set; }

        [Column("ID_ACCOUNT_STATEMENT_IMPORT_FILE")]
        public int IdAccountStatementImportFile { get; set; }
        [ForeignKey("IdAccountStatementImportFile")]
        public AccountStatementImportFile AccountStatementImportFile { get; set; }


    }
}
