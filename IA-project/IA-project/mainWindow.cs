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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace IA_project
{
    public partial class mainWindow : Form
    {
        //variables contenedoras
        private const int mapSize = 16;
        public Dictionary<int, Terrain> terrainsDictionary = null;
        public List<CharacterData> characterList = new List<CharacterData>();
        public string fileRoute;
        private Panel startPanel = null;
        private Panel goalPanel = null;
        private Terrain[,] matrixPosition;

        //variables de control de coordenadas [0] = fila, [1] = columna
        private int[] startCoord = new int[] { 0, 0 };
        private int[] goalCoord = new int[] { 0, 0 };
        private int[] currentCoord;

        //Variables bandera
        private bool gameStarted = false;
        private bool terrainsConfigured = false;
        public bool playersConfigured = false;
        private bool initialStateSet = false;
        private bool finalStateSet = false;

        //Variable contadora de visitas
        private int visitNumber;

        public mainWindow()
        {
            InitializeComponent();
            //Incrementando el procesamiento del tableLayout del mapa
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            map, new object[] { true });

            //Dibujando el mapa al iniciar
            drawMap();

            //Botón de jugar desactivado al inicio
            playBtn.Enabled = false;

            stopBtn.Enabled = false;
            visitNumber = 1;
        }

        #region configPlayer
        private void drawPlayer(Panel containerPanel, Image image)
        {
            //Dibujar imagen de jugador
            Bitmap bm1 = new Bitmap(containerPanel.BackgroundImage);
            Bitmap bm2 = new Bitmap(image);
            Bitmap finalImage = new Bitmap(bm1.Width, bm1.Height);
            Graphics gf = Graphics.FromImage(finalImage);
            gf.DrawImage(bm1, new Rectangle(0, 0, bm1.Width, bm1.Height));
            gf.DrawImage(bm2, new Rectangle(0, 0, bm1.Width, bm1.Height));
            containerPanel.BackgroundImage = setOpacity(finalImage, Convert.ToSingle(0.6));
        }

        public void loadCharacters()
        {
            playerImage.Image = null;
            playerSelector.Items.Clear();
            foreach(CharacterData character in characterList)
            {
                playerSelector.Items.Add(character.Name);
            }
        }

        public void cleanPlayerSelector()
        {
            playerImage.Image = null;
            characterList = null;
            playerSelector.Items.Clear();
        }
        #endregion

        #region ConfigMap
        private void drawMap()
        {
            map.Controls.Clear();
            map.RowStyles.Clear();
            map.ColumnStyles.Clear();
            
            map.ColumnCount = mapSize;
            map.RowCount = mapSize;

            //Pintando cuadrícula
            map.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
            for (int i = 1; i < mapSize; i++)
            {
                map.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, (map.Width - 20) / (map.ColumnCount - 1)));
            }

            map.RowStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            for (int i = 0; i < mapSize; i++)
            {
                map.RowStyles.Add(new RowStyle(SizeType.Absolute, (map.Height - 10) / (map.RowCount - 1)));
            }
               
            //Pintando letras de columnas
            char letter = 'A';
            for(int i = 1; i < mapSize; i++)
            {
                Label label = new Label()
                {
                    Text = letter.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                map.Controls.Add(label, i, 0);
                letter++;
            }

            //Pintando números de filas
            for (int i = 1; i < mapSize; i++)
            {
                Label label = new Label()
                {
                    Text = i.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                map.Controls.Add(label, 0, i);
            }
        }

        private Image setOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);

            //Crea un objeto de tipo Graphics a partir de la imagen
            using (Graphics gfx = Graphics.FromImage(bmp))
            {

                //Crea un objeto ColorMatrix
                ColorMatrix matrix = new ColorMatrix();

                //Asigna la opacidad a dicha matriz
                matrix.Matrix33 = opacity;

                //Crea los atributos de la imagen
                ImageAttributes attributes = new ImageAttributes();

                //Cambia la opacidad de la imagen
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                //Pinta la imagen en el contenedor designado 
                gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, 
                    image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        public void resetMap()
        {
            startPanel = null;
            goalPanel = null;
            startCoord = new int[] { 0, 0 };
            goalCoord = new int[] { 0, 0 };
            initialStateSet = false;
            finalStateSet = false;
            map.SuspendLayout();
            for (int i = 1; i < map.RowCount; i++)
            {
                for (int j = 1; j < map.ColumnCount; j++)
                {
                    map.Controls.Remove(map.GetControlFromPosition(j, i));
                }
            }
            map.ResumeLayout();
        }

        public void loadMap()
        {
            int column = 1;
            int row = 1;
            string[] lines = File.ReadAllLines(fileRoute);

            //lines.lenght = number of rows, lines[0].split(',').lenght = number of columns
            matrixPosition = new Terrain[lines.Length, lines[0].Split(',').Length];

            map.SuspendLayout();
            foreach (string line in lines)
            {
                string[] splittedLines = line.Split(',');
                foreach (string character in splittedLines)
                {
                    int value = Int32.Parse(character);

                    //Inicializa panel en cierta celda que contendrá todos los controles
                    Panel containerPanel = new Panel()
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        BackColor = Color.Transparent,
                        BackgroundImage = setOpacity(terrainsDictionary[value].Image, Convert.ToSingle(0.6)),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    //Panel en posición cero (Controls[0]) tiene label de inicio o final
                    Label stateLabel = new Label()
                    {
                        Dock = DockStyle.Top,
                        Text = "",
                        Font = new Font("Arial", 7, FontStyle.Bold),
                        BackColor = Color.Transparent,
                        Height = 12
                    };
                    containerPanel.Controls.Add(stateLabel);

                    //Panel en posición uno (Controls[1]) tiene label de visitas
                    Label visitLabel = new Label()
                    {
                        Dock = DockStyle.Bottom,
                        Text = "",
                        Font = new Font("Arial", 7, FontStyle.Bold),
                        BackColor = Color.Transparent,
                        Height= 12
                    };
                    containerPanel.Controls.Add(visitLabel);

                    //Se crean estas variables para almacenar la instancia actual de fila y columna
                    int newRow = row;
                    int newColumn = column;

                    containerPanel.MouseClick += (s, meArgs) 
                        => { ContainerPanel_MouseClick(s, meArgs, containerPanel, 
                            new int[]{newRow, newColumn}, terrainsDictionary[value].Name); };

                    Terrain terrain = new Terrain(terrainsDictionary[value]);
                    matrixPosition[row - 1, column - 1] = terrain;
                    map.Controls.Add(containerPanel, column, row);
                    column++;
                }
                column = 1;
                row++;
            }
            map.ResumeLayout();
        }

        //Evento del click derecho en celda
        private void ContainerPanel_MouseClick(object sender, MouseEventArgs e, Panel panel, 
            int[] coords, string terrainName)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Inicio").Name = "inicio";
                menu.Items.Add("Final").Name = "final";
                if (gameStarted || playerSelector.SelectedIndex < 0)
                {
                    menu.Items[0].Enabled = false;
                    menu.Items[1].Enabled = false;
                }

                menu.Items.Add("Información").Name = "informacion";
                menu.Show(map, panel.Location);
                menu.ItemClicked += (s, tsceArgs) 
                    => { Menu_ItemClicked(s, tsceArgs, panel, coords, terrainName, menu);};
            }
        }

        //Evento de click de los items del menú desplegable
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e, Panel panel, 
            int[] coords, string terrainName, ContextMenuStrip menu)
        {
            menu.Close();
            switch (e.ClickedItem.Name)
            {
                case "inicio":
                    if (panel == goalPanel) break;
                    if(characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                       [matrixPosition[coords[0] - 1, coords[1] - 1].Value] == -1)
                    {
                        MessageBox.Show(this, "El ser no se puede mover en el estado inicial", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if(startPanel != null)
                    {
                        startPanel.Controls[0].Text = "";
                        startPanel.BackgroundImage = 
                            setOpacity(matrixPosition[startCoord[0], startCoord[1]].Image, Convert.ToSingle(0.6));

                        startPanel.Controls[1].Text = "";
                    }
                    panel.Controls[0].Text = "Inicio";
                    panel.Controls[1].Text = visitNumber + ",";
                    drawPlayer(panel, playerImage.Image);
                    startPanel = panel;
                    startCoord[0] = coords[0] - 1;
                    startCoord[1] = coords[1] - 1;
                    initialStateSet = true;
                    playerSelector.Enabled = false;
                    if (playersConfigured && finalStateSet) playBtn.Enabled = true;
                    break;

                case "final":
                    if (panel == startPanel) break;
                    if (characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                       [matrixPosition[coords[0] - 1, coords[1] - 1].Value] == -1)
                    {
                        MessageBox.Show(this, "El ser no se puede mover en el estado final", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (goalPanel != null)
                    {
                        goalPanel.Controls[0].Text = "";
                    }
                    panel.Controls[0].Text = "final";
                    goalPanel = panel;
                    goalCoord[0] = coords[0] - 1;
                    goalCoord[1] = coords[1] - 1;
                    finalStateSet = true;
                    playerSelector.Enabled = false;
                    if (playersConfigured && initialStateSet) playBtn.Enabled = true;
                    break;

                case "informacion":
                    char letter = (char)(coords[1] + 64);
                    MessageBox.Show(this, string.Format("La coordenada ({0},{1}) es {2}", 
                        letter, coords[0], terrainName), "Información de celda", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    break;
            }
        }
        #endregion

        #region configEvents
        //Evento de botón Reiniciar
        private void resetButton_Click(object sender, EventArgs e)
        {
            resetMap();
            gameStarted = false;
            stopBtn.Enabled = false;
            configMapBtn.Enabled = true;
            configPlayerBtn.Enabled = true;
            howToPlayBtn.Enabled = true;
            playerSelector.Enabled = true;
            terrainsConfigured = false;
            playersConfigured = false;
            terrainsDictionary = null;
            visitNumber = 1;
            cleanPlayerSelector();
        }

        //Evento de botón "configurar terrenos" en menú lateral
        private void configMapBtn_Click(object sender, EventArgs e)
        {
            Map configMapWindow = new Map();
            AddOwnedForm(configMapWindow);
            configMapWindow.ShowDialog();
            terrainsConfigured = true;
            playersConfigured = false;
        }

        //Evento de botón "configurar jugadores" en menú lateral
        private void configPlayerBtn_Click(object sender, EventArgs e)
        {
            if(terrainsDictionary == null || !terrainsConfigured)
            {
                MessageBox.Show(this, "Primero configure los terrenos", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Character confiCharacterWindow = new Character(terrainsDictionary);
                AddOwnedForm(confiCharacterWindow);
                confiCharacterWindow.ShowDialog();
            }
        }

        //Evento de botón "Cómo jugar" en menú lateral
        private void howToPlayBtn_Click(object sender, EventArgs e)
        {
            string instructions =
                "1. Configure los terrenos con el botón en el menú lateral\n\n2. Configure los jugadores con el" +
                " botón en el menú lateral\n\n3. Indique los estados inicial y final haciendo click derecho en" +
                "     las celdas deseadas (también puede consultar información)\n\n4. Presione el botón jugar";
            MessageBox.Show(this, instructions, "Instrucciones",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Evento de botón "Jugar" en ventana principal
        private void playBtn_Click(object sender, EventArgs e)
        {
            gameStarted = true;
            playBtn.Enabled = false;
            stopBtn.Enabled = true;
            configMapBtn.Enabled = false;
            configPlayerBtn.Enabled = false;
            howToPlayBtn.Enabled = false;
            playerSelector.Enabled = false;
            Focus();
            currentCoord = startCoord;
        }

        //Evento de botón Detener
        private void stopBtn_Click(object sender, EventArgs e)
        {
            gameStarted = false;
            initialStateSet = false;
            finalStateSet = false;
            stopBtn.Enabled = false;
            configMapBtn.Enabled = true;
            configPlayerBtn.Enabled = true;
            howToPlayBtn.Enabled = true;
            playerSelector.Enabled = true;
            visitNumber = 1;
            resetMap();
            loadMap();
            MessageBox.Show(this, "Juego detenido", "Gameover",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Evento de cambio de combobox para seleccionar jugador
        private void playerSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            playerImage.Image = characterList.Find(x => x.Name == playerSelector.SelectedItem.ToString()).Image;
        }

        #endregion

        #region movePlayerEvents
        private void goalReached()
        {
            if(currentCoord.SequenceEqual(goalCoord))
            {
                MessageBox.Show(this, "Meta alcanzada", "Gameover",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameStarted = false;
                stopBtn.Enabled = false;
                configMapBtn.Enabled = true;
                configPlayerBtn.Enabled = true;
                howToPlayBtn.Enabled = true;
                playerSelector.Enabled = true;
                visitNumber = 1;
                resetMap();
                loadMap();
            }
        }

        private void movePlayer(Keys key)
        {
            map.GetControlFromPosition(currentCoord[1] + 1, currentCoord[0] + 1).BackgroundImage =
                        setOpacity(matrixPosition[currentCoord[0], currentCoord[1]].Image, Convert.ToSingle(0.6));

            switch (key)
            {
                case Keys.Up:    currentCoord[0]--; break;
                case Keys.Down:  currentCoord[0]++; break;
                case Keys.Left:  currentCoord[1]--; break;
                case Keys.Right: currentCoord[1]++; break;
            }

            drawPlayer(((Panel)map.GetControlFromPosition(currentCoord[1] + 1, currentCoord[0] + 1)),
                            playerImage.Image);

            map.GetControlFromPosition(currentCoord[1] + 1, currentCoord[0] + 1).Controls[1].Text +=
                string.Format("{0},", ++visitNumber);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (gameStarted)
            {
                if (keyData == Keys.Up)
                {
                    if(currentCoord[0] > 0)
                    {
                        if(characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                            [matrixPosition[currentCoord[0] - 1, currentCoord[1]].Value] != -1)
                            movePlayer(keyData);
                    }
                }

                else if (keyData == Keys.Down)
                {
                    if (currentCoord[0] < matrixPosition.GetLength(0) - 1)
                    {
                        if (characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                            [matrixPosition[currentCoord[0] + 1, currentCoord[1]].Value] != -1)
                            movePlayer(keyData);
                    }
                }

                else if (keyData == Keys.Left)
                {
                    if (currentCoord[1] > 0)
                    {
                        if (characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                            [matrixPosition[currentCoord[0], currentCoord[1] - 1].Value] != -1)
                            movePlayer(keyData);
                    }
                }

                else if (keyData == Keys.Right)
                {
                    if (currentCoord[1] < matrixPosition.GetLength(1) - 1)
                    {
                        if (characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                            [matrixPosition[currentCoord[0], currentCoord[1] + 1].Value] != -1)
                            movePlayer(keyData);
                    }
                }
                goalReached();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
