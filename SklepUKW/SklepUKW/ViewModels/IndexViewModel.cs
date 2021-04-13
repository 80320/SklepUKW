using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SklepUKW.Models;

namespace SklepUKW.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}