using System;
using System.Windows.Forms;

namespace AnnouncementsAddIn
	{
	public partial class SettingsForm : Form
		{
		public SettingsForm()
			{
			InitializeComponent();
			}

		public static bool EditSettings()
			{
			bool ret = false;
			SettingsForm sf = new SettingsForm();

			ret = sf.ShowDialog() == DialogResult.OK;
			if (ret)
				{
				Properties.Settings.Default.TemplateName = sf.txtTemplateFileName.Text;
				Properties.Settings.Default.ProgrammeFile = sf.txtProgrammeFileName.Text;
				Properties.Settings.Default.SavePath = sf.txtSavePath.Text;
				Properties.Settings.Default.CleaningWeekEnding = sf.ckCleaningBefore.Checked;
				Properties.Settings.Default.Save();
				}
			return ret;
			}

		private void SettingsForm_Load(object sender, EventArgs e)
			{
			txtTemplateFileName.Text = Properties.Settings.Default.TemplateName;
			txtProgrammeFileName.Text = Properties.Settings.Default.ProgrammeFile;
			txtSavePath.Text = Properties.Settings.Default.SavePath;
			ckCleaningBefore.Checked = Properties.Settings.Default.CleaningWeekEnding;
			}
		}
	}
