namespace AnnouncementsAddIn
	{
	partial class SettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.label1 = new System.Windows.Forms.Label();
			this.txtTemplateFileName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtProgrammeFileName = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSavePath = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.ckCleaningBefore = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Template file name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtTemplateFileName
			// 
			this.txtTemplateFileName.Location = new System.Drawing.Point(148, 10);
			this.txtTemplateFileName.Name = "txtTemplateFileName";
			this.txtTemplateFileName.Size = new System.Drawing.Size(228, 20);
			this.txtTemplateFileName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(9, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(238, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "File name ONLY; do not include path information.";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(13, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "&Programme file name:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtProgrammeFileName
			// 
			this.txtProgrammeFileName.Location = new System.Drawing.Point(148, 54);
			this.txtProgrammeFileName.Name = "txtProgrammeFileName";
			this.txtProgrammeFileName.Size = new System.Drawing.Size(228, 20);
			this.txtProgrammeFileName.TabIndex = 4;
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(13, 83);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(363, 35);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "May be just a file name, or a file name with a relative or absolute path. A relat" +
    "ive path is relative to the folder in which the template file is located.";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(16, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(125, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "&Save path:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtSavePath
			// 
			this.txtSavePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtSavePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.txtSavePath.Location = new System.Drawing.Point(148, 133);
			this.txtSavePath.Name = "txtSavePath";
			this.txtSavePath.Size = new System.Drawing.Size(228, 20);
			this.txtSavePath.TabIndex = 7;
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Enabled = false;
			this.textBox3.Location = new System.Drawing.Point(12, 159);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(364, 17);
			this.textBox3.TabIndex = 8;
			this.textBox3.Text = "Determines where the document and PDF output files are saved.";
			// 
			// textBox4
			// 
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox4.Enabled = false;
			this.textBox4.Location = new System.Drawing.Point(12, 182);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(364, 56);
			this.textBox4.TabIndex = 9;
			this.textBox4.Text = resources.GetString("textBox4.Text");
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(220, 298);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(301, 298);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(187, 250);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(189, 33);
			this.label5.TabIndex = 11;
			this.label5.Text = "(Cleaning should be completed BEFORE the programme date)";
			// 
			// ckCleaningBefore
			// 
			this.ckCleaningBefore.AutoSize = true;
			this.ckCleaningBefore.Location = new System.Drawing.Point(12, 249);
			this.ckCleaningBefore.Name = "ckCleaningBefore";
			this.ckCleaningBefore.Size = new System.Drawing.Size(169, 17);
			this.ckCleaningBefore.TabIndex = 10;
			this.ckCleaningBefore.Text = "&Cleaning date is \'week ending\'";
			this.ckCleaningBefore.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(388, 333);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ckCleaningBefore);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtSavePath);
			this.Controls.Add(this.txtProgrammeFileName);
			this.Controls.Add(this.txtTemplateFileName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "AnnouncementsAddIn Settings";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTemplateFileName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtProgrammeFileName;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSavePath;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox ckCleaningBefore;
		}
	}