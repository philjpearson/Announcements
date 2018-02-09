//
//	Last mod:	15 July 2017 22:03:07
//
using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace AnnouncementsAddIn
	{
	public partial class ThisAddIn
		{
		private bool connectedTaskPane;
		private Microsoft.Office.Tools.CustomTaskPane ctpAnnouncements = null;
		private AnnouncementsControl ctlAnn = null;
		private Excel.Application xlApp = null;
		private Excel.Workbook xlWb = null;
		private Excel.Range xlRng = null;
		private Word.Document wdDoc = null;
		private Properties.Settings settings;
		private string templatePath;

		#region Column numbers on Excel worksheet (1-based)

		// struct to contain the column numbers.
		private struct xlColumn_t
			{
			public int year;
			public int colDate;
			public int colSunPres;
			public int colSunSpkr;
			public int colSunSpkEcc;
			public int colSunSubj;
			public int colBCPres;
			public int colBCSpkr;
			public int colBCSpkEcc;
			public int colBCSubj;
			public int colBCOrgan;
			public int colDk;
			public int colClean;
			public int colOrgan;
			public int colColl;
			public int colColl3;
			public int colRemind;
			}

		xlColumn_t xlColumn = new xlColumn_t();

		private void InitialiseColumnNumbers(int year)
			{
			xlColumn.colDate = xlApp.get_Range("Date").Column;
			xlColumn.colSunPres = xlApp.get_Range("SunPres").Column;
			xlColumn.colSunSpkr = xlApp.get_Range("SunSpkr").Column;
			xlColumn.colSunSpkEcc = xlApp.get_Range("SunSpkEcc").Column;
			xlColumn.colSunSubj = xlApp.get_Range("SunSubj").Column;
			xlColumn.colBCPres = xlApp.get_Range("BCPres").Column;
			xlColumn.colBCSpkr = xlApp.get_Range("BCSpkr").Column;
			xlColumn.colBCSpkEcc = xlApp.get_Range("BCSpkEcc").Column;
			xlColumn.colBCSubj = xlApp.get_Range("BCSubj").Column;
			xlColumn.colBCOrgan = xlApp.get_Range("BCOrgan").Column;
			xlColumn.colDk = xlApp.get_Range("Dk").Column;
			xlColumn.colClean = xlApp.get_Range("Clean").Column;
			xlColumn.colOrgan = xlApp.get_Range("Organ").Column;
			xlColumn.colColl = xlApp.get_Range("Coll2").Column;
			xlColumn.colColl3 = xlApp.get_Range("Coll3").Column;
			xlColumn.colRemind = xlApp.get_Range("Remind").Column;
			xlColumn.year = year;
			}

		#endregion

		private void ThisAddIn_Startup(object sender, EventArgs e)
			{
			((Word.ApplicationEvents4_Event)Application).NewDocument += new Word.ApplicationEvents4_NewDocumentEventHandler(ThisAddIn_NewDocument);
			((Word.ApplicationEvents4_Event)Application).DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(ThisAddIn_DocumentOpen);
			((Word.ApplicationEvents4_Event)Application).DocumentChange += new Word.ApplicationEvents4_DocumentChangeEventHandler(ThisAddIn_DocumentChange);
			}

		void ThisAddIn_DocumentChange()
			{
			Word.Document Doc = null;
			try
				{
				Doc = Application.ActiveDocument;
				}
			catch (Exception)
				{
				// Application.ActiveDocument throws up if there's no document open!
				}
			if (Doc != null)
				ProcessDocument(Doc);
			}

		void ThisAddIn_NewDocument(Word.Document Doc)
			{
			ProcessDocument(Doc);
			}

		void ThisAddIn_DocumentOpen(Word.Document Doc)
			{
			ProcessDocument(Doc);
			}

		void ThisAddIn_DocumentClose()
			{
			connectedTaskPane = false;
			CustomTaskPanes.Remove(ctpAnnouncements);
			if (xlApp != null)
				{
				xlApp.Quit();
				xlApp = null;
				}
			wdDoc = null;
			}

		private void ThisAddIn_Shutdown(object sender, EventArgs e)
			{
			}

		void ProcessDocument(Word.Document Doc)
			{
			settings = Properties.Settings.Default;
			string templateName = settings.TemplateName;
			wdDoc = Doc;
			Word.Template template = (Word.Template)Doc.get_AttachedTemplate();
			templatePath = Path.GetDirectoryName(template.FullName);
			if (template.Name == templateName)
				{
				if (!connectedTaskPane)
					{
					((Word.DocumentEvents_Event)Doc).Close += new Microsoft.Office.Interop.Word.DocumentEvents_CloseEventHandler(ThisAddIn_DocumentClose);
					ctlAnn = new AnnouncementsControl();
					ctpAnnouncements = CustomTaskPanes.Add(ctlAnn, "Announcements");
					int wid = Properties.Settings.Default.CTPWidth;
					if (wid != 0)
						ctpAnnouncements.Width = wid;
					ctlAnn.CreateAnnouncements += new AnnouncementsAddIn.AnnouncementsControl.CreateAnnouncementsHandler(ctlAnn_CreateAnnouncements);
					ctlAnn.SaveAnnouncements += new EventHandler(ctlAnn_SaveAnnouncements);
					ctlAnn.AddEditReminder += new AnnouncementsControl.AnnouncementsReminderHandler(ctlAnn_AddEditReminder);
					ctlAnn.PrintAnnouncements += new EventHandler(ctlAnn_PrintAnnouncements);
					ctlAnn.DateSelected += new AnnouncementsControl.DateSelectedHandler(ctlAnn_DateSelected);
					Doc.ActiveWindow.View.Zoom.PageFit = Microsoft.Office.Interop.Word.WdPageFit.wdPageFitBestFit;
					ConnectToExcel();
					connectedTaskPane = true;
					}
				ctpAnnouncements.Visible = true;
				}
			else if (connectedTaskPane)
				ctpAnnouncements.Visible = false;
			}

		#region Event handlers for events from our Custom Task Pane

		void ctlAnn_AddEditReminder(object sender, AnnouncementsControl.AnnouncementsDateEventArgs e)
			{
			int week = GetWeekFromDate(e.Date);
			SelectWorksheet(e.Date);
			string reminder = GetReminder(week);
			ReminderForm.EditReminder(e.Date, ref reminder);
			SetReminderText(reminder);
			StoreReminder(week, reminder);
			}

		void ctlAnn_CreateAnnouncements(object sender, AnnouncementsControl.AnnouncementsDateEventArgs e)
			{
			SelectWorksheet(e.Date);

			int week = GetWeekFromDate(e.Date);
			SetReminderText(GetReminder(week));
			Application.ScreenUpdating = false;
			FillIn(week);
			Application.ScreenUpdating = true;

			object bn = "Date1";
			wdDoc.Bookmarks.get_Item(ref bn).Select(); //to get the doc scrolled back to the top
			bn = "Visitors";
			wdDoc.Bookmarks.get_Item(ref bn).Select();
			}

		void ctlAnn_DateSelected(object sender, AnnouncementsControl.AnnouncementsDateEventArgs e)
			{
			SelectWorksheet(e.Date);
			SetReminderText(GetReminder(GetWeekFromDate(e.Date)));
			}

		void ctlAnn_PrintAnnouncements(object sender, EventArgs e)
			{
			object background = true;
			wdDoc.PrintOut(ref background);
			}

		void ctlAnn_SaveAnnouncements(object sender, EventArgs e)
			{
			string savePath = settings.SavePath;
			if (!Path.IsPathRooted(savePath))
				savePath = Path.Combine(templatePath, savePath);
			object oFile = Path.Combine(savePath, "Announcements.docx");
			object pdfFile = Path.ChangeExtension((string)oFile, "pdf");
			object pdfFormat = Word.WdSaveFormat.wdFormatPDF;
			wdDoc.SaveAs(ref oFile);
			wdDoc.SaveAs2(ref pdfFile, ref pdfFormat);
			Application.StatusBar = string.Format("Saved to {0} and {1}", oFile, pdfFile);
			}

		#endregion

		#region local helper functions

		private void ConnectToExcel()
			{
			if (xlApp == null)
				{
				string progname = settings.ProgrammeFile;
				progname = @"D:\philj\Documents\OneDrive\My Documents\Ecclesia\Programme\Ecclesial Programme.xlsx";
				if (!Path.IsPathRooted(progname))
					{
					progname = Path.Combine(templatePath, settings.ProgrammeFile);
					}

				try
					{
					xlApp = new Microsoft.Office.Interop.Excel.Application();
					xlWb = xlApp.Workbooks.Open(progname);
					ctlAnn.EnableCreateButton(true);
					Application.StatusBar = "Successfully connected to Excel programme";
					}
				catch (Exception e)
					{
					MessageBox.Show(string.Format("Failed to connect to the Excel Programme at {0}\r\n{1}", progname, e.Message), "AnnouncementsAddIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.StatusBar = "Failed connection to Excel programme";
					throw;
					}
				}
			}

		public void FillIn(int WeekNum)
			{
			try
				{
				SetText("WeekNum1", WeekNum.ToString());
				SetText("WeekNum2", WeekNum.ToString());

				SetText("Date1", GetDateForWeek(WeekNum));
				SetText("Date2", GetDateForWeek(WeekNum));

				SetText("PresidentToday1", GetProgrammeValueBro(WeekNum, xlColumn.colSunPres));
				SetText("PresidentToday2", GetProgrammeValueBro(WeekNum, xlColumn.colSunPres));
				string s = GetSpeakerText(WeekNum);
				SetText("SpeakerToday1", s);
				SetText("SpeakerToday2", s);
				SetText("SubjectToday1", GetProgrammeValue(WeekNum, xlColumn.colSunSubj));
				SetText("SubjectToday2", GetProgrammeValue(WeekNum, xlColumn.colSunSubj));
				s = GetBCSpeakerText(WeekNum);
				SetText("SpeakerBC1", s);
				SetText("SpeakerBC2", s);
				SetText("SubjectBC1", GetProgrammeValue(WeekNum, xlColumn.colBCSubj));
				SetText("SubjectBC2", GetProgrammeValue(WeekNum, xlColumn.colBCSubj));
				SetText("PresidentBC1", GetProgrammeValueBro(WeekNum, xlColumn.colBCPres));
				SetText("OrganBC", GetBCOrganistText(WeekNum));
				s = GetSpeakerText(WeekNum + 1);
				SetText("SpeakerNextSun1", s);
				SetText("SpeakerNextSun2", s);
				SetText("SubjectNextSun1", GetProgrammeValue(WeekNum + 1, xlColumn.colSunSubj));
				SetText("SubjectNextSun2", GetProgrammeValue(WeekNum + 1, xlColumn.colSunSubj));
				SetText("PresidentNextSun1", GetProgrammeValueBro(WeekNum + 1, xlColumn.colSunPres));
				SetText("Doorkeeper", GetProgrammeValueBro(WeekNum + 1, xlColumn.colDk));
				int wk = Properties.Settings.Default.CleaningWeekEnding ? WeekNum + 1 : WeekNum;
				SetText("Cleaning", GetProgrammeValue(wk, xlColumn.colClean));
				SetText("Organ", GetOrganistText(WeekNum));
				SetText("CollectionLastSun", GetProgrammeValue(WeekNum - 1, xlColumn.colColl));
				SetText("Collection3LastSun", GetProgrammeValue(WeekNum - 1, xlColumn.colColl3));
				SetText("CollectionToday1", GetProgrammeValue(WeekNum, xlColumn.colColl));
				SetText("CollectionToday2", GetProgrammeValue(WeekNum, xlColumn.colColl));
				SetText("Collection3Today1", GetProgrammeValue(WeekNum, xlColumn.colColl3));
				SetText("Collection3Today2", GetProgrammeValue(WeekNum, xlColumn.colColl3));
				SetText("CollectionNextSun", GetProgrammeValue(WeekNum + 1, xlColumn.colColl));
				SetText("Collection3NextSun", GetProgrammeValue(WeekNum + 1, xlColumn.colColl3));
				SetText("FollWedSpk", GetBCSpeakerText(WeekNum + 1));
				SetText("FollWedSub", GetProgrammeValue(WeekNum + 1, xlColumn.colBCSubj));

				ctlAnn.ReminderText = GetProgrammeValue(WeekNum, xlColumn.colRemind);
				}
			catch (Exception e)
				{
				MessageBox.Show(string.Format("Something went wrong while filling in data in the document.\r\n{0}", e.Message), "AnnouncementsAddIn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				throw;
				}
			}

		private string GetSpeakerText(int WeekNum)
			{
			string spk = GetProgrammeValueBro(WeekNum, xlColumn.colSunSpkr);
			string ecc = GetProgrammeValue(WeekNum, xlColumn.colSunSpkEcc);
			if (string.IsNullOrEmpty(ecc))
				return spk;
			else
				return string.Format("{0} ({1})", spk, ecc);
			}

		private string GetBCSpeakerText(int WeekNum)
			{
			string spk = GetProgrammeValueBro(WeekNum, xlColumn.colBCSpkr);
			string ecc = GetProgrammeValue(WeekNum, xlColumn.colBCSpkEcc);
			if (string.IsNullOrEmpty(ecc))
				return spk;
			else
				return string.Format("{0} ({1})", spk, ecc);
			}

		private string GetBCOrganistText(int WeekNum)
			{
			return GetProgrammeValue(WeekNum, xlColumn.colBCOrgan);
			}

		private string GetOrganistText(int WeekNum)
			{
			return GetProgrammeValue(WeekNum + 1, xlColumn.colOrgan);
			}

		private string GetDateForWeek(int week)
			{
			object val;
			String sDate = "";

			val = ((Excel.Range)xlRng[week, xlColumn.colDate]).get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
			if (val != null)
				{
				sDate = val.ToString();
				DateTime dt = DateTime.Parse(sDate);
				sDate = dt.ToString("d MMMM yyyy");
				}
			return sDate;
			}

		private void SelectWorksheet(DateTime Date)
			{
			string sheetName = Date.Year.ToString();
			((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[sheetName]).Select();
			xlRng = xlApp.get_Range("Start");
			InitialiseColumnNumbers(Date.Year);
			}

		private string GetProgrammeValue(int row, int col)
			{
			object val;
			string s = "";

			val = ((Excel.Range)xlRng[row, col]).get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
			if (val != null)
				{
				s = val.ToString();
				}
			return s;
			}

		private string GetProgrammeValueBro(int row, int col)
			{
			string s = GetProgrammeValue(row, col);
			if (!s.StartsWith("Bro"))
				s = "Bro " + s;
			return s;
			}

		public string GetReminder(int week)
			{
			string s = string.Empty;
			object ob = ((Excel.Range)xlRng[week, xlColumn.colRemind]).Value2;
			if (ob != null)
				s = ob.ToString();
			return s;
			}

		private int GetWeekFromDate(DateTime date)
			{
			System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-GB", false);
			return culture.Calendar.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstFullWeek, System.DayOfWeek.Sunday);
			}

		private void SetText(string BookmarkName, string text)
			{
			// special technique to replace text in a bookmark *and* keep the bookmark enclosing the text
			// (so it can be replaced again if necessary).
			object bn = BookmarkName;
			Word.Range rng = wdDoc.Bookmarks.get_Item(ref bn).Range;
			rng.Text = text;
			object rngObj = rng;
			wdDoc.Bookmarks.Add(BookmarkName, ref rngObj);
			}

		private void SetReminderText(string reminder)
			{
			ctlAnn.ReminderText = reminder;
			}

		public void StoreReminder(int week, string s)
			{
			((Excel.Range)xlRng[week, xlColumn.colRemind]).Value2 = s;
			xlWb.Save();
			}

		#endregion

		#region VSTO generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup()
			{
			this.Startup += new System.EventHandler(ThisAddIn_Startup);
			this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
			}

		#endregion
		}
	}
