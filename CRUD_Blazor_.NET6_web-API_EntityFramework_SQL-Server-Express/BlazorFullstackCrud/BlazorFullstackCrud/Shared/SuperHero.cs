using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullstackCrud.Shared
{
    internal class SuperHero
    {
        public int Id { get; set;  }
        public string FirstName { get; set; } = string.Empty;
        public string LasttName { get; set; } = string.Empty;
        public string FHeroName { get; set; } = string.Empty;
        public Comic? Comic { get; set; }
        public int ComicId { get; set; }

    }
}
