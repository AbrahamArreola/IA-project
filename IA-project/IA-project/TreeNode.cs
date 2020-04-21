using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_project
{
    public class Node
    {
        //Variables necesarias para construcción del árbol
        private int[] coord;
        private Node parent;
        private List<Node> childNodes;
        private int visitNumber;
        private double terrainCost;

        //Información que se mostrará en el nodo pintado
        private string stringData;

        //Variable para almacenar la posición central del nodo para pintarlo
        private PointF nodePosition;

        //Variable para pintar el fondo del nodo
        private Brush backgroundBrush;

        //Constructor
        public Node(int[] coord, Node parent)
        {
            childNodes = new List<Node>();
            this.coord = coord;
            this.parent = parent;
            visitNumber = 0;
            terrainCost = 0;
            backgroundBrush = Brushes.White;

            //Inicializa la información que mostrará el nodo sin el número de visita
            stringData = String.Format("({0},{1})\n{2}", (char)(coord[1] + 65),
                coord[0] + 1, terrainCost);

            nodePosition = new PointF(0, 0);
        }

        //Se agrega el número de visita y se actualiza la información mostrará el nodo
        public void setData(int visitNumber)
        {
            this.visitNumber = visitNumber;
            stringData = String.Format("{0}\n({1},{2})\n{3}", visitNumber, (char)(coord[1] + 65),
                coord[0] + 1, terrainCost);
        }

        //Devuelve el tamaño de la cadena de la información del nodo que ocupará el objeto Graphics
        public SizeF getNodeSize(Graphics graphics, Font textFont)
        {
            return graphics.MeasureString(stringData, textFont) + new SizeF(10, 10);
        }

        //Getters, setters
        public int[] Coord { get => coord; set => coord = value; }
        public Node Parent { get => parent; set => parent = value; }
        public List<Node> ChildNodes { get => childNodes; set => childNodes = value; }
        public string StringData { get => stringData; set => stringData = value; }
        public PointF NodePosition { get => nodePosition; set => nodePosition = value; }
        public Brush BackgroundBrush { get => backgroundBrush; set => backgroundBrush = value; }
    }

    public class Tree
    {
        //Nodo raíz
        private Node root;

        //Variables para pintar el árbol
        private Font nodeTextFont;
        private const int widthSpace = 8;
        private const int heightSpace = 12;

        //Método recursivo de búsqueda de un nodo en el árbol
        private Node searchNode(int[] coord, Node node)
        {
            if (coord.SequenceEqual(node.Coord))
                return node;

            foreach (Node childNode in node.ChildNodes)
            {
                node = searchNode(coord, childNode);
                if (coord.SequenceEqual(node.Coord))
                    break;
            }
            return node;
        }

        //Constructor, se le pasa el nodo raíz
        public Tree(Node root)
        {
            this.root = root;
            nodeTextFont = new Font("Arial", 10);
        }

        //Método interfaz para invocar el método searchNode
        public Node retrieveNode(int[] coord)
        {
            return searchNode(coord, root);
        }

        //Método para calcular los espacios donde será dibujado cada nodo del árbol
        public void calculateNodesPosition(Node node, Graphics graphics, ref float startx, ref float starty)
        {
            SizeF nodeSize = node.getNodeSize(graphics, nodeTextFont);

            float x = startx;
            float biggesty = starty + nodeSize.Height;
            float startSubtree = starty + nodeSize.Height + heightSpace;
            foreach (Node childNode in node.ChildNodes)
            {
                float startChildNode = startSubtree;
                calculateNodesPosition(childNode, graphics, ref x, ref startChildNode);

                if (biggesty < startChildNode) biggesty = startChildNode;

                x += widthSpace;
            }

            if (node.ChildNodes.Count > 0) x -= widthSpace;

            float subtree_width = x - startx;
            if (nodeSize.Width > subtree_width)
            {
                x = startx + (nodeSize.Width - subtree_width) / 2;
                foreach (Node childNode in node.ChildNodes)
                {
                    calculateNodesPosition(childNode, graphics, ref x, ref startSubtree);

                    x += widthSpace;
                }
                subtree_width = nodeSize.Width;
            }

            node.NodePosition = new PointF
            {
                X = startx + subtree_width / 2,
                Y = starty + nodeSize.Height / 2
            };

            startx += subtree_width;
            starty = biggesty;
        }

        //Getters, setters
        public Node Root { get => root; set => root = value; }
        public Font NodeTextFont { get => nodeTextFont; set => nodeTextFont = value; }
    }
}
