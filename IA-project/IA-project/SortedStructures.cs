using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_project
{
    public class MapPosition
    {
        private int[] coord;
        private decimal cost;
        private decimal fCost;
        private decimal hCost;

        public MapPosition(int[] coord)
        {
            this.coord = coord;
        }

        public MapPosition(int[] coord, decimal cost) : this(coord)
        {
            this.cost = cost;
        }

        public MapPosition(int[] coord, decimal fCost, decimal hCost, decimal cost) : this(coord, cost)
        {
            this.fCost = fCost;
            this.hCost = hCost;
        }

        public int[] Coord { get => coord; set => coord = value; }
        public decimal Cost { get => cost; set => cost = value; }
        public decimal FCost { get => fCost; set => fCost = value; }
        public decimal HCost { get => hCost; set => hCost = value; }
    }

    public class PriorityQueue
    {
        private List<MapPosition> queue;

        public PriorityQueue()
        {
            queue = new List<MapPosition>();
        }

        public void Enqueue(MapPosition item)
        {
            queue.Add(item);
            queue = queue.OrderBy(i => i.Cost).ToList();
        }

        public MapPosition Dequeue()
        {
            if(queue.Count > 0)
            {
                MapPosition item = queue[0];
                queue.RemoveAt(0);
                return item;
            }
            return null;
        }

        public void Delete(int[] coord)
        {
            var item = queue.SingleOrDefault(x => x.Coord.SequenceEqual(coord));
            if (item != null)
                queue.Remove(item);
        }

        public void Clear(){queue.Clear();}
    }
}
