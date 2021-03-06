using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SklepUKW.Models;

namespace SklepUKW.ViewModels
{
    public class ListViewModel
    {
        public Category Category { get; set; }

        public IEnumerable<Film> FilmsFromCategory { get; set; } // lista filmow z danej kategorii

        public IEnumerable<Film> Top3NewestFilms { get; set; }

        public IEnumerable<Film> Top3LongestFilms { get; set; }
    }
}