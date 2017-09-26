namespace FinalBoostrapIntro.Migrations
{
    using FinalBoostrapIntro.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using FinalBoostrapIntro.DAL;

    public class Configuration : DropCreateDatabaseAlways<BookContext>
    {

        protected override void Seed(DAL.BookContext context)
        {

            var author = new Author
            {
                Biography="...",
                FirstName = "Jamie",
                LastName = "Munro"
            };

            var books = new List<Book>
            {
                new Book
                {
                    Author = author,
                    Description = "...",
                    ImageUrl = "http:// ecx.images-amazon.com/ images/ I/ 51T% 2BWt430bL._AA160_. jpg",
                    Isbn = "1491914319",
                    Synopsis = "...",
                    Title = "Knockout.js: Building Dynamic Client-Side Web Applications"
                },
                new Book {
                    Author = author,
                    Description = "...",
                    ImageUrl = "http:// ecx.images-amazon.com/ images/ I/ 51AkFkNeUxL._AA160_. jpg",
                    Isbn = "1449319548",
                    Synopsis = "...",
                    Title = "20 Recipes for Programming PhoneGap: Cross-Platform Mobile Development"
                },
                new Book {
                    Author = author,
                    Title = "20 Recipes for Programming MVC 3: Faster, Smarter Web Development"
                },
                new Book {
                    Author = author,
                    Description = "...",
                    ImageUrl = "http:// ecx.images-amazon.com/ images/ I/ 41JC54HEroL._AA160_. jpg",
                    Isbn = "1460954394",
                    Synopsis = "...",
                    Title = "Rapid Application Development With CakePHP"
                }

            };

            books.ForEach( book => context.Books.AddOrUpdate(book));
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
