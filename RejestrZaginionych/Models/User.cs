using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Data.Entity.Infrastructure;
using RejestrZaginionych.Utils.Validation;
using RejestrZaginionych.Utils;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace RejestrZaginionych.Models {

    public class User {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Required]
        public int UserType { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(256)]
        [UniqueLogin(ErrorMessage = "Podany login jest zajęty")]
        public string Login { get; set; }
        [EmailAddress]
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(256)]
        [Display(Name = "Adres e-mail")]
        [UniqueEmail(ErrorMessage = "Adres e-mail istnieje już w bazie danych")]
        public string Email { get; set; }
        [Required]
        public bool Active { get; set; }
        public string Password { get; set; }
 
        [NotMapped]
        [Required]
        [Display(Name = "Hasło")]
        [MinLength(6, ErrorMessage = "Hasło musi składać się z co najmniej 6 znaków")]
        public string PasswordString { get; set; }
        [NotMapped]
        [Required]
        [MinLength(6, ErrorMessage = "Hasło musi składać się z co najmniej 6 znaków")]
        [Compare("PasswordString", ErrorMessage = "Hasła nie są identyczne")]
        [Display(Name = "Powtórz hasło")]
        public string RepeatPasswordString { get; set; }
        [EmailAddress]
        [Required]
        [NotMapped]
        [Compare("Email", ErrorMessage = "Adresy e-mail nie są identyczne")]
        [Display(Name = "Powtórz adres e-mail")]
        public string RepeatEmail { get; set; }

        public virtual List<User> Users { get; set; }


        private void createUser() {
            MissingPersonListContext db = new MissingPersonListContext();
            UserType = Int32.Parse(ConfigurationManager.AppSettings["NORMAL_USER"]);
            
            db.Users.Add(this);
            db.SaveChanges();

        }

        public bool registerUser() {
            Crypt cryptObj = new Crypt();
            Password = cryptObj.hashString(PasswordString);
            createUser();

            return true;
        }

        public static List<User> getUserList() {
            MissingPersonListContext db = new MissingPersonListContext();
            List<User> userList = db.Users.ToList();

            return userList;
        }

        public static void changeUserActiveStatus(int userId) {
            MissingPersonListContext db = new MissingPersonListContext();
            User user = db.Users.Single(u => u.Id == userId);
            String active = user.Active == true ? "0" : "1";
            String query = "Update Users SET active = " + active + " WHERE Id = " + user.Id.ToString();

            db.Database.ExecuteSqlCommand(query);
            db.SaveChanges();

        }

        public static void changeUserType(int userId) {
            MissingPersonListContext db = new MissingPersonListContext();
            User user = db.Users.Single(u => u.Id == userId);
            int type = user.UserType == Int32.Parse(ConfigurationManager.AppSettings["ADMIN_USER"]) ? Int32.Parse(ConfigurationManager.AppSettings["NORMAL_USER"]) : Int32.Parse(ConfigurationManager.AppSettings["ADMIN_USER"]);
            String query = "Update Users SET UserType = " + type + " WHERE Id = " + user.Id.ToString();

            Debug.WriteLine(query);
            db.Database.ExecuteSqlCommand(query);
            db.SaveChanges();

        }
        
    }
}