using SklepUKW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SklepUKW.Migrations;
using System.Data.Entity.Migrations;

namespace SklepUKW.DAL
{
    public class FilmsInitializer : MigrateDatabaseToLatestVersion<FilmsContext, Configuration>//DropCreateDatabaseIfModelChanges<FilmsContext>//DropCreateDatabaseAlways<FilmsContext> //MigrateDatabaseToLatestVersion<FilmsContext, Configuration>//
    {
        /*
        protected override void Seed(FilmsContext context)
        {
            base.Seed(context);
            SeedFilmy(context);
        }
        */

        public static void SeedFilmy(FilmsContext context)
        {
            var categories = new List<Category>()
           {
               
               new Category
               {
                    CategoryID = 1,
                    Name = "Horror",
                    Desc = "Straszne filmy"
               },
               new Category
               {
                    CategoryID = 2,
                    Name = "Dokumentalne",
                    Desc = "Filmy naukowe"
               },
               new Category
               {
                    CategoryID = 3,
                    Name = "Dramat",
                    Desc = "O życiu w Polsce"
               },
               new Category
               {
                    CategoryID = 4,
                    Name = "Western",
                    Desc = "Ktoś to jeszcze nagrywa?"
               },
               new Category
               {
                    CategoryID = 5,
                    Name = "Fantastyka",
                    Desc = "Miecze, magia i smoki"
               },
               new Category
               {
                    CategoryID = 6,
                    Name = "Wojenny",
                    Desc = "Filmy o drugiej wojnie światowej (bo innych przecież nie było)"
               }
              
           };

           foreach (var category in categories)
           {
               context.Categories.AddOrUpdate(c=>c.Name, category);
           }

           context.SaveChanges();

           var filmy = new List<Film>()
           {
                new Film
                {
                    FilmID = 1,
                    CategoryID = 1,
                    Title = "Teksańska Masakra Piłą Mechaniczną",
                    Director = "Marcus Nispel",
                    Desc = "20 sierpnia 1973 roku teksańska policja trafiła do stojącego na uboczu domu Thomasa Hewitta - byłego pracownika lokalnej rzeźni. Na miejscu odkryli rozkładające się zwłoki 33 osób, które zostały zamordowane przez psychopatycznego zabójcę noszącego na twarzy maskę z ludzkiej skóry i posługującego się piłą mechaniczną.",
                    Price = 10,
                    PosterName = "Teksanska.jpg",
                    AddDate = new DateTime(2020,12,4), //DateTime.Now
                    FilmLength = 76
                },
                new Film
                {
                    FilmID = 2,
                    CategoryID = 3,
                    Title = "Numer 23",
                    Director = "Joel Schumacher",
                    Desc = "Mężczyzna dostaje obsesji na punkcie książki, która według niego opisuje i przewiduje jego życie i przyszłość.",
                    Price = 14,
                    PosterName = "Numer23.jpg",
                    AddDate = new DateTime(2021,3,13),
                    FilmLength = 46
                },
                new Film
                {
                    FilmID = 3,
                    CategoryID = 3,
                    Title = "Sekretne Okno",
                    Director = "David Koepp",
                    Desc = "Uznany pisarz przenosi się na prowincję, by w spokoju tworzyć kolejne książki. Wkrótce odwiedzi go tajemniczy mężczyzna, który oskarży Raineya o plagiat.",
                    Price = 12,
                    PosterName = "SekretneOkno.jpg",
                    AddDate = new DateTime(2019,8,1),
                    FilmLength = 92
                },
                new Film
                {
                    FilmID = 4,
                    CategoryID = 5,
                    Title = "Władca Pierścieni: Drużyna Pierścienia",
                    Director = "Peter Jackson",
                    Desc = "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.",
                    Price = 20,
                    PosterName = "DruzynaPierscienia.jpg",
                    AddDate = new DateTime(2005,7,2),
                    FilmLength = 85
                },
                new Film
                {
                    FilmID = 5,
                    CategoryID = 4,
                    Title = "Red",
                    Director = "Robert Schwentke",
                    Desc = "Emerytowani agenci specjalni CIA zostają wrobieni w zamach. By się ratować, muszą reaktywować stary zespół.",
                    Price = 11,
                    PosterName = "Red.jpg",
                    AddDate = new DateTime(2021,1,6),
                    FilmLength = 81
                },
                new Film
                {
                    FilmID = 6,
                    CategoryID = 2,
                    Title = "Tylko nie mów nikomu",
                    Director = "Tomasz Sekielski",
                    Desc = "Dziennikarz śledczy rozmawia z dziewięcioma księżmi katolickimi, którzy dopuścili się zbrodni pedofilii i molestowania nieletnich, a także ich ofiarami.",
                    Price = 0,
                    PosterName = "TylkoNieMow.jpg",
                    AddDate = new DateTime(2013,11,24),
                    FilmLength = 129
                },
                new Film
                {
                    FilmID = 7,
                    CategoryID = 5,
                    Title = "Iluzjonista",
                    Director = "Neil Burger",
                    Desc = "Wiedeń u progu XX w. Syn rzemieślnika, iluzjonista Eisenheim, wykorzystuje niezwykłe umiejętności, by zdobyć miłość arystokratki, narzeczonej austro-węgierskiego księcia.",
                    Price = 13,
                    PosterName = "Iluzjonista.jpg",
                    AddDate = new DateTime(2018,9,1),
                    FilmLength = 99
                },
                new Film
                {
                    FilmID = 8,
                    CategoryID = 3,
                    Title = "Cube",
                    Director = "Vincenzo Natali",
                    Desc = "Grupa osób budzi się w pełnym śmiertelnych pułapek sześcianie. Nieznajomi muszą zacząć współpracować ze sobą, by przeżyć.",
                    Price = 15,
                    PosterName = "Cube.jpg",
                    AddDate = new DateTime(2020,5,3),
                    FilmLength = 86
                },
                new Film
                {
                    FilmID = 9,
                    CategoryID = 1,
                    Title = "Hellraiser: Wysłannik Piekieł",
                    Director = "Clive Barker",
                    Desc = "Frank Cotton nabywa tajemniczą kostkę, za pomocą której można przywołać demony z piekła.",
                    Price = 16,
                    PosterName = "Hellraiser.jpg",
                    AddDate = new DateTime(2010,8,12),
                    FilmLength = 100
                },
                new Film
                {
                    FilmID = 10,
                    CategoryID = 3,
                    Title = "Milczenie Owiec",
                    Director = "Jonathan Demme",
                    Desc = "Seryjny morderca i inteligentna agentka łączą siły, by znaleźć przestępcę obdzierającego ze skóry swoje ofiary.",
                    Price = 17,
                    PosterName = "MilczenieOwiec.jpg",
                    AddDate = new DateTime(2021,4,14),
                    FilmLength = 151
                }
           };

            foreach (var film in filmy)
            {
                context.Films.AddOrUpdate(f=>f.Title, film);
            }

            context.SaveChanges();
        }
    }
}