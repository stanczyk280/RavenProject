using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Rental
    {
        public string Id { get; set; }
        public Book Book { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly ReturnDate { get; set; }
    }
}