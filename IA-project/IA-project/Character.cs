using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IA_project
{
    public partial class Character : Form
    {

        private const int NUMBER_OF_CHARACTERS = 6;
        private Dictionary<int,Terrain> terrainsDictionary = new Dictionary<int, Terrain>();

        public Character(Dictionary<int, Terrain> terrainsDictionary)
        {    
            InitializeComponent();
            this.terrainsDictionary = terrainsDictionary;
            initializeCharacterList();
        }

    
        private void initializeCharacterList()
        {
            //Inicializando todo lo referente al listview de imagenes
            charactersDisplayer.View = View.Details;
            charactersDisplayer.Columns.Add("Personajes", 150);
            charactersDisplayer.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            ImageList images = new ImageList();
            images.ImageSize = new Size(40, 40);
            string absolutePath = AppDomain.CurrentDomain.BaseDirectory;
            string imagesPath = string.Format("{0}Resources\\characters_images",
                                Path.GetFullPath(Path.Combine(absolutePath, @"..\..\")));

            string[] paths = Directory.GetFiles(imagesPath);

            foreach (string path in paths)
            {
                images.Images.Add(Image.FromFile(path));
            }

            charactersDisplayer.SmallImageList = images;
            for (int i = 1; i < NUMBER_OF_CHARACTERS; i++)
            {
                charactersDisplayer.Items.Add(string.Format("personaje {0}", i), i - 1);
            }

            //Activando y desactivando los controles necesarios
           
            
       
            if (terrainsDictionary.Count == 1)
            {
               nextCharacterBtn.Enabled = true;
               loadCharactersButton.Enabled = false;
             }

            //Cargando el número de terrenos
            // continuar
            terrainLabel.Text = terrainsDictionary.Count.ToString();
        }
    }
}
