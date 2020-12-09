using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int ClassesInTwoWeeks { get; set; }
    }
}
