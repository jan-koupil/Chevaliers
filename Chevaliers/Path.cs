using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chevaliers
{
    class Path
    {
        public int To { get; }
        public List<Item> Requirements = [];
        public string Remark { get; }

        public Path(int to, string remark = "")
        {
            To = to;
            Remark = remark;
            if (!Place.PlaceIndex.ContainsKey(to))
            {
                new Place(to);
            }
        }

        public Path AddRequirement(Item requirement)
        {
            Requirements.Add(requirement);
            return this;
        }
    }
}
