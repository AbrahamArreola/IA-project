using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IA_project
{
    public partial class TreeWindow : Form
    {
        mainWindow mainForm;
        Tree tree;

        //Variables para pintar el árbol
        private Pen linkPen = Pens.Black;
        private Brush fontBrush = Brushes.Black;

        public TreeWindow(mainWindow main)
        {
            InitializeComponent();
            SystemSounds.Exclamation.Play();
            mainForm = main;
            tree = main.tree;
            panel1.Size = new Size(7000, 7000);
        }

        //Manda a llamar las funciones recursivas que se encargan de pintar el árbol
        private void drawTree(Graphics graphics)
        {
            drawNodeLinks(tree.Root, graphics);

            drawTreeNodes(tree.Root, graphics);
        }

        //Pinta de manera recursiva los enlaces del nodo padre con los hijos
        private void drawNodeLinks(Node node, Graphics graphics)
        {
            foreach (Node childNode in node.ChildNodes)
            {
                graphics.DrawLine(linkPen, node.NodePosition, childNode.NodePosition);

                drawNodeLinks(childNode, graphics);
            }
        }

        //Pinta de manera recursiva los nodos hijos
        private void drawTreeNodes(Node node, Graphics graphics)
        {
            drawNode(node, graphics);

            foreach (Node childNode in node.ChildNodes)
            {
                drawTreeNodes(childNode, graphics);
            }
        }

        //Pinta un nodo con todas las configuraciones seleccionadas
        private void drawNode(Node node, Graphics graphics)
        {
            SizeF nodeSize = node.getNodeSize(graphics, tree.NodeTextFont);

            RectangleF rectangle = new RectangleF()
            {
                X = node.NodePosition.X - nodeSize.Width / 2,
                Y = node.NodePosition.Y - nodeSize.Height / 2,
                Width = nodeSize.Width,
                Height = nodeSize.Height
            };

            graphics.DrawEllipse(linkPen, rectangle);
            graphics.FillEllipse(node.BackgroundBrush, rectangle);

            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                graphics.DrawString(node.StringData, tree.NodeTextFont, fontBrush, node.NodePosition.X,
                    node.NodePosition.Y, stringFormat);
            }
        }

        //Este evento pinta el árbol cada que sea necesario por si se hace scroll a la ventana
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using(Graphics graphics = e.Graphics)
            {
                float startPositionX = 5, startPositionY = 5;
                tree.calculateNodesPosition(tree.Root, graphics, ref startPositionX, ref startPositionY);
                graphics.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint =
                    TextRenderingHint.AntiAliasGridFit;
                drawTree(graphics);
            }
        }

        //Evento para llamar método de la venta principal y reiniciar los controles
        private void TreeWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.goalReachedAlgorithm();
        }
    }
}
