using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RejestrZaginionych.Utils {
    public class Crypt {

        public String hashString(string stringToHash) {
            String hashString = "";

            if (stringToHash != "" && stringToHash != null) {
                byte[] data = Encoding.UTF8.GetBytes(stringToHash);



                // UTF conversion - String from bytes  

                byte[] hash = System.Security.Cryptography.SHA512.Create().ComputeHash(data);
                hashString = Convert.ToBase64String(hash);
            }

            return hashString;
        }

    }
}