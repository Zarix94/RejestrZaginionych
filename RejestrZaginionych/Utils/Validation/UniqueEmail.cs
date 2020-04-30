using RejestrZaginionych.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrZaginionych.Utils.Validation {
    public class UniqueEmail:ValidationAttribute {
        public override bool IsValid(object value) {
            MissingPersonListContext db = new MissingPersonListContext();
            int count = db.Users.Count(u => u.Email == (string) value);

            return count == 0;
        }

    }
}