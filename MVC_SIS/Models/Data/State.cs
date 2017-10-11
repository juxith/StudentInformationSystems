using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State
    {
        [RegularExpression("^[A-Z]{2}$")]
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
    }
}