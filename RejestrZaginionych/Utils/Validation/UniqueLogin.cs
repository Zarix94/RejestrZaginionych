using RejestrZaginionych.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrZaginionych.Utils.Validation {
    public class UniqueLogin:ValidationAttribute {
        public override bool IsValid(object value) {
            MissingPersonListContext db = new MissingPersonListContext();
            int count = db.Users.Count(u => u.Login == (string) value);

            return count == 0;
        }

    }
}