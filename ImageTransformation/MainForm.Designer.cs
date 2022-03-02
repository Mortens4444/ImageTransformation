namespace ImageTransformation
{
	partial class MainForm
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
            this.p_Main = new System.Windows.Forms.Panel();
            this.gb_Method = new System.Windows.Forms.GroupBox();
            this.lbl_Arrow = new System.Windows.Forms.Label();
            this.lbl_FromTo = new System.Windows.Forms.Label();
            this.p_Replaced = new System.Windows.Forms.Panel();
            this.p_To = new System.Windows.Forms.Panel();
            this.p_From = new System.Windows.Forms.Panel();
            this.rb_ColorReplace = new System.Windows.Forms.RadioButton();
            this.rb_FilterMatrixTransform = new System.Windows.Forms.RadioButton();
            this.nud_BlockSize = new System.Windows.Forms.NumericUpDown();
            this.rb_BlockTransform = new System.Windows.Forms.RadioButton();
            this.rb_ImageTransformMethod = new System.Windows.Forms.RadioButton();
            this.rb_ColorTransformMethod = new System.Windows.Forms.RadioButton();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.cb_Method = new System.Windows.Forms.ComboBox();
            this.pb_Transformed = new System.Windows.Forms.PictureBox();
            this.pb_Original = new System.Windows.Forms.PictureBox();
            this.ofd_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.sfd_SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.cd_ColorDialog = new System.Windows.Forms.ColorDialog();
            this.p_Main.SuspendLayout();
            this.gb_Method.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Transformed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Original)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Main
            // 
            this.p_Main.Controls.Add(this.gb_Method);
            this.p_Main.Controls.Add(this.btn_Save);
            this.p_Main.Controls.Add(this.btn_Browse);
            this.p_Main.Controls.Add(this.cb_Method);
            this.p_Main.Controls.Add(this.pb_Transformed);
            this.p_Main.Controls.Add(this.pb_Original);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 0);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(761, 570);
            this.p_Main.TabIndex = 0;
            // 
            // gb_Method
            // 
            this.gb_Method.BackColor = System.Drawing.SystemColors.Control;
            this.gb_Method.Controls.Add(this.lbl_Arrow);
            this.gb_Method.Controls.Add(this.lbl_FromTo);
            this.gb_Method.Controls.Add(this.p_Replaced);
            this.gb_Method.Controls.Add(this.p_To);
            this.gb_Method.Controls.Add(this.p_From);
            this.gb_Method.Controls.Add(this.rb_ColorReplace);
            this.gb_Method.Controls.Add(this.rb_FilterMatrixTransform);
            this.gb_Method.Controls.Add(this.nud_BlockSize);
            this.gb_Method.Controls.Add(this.rb_BlockTransform);
            this.gb_Method.Controls.Add(this.rb_ImageTransformMethod);
            this.gb_Method.Controls.Add(this.rb_ColorTransformMethod);
            this.gb_Method.Location = new System.Drawing.Point(0, 0);
            this.gb_Method.Name = "gb_Method";
            this.gb_Method.Size = new System.Drawing.Size(156, 169);
            this.gb_Method.TabIndex = 5;
            this.gb_Method.TabStop = false;
            this.gb_Method.Text = "Method";
            // 
            // lbl_Arrow
            // 
            this.lbl_Arrow.AutoSize = true;
            this.lbl_Arrow.Location = new System.Drawing.Point(87, 142);
            this.lbl_Arrow.Name = "lbl_Arrow";
            this.lbl_Arrow.Size = new System.Drawing.Size(16, 13);
            this.lbl_Arrow.TabIndex = 9;
            this.lbl_Arrow.Text = "->";
            // 
            // lbl_FromTo
            // 
            this.lbl_FromTo.AutoSize = true;
            this.lbl_FromTo.Location = new System.Drawing.Point(39, 142);
            this.lbl_FromTo.Name = "lbl_FromTo";
            this.lbl_FromTo.Size = new System.Drawing.Size(10, 13);
            this.lbl_FromTo.TabIndex = 8;
            this.lbl_FromTo.Text = "-";
            // 
            // p_Replaced
            // 
            this.p_Replaced.BackColor = System.Drawing.Color.White;
            this.p_Replaced.Location = new System.Drawing.Point(108, 136);
            this.p_Replaced.Name = "p_Replaced";
            this.p_Replaced.Size = new System.Drawing.Size(29, 26);
            this.p_Replaced.TabIndex = 7;
            this.p_Replaced.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseColor);
            // 
            // p_To
            // 
            this.p_To.BackColor = System.Drawing.Color.Black;
            this.p_To.Location = new System.Drawing.Point(52, 136);
            this.p_To.Name = "p_To";
            this.p_To.Size = new System.Drawing.Size(29, 26);
            this.p_To.TabIndex = 7;
            this.p_To.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseColor);
            // 
            // p_From
            // 
            this.p_From.BackColor = System.Drawing.Color.DarkBlue;
            this.p_From.Location = new System.Drawing.Point(7, 135);
            this.p_From.Name = "p_From";
            this.p_From.Size = new System.Drawing.Size(29, 26);
            this.p_From.TabIndex = 6;
            this.p_From.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseColor);
            // 
            // rb_ColorReplace
            // 
            this.rb_ColorReplace.AutoSize = true;
            this.rb_ColorReplace.Location = new System.Drawing.Point(6, 111);
            this.rb_ColorReplace.Name = "rb_ColorReplace";
            this.rb_ColorReplace.Size = new System.Drawing.Size(87, 17);
            this.rb_ColorReplace.TabIndex = 5;
            this.rb_ColorReplace.Text = "Color replace";
            this.rb_ColorReplace.UseVisualStyleBackColor = true;
            // 
            // rb_FilterMatrixTransform
            // 
            this.rb_FilterMatrixTransform.AutoSize = true;
            this.rb_FilterMatrixTransform.Location = new System.Drawing.Point(6, 88);
            this.rb_FilterMatrixTransform.Name = "rb_FilterMatrixTransform";
            this.rb_FilterMatrixTransform.Size = new System.Drawing.Size(122, 17);
            this.rb_FilterMatrixTransform.TabIndex = 4;
            this.rb_FilterMatrixTransform.Text = "FilterMatrixTransform";
            this.rb_FilterMatrixTransform.UseVisualStyleBackColor = true;
            this.rb_FilterMatrixTransform.CheckedChanged += new System.EventHandler(this.rb_FilterMatrixTransform_CheckedChanged);
            // 
            // nud_BlockSize
            // 
            this.nud_BlockSize.Location = new System.Drawing.Point(108, 62);
            this.nud_BlockSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_BlockSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_BlockSize.Name = "nud_BlockSize";
            this.nud_BlockSize.Size = new System.Drawing.Size(42, 20);
            this.nud_BlockSize.TabIndex = 3;
            this.nud_BlockSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_BlockSize.ValueChanged += new System.EventHandler(this.SetTransformedImage);
            // 
            // rb_BlockTransform
            // 
            this.rb_BlockTransform.AutoSize = true;
            this.rb_BlockTransform.Location = new System.Drawing.Point(6, 65);
            this.rb_BlockTransform.Name = "rb_BlockTransform";
            this.rb_BlockTransform.Size = new System.Drawing.Size(99, 17);
            this.rb_BlockTransform.TabIndex = 2;
            this.rb_BlockTransform.Text = "BlockTransform";
            this.rb_BlockTransform.UseVisualStyleBackColor = true;
            this.rb_BlockTransform.CheckedChanged += new System.EventHandler(this.rb_BlockTransform_CheckedChanged);
            // 
            // rb_ImageTransformMethod
            // 
            this.rb_ImageTransformMethod.AutoSize = true;
            this.rb_ImageTransformMethod.Location = new System.Drawing.Point(6, 42);
            this.rb_ImageTransformMethod.Name = "rb_ImageTransformMethod";
            this.rb_ImageTransformMethod.Size = new System.Drawing.Size(137, 17);
            this.rb_ImageTransformMethod.TabIndex = 1;
            this.rb_ImageTransformMethod.Text = "ImageTransformMethod";
            this.rb_ImageTransformMethod.UseVisualStyleBackColor = true;
            this.rb_ImageTransformMethod.CheckedChanged += new System.EventHandler(this.rb_ImageTransformMethod_CheckedChanged);
            // 
            // rb_ColorTransformMethod
            // 
            this.rb_ColorTransformMethod.AutoSize = true;
            this.rb_ColorTransformMethod.Location = new System.Drawing.Point(6, 19);
            this.rb_ColorTransformMethod.Name = "rb_ColorTransformMethod";
            this.rb_ColorTransformMethod.Size = new System.Drawing.Size(132, 17);
            this.rb_ColorTransformMethod.TabIndex = 0;
            this.rb_ColorTransformMethod.Text = "ColorTransformMethod";
            this.rb_ColorTransformMethod.UseVisualStyleBackColor = true;
            this.rb_ColorTransformMethod.CheckedChanged += new System.EventHandler(this.rb_ColorTransformMethod_CheckedChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Save.Location = new System.Drawing.Point(84, 199);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Browse.Location = new System.Drawing.Point(3, 199);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 3;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // cb_Method
            // 
            this.cb_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Method.FormattingEnabled = true;
            this.cb_Method.Location = new System.Drawing.Point(3, 175);
            this.cb_Method.Name = "cb_Method";
            this.cb_Method.Size = new System.Drawing.Size(156, 21);
            this.cb_Method.TabIndex = 2;
            this.cb_Method.SelectedIndexChanged += new System.EventHandler(this.SetTransformedImage);
            // 
            // pb_Transformed
            // 
            this.pb_Transformed.BackColor = System.Drawing.SystemColors.Control;
            this.pb_Transformed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Transformed.Location = new System.Drawing.Point(0, 0);
            this.pb_Transformed.Name = "pb_Transformed";
            this.pb_Transformed.Size = new System.Drawing.Size(761, 570);
            this.pb_Transformed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Transformed.TabIndex = 1;
            this.pb_Transformed.TabStop = false;
            // 
            // pb_Original
            // 
            this.pb_Original.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Original.Location = new System.Drawing.Point(0, 0);
            this.pb_Original.Name = "pb_Original";
            this.pb_Original.Size = new System.Drawing.Size(761, 570);
            this.pb_Original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Original.TabIndex = 0;
            this.pb_Original.TabStop = false;
            this.pb_Original.Visible = false;
            // 
            // ofd_OpenFile
            // 
            this.ofd_OpenFile.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(761, 570);
            this.Controls.Add(this.p_Main);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image transformation";
            this.TransparencyKey = System.Drawing.Color.LightPink;
            this.p_Main.ResumeLayout(false);
            this.gb_Method.ResumeLayout(false);
            this.gb_Method.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Transformed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Original)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.PictureBox pb_Original;
		private System.Windows.Forms.PictureBox pb_Transformed;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.Button btn_Browse;
		private System.Windows.Forms.ComboBox cb_Method;
		private System.Windows.Forms.OpenFileDialog ofd_OpenFile;
		private System.Windows.Forms.SaveFileDialog sfd_SaveFile;
		private System.Windows.Forms.GroupBox gb_Method;
        private System.Windows.Forms.RadioButton rb_ImageTransformMethod;
        private System.Windows.Forms.RadioButton rb_ColorTransformMethod;
		private System.Windows.Forms.RadioButton rb_BlockTransform;
		private System.Windows.Forms.NumericUpDown nud_BlockSize;
		private System.Windows.Forms.RadioButton rb_FilterMatrixTransform;
        private System.Windows.Forms.Label lbl_Arrow;
		private System.Windows.Forms.Label lbl_FromTo;
		private System.Windows.Forms.Panel p_Replaced;
		private System.Windows.Forms.Panel p_To;
		private System.Windows.Forms.Panel p_From;
		private System.Windows.Forms.RadioButton rb_ColorReplace;
		private System.Windows.Forms.ColorDialog cd_ColorDialog;
	}
}
