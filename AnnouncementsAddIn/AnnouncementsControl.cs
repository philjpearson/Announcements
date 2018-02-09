//
//	Last mod:	03 March 2016 11:56:57
//
using System;
using System.Windows.Forms;

namespace AnnouncementsAddIn
	{
	public partial class AnnouncementsControl : UserControl
		{
		public class AnnouncementsDateEventArgs : System.EventArgs
			{
			public DateTime Date;

			public AnnouncementsDateEventArgs(DateTime dt)
				{
				Date = dt;
				}
			}

		public delegate void AnnouncementsReminderHandler(object sender, AnnouncementsDateEventArgs e);
		public delegate void CreateAnnouncementsHandler(object sender, AnnouncementsDateEventArgs e);
		public delegate void DateSelectedHandler(object sender, AnnouncementsDateEventArgs e);

		public event AnnouncementsReminderHandler AddEditReminder;
		public event CreateAnnouncementsHandler CreateAnnouncements;
		public event DateSelectedHandler DateSelected;
		public event System.EventHandler PrintAnnouncements;
		public event System.EventHandler SaveAnnouncements;

		private bool created;

		public string ReminderText
			{
			get { return rtbReminder.Text; }
			set
				{
				if (value.StartsWith(@"{\rtf"))
					{
					rtbReminder.Rtf = value;
					}
				else
					{
					rtbReminder.Text = value;
					}
				}
			}

		public string ReminderRtf
			{
			get { return rtbReminder.Rtf; }
			}

		public AnnouncementsControl()
			{
			InitializeComponent();
			EnableCreateButton(false);
			DateTime dt = DateTime.Now;
			while (dt.DayOfWeek != DayOfWeek.Sunday)
				{
				dt = dt.AddDays(1);
				}
			monthCalendar1.SelectionRange = new SelectionRange(dt, dt);
			}

		internal void EnableCreateButton(bool enable)
			{
			btnCreateAnnouncements.Enabled = enable;
			}

		private void btnCreateAnnouncements_Click(object sender, EventArgs e)
			{
			CreateAnnouncements(this, new AnnouncementsDateEventArgs(monthCalendar1.SelectionStart));
			created = true;
			}

		private void btnSaveAnnouncements_Click(object sender, EventArgs e)
			{
			SaveAnnouncements(this, EventArgs.Empty);
			}

		private void btnPrintAnnouncements_Click(object sender, EventArgs e)
			{
			PrintAnnouncements(this, EventArgs.Empty);
			}

		private void btnReminder_Click(object sender, EventArgs e)
			{
			if (AddEditReminder != null)
				AddEditReminder(this, new AnnouncementsDateEventArgs(monthCalendar1.SelectionStart));
			}

		private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
			{
			if (DateSelected != null)
				DateSelected(this, new AnnouncementsDateEventArgs(monthCalendar1.SelectionStart));
			}

		private void btnSettings_Click(object sender, EventArgs e)
			{
			if (SettingsForm.EditSettings() && created)
				btnCreateAnnouncements.PerformClick();
			}
		}
	}
