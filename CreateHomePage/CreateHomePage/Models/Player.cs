using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CreateHomePage.Models
{
    public class Player
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength =  1)]
        //[RegularExpression(@"(\S)+", ErrorMessage = "Нельзя использовать пробелы")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CountToutnament { get; set; }
        public string Action { get; set; }

        public string ImageName {get; set;}        
        public override string ToString()
        {
            return this.Name;
        }

        public Player( string name, int rating, int tours, string action, string imageName)
        {
            Random rndm = new Random();
            this.ID = rndm.Next(100);
            this.Name = name;
            this.Rating = rating;
            this.CountToutnament = tours;
            this.Action = action;
            this.ImageName= imageName;
        }

        // add конструктор по умолчанию
        public Player() { }
    }
}