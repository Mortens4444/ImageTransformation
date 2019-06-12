using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ImageTransformation.TransformMethods;

namespace ImageTransformation
{
	public partial class MainForm : Form
	{
		private readonly TransformatedImageFactory transformatorFactory;

		public MainForm()
		{
			transformatorFactory = new TransformatedImageFactory();
			InitializeComponent();
            rb_ColorTransformMethod.Checked = true;
            TransparencyKey = Color.Silver;
		}

		void btn_Browse_Click(object sender, EventArgs e)
		{
            if (ofd_OpenFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

			pb_Original.Image = Image.FromFile(ofd_OpenFile.FileName);

			SetTransformedImage();
		}

		void btn_Save_Click(object sender, EventArgs e)
		{
            if (sfd_SaveFile.ShowDialog() == DialogResult.OK && pb_Transformed.Image != null)
            {
                pb_Transformed.Image.Save(sfd_SaveFile.FileName);
            }
		}

        void rb_ColorTransformMethod_CheckedChanged(object sender, EventArgs e)
        {
	        if (((RadioButton)sender).Checked)
	        {
		        GetTransformItems(typeof (ColorTransformMethod));
	        }
        }

        void rb_ImageTransformMethod_CheckedChanged(object sender, EventArgs e)
        {
	        if (((RadioButton)sender).Checked)
	        {
		        GetTransformItems(typeof (ImageTransformMethod));
	        }
        }

        void rb_FilterMatrixTransform_CheckedChanged(object sender, EventArgs e)
        {
	        if (((RadioButton)sender).Checked)
	        {
		        GetTransformItems(typeof (FilterMatrixTransformMethod));
	        }
        }

        void GetTransformItems(Type type)
        {
            nud_BlockSize.Enabled = false;
            GetItems(cb_Method, type);
        }

        void rb_BlockTransform_CheckedChanged(object sender, EventArgs e)
		{
			nud_BlockSize.Enabled = true;
			ClearComboBox(cb_Method);
            SetTransformedImage();
		}

        void SetTransformedImage(object sender, EventArgs e)
        {
            SetTransformedImage();
        }

        void SetTransformedImage()
        {
            pb_Transformed.Image = GetTransformedImage();
        }

		static void ClearComboBox(ComboBox cb)
		{
            cb.Enabled = false;
			cb.DataSource = null;
			cb.Text = String.Empty;
			cb.Items.Clear();
		}

		void ChooseColor(object sender, MouseEventArgs e)
		{
            if (cd_ColorDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
			
			((Control)sender).BackColor = cd_ColorDialog.Color;
            SetTransformedImage();
		}

        static void GetItems(ComboBox cb, Type enumType)
        {
            cb.Enabled = true;
            if (!enumType.IsEnum)
            {
                throw new InvalidEnumArgumentException();
            }
            cb.DataSource = Enum.GetValues(enumType);
            cb.SelectedIndex = 0;
        }

        Image GetTransformedImage()
        {
			if (pb_Original.Image == null)
			{
				return null;
			}

            if (rb_ColorTransformMethod.Checked)
            {
                var colorTransformMethod = (ColorTransformMethod)cb_Method.SelectedIndex;
				return transformatorFactory.Get(colorTransformMethod, (Image)pb_Original.Image.Clone());
            }
            
			if (rb_ImageTransformMethod.Checked)
            {
                var imageTransformMethod = (ImageTransformMethod)cb_Method.SelectedIndex;
				return transformatorFactory.Get(imageTransformMethod, (Image)pb_Original.Image.Clone());
            }

			if (rb_ColorReplace.Checked)
            {
				return transformatorFactory.Get((Image)pb_Original.Image.Clone(), p_From.BackColor, p_To.BackColor, p_Replaced.BackColor);
            }
            
			if (rb_BlockTransform.Checked)
            {
				return transformatorFactory.Get((Image)pb_Original.Image.Clone(), (int)nud_BlockSize.Value);
            }
            
			if (rb_FilterMatrixTransform.Checked)
			{
				if (cb_Method.SelectedIndex == -1)
				{
					return (Image)pb_Original.Image.Clone();
				}

				return transformatorFactory.Get((Image)pb_Original.Image.Clone(), (FilterMatrixTransformMethod)cb_Method.SelectedIndex);
            }

	        throw new NotImplementedException();
        }
	}
}
