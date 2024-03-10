using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2023
{
    public class Format
    {
        int w;
        int h;
        Bitmap bitmap;
        Shannon_Fano sf;
        byte[,] r;
        byte[,] g;
        byte[,] b;

        double[,] y;
        double[,] u;
        double[,] v;


        public Format() { 
            
        }
        public Format(Bitmap bmp)
        {
            bitmap = bmp;
            sf = new Shannon_Fano();
            w = bmp.Width;
            h = bmp.Height;

            r = new byte[bitmap.Width, bitmap.Height];
            g = new byte[bitmap.Width, bitmap.Height];
            b = new byte[bitmap.Width, bitmap.Height];

            y = new double[bitmap.Width, bitmap.Height];
            u = new double[bitmap.Width, bitmap.Height];
            v = new double[bitmap.Width, bitmap.Height];
        }

        private void RGB()
        {

            for (int y = 0; y < w; y++)
            {
                for (int x = 0; x < h; x++)
                {
                    //uzima vrednost boje pixela u ovoj koordinati
                    Color c = bitmap.GetPixel(y, x);
                    r[y, x] = c.R;
                    g[y, x] = c.G;
                    b[y, x] = c.B;
                }
            }

        }

        private Bitmap setPixel()
        {
            for (int y = 0; y < w; y++)
            {
                for (int x = 0; x < h; x++)
                {
                    Color c = new Color();
                    c = Color.FromArgb(r[y, x], g[y, x], b[y, x]);
                    bitmap.SetPixel(y, x, c);
                    //koordinate pixela i boja koja se postavlja tom pixelu
               
                }
            }

            return bitmap;
        }

        private void RgbToYuv()
        {

            for (int z = 0; z < w; z++)
            {
                for (int x = 0; x < h; x++)
                {
          
                    y[z, x] = r[z,x] * 0.299 + g[z,x] * 0.587+ b[z,x] * 0.114;
                    u[z, x] = (-0.147)*r[z, x] - g[z, x] *0.289 + b[z, x] * 0.436;
                    v[z, x] = r[z, x] * 0.615 - g[z, x] *0.515 - b[z, x] * 0.100;
                }
            }
        }

        private void YuvToRgb() {

            for (int z = 0; z < w; z++)
            {
                for (int x = 0; x < h; x++)
                {
                    if (z < y.GetLength(0) && x < y.GetLength(1) && z < u.GetLength(0) && x < u.GetLength(1) && z < v.GetLength(0) && x < v.GetLength(1))
                    {
                        r[z, x] = (byte)(y[z, x] + 1.140 * v[z, x]);
                        g[z, x] = (byte)(y[z, x] - 0.395 * (u[z, x]) - (0.581 * v[z, x]));
                        b[z, x] = (byte)(y[z, x] + 2.032 * u[z, x]);
                    }
                }
            }

        }

        //Primena downsampling-a na U i V kanal po slici, dok Y ostaje isti
        private double[,] Downsampling(double[,] matrix)
        {
            double[,] rez = new double[w, h ];
            int x = 0;
            int y = 0;

            for (int i = 0; i < w; i++)
            {
                y = 0;
                for (int j = 0; j < h-1 ; j+=2)
                {
                    rez[x, y] = matrix[i, j];
                    rez[x, y+1] = matrix[i, j];
                    

                    y += 2;
                }
                x += 1;
            }

            return rez;

        }

        //Postavljanje vrednosti U i V kanala
        private double[,] loadValues(double[,] matrix)
        {

            double[,] rez = new double[w, h];
            int x = 0;
            int y = 0;

            for (int i = 0; i < w/2; i++)
            {
                y = 0;
                for (int j = 0; j < h/2; j++)
                {
                    rez[x,y] = matrix[i, j];
                    rez[x, y+1] = matrix[i, j];

                    y += 2;
                }
                x += 1;
            }

            return rez;
        }




        public void SaveImage(string fajl)
        {
            this.RGB();
            this.RgbToYuv();
            double[,] uD = this.Downsampling(u);
            double[,] vD = this.Downsampling(v);

            using (FileStream fs = File.Open(fajl, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(w + " " + h);

                    for (int i = 0; i < bitmap.Width; i++)
                    {
                        string line = "";
                        for (int j = 0; j < bitmap.Height; j++)
                        {
                            line += y[i, j];
                            line += " ";
                        }
                        sw.WriteLine(line);
                    }
                    for (int i = 0; i < bitmap.Width / 2; i++)
                    {
                        string line = "";
                        for (int j = 0; j < bitmap.Height/2 ; j++)
                        {
                            line += uD[i, j];
                            line += " ";
                        }
                        sw.WriteLine(line);
                    }

                    for (int i = 0; i < bitmap.Width / 2; i++)
                    {
                        string line = "";
                        for (int j = 0; j < bitmap.Height/2 ; j++)
                        {
                            line += vD[i, j];
                            line += " ";
                        }
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
                fs.Close();
            }

        }

        public void SaveImageWithCompression(string fajl)
        {
            this.RGB();
            this.RgbToYuv();
            double[,] uD = this.Downsampling(u);
            double[,] vD = this.Downsampling(v);

            int[] niz = new int[256];
            double[] yF = new double[h];
            double[] uF = new double[h/2];
            double[] vF = new double[h/2];
            using (FileStream fs = File.Open(fajl, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int j = 0; j < w; j++)
                    {
                        for (int k = 0; k < 256; k++)
                        {
                            niz[k] = 0;
                        }

                        for (int i = 0; i < h; i++)
                            yF[i] = y[j, i];

                        sf.identifikujRazlicite(niz, yF, sw);
                    }

                    for (int j = 0; j < w/2; j++)
                    {
                        for (int k = 0; k < 256; k++)
                        {
                            niz[k] = 0;
                        }

                        for (int i = 0; i < h/2; i++)
                            uF[i] = uD[j, i];

                        sf.identifikujRazlicite(niz, uF, sw);
                    }

                    for (int j = 0; j < w / 2; j++)
                    {
                        for (int k = 0; k < 256; k++)
                        {
                            niz[k] = 0;
                        }

                        for (int i = 0; i < h / 2; i++)
                            vF[i] = vD[j, i];

                        sf.identifikujRazlicite(niz, vF, sw);
                    }
                    sw.Close();
                }

                fs.Close();
            }
            
            
        }

        //Učitavanje vrednosti iz fajla
        public Bitmap ReadImage(string fajl)
        {
            StreamReader sr = new StreamReader(fajl);
            string dim = sr.ReadLine();
            string[] hw = dim.Split(' ');
            this.w = Convert.ToInt32(hw[0]);
            this.h = Convert.ToInt32(hw[1]);

            r = new byte[this.w, this.h];
            g = new byte[this.w, this.h];
            b = new byte[this.w, this.h];

            y = new double[this.w, this.h];
            u = new double[this.w, this.h];
            v = new double[this.w, this.h];

            double[,] uD = new double[w /2, h/2]; 
            double[,] vD = new double[w /2, h /2];

            bitmap = new Bitmap(w,h);

            for (int i = 0; i < w; i++)
            {
                string line = sr.ReadLine();
                string[] mat = line.Split(' ');
                for (int j = 0; j < h; j++)
                {
                    y[i, j] = Convert.ToDouble(mat[j]);
                }
                
            }

            for (int i = 0; i < w / 2; i++)
            {
                string line = sr.ReadLine();
                string[] mat = line.Split(' ');

                for (int j = 0; j < h / 2; j++)
                {
                    uD[i, j] = Convert.ToDouble(mat[j]);
                }
             
            }
            for (int i = 0; i < w/ 2; i++)
            {
                string line = sr.ReadLine();
                string[] mat = line.Split(' ');

                for (int j = 0; j < h / 2; j++)
                {
                    vD[i, j] = Convert.ToDouble(mat[j]);
                }

            }
            sr.Close();
            u = loadValues(uD);
            v = loadValues(vD);
            YuvToRgb();

            bitmap = setPixel();
            return bitmap;

        }
    }
}
