namespace AnnouncementsAddIn
	{
	partial class AnnouncementsControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
			{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnouncementsControl));
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.btnCreateAnnouncements = new System.Windows.Forms.Button();
			this.btnSaveAnnouncements = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnPrintAnnouncements = new System.Windows.Forms.Button();
			this.btnReminder = new System.Windows.Forms.Button();
			this.rtbReminder = new System.Windows.Forms.RichTextBox();
			this.btnSettings = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
			this.monthCalendar1.Location = new System.Drawing.Point(9, 9);
			this.monthCalendar1.MaxSelectionCount = 1;
			this.monthCalendar1.MinDate = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.ShowWeekNumbers = true;
			this.monthCalendar1.TabIndex = 0;
			this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
			// 
			// btnCreateAnnouncements
			// 
			this.btnCreateAnnouncements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCreateAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCreateAnnouncements.Location = new System.Drawing.Point(9, 268);
			this.btnCreateAnnouncements.Name = "btnCreateAnnouncements";
			this.btnCreateAnnouncements.Size = new System.Drawing.Size(249, 23);
			this.btnCreateAnnouncements.TabIndex = 2;
			this.btnCreateAnnouncements.Text = "Create Announcements";
			this.btnCreateAnnouncements.UseVisualStyleBackColor = true;
			this.btnCreateAnnouncements.Click += new System.EventHandler(this.btnCreateAnnouncements_Click);
			// 
			// btnSaveAnnouncements
			// 
			this.btnSaveAnnouncements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSaveAnnouncements.Location = new System.Drawing.Point(9, 297);
			this.btnSaveAnnouncements.Name = "btnSaveAnnouncements";
			this.btnSaveAnnouncements.Size = new System.Drawing.Size(249, 23);
			this.btnSaveAnnouncements.TabIndex = 3;
			this.btnSaveAnnouncements.Text = "Save Announcements";
			this.btnSaveAnnouncements.UseVisualStyleBackColor = true;
			this.btnSaveAnnouncements.Click += new System.EventHandler(this.btnSaveAnnouncements_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(9, 451);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(249, 217);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// btnPrintAnnouncements
			// 
			this.btnPrintAnnouncements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrintAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnPrintAnnouncements.Location = new System.Drawing.Point(9, 327);
			this.btnPrintAnnouncements.Name = "btnPrintAnnouncements";
			this.btnPrintAnnouncements.Size = new System.Drawing.Size(249, 23);
			this.btnPrintAnnouncements.TabIndex = 4;
			this.btnPrintAnnouncements.Text = "Print Announcements";
			this.btnPrintAnnouncements.UseVisualStyleBackColor = true;
			this.btnPrintAnnouncements.Click += new System.EventHandler(this.btnPrintAnnouncements_Click);
			// 
			// btnReminder
			// 
			this.btnReminder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReminder.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnReminder.Location = new System.Drawing.Point(9, 357);
			this.btnReminder.Name = "btnReminder";
			this.btnReminder.Size = new System.Drawing.Size(249, 23);
			this.btnReminder.TabIndex = 5;
			this.btnReminder.Text = "Add/Edit Reminder...";
			this.btnReminder.UseVisualStyleBackColor = true;
			this.btnReminder.Click += new System.EventHandler(this.btnReminder_Click);
			// 
			// rtbReminder
			// 
			this.rtbReminder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbReminder.DetectUrls = false;
			this.rtbReminder.Location = new System.Drawing.Point(9, 175);
			this.rtbReminder.Name = "rtbReminder";
			this.rtbReminder.ReadOnly = true;
			this.rtbReminder.Size = new System.Drawing.Size(249, 88);
			this.rtbReminder.TabIndex = 1;
			this.rtbReminder.Text = "";
			// 
			// btnSettings
			// 
			this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSettings.Location = new System.Drawing.Point(9, 671);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(48, 18);
			this.btnSettings.TabIndex = 9;
			this.btnSettings.Text = "Settings...";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(64, 672);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(194, 33);
			this.textBox1.TabIndex = 10;
			this.textBox1.Text = "Copyright 2014-2016 by Real World Software";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// AnnouncementsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.rtbReminder);
			this.Controls.Add(this.btnReminder);
			this.Controls.Add(this.btnPrintAnnouncements);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnSaveAnnouncements);
			this.Controls.Add(this.btnCreateAnnouncements);
			this.Controls.Add(this.monthCalendar1);
			this.Name = "AnnouncementsControl";
			this.Size = new System.Drawing.Size(266, 770);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.Button btnCreateAnnouncements;
		private System.Windows.Forms.Button btnSaveAnnouncements;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnPrintAnnouncements;
		private System.Windows.Forms.Button btnReminder;
		private System.Windows.Forms.RichTextBox rtbReminder;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.TextBox textBox1;
		}
	}
