using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IUserPreferenceService
    {
        UserPreference Get(int id);
        UserPreference GetByIdUser(int idUser);
        UserPreference Update(UserPreference userPreference);
        void UpdateUserStatut(int idUser, string statut);

    }
}
