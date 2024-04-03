using Budget.MODEL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.MODEL
{
    //[Table("USER", Schema = "user")]
    public class User
    {
        public int Id { get; set; }

        public int? IdUserPreference { get; set; }
        public UserPreference UserPreference { get; set; }
        public int? IdGMapAddress { get; set; }
        public GMapAddress GMapAddress { get; set; }

        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastActive { get; set; }
        public int IdUserGroup { get; set; }
        public string Email { get; set; }
        public string ActivationCode { get; set; }
        public DateTime? ActivationDateSend { get; set; }
        public bool ActivationIsConfirmed { get; set; }
        public string Role { get; set; }
        

        //[Key]
        //[Column("ID")]
        //public int Id { get; set; }

        //[Column("USER_NAME")]
        //public string UserName { get; set; }
        //[Column("LAST_NAME")]
        //public string LastName { get; set; }
        //[Column("FIRST_NAME")]
        //public string FirstName { get; set; }
        //[Column("PASSWORD_HASH")]
        //public byte[] PasswordHash { get; set; }
        //[Column("PASSWORD_SALT")]
        //public byte[] PasswordSalt { get; set; }
        //[Column("GENDER")]
        //public string Gender { get; set; }
        //[Column("BIRTH_DATE")]
        //public DateTime? DateOfBirth { get; set; }
        //[Column("CREATION_DATE")]
        //public DateTime DateCreated { get; set; }
        //[Column("LAST_ACTIVE_DATE")]
        //public DateTime DateLastActive { get; set; }

        //[Column("ID_GMAP_ADDRESS")]
        //public int? IdGMapAddress { get; set; }
        //[ForeignKey("IdGMapAddress")]
        //public GMapAddress GMapAddress { get; set; }

        //[Column("AVATAR_URL")]
        //public string AvatarUrl { get; set; }
        //[Column("ID_AVATAR_CLOUD")]
        //public string IdAvatarCloud { get; set; }
        //[Column("ID_USER_GROUP")]
        //public int IdUserGroup { get; set; }

        //[Column("MAIL_ADDRESS")]
        //public string Email { get; set; }

        //[Column("ACTIVATION_CODE")]
        //public string ActivationCode { get; set; }
        //[Column("ACTIVATION_DATE_SEND")]
        //public DateTime? ActivationDateSend { get; set; }

        //[Column("ACTIVATION_IS_CONFIRMED")]
        //public bool ActivationIsConfirmed { get; set; }

        //[Column("ROLE")]
        //public string Role { get; set; }

        //[Column("LANGUAGE")]
        //public string Language { get; set; }

        //[Column("STATUS")]
        //public string Status { get; set; }
        //[Column("BANNER_URL")]
        //public string BannerUrl { get; set; }
        //public List<UserShortcut> Shortcuts { get; set; }
        //public virtual List<UserAccount> UserAccounts { get; set; }

        //public User()
        //{
        //    //Shortcuts = new List<UserShortcut>();
        //    //UserAccounts = new List<UserAccount>();
        //}

    }



    

}
