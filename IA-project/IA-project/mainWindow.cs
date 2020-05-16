using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
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
        private bool gameStartedAlgorithm = false;
        private bool terrainsConfigured = false;
        public bool playersConfigured = false;
        private bool initialStateSet = false;
        private bool finalStateSet = false;

        //Variable contadora de visitas
        private int visitNumber;

        //Lista de ComboBoxes de orden de expansión
        private List<ComboBox> comboBoxValues = new List<ComboBox>();
        private List<int> comboBoxOrder;

        //Estructuras para el control de la ejecución de algoritmos ciegos
        Stack<int[]> auxStack = new Stack<int[]>();
        List<int[]> expandedNodes = new List<int[]>();
        List<int[]> visitedNodes = new List<int[]>();
        int[] currentNode;

        //Estructuras para el control de la ejecución de alogoritmos heurísticos
        PriorityQueue priorityQueue = new PriorityQueue();
        List<MapPosition> expandedNodesh = new List<MapPosition>();
        List<MapPosition> visitedNodesh = new List<MapPosition>();
        MapPosition currentNodeh;

        //Clases para la construcción del árbol de expansión
        public Tree tree;
        public Node node;


        private Dictionary<string, double> dictionaryOfEuclidiansPosition = new Dictionary<string, double>();
        private Dictionary<string, double> dictionaryOfEuclidiansCoordenates = new Dictionary<string, double>();

        private Dictionary<string, double> dictionaryOfManhattanPosition = new Dictionary<string, double>();
        private Dictionary<string, double> dictionaryOfManhattanCoordenates = new Dictionary<string, double>();


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

            //Inicializando los comboBox de orden de expasión
            initializeComboBoxes();
            initializeAlgorithmsCb();

            //Función para testear el programa
            initializeToPlay();
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
                if (gameStarted || gameStartedAlgorithm || playerSelector.SelectedIndex < 0)
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
            playBtn.Enabled = false;
            stopBtn.Enabled = true;
            resetButton.Enabled = false;
            configMapBtn.Enabled = false;
            configPlayerBtn.Enabled = false;
            howToPlayBtn.Enabled = false;
            playerSelector.Enabled = false;
            ExpasionOrderGb.Enabled = false;
            AlgorithmsGb.Enabled = false;
            currentCoord = startCoord;

            maskMapInit();

            // make a selection of distance choosen here
            distancesByEuclidianMedition();
           
            //switch (AlgorithmsCb.SelectedIndex
            
            if(AlgorithmsCb.SelectedIndex == 0)
            {
                gameStarted = true;
                Focus();
            }
            else
            {
                gameStartedAlgorithm = true;
                //Ordena los comboBoxes de orden de expansión
                sortComboBoxes();

                //Inicializa el árbol
                node = new Node(startCoord, null);
                tree = new Tree(node);

                switch (AlgorithmsCb.SelectedIndex)
                {
                    //Caso 1 = Algoritmo primero en profundidad
                    case 1:
                        auxStack.Push(startCoord);
                        depthFirstSearch();
                        break;

                    case 2:
                        currentNodeh = new MapPosition(startCoord, 0);
                        priorityQueue.Enqueue(currentNodeh);
                        break;
                }

                //Continua con la ejecución del algoritmo
                timer1.Start();
            }

        }

        //Función para reiniciar los controles necesarios
        private void stopConfig()
        {
            gameStarted = false;
            gameStartedAlgorithm = false;
            initialStateSet = false;
            finalStateSet = false;
            resetButton.Enabled = true;
            stopBtn.Enabled = false;
            configMapBtn.Enabled = true;
            configPlayerBtn.Enabled = true;
            howToPlayBtn.Enabled = true;
            playerSelector.Enabled = true;
            ExpasionOrderGb.Enabled = true;
            AlgorithmsGb.Enabled = true;
            visitNumber = 1;

            MessageBox.Show(this, "Juego detenido", "Gameover",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Evento de botón Detener
        private void stopBtn_Click(object sender, EventArgs e)
        {
            if(AlgorithmsCb.SelectedIndex != 0)
            {
                timer1.Stop();
                //Limpiando estructuras de control
                auxStack.Clear();
                expandedNodes.Clear();
                visitedNodes.Clear();
                priorityQueue.Clear();
                expandedNodesh.Clear();
                visitedNodesh.Clear();
            }
            stopConfig();
            resetMap();
            loadMap();
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
                if(AlgorithmsCb.SelectedIndex == 0)
                {
                    MessageBox.Show(this, "Meta alcanzada", "Gameover",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TreeWindow treeWindow = new TreeWindow(this);
                    treeWindow.Show();
                    return;
                }
                gameStarted = false;
                stopBtn.Enabled = false;
                configMapBtn.Enabled = true;
                configPlayerBtn.Enabled = true;
                howToPlayBtn.Enabled = true;
                playerSelector.Enabled = true;
                resetButton.Enabled = true;
                ExpasionOrderGb.Enabled = true;
                AlgorithmsGb.Enabled = true;
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

            //does the cross when the character moves
            makeCross(currentCoord);

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

        #region ExpasionOrderComboBoxEvents

        //Llamada en el constructor para inicializar los comboBoxes de "orden de expansion"
        private void initializeComboBoxes()
        {
            string[] directionsList = { "Arriba (↑)", "Derecha (→)", "Abajo (↓)", "Izquierda (←)" };

            firstComboBox.DataSource = (string[])directionsList.Clone();
            secondComboBox.DataSource = (string[])directionsList.Clone();
            thirdComboBox.DataSource = (string[])directionsList.Clone();
            fourthComboBox.DataSource = (string[])directionsList.Clone();

            //Index 0 = Arriba (↑), index 1 = Derecha (→), index 2 = Abajo (↓), index 3 = Izquierda (←)
            secondComboBox.SelectedIndex = 1;
            thirdComboBox.SelectedIndex = 2;
            fourthComboBox.SelectedIndex = 3;

            /*Agrega los elementos a una lista en la que el index será arriba, abajo, derecha, izquierda de
            acuerdo al criterio anterior, y contendrá un comboBox, por lo que si se tiene que
            comboBoxValues[0], quiere decir que el valor que contenga en dicho index es el comboBox que
            contiene el valor "Arriba" seleccionado*/
            comboBoxValues.Add(firstComboBox);
            comboBoxValues.Add(secondComboBox);
            comboBoxValues.Add(thirdComboBox);
            comboBoxValues.Add(fourthComboBox);
        }

        /*Intercambia el item de los comboBox, por ejemplo: si el primer comboBox tiene el valor "Arriba" y
        se selecciona el valor de "Abajo", se intercambian los valores con el comboBox que tiene el valor de "Abajo*/
        private void swapItems(ComboBox comboBox)
        {
            if(comboBoxValues.Count != 0)
            {
                //Se busca el index donde se encuentra el comboBox
                int tempIndex = comboBoxValues.FindIndex(x => x == comboBox);
                
                //Se obtiene el comboBox que contiene el nuevo valor seleccionado
                ComboBox tempComboBox = comboBoxValues[comboBox.SelectedIndex];

                /*Al comboBox seleccionado se le cambia el index en la interfáz, pero al comboBox que contenía
                 el index que se acaba de seleccionar se le cambia con el index del comboBox seleccionado*/
                tempComboBox.SelectedIndex = tempIndex;

                //Se actualiza la lista de valores
                comboBoxValues[comboBox.SelectedIndex] = comboBox;
                comboBoxValues[tempIndex] = tempComboBox;
            }
        }

        //Se programa el evento de cambio de index para todos los comboBox del grupo "orden de expansión"
        private void firstComboBox_SelectedIndexChanged(object sender, EventArgs e) { swapItems((ComboBox)sender); }

        private void secondComboBox_SelectedIndexChanged(object sender, EventArgs e) { swapItems((ComboBox)sender); }

        private void thirdComboBox_SelectedIndexChanged(object sender, EventArgs e) { swapItems((ComboBox)sender); }

        private void fourthComboBox_SelectedIndexChanged(object sender, EventArgs e) { swapItems((ComboBox)sender); }

        //Guarda en una lista el orden de los comboBoxes para poder decretar el orden de expansión
        private void sortComboBoxes()
        {
            List<int> tempComboBoxList = new List<int>();

            tempComboBoxList.Add(firstComboBox.SelectedIndex);
            tempComboBoxList.Add(secondComboBox.SelectedIndex);
            tempComboBoxList.Add(thirdComboBox.SelectedIndex);
            tempComboBoxList.Add(fourthComboBox.SelectedIndex);

            comboBoxOrder = tempComboBoxList;
        }

        #endregion

        #region Algorithms

        //Inicializa el comboBox para seleccionar si jugar con teclas o ejecutar algún algoritmo
        private void initializeAlgorithmsCb()
        {
            string[] Algorithms = { "Mover con teclas", "Profundidad", "Costo uniforme" };

            AlgorithmsCb.DataSource = Algorithms;
        }

        //Función para testear. P.D. eliminar al terminar el programa
        private void initializeToPlay()
        {
            //Cargar terrenos
            fileRoute = "D:\\AbrahamArreolaPC\\Escritorio\\Dev\\Maps test\\mapAlgorithm2.txt";
            //fileRoute = "D:\\Arturo\\Documents\\Escuela\\8vo semestre\\IA 1\\Mapas\\map2.txt";

            Dictionary<int, Terrain> terrains = new Dictionary<int, Terrain>();

            string absolutePath = AppDomain.CurrentDomain.BaseDirectory;
            string imagesPath = string.Format("{0}Resources\\terrain_images",
                                Path.GetFullPath(Path.Combine(absolutePath, @"..\..\")));

            for (int i = 1; i <= 4; i++)
            {
                Terrain terrain = new Terrain
                {
                    Value = i,
                    Name = i.ToString(),
                    Image = Image.FromFile(imagesPath + String.Format("//terreno {0}.jpg", i))
                };
                terrains[i] = terrain;
            }

            terrainsDictionary = terrains;
            loadMap();

            //Cargar personajes
            List<CharacterData> characters = new List<CharacterData>();

            imagesPath = string.Format("{0}Resources\\characters_images", 
                         Path.GetFullPath(Path.Combine(absolutePath, @"..\..\")));

            string[] paths = Directory.GetFiles(imagesPath);

            for(int i = 1; i <= 2; i++)
            {
                CharacterData character = new CharacterData
                {
                    Name = i.ToString(),
                    Image = Image.FromFile(paths[i]),
                    MovilityOfCharacter = new Dictionary<int, decimal>
                    {
                        {1, 2}, {2, 4}, {3, 6}, {4, 8}
                    }
                };
                characters.Add(character);
            }
            characterList = characters;

            playersConfigured = true;
            loadCharacters();
        }

        //Función para mover el jugador a una coordenada dada
        private void movePlayerAlgorithm(int[] coord)
        {
            //Borra al jugador de la posición en la que estaba
            map.GetControlFromPosition(currentCoord[1] + 1, currentCoord[0] + 1).BackgroundImage =
                        setOpacity(matrixPosition[currentCoord[0], currentCoord[1]].Image, Convert.ToSingle(0.6));

            //Pinta al jugador en la nueva posición dada
            drawPlayer(((Panel)map.GetControlFromPosition(coord[1] + 1, coord[0] + 1)), playerImage.Image);


            makeCross(coord);

            //Actualiza el contador de visitas en la nueva posición
            map.GetControlFromPosition(coord[1] + 1, coord[0] + 1).Controls[1].Text +=
                string.Format("{0},", ++visitNumber);

            currentCoord = coord;
        }

        //Evento timer que ejecuta código cada determinados milisengundos en segundo plano hasta que sea detenido
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (AlgorithmsCb.SelectedIndex)
            {
                case 1:
                    depthFirstSearch();
                    break;

                case 2:
                    uniformCostSearch();
                    break;
            }
        }

        //Algoritmo costo uniforme
        private void uniformCostSearch()
        {
            currentNodeh = priorityQueue.Dequeue();
            decimal currentCost = currentNodeh.Cost;
            if (!currentNodeh.Coord.SequenceEqual(startCoord))
            {
                movePlayerAlgorithm(currentNodeh.Coord);
            }
            if (currentCoord.SequenceEqual(goalCoord))
            {
                //Agrega última visita al nodo destino
                node = tree.retrieveNode(currentNodeh.Coord);
                node.setData(visitNumber);

                //Reinicia lo necesario para finalizar con la ejecución del algoritmo
                AlgorithmEnds();
                return;
            }

            if (!visitedNodesh.Any(x => x.Coord.SequenceEqual(currentNodeh.Coord)))
            {
                //Obtiene las coordenadas hijo de una posición ordenadas acorde al orden de expansión
                List<int[]> childNodes = getNodes(currentNodeh.Coord);

                //Agrega el nodo a la lista de visitados y expandidos
                expandedNodesh.Add(currentNodeh);
                visitedNodesh.Add(currentNodeh);

                //Agregar a visita del nodo en el árbol
                node = tree.retrieveNode(currentNodeh.Coord);
                node.setData(visitNumber);

                //Verifica los posiciones hijo para seguir con la ejecución del algoritmo
                foreach (int[] childNode in childNodes)
                {
                    MapPosition newNode = new MapPosition(childNode, characterList[playerSelector.SelectedIndex].
                        MovilityOfCharacter[matrixPosition[childNode[0], childNode[1]].Value]);
                    newNode.Cost += currentCost;

                    int nodeIndex = expandedNodesh.FindIndex(x => x.Coord.SequenceEqual(childNode));
                    if(nodeIndex == -1)
                    {
                        priorityQueue.Enqueue(newNode);
                        expandedNodesh.Add(newNode);
                        node.ChildNodes.Add(new Node(childNode, node, newNode.Cost));
                    }
                    else
                    {
                        if(!visitedNodesh.Any(x => x.Coord.SequenceEqual(childNode)) && 
                            newNode.Cost < expandedNodesh[nodeIndex].Cost)
                        {
                            expandedNodesh[nodeIndex] = newNode;
                            priorityQueue.Delete(childNode);
                            priorityQueue.Enqueue(newNode);

                            Node tempNode = tree.retrieveNode(childNode);
                            if (tempNode != null)
                            {
                                tempNode.Parent.ChildNodes.Remove(tempNode);
                                node.ChildNodes.Add(new Node(childNode, node, newNode.Cost));
                            }
                        }
                    }
                }
            }
        }

        //Algoritmo primero en profundidad
        private void depthFirstSearch()
        {
            currentNode = auxStack.Pop();
            if (!currentNode.SequenceEqual(startCoord))
            {
                movePlayerAlgorithm(currentNode);
            }
            if (currentCoord.SequenceEqual(goalCoord))
            {
                //Agrega última visita al nodo destino
                node = tree.retrieveNode(currentNode);
                node.setData(visitNumber);

                //Reinicia lo necesario para finalizar con la ejecución del algoritmo
                AlgorithmEnds();
                return;
            }

            if (!visitedNodes.Any(x => x.SequenceEqual(currentNode)))
            {
                List<int[]> statesList = getNodes(currentNode);
                expandedNodes.Add(currentNode);
                visitedNodes.Add(currentNode);
                node = tree.retrieveNode(currentNode);
                node.setData(visitNumber);
                foreach (int[] state in statesList)
                {
                    if (!expandedNodes.Any(x => x.SequenceEqual(state)))
                    {
                        auxStack.Push(state);
                        expandedNodes.Add(state);
                        node.ChildNodes.Add(new Node(state, node));
                    }
                }
            }
        }

        //Reinicia lo necesario para finalizar con la ejecución del algoritmo
        private void AlgorithmEnds()
        {
            timer1.Stop();              //Se detiene el timer para que pare el algoritmo
            stopBtn.Enabled = false;    //Se deshabilita el boton de detener
            drawSolutionPath();         //Se pinta el camino a la solución en el mapa
            goalReached();

            //Limpiando estructuras de control
            auxStack.Clear();
            expandedNodes.Clear();
            visitedNodes.Clear();

            priorityQueue.Clear();
            expandedNodesh.Clear();
            visitedNodesh.Clear();
        }

        //Función para reiniciar los controles cuando se alcanzó la meta con un algoritmo
        public void goalReachedAlgorithm()
        {
            gameStartedAlgorithm = false;
            stopBtn.Enabled = false;
            configMapBtn.Enabled = true;
            configPlayerBtn.Enabled = true;
            howToPlayBtn.Enabled = true;
            playerSelector.Enabled = true;
            resetButton.Enabled = true;
            ExpasionOrderGb.Enabled = true;
            AlgorithmsGb.Enabled = true;
            visitNumber = 1;
            resetMap();
            loadMap();
        }

        //Obtiene los nodos (coordenadas) a los que se puede mover el jugador de acuerdo al orden de expansión
        private List<int[]> getNodes(int[] coord) 
        {
            List<int[]> statesList = new List<int[]>();

            //Itera sobre la lista ordenada de indices que corresponde a una posición
            foreach (int position in comboBoxOrder)
            {
                int[] tempCoord = (int[])coord.Clone();
                switch (position)
                {
                    //Obtener posición arriba
                    case 0:
                        if (tempCoord[0] > 0)
                        {
                            if (characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                                [matrixPosition[tempCoord[0] - 1, tempCoord[1]].Value] != -1)
                            {
                                tempCoord[0]--;
                                statesList.Add(tempCoord);
                            }
                        }
                        break;

                    //Obtener posición derecha
                    case 1:
                        if (tempCoord[1] < matrixPosition.GetLength(1) - 1)
                        {
                            if (characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                                [matrixPosition[tempCoord[0], tempCoord[1] + 1].Value] != -1)
                            {
                                tempCoord[1]++;
                                statesList.Add(tempCoord);
                            }
                        }
                        break;

                    //Obtener posición abajo
                    case 2:
                        if (tempCoord[0] < matrixPosition.GetLength(0) - 1)
                        {
                            if (characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                                [matrixPosition[tempCoord[0] + 1, tempCoord[1]].Value] != -1)
                            {
                                tempCoord[0]++;
                                statesList.Add(tempCoord);
                            }
                        }
                        break;

                    //Obtener posición izquierda
                    case 3:
                        if (tempCoord[1] > 0)
                        {
                            if (characterList[playerSelector.SelectedIndex].MovilityOfCharacter
                                [matrixPosition[tempCoord[0], tempCoord[1] - 1].Value] != -1)
                            {
                                tempCoord[1]--;
                                statesList.Add(tempCoord);
                            }
                        }
                        break;
                }
            }
            return statesList;
        }

        //Método para pintar los espacios del laberinto que pertenecen al camino a la solución
        private void drawSolutionPath()
        {
            if (tree != null)
            {
                Node node = tree.retrieveNode(goalCoord);
                node.BackgroundBrush = Brushes.LightBlue;

                while (node != null)
                {
                    node = node.Parent;
                    if(node != null)
                    {
                        drawImagePath((Panel)map.GetControlFromPosition(node.Coord[1] + 1, node.Coord[0] + 1), 
                            Properties.Resources.pickaxe);
                        node.BackgroundBrush = Brushes.LightBlue;
                    }
                }
            }
        }

        //Función para pintar imagen de camino solución en un panel
        private void drawImagePath(Panel containerPanel, Image image)
        {
            Bitmap bm1 = new Bitmap(containerPanel.BackgroundImage);
            Bitmap bm2 = new Bitmap(setOpacity(image, Convert.ToSingle(0.7)));
            Bitmap finalImage = new Bitmap(bm1.Width, bm1.Height);
            Graphics gf = Graphics.FromImage(finalImage);
            gf.DrawImage(bm1, new Rectangle(0, 0, bm1.Width, bm1.Height));
            gf.DrawImage(bm2, new Rectangle(0, 0, bm1.Width, bm1.Height));
            containerPanel.BackgroundImage = finalImage;
        }

        #endregion

        #region maskMap

        private void maskMapInit()
        {
            int[] coordinateToAvoid = new int[2];

            for (int i = 1; i < matrixPosition.GetLength(0) + 1; i++)
            {
                for (int j = 1; j < matrixPosition.GetLength(1) + 1; j++)
                {
                    coordinateToAvoid[0] = i - 1;
                    coordinateToAvoid[1] = j - 1;

                    // if the coordinate is not the origin nor the goal
                    if (!coordinateToAvoid.SequenceEqual(goalCoord) &&
                        !coordinateToAvoid.SequenceEqual(startCoord))
                    {
                        map.GetControlFromPosition(j, i).BackgroundImage = 
                            setOpacity(map.GetControlFromPosition(j, i).BackgroundImage, Convert.ToSingle(0));
                    }
                }
            }

            makeCross(startCoord);
        }

        private void paintTileNormal(Control tileOfMap, int[] coordinates)
        {

            if (tileOfMap != null)
            {
                if(tileOfMap.BackgroundImage != null)
                {
                    tileOfMap.BackgroundImage =
                    setOpacity(matrixPosition[coordinates[1]-1, coordinates[0]-1].Image, Convert.ToSingle(0.6));
                }               
            }
        }

        private void makeCross(int [] coordinateToGet )
        {
            // up of character
            var tile = map.GetControlFromPosition(coordinateToGet[1] + 1, coordinateToGet[0]);
            int[] coordinates = { coordinateToGet[1] + 1, coordinateToGet[0] };
            paintTileNormal(tile, coordinates);


            //left of initial Cordinate
            tile = map.GetControlFromPosition(coordinateToGet[1], coordinateToGet[0] + 1);
            coordinates[0] = coordinateToGet[1];
            coordinates[1] = coordinateToGet[0] + 1;
            paintTileNormal(tile, coordinates);

            //down of initial Cordinate
            tile = map.GetControlFromPosition(coordinateToGet[1] + 1, coordinateToGet[0] + 2);
            coordinates[0] = coordinateToGet[1] + 1;
            coordinates[1] = coordinateToGet[0] + 2;
            paintTileNormal(tile, coordinates);

            //right of initial Cordinate
            tile = map.GetControlFromPosition(coordinateToGet[1] + 2, coordinateToGet[0] + 1);
            coordinates[0] = coordinateToGet[1] + 2;
            coordinates[1] = coordinateToGet[0] + 1;
            paintTileNormal(tile, coordinates);
        }


        #endregion


        #region Distances


        private void euclidianDistancewithPosition(Control tileOfMap, int[] coordenates)
        {
            Control end = map.GetControlFromPosition(goalCoord[1]+1,goalCoord[0]+1);

            var current = tileOfMap.Location;
            var secondLocation = end.Location;


            double x1, x2, y2, y1;

            x1 = current.X;
            y1 = current.Y;

            x2 = secondLocation.X;
            y2 = secondLocation.Y;

            double xSquares = (x2 - x1);
            xSquares = Math.Pow(xSquares, 2);

            double YSquares = (y2 - y1);
            YSquares = Math.Pow(YSquares, 2);

            double sumSquares = xSquares + YSquares;

            sumSquares = Math.Sqrt(sumSquares);

            string key = (coordenates[0] - 1) + "/" + (coordenates[1] - 1);

            dictionaryOfEuclidiansPosition.Add(key, sumSquares);

        }

        private void euclidianDistanceWithCoordenates(int[] coordenates)
        {

            double x1, x2, y2, y1;

            //row
            x1 = coordenates[0];
            //column
            y1 = coordenates[1];

            // row
            x2 = goalCoord[0]+1;
            //column
            y2 = goalCoord[1]+1;

            double xSquares = (x2 - x1);
            xSquares = Math.Pow(xSquares, 2);

            double YSquares = (y2 - y1);
            YSquares = Math.Pow(YSquares, 2);

            double sumSquares = xSquares + YSquares;

            sumSquares = Math.Sqrt(sumSquares);

            string key = (coordenates[0] - 1) + "/" + (coordenates[1] - 1);

            dictionaryOfEuclidiansCoordenates.Add(key, sumSquares);
        }

        private void manhattanDistanceWithCoordenates(int[] coordenates)
        {

            double x1, x2, y2, y1;

            //row
            x1 = coordenates[0];
            //column
            y1 = coordenates[1];

            // row
            x2 = goalCoord[0] + 1;
            //column
            y2 = goalCoord[1] + 1;

            double xAbs = (x1 - x2);
            xAbs = Math.Abs(xAbs);

            double yAbs = (y1 - y2);
            yAbs = Math.Abs(yAbs);

            double sumAbsolutes = xAbs + yAbs;

            string key = (coordenates[0] - 1) + "/" + (coordenates[1] - 1);


            dictionaryOfManhattanCoordenates.Add(key, sumAbsolutes);
        }

        private void manhattanDistancewithPosition(Control tileOfMap, int[] coordenates)
        {
            Control end = map.GetControlFromPosition(goalCoord[1] + 1, goalCoord[0] + 1);

            var current = tileOfMap.Location;
            var secondLocation = end.Location;


            double x1, x2, y2, y1;

            x1 = current.X;
            y1 = current.Y;

            x2 = secondLocation.X;
            y2 = secondLocation.Y;

            double xAbs = (x1 - x2);
            xAbs = Math.Abs(xAbs);

            double yAbs = (y1 - y2);
            yAbs = Math.Abs(yAbs);

            double sumAbsolutes = xAbs + yAbs;

            string key = (coordenates[0]-1) + "/" + (coordenates[1]-1);


            dictionaryOfManhattanPosition.Add(key, sumAbsolutes);

        }




        private void distancesByEuclidianMedition()
        {

            int rows = matrixPosition.GetLength(0);
            int columns = matrixPosition.GetLength(1);

            int column, row;
            int[] positions;
           // int[] positions2;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
               
                    var tile = map.GetControlFromPosition(j, i);

                    column = j;
                    row = i;

                    // to avoid alteration of references
                    positions = new int[2] { row, column };

                    // just for test, remove at last
                    if(j == 4 && i == 6)
                    {
                        tile.BackgroundImage = Properties.Resources.pickaxe;
                    }

                    // column // row

                    euclidianDistancewithPosition(tile, positions); // the one with location
                    euclidianDistanceWithCoordenates(positions); // the one with coordenates

                    manhattanDistanceWithCoordenates(positions);
                    manhattanDistancewithPosition(tile, positions);
                }
            }

        }

        #endregion
    }
}
