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
        private List<int> habilitiesInTerrain;
        private Image characterImage;


        public String Name { get => name; set => name = value; }
        public List<int> HabilitiesInTerrain { get => habilitiesInTerrain; set => habilitiesInTerrain = value; }
        public Image CharacterImage { get => characterImage; set => characterImage = value; }



    }
}
