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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<SubmissionResponse>().HasData(
                new SubmissionResponse
                {
                    SubmissionId = 1,
                    Category = "Action/Adventure",
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
                    Category = "Romantic Comedy",
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
                    Category = "Action/Adventure",
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
