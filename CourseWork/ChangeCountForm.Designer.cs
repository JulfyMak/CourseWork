
namespace CourseWork
{
	partial class ChangeCountForm
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
			this.changeCountLabel = new System.Windows.Forms.Label();
			this.changeCountTextBox = new System.Windows.Forms.TextBox();
			this.applyButton = new System.Windows.Forms.Button();
			this.cancelingButton = new System.Windows.Forms.Button();
			this.changeCountErrTextBox = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// changeCountLabel
			// 
			this.changeCountLabel.AutoSize = true;
			this.changeCountLabel.Location = new System.Drawing.Point(12, 9);
			this.changeCountLabel.Name = "changeCountLabel";
			this.changeCountLabel.Size = new System.Drawing.Size(220, 17);
			this.changeCountLabel.TabIndex = 0;
			this.changeCountLabel.Text = "Введите значение для досчета:";
			// 
			// changeCountTextBox
			// 
			this.changeCountTextBox.Location = new System.Drawing.Point(15, 49);
			this.changeCountTextBox.Name = "changeCountTextBox";
			this.changeCountTextBox.Size = new System.Drawing.Size(100, 22);
			this.changeCountTextBox.TabIndex = 1;
			this.changeCountTextBox.Text = "10000";
			this.changeCountTextBox.TextChanged += new System.EventHandler(this.changeCountTextBox_TextChanged);
			// 
			// applyButton
			// 
			this.applyButton.Location = new System.Drawing.Point(12, 98);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(150, 30);
			this.applyButton.TabIndex = 2;
			this.applyButton.Text = "Применить";
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// cancelingButton
			// 
			this.cancelingButton.Location = new System.Drawing.Point(169, 98);
			this.cancelingButton.Name = "cancelingButton";
			this.cancelingButton.Size = new System.Drawing.Size(150, 30);
			this.cancelingButton.TabIndex = 3;
			this.cancelingButton.Text = "Отмена";
			this.cancelingButton.UseVisualStyleBackColor = true;
			this.cancelingButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// changeCountErrTextBox
			// 
			this.changeCountErrTextBox.AutoSize = true;
			this.changeCountErrTextBox.Location = new System.Drawing.Point(121, 52);
			this.changeCountErrTextBox.Name = "changeCountErrTextBox";
			this.changeCountErrTextBox.Size = new System.Drawing.Size(0, 17);
			this.changeCountErrTextBox.TabIndex = 4;
			// 
			// ChangeCountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 133);
			this.Controls.Add(this.changeCountErrTextBox);
			this.Controls.Add(this.cancelingButton);
			this.Controls.Add(this.applyButton);
			this.Controls.Add(this.changeCountTextBox);
			this.Controls.Add(this.changeCountLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ChangeCountForm";
			this.Text = "Change count";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label changeCountLabel;
		private System.Windows.Forms.TextBox changeCountTextBox;
		private System.Windows.Forms.Button applyButton;
		private System.Windows.Forms.Button cancelingButton;
		private System.Windows.Forms.Label changeCountErrTextBox;
	}
}