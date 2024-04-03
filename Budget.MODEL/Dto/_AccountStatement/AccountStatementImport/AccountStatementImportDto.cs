using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class AsiForUploadDto
    {
        public IFormFile File { get; set; }
    }

    public class AsiForListDto
    {
        public int Id { get; set; }
        public Select User { get; set; }
        public Select BankAgency { get; set; }
        public string FileImport { get; set; }
        public DateTime DateImport { get; set; }
    }

    public class AsiForTableDto
    {
        public int Id { get; set; }
        public UserForMinimal User { get; set; }
        public Select BankAgency { get; set; }
        public string FileImport { get; set; }
        public DateTime DateImport { get; set; }
    }

    public class AsiForDetail : AsiForTableDto
    {

    }
}
