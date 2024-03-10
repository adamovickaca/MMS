using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2023
{
    public class BTree
    {
        private const int COUNT =  5;
        public BNode root;
        public int numEl;

        public BTree()
        {
            root = null;
            numEl = 0;
        }

        private void print2DUtil(BNode root, int space)
        {
            if(root == null)
            {
                return;
            }

            space += COUNT;

            print2DUtil(root.right, space);
            Console.WriteLine();

            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            if (root.info == 0)
            {
                Console.WriteLine(root.weight);
            }
            else
            {
                Console.WriteLine(root.weight + " " + root.info);

            }

            print2DUtil(root.left, space);
        }

        public void print2D(BNode root)
        {
            print2DUtil(root, 0);
        }
    }
}
