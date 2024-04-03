using Budget.MODEL;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IUserEventService 
    {
        List<UserEventDto> Get(UserForDetail userForDetail);
    }
}
