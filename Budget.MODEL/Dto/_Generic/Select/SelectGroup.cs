using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class SelectGroupDto: Select
    {
        public List<Select> Selects { get; set; }

        public SelectGroupDto()
        {
            Selects = new List<Select>();
        }
    }

    public class SelectNameValueGroupDto<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SelectNameValueDto<T>> Selects { get; set; }

        public SelectNameValueGroupDto() 
        {
            Selects = new List<SelectNameValueDto<T>>();
        }
}
}
