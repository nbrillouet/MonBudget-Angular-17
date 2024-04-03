using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{

    public class OperationDetail
    {
        public int Id { get; set; }
        public int IdOperation { get; set; }
        public Operation Operation { get; set; }

        public string KeywordOperation { get; set; }
        public string KeywordPlace { get; set; }
        public string OperationLabel { get; set; }
        public string PlaceLabel { get; set; }

        public int? IdGMapAddress { get; set; }
        public GMapAddress GMapAddress { get; set; }

        public int IdOperationPlace { get; set; }
        public OperationPlace OperationPlace { get; set; }

        public int IdUserGroup { get; set; }
        public bool IsMandatory { get; set; }

        //public int? IdMovement { get; set; }


    }
}
