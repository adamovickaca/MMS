
namespace Projekat2023
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withWithCompressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.rbOriginal = new System.Windows.Forms.RadioButton();
            this.rbRandomJitter = new System.Windows.Forms.RadioButton();
            this.btnFilter = new System.Windows.Forms.Button();
            this.rbEdgeDetection = new System.Windows.Forms.RadioButton();
            this.rbSharpen = new System.Windows.Forms.RadioButton();
            this.rbContrast = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.gbFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openDToolStripMenuItem,
            this.saveDToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // openDToolStripMenuItem
            // 
            this.openDToolStripMenuItem.Name = "openDToolStripMenuItem";
            this.openDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.openDToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.openDToolStripMenuItem.Text = "OpenD";
            this.openDToolStripMenuItem.Click += new System.EventHandler(this.openDToolStripMenuItem_Click);
            // 
            // saveDToolStripMenuItem
            // 
            this.saveDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withWithCompressionToolStripMenuItem});
            this.saveDToolStripMenuItem.Name = "saveDToolStripMenuItem";
            this.saveDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.saveDToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.saveDToolStripMenuItem.Text = "SaveD";
            this.saveDToolStripMenuItem.Click += new System.EventHandler(this.saveDToolStripMenuItem_Click);
            // 
            // withWithCompressionToolStripMenuItem
            // 
            this.withWithCompressionToolStripMenuItem.Name = "withWithCompressionToolStripMenuItem";
            this.withWithCompressionToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.withWithCompressionToolStripMenuItem.Text = "With compression";
            this.withWithCompressionToolStripMenuItem.Click += new System.EventHandler(this.withWithCompressionToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(12, 123);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(839, 284);
            this.pbImage.TabIndex = 2;
            this.pbImage.TabStop = false;
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.rbOriginal);
            this.gbFilters.Controls.Add(this.rbRandomJitter);
            this.gbFilters.Controls.Add(this.btnFilter);
            this.gbFilters.Controls.Add(this.rbEdgeDetection);
            this.gbFilters.Controls.Add(this.rbSharpen);
            this.gbFilters.Controls.Add(this.rbContrast);
            this.gbFilters.Location = new System.Drawing.Point(12, 21);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(839, 100);
            this.gbFilters.TabIndex = 3;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filters";
            // 
            // rbOriginal
            // 
            this.rbOriginal.AutoSize = true;
            this.rbOriginal.Location = new System.Drawing.Point(590, 40);
            this.rbOriginal.Name = "rbOriginal";
            this.rbOriginal.Size = new System.Drawing.Size(78, 21);
            this.rbOriginal.TabIndex = 5;
            this.rbOriginal.TabStop = true;
            this.rbOriginal.Text = "Original";
            this.rbOriginal.UseVisualStyleBackColor = true;
            this.rbOriginal.CheckedChanged += new System.EventHandler(this.rbOriginal_CheckedChanged);
            // 
            // rbRandomJitter
            // 
            this.rbRandomJitter.AutoSize = true;
            this.rbRandomJitter.Location = new System.Drawing.Point(444, 40);
            this.rbRandomJitter.Name = "rbRandomJitter";
            this.rbRandomJitter.Size = new System.Drawing.Size(113, 21);
            this.rbRandomJitter.TabIndex = 3;
            this.rbRandomJitter.TabStop = true;
            this.rbRandomJitter.Text = "RandomJitter";
            this.rbRandomJitter.UseVisualStyleBackColor = true;
            this.rbRandomJitter.CheckedChanged += new System.EventHandler(this.rbPixelate_CheckedChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(699, 26);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(134, 49);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Apply Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // rbEdgeDetection
            // 
            this.rbEdgeDetection.AutoSize = true;
            this.rbEdgeDetection.Location = new System.Drawing.Point(282, 40);
            this.rbEdgeDetection.Name = "rbEdgeDetection";
            this.rbEdgeDetection.Size = new System.Drawing.Size(122, 21);
            this.rbEdgeDetection.TabIndex = 2;
            this.rbEdgeDetection.TabStop = true;
            this.rbEdgeDetection.Text = "EdgeDetection";
            this.rbEdgeDetection.UseVisualStyleBackColor = true;
            // 
            // rbSharpen
            // 
            this.rbSharpen.AutoSize = true;
            this.rbSharpen.Location = new System.Drawing.Point(148, 40);
            this.rbSharpen.Name = "rbSharpen";
            this.rbSharpen.Size = new System.Drawing.Size(83, 21);
            this.rbSharpen.TabIndex = 1;
            this.rbSharpen.TabStop = true;
            this.rbSharpen.Text = "Sharpen";
            this.rbSharpen.UseVisualStyleBackColor = true;
            // 
            // rbContrast
            // 
            this.rbContrast.AutoSize = true;
            this.rbContrast.Location = new System.Drawing.Point(23, 40);
            this.rbContrast.Name = "rbContrast";
            this.rbContrast.Size = new System.Drawing.Size(82, 21);
            this.rbContrast.TabIndex = 0;
            this.rbContrast.TabStop = true;
            this.rbContrast.Text = "Contrast";
            this.rbContrast.UseVisualStyleBackColor = true;
            this.rbContrast.CheckedChanged += new System.EventHandler(this.rbGamma_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbFilters);
            this.groupBox1.Controls.Add(this.pbImage);
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 421);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.RadioButton rbRandomJitter;
        private System.Windows.Forms.RadioButton rbEdgeDetection;
        private System.Windows.Forms.RadioButton rbSharpen;
        private System.Windows.Forms.RadioButton rbContrast;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem openDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withWithCompressionToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbOriginal;
    }
}

