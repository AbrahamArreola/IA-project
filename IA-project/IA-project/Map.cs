using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace IA_project
{
    public partial class Map : Form
    {
        private List<int> terrainValues = new List<int>();
        private string terrainLblAux = "Terreno {0} de {1} detectados";
        private int currentIndex = 1;
        private List<Terrain> terrainList = new List<Terrain>();

        public Map()
        {
            InitializeComponent();
        }

        #region File_management
        //Función que verifica si el archivo es un archivo valido
        private bool validateFile(string route)
        {
            int value, columns, prevColumns = 0;
            List<int> values = new List<int>();
            bool isValid = true;
            bool passFlag = false;
            string[] lines = File.ReadAllLines(route);

            if (lines.Length < 2)
            {
                MessageBox.Show(this, "Archivo vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            else if(lines.Length > 15)
            {
                MessageBox.Show(this, "Número de filas sobrepasado", "Error", MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                isValid = false;
            }
            else
            {
                foreach (string line in lines)
                {
                    string[] splittedLines = line.Split(',');
                    columns = splittedLines.Length;
                    if (prevColumns != columns && passFlag)
                    {
                        MessageBox.Show(this, "Número de columnas incongruentes", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        isValid = false;
                        break;
                    }
                    foreach (string character in splittedLines)
                    {
                        if (character == "")
                        {
                            MessageBox.Show(this, "Archivo con valores nulos", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            isValid = false;
                        }
                        if (Regex.IsMatch(character, @"\D+"))
                        {
                            MessageBox.Show(this, "Archivo con valores no numéricos", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            isValid = false;
                        }
                        if(splittedLines.Length > 15)
                        {
                            MessageBox.Show(this, "Número de columnas sobrepasado", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            isValid = false;
                        }
                        if (!isValid) return false;

                        value = Int32.Parse(character);
                        if (!values.Contains(value))
                        {
                            values.Add(value);
                        }
                    }
                    prevColumns = splittedLines.Length;
                    passFlag = true;
                }
            }

            terrainValues = values;
            return isValid;
        }

        #endregion

        #region Initialize_configuration
        private void initializeSecondGroup()
        {
            //Inicializando todo lo referente al listview de imagenes
            imagesDisplayer.View = View.Details;
            imagesDisplayer.Columns.Add("Terrenos", 150);
            imagesDisplayer.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            ImageList images = new ImageList();
            images.ImageSize = new Size(40, 40);
            string absolutePath = AppDomain.CurrentDomain.BaseDirectory;
            string imagesPath = string.Format("{0}Resources\\terrain_images",
                                Path.GetFullPath(Path.Combine(absolutePath, @"..\..\")));

            string[] paths = Directory.GetFiles(imagesPath);

            foreach (string path in paths)
            {
                images.Images.Add(Image.FromFile(path));
            }

            imagesDisplayer.SmallImageList = images;
            imagesDisplayer.Items.Add("terreno 1", 0);
            imagesDisplayer.Items.Add("terreno 2", 1);
            imagesDisplayer.Items.Add("terreno 3", 2);
            imagesDisplayer.Items.Add("terreno 4", 3);
            imagesDisplayer.Items.Add("terreno 5", 4);
            imagesDisplayer.Items.Add("terreno 6", 5);
            imagesDisplayer.Items.Add("terreno 7", 6);
            imagesDisplayer.Items.Add("terreno 8", 7);
            imagesDisplayer.Items.Add("terreno 9", 8);
            imagesDisplayer.Items.Add("terreno 10", 9);

            //Activando y desactivando los controles necesarios
            loadMapGb.Enabled = false;
            configTerrainGb.Enabled = true;
            prevBtn.Enabled = false;

            //Cargando el número de terrenos
            terrainLabel.Text = String.Format(terrainLblAux, currentIndex, terrainValues.Count);
            valueTxt.Text = terrainValues.ElementAt(currentIndex - 1).ToString();
        }
        #endregion

        #region data_management
        private void retrieveTerrainData()
        {
            Terrain terrain = new Terrain();
            terrain.Value = terrainValues[currentIndex - 1];
            terrain.Name = nameTxt.Text;
            terrain.Image = imagesDisplayer.SmallImageList.Images[imagesDisplayer.SelectedItems[0].ImageIndex];

            if (terrainList.Exists(ind => ind.Value == terrain.Value))
                terrainList[terrainList.FindIndex(ind => ind.Value == terrain.Value)] = terrain;
            else
                terrainList.Add(terrain);
        }
        #endregion

        #region Events
        //Evento del boton seleccionar archivo
        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (validateFile(openFileDialog.FileName))
                {
                    initializeSecondGroup();
                }
            }
        }

        //Evento del boton siguiente
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
                errorProvider1.SetError(nameTxt, "Proporcione un nombre al terreno");

            else if (imagesDisplayer.SelectedItems.Count == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(imagesDisplayer, "Seleccione una imagen para el terreno");
            }
            else
            {
                errorProvider1.Clear();
                currentIndex++;
                if (currentIndex == terrainValues.Count)
                {
                    nextBtn.Text = "Cargar";
                }
                if (currentIndex == terrainValues.Count + 1)
                {
                    mainWindow main = Owner as mainWindow;
                    main.terrains = terrainList;
                    Close();
                    return;
                }
                if (currentIndex > 1) prevBtn.Enabled = true;
                terrainLabel.Text = String.Format(terrainLblAux, currentIndex, terrainValues.Count);
                valueTxt.Text = terrainValues[currentIndex - 1].ToString();
                retrieveTerrainData();
                nameTxt.Clear();
                imagesDisplayer.SelectedItems.Clear();
            }
        }

        //Evento del boton anterior
        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
                errorProvider1.SetError(nameTxt, "Proporcione un nombre al terreno");

            else if (imagesDisplayer.SelectedItems.Count == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(imagesDisplayer, "Seleccione una imagen para el terreno");
            }
            else
            {
                errorProvider1.Clear();
                currentIndex--;
                if (currentIndex < 2) prevBtn.Enabled = false;
                if (currentIndex == terrainValues.Count - 1) nextBtn.Text = "Siguiente";
                terrainLabel.Text = String.Format(terrainLblAux, currentIndex, terrainValues.Count);
                valueTxt.Text = terrainValues[currentIndex - 1].ToString();
                retrieveTerrainData();
                nameTxt.Clear();
                imagesDisplayer.SelectedItems.Clear();
            }
            
        }
        #endregion
    }
}
