using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IPosteService
    {
        Poste GetById(int idPoste);
        List<Select> GetAllSelect();
    }

}
