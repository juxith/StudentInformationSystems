using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Must enter a first name")]
        [RegularExpression("^[a-zA-Z]{1,20}", ErrorMessage = "You must enter a first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Must enter a last name")]
        [RegularExpression("^[a-zA-Z]{1,20}", ErrorMessage = "You must enter a last name.")]
        public string LastName { get; set; }
        [Range(0,4, ErrorMessage = "You must enter a valid GPA.")]
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}