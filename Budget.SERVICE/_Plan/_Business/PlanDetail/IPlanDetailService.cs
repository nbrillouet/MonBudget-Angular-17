using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IPlanDetailService
    {
        PlanForDetailDto GetForDetail(int idPlan, int idUser);

        void Save(PlanForDetailDto planForDetailDto);
    }

}
