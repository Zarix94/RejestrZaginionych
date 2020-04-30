using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RejestrZaginionych.Utils;
using System.Diagnostics;

namespace RejestrZaginionych.Models {

    public class UserLogin {
        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(256)]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Hasło")]
        public string PasswordString { get; set; }

        public User authorize() {
            User user;

            String Password = new Crypt().hashString(PasswordString);

            MissingPersonListContext db = new MissingPersonListContext();
            try {
                user = db.Users.Single(u => u.Login == Login && u.Password == Password);
            }
            catch (InvalidOperationException e) {
                return null;
            }
            return user;
        }
    }


    
}
    
