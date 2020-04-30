using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace RejestrZaginionych.Models {
    public class MissingPerson {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Wiek")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Kolor oczu")]
        public String EyeColor { get; set; }
        [Required]
        [Display(Name = "Kolor włosów")]
        public String HairColor { get; set; }
        [Required]
        [Display(Name = "Wzrost")]
        public String Height { get; set; }
        [Required]
        [Display(Name = "Data zaginięcia")]
        public String MissingDate { get; set; }
        [Display(Name = "Znaki szczególne")]
        public String DistinguishingMarks { get; set; }
        [Required]
        [Display(Name = "Miasto")]
        public String City { get; set; }
        [Display(Name = "Opis")]
        public String Description { get; set; }
        public int AddedByUserId { get; set; }

        [Display(Name = "Zdjęcie")]
        public string ImagePath { get; set; }

        [NotMapped]
        [Required]

        public HttpPostedFileBase ImageFile { get; set; }
    

    public virtual List<MissingPerson> MissingPersons { get; set; }


        public static List<MissingPerson> getList() {
            MissingPersonListContext db = new MissingPersonListContext();
            List<MissingPerson> MissingPersonList = db.MissingPersons.ToList();

            return MissingPersonList;
        }

        public void addMissingPerson() {

            MissingPersonListContext db = new MissingPersonListContext();

            db.MissingPersons.Add(this);
            db.SaveChanges();
        }

        public static MissingPerson getPopUpInfo(int userId) {
            MissingPerson person;

            MissingPersonListContext db = new MissingPersonListContext();
            try {
                person = db.MissingPersons.Single(u => u.Id == userId);
            }
            catch (InvalidOperationException e) {
                return null;
            }

            return person;
        } 

    }

}