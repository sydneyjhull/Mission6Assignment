using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment.Models
{
    public class SubmissionResponse
    {
        [Key]
        [Required]
        public int SubmissionId { get; set; }
        
        //Foreign Key Relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage = "Movie Title Required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Movie Year Required")]
        public string DirectorFirstName {get;set;}
        [Required(ErrorMessage ="Director First Name Required")]
        public string DirectorLastName { get; set; }
        [Required(ErrorMessage = "Director Last Name Required")]
        public string Rating { get; set; }
        [Required(ErrorMessage = "Movie Rating Required")]
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }
    }
}
