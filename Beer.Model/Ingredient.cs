using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Model
{
    public class Ingredient : RepositoryObject
    {
        public string Type { get; set; }
        public string Description { get; set; }

        //unit of measure
        public string Units { get; set; }

    }
}
