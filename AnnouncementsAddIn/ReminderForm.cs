using System;
using System.Windows.Forms;

namespace AnnouncementsAddIn
	{
	public partial class ReminderForm : Form
		{
		public ReminderForm()
			{
			InitializeComponent();
			}

		public static bool EditReminder(DateTime Date, ref string Reminder)
			{
			ReminderForm f = new ReminderForm();
			f.lblDate.Text = Date.ToLongDateString();
			if (Reminder.StartsWith(@"{\rtf"))
				{
				f.rtbReminder.Rtf = Reminder;
				}
			else
				{
				f.rtbReminder.Text = Reminder;
				}
			bool ret = f.ShowDialog() == DialogResult.OK;
			if (ret)
				{
				Reminder = f.rtbReminder.Rtf;
				}
			return ret;
			}

		private void rtbReminder_KeyPress(object sender, KeyPressEventArgs e)
			{
			if (e.KeyChar == '\t')
				{
				FocusNextControl(this, ActiveControl, e);
				}
			}

		private void FocusNextControl(Control container, Control activeControl, KeyPressEventArgs e)
			{
			try
				{
				Control ctrl;
				ctrl = container.GetNextControl(activeControl, true);
				if (ctrl != null)
					{
					if (ctrl.Visible && ctrl.Enabled && ctrl.TabStop)
						{
						ctrl.Focus();
						e.Handled = true;
						return;
						}
					else
						{
						FocusNextControl(container, ctrl, e);
						}
					}
				else
					{
					FocusNextControl(container, null, e);
					}
				}
			catch (Exception ex)
				{
				MessageBox.Show(ex.Message);
				}
			}
		}
	}