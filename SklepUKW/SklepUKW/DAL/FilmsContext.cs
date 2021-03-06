using Microsoft.AspNet.Identity.EntityFramework;
using SklepUKW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SklepUKW.DAL
{
    public class FilmsContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Film> Films { get; set; }

        public DbSet<Category> Categories { get; set; }

        public FilmsContext() : base("FilmsContext")
        {
            //Configuration.ProxyCreationEnabled = false; // Dodane
        }

        static FilmsContext()
        {
            Database.SetInitializer<FilmsContext>(new FilmsInitializer());
        }

        public static FilmsContext Create()
        {
            return new FilmsContext();
        }

        /*
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.8.3.js"></script>
         */
    }
}