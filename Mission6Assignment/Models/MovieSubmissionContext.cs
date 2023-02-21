using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//setting up the connection between our database and our program
namespace Mission6Assignment.Models
{
    //inheriting from our dbcontext file
    public class MovieSubmissionContext : DbContext
    {
        //Constructor
        //inheriting all the base options
        public MovieSubmissionContext (DbContextOptions<MovieSubmissionContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<SubmissionResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        //seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName="Action/Adventure"},
                new Category { CategoryId=2, CategoryName="Comedy"},
                new Category { CategoryId=3, CategoryName="Drama"},
                new Category { CategoryId=4, CategoryName="Family"},
                new Category { CategoryId=5, CategoryName="Horror/Suspense"},
                new Category { CategoryId=6, CategoryName="Miscellaneous"}
                );
            mb.Entity<SubmissionResponse>().HasData(
                new SubmissionResponse
                {
                    SubmissionId = 1,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    DirectorFirstName = "Christopher",
                    DirectorLastName = "Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },

                new SubmissionResponse
                {
                    SubmissionId = 2,
                    CategoryId = 2,
                    Title = "The Proposal",
                    Year = 2009,
                    DirectorFirstName = "Anne",
                    DirectorLastName = "Fletcher",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },

                new SubmissionResponse
                {
                    SubmissionId = 3,
                    CategoryId = 1,
                    Title = "Inception",
                    Year = 2010,
                    DirectorFirstName = "Christopher",
                    DirectorLastName = "Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
             );
        }
    }
}
