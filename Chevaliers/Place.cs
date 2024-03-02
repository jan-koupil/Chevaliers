using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Chevaliers
{
    class Place
    {
        public static Dictionary<int, Place> PlaceIndex = [];

        public int ID { get; }
        public bool EndGame {get; } 
        public List<Path> Paths { get; } = [];
        public List<Item> Items { get; } = [];
        public List<string> Enemies { get; } = [];
        public string Remark { get; set; }
        public bool IsDeadEnd { get; private set; }
        public bool HasNoEntry { get; private set; }

        public static void EvaluateDeadEnds()
        {
            Dictionary<int, bool> hasEntry = PlaceIndex.Select(x => new KeyValuePair<int,bool>(x.Key, false)).ToDictionary();
            Dictionary<int, bool> hasExit = PlaceIndex.Select(x => new KeyValuePair<int, bool>(x.Key, false)).ToDictionary();

            foreach (Place place in PlaceIndex.Values)
            {
                if (place.Paths.Count > 0)
                    hasExit[place.ID] = true;

                foreach (Path path in place.Paths)
                    hasEntry[path.To] = true;
            }

            foreach (Place place in PlaceIndex.Values)
            {
                place.HasNoEntry = !hasEntry[place.ID];
                place.IsDeadEnd = !hasExit[place.ID];
            }
        }

        public Place (int id, bool endGame = false, string remark = "")
        {
            ID = id;
            PlaceIndex[id] = this;
            EndGame = endGame;
            Remark = remark;
        }

        public Place AddPath(Path path)
        {
            Paths.Add(path);
            return this;
        }
        
        public Place AddPath(int pathId)
        {
            return AddPath(new Path(pathId));
        }


        public Place AddItem(Item item)
        {
            Items.Add(item);
            return this;
        }

        public Place AddEnemy(string enemy)
        {
            Enemies.Add(enemy);
            return this;
        }

        public Place SetRemark(string remark)
        {
            Remark = remark;
            return this;
        }

        public bool IsConnectedTo(Place otherPlace)
        {
            return this.Paths.Select(p => p.To).Contains(otherPlace.ID)
                || otherPlace.Paths.Select(p => p.To).Contains(this.ID);
        }

        public bool IsConnectedTo(int otherPlaceID)
        {
            return IsConnectedTo(PlaceIndex[otherPlaceID]);
        }
    }
}
