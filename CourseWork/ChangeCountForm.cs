using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
	public partial class ChangeCountForm : Form
	{

		private Int64 count;
		public ChangeCountForm()
		{
			InitializeComponent();
			Count = 0;
		}

		public Int64 Count { get => count; set => count = value; }

		private void button1_Click(object sender, EventArgs e)
		{

			Count = Convert.ToInt32(changeCountTextBox.Text);
			this.DialogResult = DialogResult.OK;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Count = 0;
			this.DialogResult = DialogResult.Cancel;
		}

		private void changeCountTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (changeCountTextBox.Text.Length != 0)
					if (Convert.ToInt64(changeCountTextBox.Text) <= 0)
					{
						changeCountErrTextBox.Text = "Число должно быть > 0";
						applyButton.Enabled = false;
					}
					else
					{
						changeCountErrTextBox.Text = "";
						applyButton.Enabled = true;
					}
				else throw new FormatException();
			}
			catch (FormatException ex)
			{
				changeCountErrTextBox.Text = "Введите целое число";
				applyButton.Enabled = false;
			}
		}
	}
}
