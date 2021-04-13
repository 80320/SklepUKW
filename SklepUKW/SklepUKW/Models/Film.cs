using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SklepUKW.Models
{
    public class Film
    {
        
        public int FilmID { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł filmu")]
        [StringLength(50)]
        public string Title { get; set; }

        public string Director { get; set; }

        public string Desc { get; set; }

        [Required(ErrorMessage = "Podaj cenę filmu")]
        public decimal Price { get; set; }

        public DateTime AddDate { get; set; }

        public int CategoryID { get; set; }

        public int FilmLength { get; set; }

        public virtual Category Category { get; set; }

        public string PosterName { get; set; }
    }
}