using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2023
{
    public class BNode
    {
		public double info;
		public int weight;
		public BNode left, right;

        public BNode()
        {
            info = 0;
            weight = 0;
            left = right = null;
        }

        public BNode(double b)
        {
            info = b;
            weight = 0;
            left = right = null;
        }
	
		public BNode(int i)
		{
			info = 0;
			weight = i;
			left = right = null;
		}


		public BNode(double i, int w)
		{
			info = i;
			weight = w;
			left = right = null;
		}

		public BNode(double i, BNode l)
		{
			info = i;
			left = l;
			weight = 0;
			right = null;
		}

		public BNode(double i, BNode l, BNode r)
		{
			info = i;
			weight = 0;
			left = l;
			right = r;
		}


		public BNode(double i, int w, BNode l, BNode r)
		{
			info = i;
			weight = w;
			left = l;
			right = r;
		}

		public bool isLT(double el)
		{
			return info > el;
		}

		public bool isGT(double el)
		{
			return info < el;
		}

		public bool isEq(double el)
		{
			return info == el;
		}
	}
}
