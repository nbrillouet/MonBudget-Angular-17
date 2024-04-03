using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IUserService
    {
        PagedList<UserForTableDto> GetUserTable(FilterUserTableSelected filter);

        User GetById(int id);
        User GetByUsername(string username);
        //Task<User> GetByIdAsync(int id);
        User GetLast();
        User GetByMail(string mail);
        User ActivateAccount(string activationCode);
        UserForDetail GetForDetailById(int id);
        UserForLogged GetForLoggedById(int id);
        UserForGroupDto GetForUserGroup(int id);
        UserPreference GetUserPreference(int idUser);
        List<User> GetAll();
        List<User> GetByIdUserGroup(int idUserGroup);

        UserForDetail Save(UserForDetail userForDetail);
        //void UpdateUserStatut(int idUser, string statut);
        void UpdateAvatar(int idUser, IFormFile file, string savePath);
        //string UpdateUserPreference(int idUser, UserPreference userPreference);
        //void Update(UserForDetail entity);
        //User Update(User entity);
        User UpdatePassword(User user);
        UserForLogged Update(UserForLogged userForLogged);
        User Register(User user);
    }
}
