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
using System.Text.RegularExpressions;


namespace IA_project
{
    public partial class Character : Form
    {

        private const int NUMBER_OF_CHARACTERS = 10;
        private const int ROW_OF_VALUES = 2;
        private Dictionary<int, Terrain> terrainsDictionary = new Dictionary<int, Terrain>();
        private List<decimal> listAuxForCharacters;
        private List<CharacterData> characters = new List<CharacterData>();
        int numberOfCharacters = 0;

        string[] imagesNames = new string[9] {
            "endman","Horse","PigMan","Skelleton","spider","steve","villageMan","Wolf","Zombie"};


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
                string imageFromResource = imagesNames[i-1];
                charactersDisplayer.Items.Add(string.Format(imageFromResource, i), i - 1);
            }
                 
       
            if (terrainsDictionary.Count == 1)
            {
               nextCharacterBtn.Enabled = true;
               loadCharactersButton.Enabled = false;
             }

            
            initGridView();          
        }

        private void initGridView()
        {

            DataTable dataTableTerrains = new DataTable();
            dataTableTerrains.Columns.Add("Imagen", typeof(Image));
            dataTableTerrains.Columns.Add("Nombre del terreno");
            dataTableTerrains.Columns.Add("Valor");


            foreach (var myObject in terrainsDictionary)
            {
                dataTableTerrains.Rows.Add(new object[] { myObject.Value.Image,myObject.Value.Name });
            }


            dataGridViewTerrains.DataSource = dataTableTerrains;

            dataGridViewTerrains.Columns[0].ReadOnly = true;
            dataGridViewTerrains.Columns[0].Selected = false;

            dataGridViewTerrains.Columns[1].ReadOnly = true;
            dataGridViewTerrains.Columns[1].Selected = false;
            
        }

        private void Character_Load(object sender, EventArgs e)
        {
            dataGridViewTerrains.ClearSelection();
        }

        private bool validateRows()
        {
            List<decimal> habilityInTerrains = new List<decimal>();
            var regex = new Regex(@"^(?:[1-9]\d*|0)?(?:\.\d+)?$");
            decimal valueToTruncate;


            foreach (DataGridViewRow row in dataGridViewTerrains.Rows)
            {        
                string rowValue = row.Cells[ROW_OF_VALUES].Value.ToString();

                if (regex.IsMatch(rowValue) && rowValue != ""){

                    valueToTruncate = Convert.ToDecimal(rowValue);

                    var resistance = truncateNumber(valueToTruncate);

                    habilityInTerrains.Add(resistance);

                }
                else if(rowValue == "")
                {
                    habilityInTerrains.Add(-1); // represents N/A
                }
                else 
                {
                    MessageBox.Show("Letra o numero negativo detectado",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            listAuxForCharacters = new List<decimal>(habilityInTerrains);
            return true;
        }

        decimal truncateNumber(decimal number)
        {
            return Math.Truncate(number * 100) / 100;
        }

        private void nextCharacterBtn_Click(object sender, EventArgs e)
        {

            // no image selected
            if (charactersDisplayer.SelectedItems.Count == 0)
            {
                errorProviderCharacter.Clear();
                errorProviderCharacter.SetError(charactersDisplayer, "Seleccione una imagen para el el ser");
            }
            // something wrong on the rows
            else if (!validateRows())
            {
                errorProviderCharacter.Clear();
                errorProviderCharacter.SetError(dataGridViewTerrains, "Todos los campos deben ser positivos o vacios");
            }
            else
            {
                errorProviderCharacter.Clear();

                CharacterData character = new CharacterData();

                character.Name = charactersDisplayer.SelectedItems[0].Text;      
                character.Image = charactersDisplayer.SmallImageList.Images[charactersDisplayer.SelectedItems[0].ImageIndex];
                character.MovilityOfCharacter = makeDictionaryOfMovility();

                charactersDisplayer.Items.Remove(charactersDisplayer.SelectedItems[0]);
                charactersDisplayer.SelectedItems.Clear();

                characters.Add(character);

                numberOfCharacters++;
                charactersLabel.Text = "Numero de seres creados: " + numberOfCharacters.ToString();
                loadCharactersButton.Enabled = true;

                cleanValuesColumn();

                // to not allow another Character
                if (numberOfCharacters == 5)
                {
                    nextCharacterBtn.Enabled = false;
                    dataGridViewTerrains.Columns[2].ReadOnly = true;
                }

            }
        }

        private void loadCharactersButton_Click(object sender, EventArgs e)
        {
           // characters; esta es la lista con los personajes, mas no se como quieras recibirla
            mainWindow main = Owner as mainWindow;
            main.loadMap();
            Close();
        }

        private Dictionary<int,decimal> makeDictionaryOfMovility()
        {
            int indexOfList = 0;

            Dictionary<int, decimal> movilityOfCharacter = new Dictionary<int, decimal>();

            foreach (var terrain in terrainsDictionary)
            {
                decimal mobility = listAuxForCharacters[indexOfList];
                movilityOfCharacter.Add(terrain.Key, mobility);
                indexOfList++;
            }
            return movilityOfCharacter;
        }

        private void cleanValuesColumn()
        {
            foreach (DataGridViewRow row in dataGridViewTerrains.Rows)
            {
                row.Cells[ROW_OF_VALUES].Value = "";
            }
        }
    }
}
