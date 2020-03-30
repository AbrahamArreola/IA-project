using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace IA_project
{
    public class Terrain
    {
        private int value;
        private string name;
        private Image image;
        private int visitNumber;

        public Terrain() {}
        public Terrain(Terrain terrain)
        {
            value = terrain.value;
            name = terrain.name;
            image = terrain.image;
            visitNumber = 0;
        }

        public int Value { get => value; set => this.value = value; }
        public string Name { get => name; set => name = value; }
        public Image Image { get => image; set => image = value; }
        public int VisitNumber { get => visitNumber; set => visitNumber = value; }
    }
}
