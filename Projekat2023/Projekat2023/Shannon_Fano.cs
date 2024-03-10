using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2023
{
    public class Shannon_Fano
    {
        //moguc br razlicitih bajtova
        private const int brBajtova = 256;

        public Shannon_Fano() { }

        private double[] nizBajtova() {
            double[] niz = new double[brBajtova];
            for (int i = 0; i < brBajtova; i++)
            {
                //inicijalizujemo niz tako da svaki simbol ima vrednost koja odgovara njevovom indexu
                niz[i] = Convert.ToDouble(i);
            }

            return niz;
        }

        // sortiranje simbola i njihovih verovatnoce pojavljivanja u opadajućem redosledu
        private void Sortiraj(ref int[] niz, ref double[] vrednosti)
        {
            int i, j;
            int imax;

            for(i = 0; i < brBajtova-1; i++)
            {
                imax = i;

                for(j = i + 1; j < brBajtova; j++)
                {
                    if (niz[j] > niz[imax])
                        imax = j;
                }

                if(i != imax)
                {
                    int pom = niz[i];
                    niz[i] = niz[imax];
                    niz[imax] = pom;

                    double p = vrednosti[i];
                    vrednosti[i] = vrednosti[imax];
                    vrednosti[imax] = p;
                }
            }

        }

        //delimo listu na 2 dela tako da su zbirovi frekvencija pojavljivanja sto priblizniji
        private void nadjiPozicije(out int poc,  out int kraj, int[] niz)
        {
            poc = 0;
            kraj = 1;

            int deo1 = niz[0];
            int deo2 = 0;

            for(int i = 0; i < niz.Count(); i++)
            {
                deo2 += niz[i];
            }
            int minDiff = Math.Abs(deo1 - deo2);

            for(int i=1;i<niz.Count() - 1; i++)
            {
                deo1 += niz[i];
                deo2 -= niz[i];

                if(Math.Abs(deo1-deo2) < minDiff)
                {
                    minDiff = Math.Abs(deo1 - deo2);
                    kraj = i + 1;
                }
            }
        }

        private BTree kreirajStablo(int poc, int kraj, int[] niz, double[] vrednosti, int brRazlicitih, StreamWriter sw)
        {
            BTree tree = new BTree();
            BNode left = null;
            BNode right = null;


            //ako je br.razlicitih el u nizu 1 vrednost na indeksu poc i postavlja se kao koren stabla
            tree.root = new BNode();
            if(brRazlicitih == 1)
            {
                tree.root = new BNode(vrednosti[poc]);
                return tree;
            }

            //ako je br el 2, kreiraju se levi i desni cvor stabla (desni s tezinom 1)
            if(brRazlicitih == 2)
            {
                tree.root.left = new BNode(vrednosti[poc]);
                tree.root.right = new BNode(vrednosti[kraj], 1);
                return tree;
            }
            tree.root.left = new BNode();
            tree.root.right = new BNode();
            tree.root.right.weight = 1;

            left = tree.root.left;

            //ako je true, postoji 1 el u podstablu 
            if(Math.Abs(poc - kraj) == 1)
            {
                left.left = new BNode(niz[poc]);
            }
            else
            {
                for (int i = poc; i < kraj - 1; i++)
                {

                    left.left = new BNode(vrednosti[i]);

                    //dosli smo do poslednjeg el u stablu
                    if ((i + 1) == (kraj - 1))
                    {
                        left.right = new BNode(vrednosti[i + 1], 1);
                    }
                    else
                    {
      
                        left.right = new BNode(1);
                        left = left.right;
                        //idemo ne sledeci nivo u stablu
                    }
                }
            }


            right = tree.root.right;
            if (Math.Abs(brRazlicitih - kraj) == 1)
            {
                right.left = new BNode(niz[kraj]);
            }
            else
            {
                for (int i = kraj; i < brRazlicitih - 1; i++)
                {

                    right.left = new BNode(vrednosti[i]);

                    if ((i + 1) == (brRazlicitih - 1))
                    {
                        right.right = new BNode(vrednosti[i + 1], 1);
                    }
                    else
                    {
                        right.right = new BNode(1);
                        right = right.right;
                    }
                }
            }

            int[] arr = new int [brRazlicitih];
            printCodes(tree.root, arr, 0,sw);
            return tree;
        }

        private void printCodes(BNode root, int[] niz, int top, StreamWriter sw)
        {
            //rekurzivno se primenjuje sve dok je br. el u podstablu veci od 2
            //levo 0, desno 1
            //dok ne iskoristimo sve cvorove 
            if (root.left != null)
            {
                niz[top] = 0;
                printCodes(root.left, niz, top + 1, sw);
            }

            if (root.right != null)
            {
                niz[top] = 1;
                printCodes(root.right, niz, top + 1,sw);
            }
            if (root.left == null && root.right == null)
            {
                sw.Write(root.info + " | ");
                int i;
                for (i = 0; i < top; ++i)
                    sw.Write(niz[i]);

                sw.WriteLine();
            }
        }

        //identifikujemo sve razlicite simbole
        public void identifikujRazlicite(int[] niz, double[] vrednosti, StreamWriter sw)
        {
            int brRazlicitih = 0;

            double[] vr = nizBajtova();

            foreach(double b in vrednosti)
            {
                double pom = Math.Abs(b);
                if (niz[Convert.ToInt32(pom)] == 0)
                    brRazlicitih++;
                niz[Convert.ToInt32(pom)]++;
            }

            //sortiranje u opadajucem redosledu po ucestalosti pojavljivanja
            Sortiraj(ref niz, ref vr);

            int[] frekvencija = new int[brRazlicitih];
            double[] vrednosti2 = new double[brRazlicitih];

            for (int i = 0; i < brRazlicitih; i++)
            {
                frekvencija[i] = niz[i];
                vrednosti2[i] = vr[i];
            }

      
            niz = frekvencija;
            vr = vrednosti2;

            int poc, kraj;
            nadjiPozicije(out poc, out kraj, niz);

            BTree tree = kreirajStablo(poc, kraj, niz, vr, brRazlicitih,sw);

        }

    }
}
