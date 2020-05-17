using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace IA_project
{
    public class CharacterData
    {
        private String name;
        Dictionary<int, decimal> movilityOfCharacter = new Dictionary<int, decimal>();
        private Image image;


        public String Name { get => name; set => name = value; }
        public Dictionary<int,decimal> MovilityOfCharacter { get => movilityOfCharacter; set => movilityOfCharacter = value; }
        public Image Image { get => image; set => image = value; }



    }
}
