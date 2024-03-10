using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat2023
{
    public partial class Form1 : Form
    {
        private Filters filters;
        private Bitmap original;
        public Form1()
        {
            InitializeComponent();
            filters = new Filters();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (open.ShowDialog() == DialogResult.OK) {

                btnFilter.Enabled = true;
                pbImage.Image = new Bitmap(open.FileName);
                original = new Bitmap(pbImage.Image);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            btnFilter.Enabled = false;

            pbImage.SizeMode = PictureBoxSizeMode.AutoSize;
            groupBox1.AutoSize = true;
       
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (rbContrast.Checked)
            {
                Bitmap contrast = new Bitmap(pbImage.Image);
                filters.Contrast(contrast, 100);
                pbImage.Image = contrast;
            }
            else if (rbEdgeDetection.Checked)
            {
                Bitmap edgeDetection = new Bitmap(pbImage.Image);
                filters.ApplyEdgeDetection(ref edgeDetection);
                pbImage.Image = edgeDetection;
            }
            else if (rbSharpen.Checked)
            {
                Bitmap sharpen = new Bitmap(pbImage.Image);
                filters.Sharpen(sharpen, 11);
                pbImage.Image = sharpen;
            }
            else if (rbRandomJitter.Checked)
            {
                Bitmap randomJitter = new Bitmap(pbImage.Image);
                filters.RandomJitter(ref randomJitter, 10);
                pbImage.Image = randomJitter;
            }
            else if (rbOriginal.Checked)
            {
                pbImage.Image = original;
            }
        }

        private void saveDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Format format = new Format(new Bitmap(pbImage.Image));
                format.SaveImage(saveFileDialog1.FileName);
            }
        }

        private void openDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                Format open = new Format();
                Bitmap bmp = open.ReadImage(theDialog.FileName);
                pbImage.Image = bmp;
                original = bmp;
            }

        }

        private void withWithCompressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Format format = new Format(new Bitmap(pbImage.Image));
                format.SaveImageWithCompression(saveFileDialog1.FileName);
            }

        }

        private void rbPixelate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbOriginal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbGamma_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
