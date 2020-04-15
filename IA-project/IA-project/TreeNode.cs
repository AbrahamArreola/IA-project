using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_project
{
    public class Node
    {
        private int[] coord;
        private Node parent;
        private List<Node> childNodes;

        public Node(int[] coord, Node parent)
        {
            childNodes = new List<Node>();
            this.coord = coord;
            this.parent = parent;
        }

        public int[] Coord { get => coord; set => coord = value; }
        public Node Parent { get => parent; set => parent = value; }
        public List<Node> ChildNodes { get => childNodes; set => childNodes = value; }
    }

    public class Tree
    {
        private Node root;

        //Método de búsqueda de un nodo en el árbol
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
        }

        //Método interfaz para invocar el método searchNode
        public Node retrieveNode(int[] coord)
        {
            return searchNode(coord, root);
        }

        //Obtener, cambiar valor del nodo inicial
        public Node Root { get => root; set => root = value; }
    }
}
