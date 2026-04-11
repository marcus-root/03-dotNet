namespace dotNet_03_Generics_03_Bäume
{
    internal class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public void Clear()
        {
            Root = null; // lösche Root.
        }
        public void Insert(T value)
        {
            if (Root == null) // Wenn kein Root besteht, erstelle einen
            {
                Root = new BinaryTreeNode<T>(value);
            }
            else if (Contains(value)) // wenn Wert schon vorhanden, mache nichts
            {
                Console.WriteLine($"{value} ist schon im Baum vorhanden!");
                return;
            }
            else // sonst: Füge ein
            {
                Insert(Root, value);
                Console.WriteLine($"{value} wurde eingefügt");
            }
        }
        private void Insert(BinaryTreeNode<T> node, T value)
        {
            if (node.Data.CompareTo(value) > 0) // wenn Wert kleiner als node, nehme linken Pfad
            {
                if (node.Left == null) node.Left = new BinaryTreeNode<T>(value); // wenn links kein Node, erstelle Node
                else Insert(node.Left, value); // sont Neuer Aufruf mit linkem Child
            }
            else if (node.Data.CompareTo(value) < 0) // wenn Wert größer als node, nehme rechten Pfad
            {
                if (node.Right == null) node.Right = new BinaryTreeNode<T>(value); // wenn rechts kein Node, erstelle Node
                else Insert(node.Right, value); // sont Neuer Aufruf mit rechtem Child
            }
        }
        private void InsertNode(BinaryTreeNode<T> node, BinaryTreeNode<T> nodeToInsert)
        {
            if (node.Data.CompareTo(nodeToInsert.Data) > 0) // wenn Wert kleiner als node, nehme linken Pfad
            {
                if (node.Left == null) node.Left = nodeToInsert; // wenn links kein Node, füge Node ein
                else InsertNode(node.Left, nodeToInsert); // sont Neuer Aufruf mit linkem Child
            }
            else if (node.Data.CompareTo(nodeToInsert.Data) < 0) // wenn Wert größer als node, nehme rechten Pfad
            {
                if (node.Right == null) node.Right = nodeToInsert; // wenn rechts kein Node, füge Node ein
                else InsertNode(node.Right, nodeToInsert); // sont Neuer Aufruf mit rechtem Child
            }
        }
        public void Delete(T value)
        {
            if (Root == null) // wenn Baum leer, mache nichts
            {
                return;
            }
            else if (!Contains(value)) // wenn value nicht vorhanden, mache nichts
            {
                return;
            }
            else
            {
                Delete(Root, value); // Aufruf der rekursiven Methode
            }
        }
        public void Delete(BinaryTreeNode<T> node, T value)
        {
            BinaryTreeNode<T> delNode; // Node die gelöscht werden soll
            BinaryTreeNode<T> leftNode; // linke Child Node
            BinaryTreeNode<T> rightNode; // rechte child Node

            if (Root.Data.Equals(value)) // Wenn der Root gelöscht werden soll
            {
                delNode = Root;
                leftNode = Root.Left;
                rightNode = Root.Right;
                Root = leftNode; // neuer Root: linker Child
                InsertNode(Root, rightNode); // füge rechten Child in Baum ein
            }

            if (node != null && node.Left != null && node != null && node.Left.Data.Equals(value)) // wenn linker Node gelöscht werden soll
            {
                delNode = node.Left;
                leftNode = delNode.Left;
                rightNode = delNode.Right;
                node.Left = null;
                if (leftNode != null) InsertNode(Root, leftNode);
                if (rightNode != null) InsertNode(Root, rightNode);
            }
            else if (node != null && node.Right != null && node != null && node.Right.Data.Equals(value)) // rechter Node
            {
                delNode = node.Right;
                leftNode = delNode.Left;
                rightNode = delNode.Right;
                node.Right = null;
                if (leftNode != null) InsertNode(Root, leftNode);
                if (rightNode != null) InsertNode(Root, rightNode);
            }
            else // nächster Aufruf
            {
                if (node.Left != null) Delete(node.Left, value);
                if (node.Right != null) Delete(node.Right, value);
            }

        }
        public bool Contains(T value) // nutzt die Logik von Search()
        {
            if (Search(value) != null) return true;
            else return false;
        }


        public BinaryTreeNode<T> Search(T value)
        {
            return Search(Root, value); // Aufruf der rekursiven Funktion
        }

        private BinaryTreeNode<T> Search(BinaryTreeNode<T> node, T value)
        {
            if (node.Data.Equals(value)) return node; // wenn das Node mit dem gesuchten Wert übereinstimmt
            else if (node.Left != null && node.Right != null) // wenn beide Child Nodes vorhanden
            {
                if (node.Data.CompareTo(value) > 0) return Search(node.Left, value);
                else return (Search(node.Right, value));
            }
            else if (node.Left != null && node.Right == null) return Search(node.Left, value); // nur linker Child
            else if (node.Left == null && node.Right != null) return Search(node.Right, value); // nur rechter
            else return null; // kein Suchtreffer
        }

        public void PrintInorder()
        {
            if (Root == null) Console.WriteLine("leer."); // wenn Baum leer
            else PrintInorder(Root);
        }

        private void PrintInorder(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            PrintInorder(node.Left);
            Console.WriteLine(node.Data);
            PrintInorder(node.Right);
        }


    }
}
