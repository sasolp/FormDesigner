using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using Clipboard=CLIPBOARDTASKSLib;
using TINYLib;
namespace FormDesigner
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		[DllImport("user32.dll")]
		protected static extern int  CreateCaret(
			IntPtr hWnd, 
			IntPtr hBitmap, 
			int nWidth, 
			int nHeight
			); 
		[DllImport("user32.dll")]
		protected static extern int  ShowCaret(
			IntPtr  hWnd
			); 
		[DllImport("user32.dll")]
		protected static extern int  HideCaret(
			IntPtr  hWnd
			); 
		[DllImport("user32.dll")]
		protected static extern int   SetCaretPos(
			int X, 
			int Y
			);
		public static string [] arrPaths;//arrPaths[0]for undo and  arrPaths[1]for redo
		#region Form Variables
		FormView frmFormView;
		bool bLarge;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.ToolBar toolBar1;

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label  l1;
		private System.Windows.Forms.Label  l1Parent;
		private System.Windows.Forms.Label  l2;
		private System.Windows.Forms.Label  l3;
		private System.Windows.Forms.Label  l4;
		private System.Windows.Forms.Label  l5;
		private System.Windows.Forms.TrackBar t1;
		private System.Windows.Forms.TrackBar t2;
		private System.Windows.Forms.TrackBar t3;
		private System.Windows.Forms.TrackBar t4;
		private System.Windows.Forms.RadioButton  chkDash,chkSolid;
		private System.Windows.Forms.MenuItem menuItem126;
		private FormDesigner.ToolBox toolBox1;
		private Janus.Windows.UI.Tab.UITab uiTab1;
		private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
		private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
		private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
		private Janus.Windows.UI.Tab.UITabPage uiTabPage4;
		private Janus.Windows.UI.Tab.UITabPage uiTabPage5;
		private Janus.Windows.UI.Tab.UITabPage uiTabPage6;
		private Janus.Windows.UI.Tab.UITabPage uiTabPage7;
		private System.Windows.Forms.ToolBar tbCases;
		private System.Windows.Forms.TrackBar   t5;
		#endregion
		#region Cases's ToolBar Variables
		TextBox			[]			arrTextsSpecial;
		TextBox			[]			arrTextsRange;
		Rectangle		[]			arrRectangles;
		bool			[]			arrRectsStatus;
		Button			btnAddCases;
		Label			lblCases;
		Label			lblNumbers;
		Label			lblCases1;
		Label			lblNumbers1;
		Label			lblFrom;
		Label			lblTo;
		Label			lblNumberOf;
		Panel			[]arrPanels;
		RadioButton     rbSpecial;
		RadioButton     rbRange;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mnuLarge;
		private System.Windows.Forms.MenuItem mnuSmall;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mnuVer;
		private System.Windows.Forms.MenuItem mnuFarsiNumber;
		public static System.Windows.Forms.MenuItem mnuUndo;
		public  static System.Windows.Forms.MenuItem mnuRedo;
		private System.Windows.Forms.MenuItem munPast;
		private System.Windows.Forms.MenuItem munClear;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem9;
		bool			bRange;
		#endregion
		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		[STAThread]
		static void Main() 
		{
			
			
			LockCheker lc=new LockCheker();
			if(lc.IsCorrect())
			{					
				Application.Run(new	MainForm  ());
			}
			else
				Application.Exit();
			
			
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			mnuUndo = new System.Windows.Forms.MenuItem();
			mnuRedo = new System.Windows.Forms.MenuItem();
			this.munPast = new System.Windows.Forms.MenuItem();
			this.munClear = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuLarge = new System.Windows.Forms.MenuItem();
			this.mnuSmall = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem126 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuVer = new System.Windows.Forms.MenuItem();
			this.mnuFarsiNumber = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBox1 = new FormDesigner.ToolBox();
			this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
			this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
			this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
			this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
			this.uiTabPage4 = new Janus.Windows.UI.Tab.UITabPage();
			this.uiTabPage5 = new Janus.Windows.UI.Tab.UITabPage();
			this.uiTabPage6 = new Janus.Windows.UI.Tab.UITabPage();
			this.uiTabPage7 = new Janus.Windows.UI.Tab.UITabPage();
			this.tbCases = new System.Windows.Forms.ToolBar();
			((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
			this.uiTab1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem3,
																					  this.menuItem6,
																					  this.menuItem8,
																					  this.menuItem5,
																					  this.menuItem7});
			this.mainMenu1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mainMenu1.RightToLeft")));
			// 
			// menuItem1
			// 
			this.menuItem1.Enabled = ((bool)(resources.GetObject("menuItem1.Enabled")));
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem13,
																					  this.menuItem14,
																					  this.menuItem15,
																					  this.menuItem16});
			this.menuItem1.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem1.Shortcut")));
			this.menuItem1.ShowShortcut = ((bool)(resources.GetObject("menuItem1.ShowShortcut")));
			this.menuItem1.Text = resources.GetString("menuItem1.Text");
			this.menuItem1.Visible = ((bool)(resources.GetObject("menuItem1.Visible")));
			// 
			// menuItem2
			// 
			this.menuItem2.Enabled = ((bool)(resources.GetObject("menuItem2.Enabled")));
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem2.Shortcut")));
			this.menuItem2.ShowShortcut = ((bool)(resources.GetObject("menuItem2.ShowShortcut")));
			this.menuItem2.Text = resources.GetString("menuItem2.Text");
			this.menuItem2.Visible = ((bool)(resources.GetObject("menuItem2.Visible")));
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click_1);
			// 
			// menuItem11
			// 
			this.menuItem11.Enabled = ((bool)(resources.GetObject("menuItem11.Enabled")));
			this.menuItem11.Index = 1;
			this.menuItem11.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem11.Shortcut")));
			this.menuItem11.ShowShortcut = ((bool)(resources.GetObject("menuItem11.ShowShortcut")));
			this.menuItem11.Text = resources.GetString("menuItem11.Text");
			this.menuItem11.Visible = ((bool)(resources.GetObject("menuItem11.Visible")));
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Enabled = ((bool)(resources.GetObject("menuItem12.Enabled")));
			this.menuItem12.Index = 2;
			this.menuItem12.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem12.Shortcut")));
			this.menuItem12.ShowShortcut = ((bool)(resources.GetObject("menuItem12.ShowShortcut")));
			this.menuItem12.Text = resources.GetString("menuItem12.Text");
			this.menuItem12.Visible = ((bool)(resources.GetObject("menuItem12.Visible")));
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Enabled = ((bool)(resources.GetObject("menuItem13.Enabled")));
			this.menuItem13.Index = 3;
			this.menuItem13.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem13.Shortcut")));
			this.menuItem13.ShowShortcut = ((bool)(resources.GetObject("menuItem13.ShowShortcut")));
			this.menuItem13.Text = resources.GetString("menuItem13.Text");
			this.menuItem13.Visible = ((bool)(resources.GetObject("menuItem13.Visible")));
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Enabled = ((bool)(resources.GetObject("menuItem14.Enabled")));
			this.menuItem14.Index = 4;
			this.menuItem14.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem14.Shortcut")));
			this.menuItem14.ShowShortcut = ((bool)(resources.GetObject("menuItem14.ShowShortcut")));
			this.menuItem14.Text = resources.GetString("menuItem14.Text");
			this.menuItem14.Visible = ((bool)(resources.GetObject("menuItem14.Visible")));
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Enabled = ((bool)(resources.GetObject("menuItem15.Enabled")));
			this.menuItem15.Index = 5;
			this.menuItem15.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem15.Shortcut")));
			this.menuItem15.ShowShortcut = ((bool)(resources.GetObject("menuItem15.ShowShortcut")));
			this.menuItem15.Text = resources.GetString("menuItem15.Text");
			this.menuItem15.Visible = ((bool)(resources.GetObject("menuItem15.Visible")));
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Enabled = ((bool)(resources.GetObject("menuItem16.Enabled")));
			this.menuItem16.Index = 6;
			this.menuItem16.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem16.Shortcut")));
			this.menuItem16.ShowShortcut = ((bool)(resources.GetObject("menuItem16.ShowShortcut")));
			this.menuItem16.Text = resources.GetString("menuItem16.Text");
			this.menuItem16.Visible = ((bool)(resources.GetObject("menuItem16.Visible")));
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Enabled = ((bool)(resources.GetObject("menuItem3.Enabled")));
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  mnuUndo,
																					  mnuRedo,
																					  this.munPast,
																					  this.munClear});
			this.menuItem3.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem3.Shortcut")));
			this.menuItem3.ShowShortcut = ((bool)(resources.GetObject("menuItem3.ShowShortcut")));
			this.menuItem3.Text = resources.GetString("menuItem3.Text");
			this.menuItem3.Visible = ((bool)(resources.GetObject("menuItem3.Visible")));
			// 
			// mnuUndo
			// 
			mnuUndo.Enabled = ((bool)(resources.GetObject("mnuUndo.Enabled")));
			mnuUndo.Index = 0;
			mnuUndo.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuUndo.Shortcut")));
			mnuUndo.ShowShortcut = ((bool)(resources.GetObject("mnuUndo.ShowShortcut")));
			mnuUndo.Text = resources.GetString("mnuUndo.Text");
			mnuUndo.Visible = ((bool)(resources.GetObject("mnuUndo.Visible")));
			mnuUndo.Click += new System.EventHandler(mnuUndo_Click);
			// 
			// mnuRedo
			// 
			mnuRedo.Enabled = ((bool)(resources.GetObject("mnuRedo.Enabled")));
			mnuRedo.Index = 1;
			mnuRedo.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuRedo.Shortcut")));
			mnuRedo.ShowShortcut = ((bool)(resources.GetObject("mnuRedo.ShowShortcut")));
			mnuRedo.Text = resources.GetString("mnuRedo.Text");
			mnuRedo.Visible = ((bool)(resources.GetObject("mnuRedo.Visible")));
			mnuRedo.Click += new System.EventHandler(mnuRedo_Click);
			// 
			// munPast
			// 
			this.munPast.Enabled = ((bool)(resources.GetObject("munPast.Enabled")));
			this.munPast.Index = 2;
			this.munPast.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("munPast.Shortcut")));
			this.munPast.ShowShortcut = ((bool)(resources.GetObject("munPast.ShowShortcut")));
			this.munPast.Text = resources.GetString("munPast.Text");
			this.munPast.Visible = ((bool)(resources.GetObject("munPast.Visible")));
			this.munPast.Click += new System.EventHandler(this.menuItem21_Click);
			// 
			// munClear
			// 
			this.munClear.Enabled = ((bool)(resources.GetObject("munClear.Enabled")));
			this.munClear.Index = 3;
			this.munClear.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("munClear.Shortcut")));
			this.munClear.ShowShortcut = ((bool)(resources.GetObject("munClear.ShowShortcut")));
			this.munClear.Text = resources.GetString("munClear.Text");
			this.munClear.Visible = ((bool)(resources.GetObject("munClear.Visible")));
			this.munClear.Click += new System.EventHandler(this.munClear_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Enabled = ((bool)(resources.GetObject("menuItem6.Enabled")));
			this.menuItem6.Index = 2;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem4});
			this.menuItem6.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem6.Shortcut")));
			this.menuItem6.ShowShortcut = ((bool)(resources.GetObject("menuItem6.ShowShortcut")));
			this.menuItem6.Text = resources.GetString("menuItem6.Text");
			this.menuItem6.Visible = ((bool)(resources.GetObject("menuItem6.Visible")));
			// 
			// menuItem4
			// 
			this.menuItem4.Enabled = ((bool)(resources.GetObject("menuItem4.Enabled")));
			this.menuItem4.Index = 0;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuLarge,
																					  this.mnuSmall});
			this.menuItem4.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem4.Shortcut")));
			this.menuItem4.ShowShortcut = ((bool)(resources.GetObject("menuItem4.ShowShortcut")));
			this.menuItem4.Text = resources.GetString("menuItem4.Text");
			this.menuItem4.Visible = ((bool)(resources.GetObject("menuItem4.Visible")));
			// 
			// mnuLarge
			// 
			this.mnuLarge.Enabled = ((bool)(resources.GetObject("mnuLarge.Enabled")));
			this.mnuLarge.Index = 0;
			this.mnuLarge.RadioCheck = true;
			this.mnuLarge.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuLarge.Shortcut")));
			this.mnuLarge.ShowShortcut = ((bool)(resources.GetObject("mnuLarge.ShowShortcut")));
			this.mnuLarge.Text = resources.GetString("mnuLarge.Text");
			this.mnuLarge.Visible = ((bool)(resources.GetObject("mnuLarge.Visible")));
			this.mnuLarge.Click += new System.EventHandler(this.mnuLarge_Click);
			// 
			// mnuSmall
			// 
			this.mnuSmall.Checked = true;
			this.mnuSmall.Enabled = ((bool)(resources.GetObject("mnuSmall.Enabled")));
			this.mnuSmall.Index = 1;
			this.mnuSmall.RadioCheck = true;
			this.mnuSmall.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuSmall.Shortcut")));
			this.mnuSmall.ShowShortcut = ((bool)(resources.GetObject("mnuSmall.ShowShortcut")));
			this.mnuSmall.Text = resources.GetString("mnuSmall.Text");
			this.mnuSmall.Visible = ((bool)(resources.GetObject("mnuSmall.Visible")));
			this.mnuSmall.Click += new System.EventHandler(this.mnuSmall_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Enabled = ((bool)(resources.GetObject("menuItem8.Enabled")));
			this.menuItem8.Index = 3;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem126});
			this.menuItem8.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem8.Shortcut")));
			this.menuItem8.ShowShortcut = ((bool)(resources.GetObject("menuItem8.ShowShortcut")));
			this.menuItem8.Text = resources.GetString("menuItem8.Text");
			this.menuItem8.Visible = ((bool)(resources.GetObject("menuItem8.Visible")));
			// 
			// menuItem126
			// 
			this.menuItem126.Enabled = ((bool)(resources.GetObject("menuItem126.Enabled")));
			this.menuItem126.Index = 0;
			this.menuItem126.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem126.Shortcut")));
			this.menuItem126.ShowShortcut = ((bool)(resources.GetObject("menuItem126.ShowShortcut")));
			this.menuItem126.Text = resources.GetString("menuItem126.Text");
			this.menuItem126.Visible = ((bool)(resources.GetObject("menuItem126.Visible")));
			this.menuItem126.Click += new System.EventHandler(this.menuItem126_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Enabled = ((bool)(resources.GetObject("menuItem5.Enabled")));
			this.menuItem5.Index = 4;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuVer,
																					  this.mnuFarsiNumber});
			this.menuItem5.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem5.Shortcut")));
			this.menuItem5.ShowShortcut = ((bool)(resources.GetObject("menuItem5.ShowShortcut")));
			this.menuItem5.Text = resources.GetString("menuItem5.Text");
			this.menuItem5.Visible = ((bool)(resources.GetObject("menuItem5.Visible")));
			// 
			// mnuVer
			// 
			this.mnuVer.Enabled = ((bool)(resources.GetObject("mnuVer.Enabled")));
			this.mnuVer.Index = 0;
			this.mnuVer.RadioCheck = true;
			this.mnuVer.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuVer.Shortcut")));
			this.mnuVer.ShowShortcut = ((bool)(resources.GetObject("mnuVer.ShowShortcut")));
			this.mnuVer.Text = resources.GetString("mnuVer.Text");
			this.mnuVer.Visible = ((bool)(resources.GetObject("mnuVer.Visible")));
			this.mnuVer.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// mnuFarsiNumber
			// 
			this.mnuFarsiNumber.Enabled = ((bool)(resources.GetObject("mnuFarsiNumber.Enabled")));
			this.mnuFarsiNumber.Index = 1;
			this.mnuFarsiNumber.RadioCheck = true;
			this.mnuFarsiNumber.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuFarsiNumber.Shortcut")));
			this.mnuFarsiNumber.ShowShortcut = ((bool)(resources.GetObject("mnuFarsiNumber.ShowShortcut")));
			this.mnuFarsiNumber.Text = resources.GetString("mnuFarsiNumber.Text");
			this.mnuFarsiNumber.Visible = ((bool)(resources.GetObject("mnuFarsiNumber.Visible")));
			this.mnuFarsiNumber.Click += new System.EventHandler(this.mnuFarsiNumber_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Enabled = ((bool)(resources.GetObject("menuItem7.Enabled")));
			this.menuItem7.Index = 5;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem9});
			this.menuItem7.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem7.Shortcut")));
			this.menuItem7.ShowShortcut = ((bool)(resources.GetObject("menuItem7.ShowShortcut")));
			this.menuItem7.Text = resources.GetString("menuItem7.Text");
			this.menuItem7.Visible = ((bool)(resources.GetObject("menuItem7.Visible")));
			// 
			// menuItem9
			// 
			this.menuItem9.Enabled = ((bool)(resources.GetObject("menuItem9.Enabled")));
			this.menuItem9.Index = 0;
			this.menuItem9.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem9.Shortcut")));
			this.menuItem9.ShowShortcut = ((bool)(resources.GetObject("menuItem9.ShowShortcut")));
			this.menuItem9.Text = resources.GetString("menuItem9.Text");
			this.menuItem9.Visible = ((bool)(resources.GetObject("menuItem9.Visible")));
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// toolBar1
			// 
			this.toolBar1.AccessibleDescription = resources.GetString("toolBar1.AccessibleDescription");
			this.toolBar1.AccessibleName = resources.GetString("toolBar1.AccessibleName");
			this.toolBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("toolBar1.Anchor")));
			this.toolBar1.Appearance = ((System.Windows.Forms.ToolBarAppearance)(resources.GetObject("toolBar1.Appearance")));
			this.toolBar1.AutoSize = ((bool)(resources.GetObject("toolBar1.AutoSize")));
			this.toolBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolBar1.BackgroundImage")));
			this.toolBar1.ButtonSize = ((System.Drawing.Size)(resources.GetObject("toolBar1.ButtonSize")));
			this.toolBar1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("toolBar1.Dock")));
			this.toolBar1.DropDownArrows = ((bool)(resources.GetObject("toolBar1.DropDownArrows")));
			this.toolBar1.Enabled = ((bool)(resources.GetObject("toolBar1.Enabled")));
			this.toolBar1.Font = ((System.Drawing.Font)(resources.GetObject("toolBar1.Font")));
			this.toolBar1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolBar1.ImeMode")));
			this.toolBar1.Location = ((System.Drawing.Point)(resources.GetObject("toolBar1.Location")));
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolBar1.RightToLeft")));
			this.toolBar1.ShowToolTips = ((bool)(resources.GetObject("toolBar1.ShowToolTips")));
			this.toolBar1.Size = ((System.Drawing.Size)(resources.GetObject("toolBar1.Size")));
			this.toolBar1.TabIndex = ((int)(resources.GetObject("toolBar1.TabIndex")));
			this.toolBar1.TextAlign = ((System.Windows.Forms.ToolBarTextAlign)(resources.GetObject("toolBar1.TextAlign")));
			this.toolBar1.Visible = ((bool)(resources.GetObject("toolBar1.Visible")));
			this.toolBar1.Wrappable = ((bool)(resources.GetObject("toolBar1.Wrappable")));
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBox1
			// 
			this.toolBox1.AccessibleDescription = resources.GetString("toolBox1.AccessibleDescription");
			this.toolBox1.AccessibleName = resources.GetString("toolBox1.AccessibleName");
			this.toolBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("toolBox1.Anchor")));
			this.toolBox1.AutoScroll = ((bool)(resources.GetObject("toolBox1.AutoScroll")));
			this.toolBox1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("toolBox1.AutoScrollMargin")));
			this.toolBox1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("toolBox1.AutoScrollMinSize")));
			this.toolBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(228)), ((System.Byte)(226)), ((System.Byte)(214)));
			this.toolBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolBox1.BackgroundImage")));
			this.toolBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.toolBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("toolBox1.Dock")));
			this.toolBox1.Enabled = ((bool)(resources.GetObject("toolBox1.Enabled")));
			this.toolBox1.Font = ((System.Drawing.Font)(resources.GetObject("toolBox1.Font")));
			this.toolBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("toolBox1.ImeMode")));
			this.toolBox1.Location = ((System.Drawing.Point)(resources.GetObject("toolBox1.Location")));
			this.toolBox1.Name = "toolBox1";
			this.toolBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("toolBox1.RightToLeft")));
			this.toolBox1.Size = ((System.Drawing.Size)(resources.GetObject("toolBox1.Size")));
			this.toolBox1.TabIndex = ((int)(resources.GetObject("toolBox1.TabIndex")));
			this.toolBox1.Visible = ((bool)(resources.GetObject("toolBox1.Visible")));
			// 
			// uiTab1
			// 
			this.uiTab1.AccessibleDescription = resources.GetString("uiTab1.AccessibleDescription");
			this.uiTab1.AccessibleName = resources.GetString("uiTab1.AccessibleName");
			this.uiTab1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("uiTab1.Anchor")));
			this.uiTab1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiTab1.BackgroundImage")));
			this.uiTab1.Controls.Add(this.uiTabPage1);
			this.uiTab1.Controls.Add(this.uiTabPage2);
			this.uiTab1.Controls.Add(this.uiTabPage3);
			this.uiTab1.Controls.Add(this.uiTabPage4);
			this.uiTab1.Controls.Add(this.uiTabPage5);
			this.uiTab1.Controls.Add(this.uiTabPage6);
			this.uiTab1.Controls.Add(this.uiTabPage7);
			this.uiTab1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("uiTab1.Dock")));
			this.uiTab1.Enabled = ((bool)(resources.GetObject("uiTab1.Enabled")));
			this.uiTab1.FirstTabOffset = ((int)(resources.GetObject("uiTab1.FirstTabOffset")));
			this.uiTab1.FocusOnClick = ((bool)(resources.GetObject("uiTab1.FocusOnClick")));
			this.uiTab1.Font = ((System.Drawing.Font)(resources.GetObject("uiTab1.Font")));
			this.uiTab1.ImageList = ((System.Windows.Forms.ImageList)(resources.GetObject("uiTab1.ImageList")));
			this.uiTab1.ImageSize = ((System.Drawing.Size)(resources.GetObject("uiTab1.ImageSize")));
			this.uiTab1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("uiTab1.ImeMode")));
			this.uiTab1.ItemSize = ((System.Drawing.Size)(resources.GetObject("uiTab1.ItemSize")));
			this.uiTab1.LayoutStream = ((System.IO.Stream)(resources.GetObject("uiTab1.LayoutStream")));
			this.uiTab1.Location = ((System.Drawing.Point)(resources.GetObject("uiTab1.Location")));
			this.uiTab1.MultiLine = ((bool)(resources.GetObject("uiTab1.MultiLine")));
			this.uiTab1.Name = "uiTab1";
			this.uiTab1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("uiTab1.RightToLeft")));
			this.uiTab1.ShowCloseButton = true;
			this.uiTab1.ShowToolTips = ((bool)(resources.GetObject("uiTab1.ShowToolTips")));
			this.uiTab1.Size = ((System.Drawing.Size)(resources.GetObject("uiTab1.Size")));
			this.uiTab1.SizeMode = ((System.Windows.Forms.TabSizeMode)(resources.GetObject("uiTab1.SizeMode")));
			this.uiTab1.TabIndex = ((int)(resources.GetObject("uiTab1.TabIndex")));
			this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
																				   this.uiTabPage1,
																				   this.uiTabPage2,
																				   this.uiTabPage3,
																				   this.uiTabPage4,
																				   this.uiTabPage5,
																				   this.uiTabPage6,
																				   this.uiTabPage7});
			this.uiTab1.TabStripOffset = ((int)(resources.GetObject("uiTab1.TabStripOffset")));
			this.uiTab1.Text = resources.GetString("uiTab1.Text");
			this.uiTab1.UseThemes = ((bool)(resources.GetObject("uiTab1.UseThemes")));
			this.uiTab1.Visible = ((bool)(resources.GetObject("uiTab1.Visible")));
			// 
			// uiTabPage1
			// 
			this.uiTabPage1.AccessibleDescription = resources.GetString("uiTabPage1.AccessibleDescription");
			this.uiTabPage1.AccessibleName = resources.GetString("uiTabPage1.AccessibleName");
			this.uiTabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("uiTabPage1.Anchor")));
			this.uiTabPage1.AutoScroll = ((bool)(resources.GetObject("uiTabPage1.AutoScroll")));
			this.uiTabPage1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("uiTabPage1.AutoScrollMargin")));
			this.uiTabPage1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("uiTabPage1.AutoScrollMinSize")));
			this.uiTabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiTabPage1.BackgroundImage")));
			this.uiTabPage1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("uiTabPage1.Dock")));
			this.uiTabPage1.Enabled = ((bool)(resources.GetObject("uiTabPage1.Enabled")));
			this.uiTabPage1.Font = ((System.Drawing.Font)(resources.GetObject("uiTabPage1.Font")));
			this.uiTabPage1.Icon = ((System.Drawing.Icon)(resources.GetObject("uiTabPage1.Icon")));
			this.uiTabPage1.Image = ((System.Drawing.Image)(resources.GetObject("uiTabPage1.Image")));
			this.uiTabPage1.ImageIndex = ((int)(resources.GetObject("uiTabPage1.ImageIndex")));
			this.uiTabPage1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("uiTabPage1.ImeMode")));
			this.uiTabPage1.Location = ((System.Drawing.Point)(resources.GetObject("uiTabPage1.Location")));
			this.uiTabPage1.Name = "uiTabPage1";
			this.uiTabPage1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("uiTabPage1.RightToLeft")));
			this.uiTabPage1.Size = ((System.Drawing.Size)(resources.GetObject("uiTabPage1.Size")));
			this.uiTabPage1.TabIndex = ((int)(resources.GetObject("uiTabPage1.TabIndex")));
			this.uiTabPage1.TabVisible = ((bool)(resources.GetObject("uiTabPage1.TabVisible")));
			this.uiTabPage1.Text = resources.GetString("uiTabPage1.Text");
			this.uiTabPage1.ToolTipText = resources.GetString("uiTabPage1.ToolTipText");
			this.uiTabPage1.Visible = ((bool)(resources.GetObject("uiTabPage1.Visible")));
			// 
			// uiTabPage2
			// 
			this.uiTabPage2.AccessibleDescription = resources.GetString("uiTabPage2.AccessibleDescription");
			this.uiTabPage2.AccessibleName = resources.GetString("uiTabPage2.AccessibleName");
			this.uiTabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("uiTabPage2.Anchor")));
			this.uiTabPage2.AutoScroll = ((bool)(resources.GetObject("uiTabPage2.AutoScroll")));
			this.uiTabPage2.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("uiTabPage2.AutoScrollMargin")));
			this.uiTabPage2.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("uiTabPage2.AutoScrollMinSize")));
			this.uiTabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiTabPage2.BackgroundImage")));
			this.uiTabPage2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("uiTabPage2.Dock")));
			this.uiTabPage2.Enabled = ((bool)(resources.GetObject("uiTabPage2.Enabled")));
			this.uiTabPage2.Font = ((System.Drawing.Font)(resources.GetObject("uiTabPage2.Font")));
			this.uiTabPage2.Icon = ((System.Drawing.Icon)(resources.GetObject("uiTabPage2.Icon")));
			this.uiTabPage2.Image = ((System.Drawing.Image)(resources.GetObject("uiTabPage2.Image")));
			this.uiTabPage2.ImageIndex = ((int)(resources.GetObject("uiTabPage2.ImageIndex")));
			this.uiTabPage2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("uiTabPage2.ImeMode")));
			this.uiTabPage2.Location = ((System.Drawing.Point)(resources.GetObject("uiTabPage2.Location")));
			this.uiTabPage2.Name = "uiTabPage2";
			this.uiTabPage2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("uiTabPage2.RightToLeft")));
			this.uiTabPage2.Size = ((System.Drawing.Size)(resources.GetObject("uiTabPage2.Size")));
			this.uiTabPage2.TabIndex = ((int)(resources.GetObject("uiTabPage2.TabIndex")));
			this.uiTabPage2.TabVisible = ((bool)(resources.GetObject("uiTabPage2.TabVisible")));
			this.uiTabPage2.Text = resources.GetString("uiTabPage2.Text");
			this.uiTabPage2.ToolTipText = resources.GetString("uiTabPage2.ToolTipText");
			this.uiTabPage2.Visible = ((bool)(resources.GetObject("uiTabPage2.Visible")));
			// 
			// uiTabPage3
			// 
			this.uiTabPage3.AccessibleDescription = resources.GetString("uiTabPage3.AccessibleDescription");
			this.uiTabPage3.AccessibleName = resources.GetString("uiTabPage3.AccessibleName");
			this.uiTabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("uiTabPage3.Anchor")));
			this.uiTabPage3.AutoScroll = ((bool)(resources.GetObject("uiTabPage3.AutoScroll")));
			this.uiTabPage3.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("uiTabPage3.AutoScrollMargin")));
			this.uiTabPage3.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("uiTabPage3.AutoScrollMinSize")));
			this.uiTabPage3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiTabPage3.BackgroundImage")));
			this.uiTabPage3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("uiTabPage3.Dock")));
			this.uiTabPage3.Enabled = ((bool)(resources.GetObject("uiTabPage3.Enabled")));
			this.uiTabPage3.Font = ((System.Drawing.Font)(resources.GetObject("uiTabPage3.Font")));
			this.uiTabPage3.Icon = ((System.Drawing.Icon)(resources.GetObject("uiTabPage3.Icon")));
			this.uiTabPage3.Image = ((System.Drawing.Image)(resources.GetObject("uiTabPage3.Image")));
			this.uiTabPage3.ImageIndex = ((int)(resources.GetObject("uiTabPage3.ImageIndex")));
			this.uiTabPage3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("uiTabPage3.ImeMode")));
			this.uiTabPage3.Location = ((System.Drawing.Point)(resources.GetObject("uiTabPage3.Location")));
			this.uiTabPage3.Name = "uiTabPage3";
			this.uiTabPage3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("uiTabPage3.RightToLeft")));
			this.uiTabPage3.Size = ((System.Drawing.Size)(resources.GetObject("uiTabPage3.Size")));
			this.uiTabPage3.TabIndex = ((int)(resources.GetObject("uiTabPage3.TabIndex")));
			this.uiTabPage3.TabVisible = ((bool)(resources.GetObject("uiTabPage3.TabVisible")));
			this.uiTabPage3.Text = resources.GetString("uiTabPage3.Text");
			this.uiTabPage3.ToolTipText = resources.GetString("uiTabPage3.ToolTipText");
			this.uiTabPage3.Visible = ((bool)(resources.GetObject("uiTabPage3.Visible")));
			// 
			// uiTabPage4
			// 
			this.uiTabPage4.AccessibleDescription = resources.GetString("uiTabPage4.AccessibleDescription");
			this.uiTabPage4.AccessibleName = resources.GetString("uiTabPage4.AccessibleName");
			this.uiTabPage4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("uiTabPage4.Anchor")));
			this.uiTabPage4.AutoScroll = ((bool)(resources.GetObject("uiTabPage4.AutoScroll")));
			this.uiTabPage4.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("uiTabPage4.AutoScrollMargin")));
			this.uiTabPage4.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("uiTabPage4.AutoScrollMinSize")));
			this.uiTabPage4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiTabPage4.BackgroundImage")));
			this.uiTabPage4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("uiTabPage4.Dock")));
			this.uiTabPage4.Enabled = ((bool)(resources.GetObject("uiTabPage4.Enabled")));
			this.uiTabPage4.Font = ((System.Drawing.Font)(resources.GetObject("uiTabPage4.Font")));
			this.uiTabPage4.Icon = ((System.Drawing.Icon)(resources.GetObject("uiTabPage4.Icon")));
			this.uiTabPage4.Image = ((System.Drawing.Image)(resources.GetObject("uiTabPage4.Image")));
			this.uiTabPage4.ImageIndex = ((int)(resources.GetObject("uiTabPage4.ImageIndex")));
			this.uiTabPage4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("uiTabPage4.ImeMode")));
			this.uiTabPage4.Location = ((System.Drawing.Point)(resources.GetObject("uiTabPage4.Location")));
			this.uiTabPage4.Name = "uiTabPage4";
			this.uiTabPage4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("uiTabPage4.RightToLeft")));
			this.uiTabPage4.Size = ((System.Drawing.Size)(resources.GetObject("uiTabPage4.Size")));
			this.uiTabPage4.TabIndex = ((int)(resources.GetObject("uiTabPage4.TabIndex")));
			this.uiTabPage4.TabVisible = ((bool)(resources.GetObject("uiTabPage4.TabVisible")));
			this.uiTabPage4.Text = resources.GetString("uiTabPage4.Text");
			this.uiTabPage4.ToolTipText = resources.GetString("uiTabPage4.ToolTipText");
			this.uiTabPage4.Visible = ((bool)(resources.GetObject("uiTabPage4.Visible")));
			// 
			// uiTabPage5
			// 
			this.uiTabPage5.AccessibleDescription = resources.GetString("uiTabPage5.AccessibleDescription");
			this.uiTabPage5.AccessibleName = resources.GetString("uiTabPage5.AccessibleName");
			this.uiTabPage5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("uiTabPage5.Anchor")));
			this.uiTabPage5.AutoScroll = ((bool)(resources.GetObject("uiTabPage5.AutoScroll")));
			this.uiTabPage5.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("uiTabPage5.AutoScrollMargin")));
			this.uiTabPage5.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("uiTabPage5.AutoScrollMinSize")));
			this.uiTabPage5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiTabPage5.BackgroundImage")));
			this.uiTabPage5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("uiTabPage5.Dock")));
			this.uiTabPage5.Enabled = ((bool)(resources.GetObject("uiTabPage5.Enabled")));
			this.uiTabPage5.Font = ((System.Drawing.Font)(resources.GetObject("uiTabPage5.Font")));
			this.uiTabPage5.Icon = ((System.Drawing.Icon)(resources.GetObject("uiTabPage5.Icon")));
			this.uiTabPage5.Image = ((System.Drawing.Image)(resources.GetObject("uiTabPage5.Image")));
			this.uiTabPage5.ImageIndex = ((int)(resources.GetObject("uiTabPage5.ImageIndex")));
			this.uiTabPage5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("uiTabPage5.ImeMode")));
			this.uiTabPage5.Location = ((System.Drawing.Point)(resources.GetObject("uiTabPage5.Location")));
			this.uiTabPage5.Name = "uiTabPage5";
			this.uiTabPage5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("uiTabPage5.RightToLeft")));
			this.uiTabPage5.Size = ((System.Drawing.Size)(resources.GetObject("uiTabPage5.Size")));
			this.uiTabPage5.TabIndex = ((int)(resources.GetObject("uiTabPage5.TabIndex")));
			this.uiTabPage5.TabVisible = ((bool)(resources.GetObject("uiTabPage5.TabVisible")));
			this.uiTabPage5.Text = resources.GetString("uiTabPage5.Text");
			this.uiTabPage5.ToolTipText = resources.GetString("uiTabPage5.ToolTipText");
			this.uiTabPage5.Visible = ((bool)(resources.GetObject("uiTabPage5.Visible")));
			// 
			// uiTabPage6
			// 
			this.uiTabPage6.AccessibleDescription = resources.GetString("uiTabPage6.AccessibleDescription");
			this.uiTabPage6.AccessibleName = resources.GetString("uiTabPage6.AccessibleName");
			this.uiTabPage6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("uiTabPage6.Anchor")));
			this.uiTabPage6.AutoScroll = ((bool)(resources.GetObject("uiTabPage6.AutoScroll")));
			this.uiTabPage6.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("uiTabPage6.AutoScrollMargin")));
			this.uiTabPage6.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("uiTabPage6.AutoScrollMinSize")));
			this.uiTabPage6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiTabPage6.BackgroundImage")));
			this.uiTabPage6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("uiTabPage6.Dock")));
			this.uiTabPage6.Enabled = ((bool)(resources.GetObject("uiTabPage6.Enabled")));
			this.uiTabPage6.Font = ((System.Drawing.Font)(resources.GetObject("uiTabPage6.Font")));
			this.uiTabPage6.Icon = ((System.Drawing.Icon)(resources.GetObject("uiTabPage6.Icon")));
			this.uiTabPage6.Image = ((System.Drawing.Image)(resources.GetObject("uiTabPage6.Image")));
			this.uiTabPage6.ImageIndex = ((int)(resources.GetObject("uiTabPage6.ImageIndex")));
			this.uiTabPage6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("uiTabPage6.ImeMode")));
			this.uiTabPage6.Location = ((System.Drawing.Point)(resources.GetObject("uiTabPage6.Location")));
			this.uiTabPage6.Name = "uiTabPage6";
			this.uiTabPage6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("uiTabPage6.RightToLeft")));
			this.uiTabPage6.Size = ((System.Drawing.Size)(resources.GetObject("uiTabPage6.Size")));
			this.uiTabPage6.TabIndex = ((int)(resources.GetObject("uiTabPage6.TabIndex")));
			this.uiTabPage6.TabVisible = ((bool)(resources.GetObject("uiTabPage6.TabVisible")));
			this.uiTabPage6.Text = resources.GetString("uiTabPage6.Text");
			this.uiTabPage6.ToolTipText = resources.GetString("uiTabPage6.ToolTipText");
			this.uiTabPage6.Visible = ((bool)(resources.GetObject("uiTabPage6.Visible")));
			// 
			// uiTabPage7
			// 
			this.uiTabPage7.AccessibleDescription = resources.GetString("uiTabPage7.AccessibleDescription");
			this.uiTabPage7.AccessibleName = resources.GetString("uiTabPage7.AccessibleName");
			this.uiTabPage7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("uiTabPage7.Anchor")));
			this.uiTabPage7.AutoScroll = ((bool)(resources.GetObject("uiTabPage7.AutoScroll")));
			this.uiTabPage7.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("uiTabPage7.AutoScrollMargin")));
			this.uiTabPage7.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("uiTabPage7.AutoScrollMinSize")));
			this.uiTabPage7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiTabPage7.BackgroundImage")));
			this.uiTabPage7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("uiTabPage7.Dock")));
			this.uiTabPage7.Enabled = ((bool)(resources.GetObject("uiTabPage7.Enabled")));
			this.uiTabPage7.Font = ((System.Drawing.Font)(resources.GetObject("uiTabPage7.Font")));
			this.uiTabPage7.Icon = ((System.Drawing.Icon)(resources.GetObject("uiTabPage7.Icon")));
			this.uiTabPage7.Image = ((System.Drawing.Image)(resources.GetObject("uiTabPage7.Image")));
			this.uiTabPage7.ImageIndex = ((int)(resources.GetObject("uiTabPage7.ImageIndex")));
			this.uiTabPage7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("uiTabPage7.ImeMode")));
			this.uiTabPage7.Location = ((System.Drawing.Point)(resources.GetObject("uiTabPage7.Location")));
			this.uiTabPage7.Name = "uiTabPage7";
			this.uiTabPage7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("uiTabPage7.RightToLeft")));
			this.uiTabPage7.Size = ((System.Drawing.Size)(resources.GetObject("uiTabPage7.Size")));
			this.uiTabPage7.TabIndex = ((int)(resources.GetObject("uiTabPage7.TabIndex")));
			this.uiTabPage7.TabVisible = ((bool)(resources.GetObject("uiTabPage7.TabVisible")));
			this.uiTabPage7.Text = resources.GetString("uiTabPage7.Text");
			this.uiTabPage7.ToolTipText = resources.GetString("uiTabPage7.ToolTipText");
			this.uiTabPage7.Visible = ((bool)(resources.GetObject("uiTabPage7.Visible")));
			// 
			// tbCases
			// 
			this.tbCases.AccessibleDescription = resources.GetString("tbCases.AccessibleDescription");
			this.tbCases.AccessibleName = resources.GetString("tbCases.AccessibleName");
			this.tbCases.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tbCases.Anchor")));
			this.tbCases.Appearance = ((System.Windows.Forms.ToolBarAppearance)(resources.GetObject("tbCases.Appearance")));
			this.tbCases.AutoSize = ((bool)(resources.GetObject("tbCases.AutoSize")));
			this.tbCases.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbCases.BackgroundImage")));
			this.tbCases.ButtonSize = ((System.Drawing.Size)(resources.GetObject("tbCases.ButtonSize")));
			this.tbCases.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tbCases.Dock")));
			this.tbCases.DropDownArrows = ((bool)(resources.GetObject("tbCases.DropDownArrows")));
			this.tbCases.Enabled = ((bool)(resources.GetObject("tbCases.Enabled")));
			this.tbCases.Font = ((System.Drawing.Font)(resources.GetObject("tbCases.Font")));
			this.tbCases.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tbCases.ImeMode")));
			this.tbCases.Location = ((System.Drawing.Point)(resources.GetObject("tbCases.Location")));
			this.tbCases.Name = "tbCases";
			this.tbCases.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tbCases.RightToLeft")));
			this.tbCases.ShowToolTips = ((bool)(resources.GetObject("tbCases.ShowToolTips")));
			this.tbCases.Size = ((System.Drawing.Size)(resources.GetObject("tbCases.Size")));
			this.tbCases.TabIndex = ((int)(resources.GetObject("tbCases.TabIndex")));
			this.tbCases.TextAlign = ((System.Windows.Forms.ToolBarTextAlign)(resources.GetObject("tbCases.TextAlign")));
			this.tbCases.Visible = ((bool)(resources.GetObject("tbCases.Visible")));
			this.tbCases.Wrappable = ((bool)(resources.GetObject("tbCases.Wrappable")));
			// 
			// MainForm
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.tbCases);
			this.Controls.Add(this.uiTab1);
			this.Controls.Add(this.toolBox1);
			this.Controls.Add(this.toolBar1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Menu = this.mainMenu1;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "MainForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
			this.uiTab1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			#region Initializing
			arrPaths = new string[2];
			MainForm.arrPaths[0]=System.IO.Path.GetTempFileName();
			MainForm.arrPaths[1]=System.IO.Path.GetTempFileName();
			bLarge=false;
			arrRectangles=new Rectangle[31];
			arrRectsStatus=new bool [31];
			arrTextsSpecial=new TextBox[31];
			arrTextsRange=new TextBox[3];
			arrPanels=new Panel[2];
			rbRange=new RadioButton();
			rbSpecial=new RadioButton();
			btnAddCases=new Button();
			lblCases=new Label();
			lblNumbers=new Label();
			lblCases1=new Label();
			lblNumbers1=new Label();
			lblFrom=new Label();
			lblTo=new Label();;
			lblNumberOf=new Label();
			int xCounter=30;
			for(int i=0;i<31;i++)
			{
				arrRectangles[i]=new Rectangle(xCounter,10,15,10);
				
				arrTextsSpecial[i]=new TextBox();
				arrTextsSpecial[i].BorderStyle=BorderStyle.FixedSingle;
				arrTextsSpecial[i].Size=new Size(15,10);
				arrTextsSpecial[i].Multiline=true;
				arrTextsSpecial[i].Font=new Font("Tahoma",6);
				arrTextsSpecial[i].Location=new Point(xCounter,25);xCounter+=20;
			}
			for(int i=0;i<3;i++)
			{
				
				arrTextsRange[i]=new TextBox();
				arrTextsRange[i].BorderStyle=BorderStyle.FixedSingle;
				arrTextsRange[i].Size=new Size(25,15);
				arrTextsRange[i].Multiline=true;
				arrTextsRange[i].Font=new Font("Tahoma",8);
				
			}
			arrTextsRange[0].Location=new Point(500,22);
			arrTextsRange[1].Location=new Point(570,22);
			arrTextsRange[2].Location=new Point(620,22);
			//rbRange
			rbRange.Text="»’Ê—  »«“Â «Ì";
			rbRange.Checked=true;
			rbRange.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			rbRange.Location=new Point(850,0);
			rbRange.ForeColor=Color.DarkOliveGreen;
			rbRange.Size=new Size(100,15);
			rbRange.TextAlign=ContentAlignment.MiddleCenter;
			rbRange.CheckedChanged+=new EventHandler(rbRange_CheckChange);
			//rbSpecial
			rbSpecial.Text="»’Ê—  »Œ’Ê’";
			rbSpecial.Checked=false;
			rbSpecial.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			rbSpecial.Location=new Point(850,25);
			rbSpecial.ForeColor=Color.DarkOliveGreen;
			rbSpecial.Size=new Size(100,15);
			rbSpecial.TextAlign=ContentAlignment.MiddleCenter;
			rbSpecial.CheckedChanged+=new EventHandler(rbSpecial_CheckChange);
			//lblFrom
			lblFrom.Text="«“:";
			lblFrom.AutoSize=true;
			lblFrom.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			lblFrom.Location=new Point(640,22);
			lblFrom.ForeColor=Color.DarkOliveGreen;
			lblFrom.TextAlign=ContentAlignment.MiddleCenter;
			//lblTo
			lblTo.Text=" «";
			lblTo.AutoSize=true;
			lblTo.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			lblTo.Location=new Point(600,22);
			lblTo.ForeColor=Color.DarkOliveGreen;
			lblTo.TextAlign=ContentAlignment.MiddleCenter;
			//lblNumberOf
			lblNumberOf.Text="»Â  ⁄œ«œ:";
			lblNumberOf.AutoSize=true;
			lblNumberOf.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			lblNumberOf.Location=new Point(525,22);
			lblNumberOf.ForeColor=Color.DarkOliveGreen;
			lblNumberOf.TextAlign=ContentAlignment.MiddleCenter;
			//lblCases
			lblCases.Text="ê“Ì‰Â Â«:";
			lblCases.AutoSize=true;
			lblCases.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			lblCases.Location=new Point(670,0);
			lblCases.ForeColor=Color.DarkOliveGreen;
			lblCases.TextAlign=ContentAlignment.MiddleCenter;
			//lblNumbers
			lblNumbers.Text="‘„«—Â ê“Ì‰Â Â«:";
			lblNumbers.AutoSize=true;
			lblNumbers.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			lblNumbers.Location=new Point(670,20);
			lblNumbers.ForeColor=Color.DarkOliveGreen;
			lblNumbers.TextAlign=ContentAlignment.MiddleCenter;
			//lblCases1
			lblCases1.Text="ê“Ì‰Â Â«:";
			lblCases1.AutoSize=true;
			lblCases1.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			lblCases1.Location=new Point(670,0);
			lblCases1.ForeColor=Color.DarkOliveGreen;
			lblCases1.TextAlign=ContentAlignment.MiddleCenter;
			//lblNumbers1
			lblNumbers1.Text="‘„«—Â ê“Ì‰Â Â«:";
			lblNumbers1.AutoSize=true;
			lblNumbers1.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			lblNumbers1.Location=new Point(670,20);
			lblNumbers1.ForeColor=Color.DarkOliveGreen;
			lblNumbers1.TextAlign=ContentAlignment.MiddleCenter;
			//Panels
			arrPanels[0]=new Panel();
			arrPanels[0].Size=new Size(750,42);
			arrPanels[0].Left=45;
			arrPanels[0].Visible=false;
			arrPanels[0].Paint+=new PaintEventHandler(arrPanels_Paint);
			arrPanels[0].MouseDown+=new MouseEventHandler(arrPanels_MouseDown);
			arrPanels[1]=new Panel();
			arrPanels[1].Size=new Size(750,42);
			arrPanels[1].Left=45;
			arrPanels[1].Paint+=new PaintEventHandler(arrPanels_Paint);
			arrPanels[1].MouseDown+=new MouseEventHandler(arrPanels_MouseDown);
			//btnAddCases
			btnAddCases.Text="«÷«›Â";
			btnAddCases.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			btnAddCases.Location=new Point(5,20);
			btnAddCases.ForeColor=Color.DarkOliveGreen;
			btnAddCases.Size=new Size(40,20);
			btnAddCases.TextAlign=ContentAlignment.MiddleCenter;
			btnAddCases.Click+=new EventHandler(btnAddCases_Click);
			frmFormView=new FormView();
			frmFormView.MdiParent=this;
			frmFormView.BackColor=Color.FromArgb(228,226,214);
			frmFormView.Show();
			//l1parent
			l1Parent=new Label();
			l1Parent.Size=new Size(200,40);
			l1Parent.BorderStyle=BorderStyle.FixedSingle;
			l1Parent.Text="›Ê‰  Tohoma »« «‰œ«“Â 8.25";l1Parent.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			l1Parent.ForeColor=Color.DarkOliveGreen;
			l1Parent.TextAlign=ContentAlignment.BottomRight;
			l1Parent.Left=600;
			//l1
			l1=new Label();
			l1.Size=new Size(40,20);
			l1.Text="›Ê‰ :";
			l1.Click+=new EventHandler(l1_Click);
			l1.RightToLeft=System.Windows.Forms.RightToLeft.Yes;
			l1.Left=150;
			l1.Cursor=Cursors.Hand;
			//l2
			l2=new Label();
			l2.Size=new Size(70,20);
			l2.Text="Color Green";
			l2.Left=174;
			//l3
			l3=new Label();
			l3.Size=new Size(70,20);
			l3.Text="Color Blue";
			l3.Left=348;
			//l4
			l4=new Label();
			l4.Size=new Size(50,20);
			l4.Text="Opacity";
			l4.Left=522;
			//l5
			l5=new Label();
			l5.Size=new Size(70,20);
			l5.Text="«‰œ«“Â ﬁ·„Ê";
			l5.Left=40;
			l5.Top=10;
			//t1
			t1=new TrackBar();
			t1.Size=new Size(100,10);
			t1.Minimum=1;
			t1.Maximum=255;
			t1.Left=72;
			t1.Scroll+=new EventHandler(t1_scroll);
			//t2
			t2=new TrackBar();
			t2.Size=new Size(100,10);
			t2.Minimum=1;
			t2.Maximum=255;
			t2.Left=246;
			t2.Scroll+=new EventHandler(t2_scroll);
			//t3
			t3=new TrackBar();
			t3.Size=new Size(100,10);
			t3.Minimum=1;
			t3.Maximum=255;
			t3.Left=422;
			t3.Scroll+=new EventHandler(t3_scroll);
			//t4
			t4=new TrackBar();
			t4.Size=new Size(100,10);
			t4.Minimum=1;
			t4.Maximum=255;
			t4.Left=574;
			//t5
			t5=new TrackBar();
			t5.Size=new Size(500,10);
			t5.Minimum=1;
			t5.Maximum=500;
			t5.Left=100;
			//chkDash
			chkDash=new RadioButton ();
			chkDash.Font=new Font("Tahoma",8);
			chkDash.Text="—”„ »Â ’Ê—  ‰ﬁÿÂ-Œÿ";
			chkDash.Size=new Size(150,20);
			chkDash.Left=850;
			chkDash.RightToLeft=RightToLeft.Yes ;
			chkDash.Top=2;
			chkDash.CheckedChanged +=new EventHandler(chkDash_change);
			//chkSolid
			chkSolid=new RadioButton ();
			chkSolid.Text="—”„ »Â ’Ê—  ”«œÂ";
			chkSolid.Font=new Font("Tahoma",8);
			chkSolid.Size=new Size(150,20);
			chkSolid.Left=850;
			chkSolid.Checked=true;
			chkSolid.RightToLeft=RightToLeft.Yes ;
			chkSolid.Top=22;
			chkSolid.CheckedChanged+=new EventHandler(chkSolid_change);
			////////////
		    t5.Scroll+=new EventHandler(t5_scroll);
			t4.Scroll+=new EventHandler(t4_scroll);
			t3.Scroll+=new EventHandler(t3_scroll);
			t2.Scroll+=new EventHandler(t2_scroll);
			t1.Scroll+=new EventHandler(t1_scroll);
			l1Parent.Controls.Add(l1);
			
			toolBar1.Controls.Add(l1Parent);//toolBar1.Controls.Add(t1);
			//toolBar1.Controls.Add(l2);toolBar1.Controls.Add(t2);
			//toolBar1.Controls.Add(l3);toolBar1.Controls.Add(t3);
			//toolBar1.Controls.Add(l4);toolBar1.Controls.Add(t4);
			toolBar1.Controls.Add(l5);toolBar1.Controls.Add(t5);
			toolBar1.Controls.Add(chkSolid);toolBar1.Controls.Add(chkDash );
			t5.Value=1;
			PictureView.BrushWidth=1;
			
			//tbCases
			tbCases.Controls.Add(btnAddCases );
			tbCases.Controls.AddRange(arrPanels );
			tbCases.Controls.Add(rbRange  );
			tbCases.Controls.Add(rbSpecial  );
			arrPanels[0].Controls.Add(lblCases );arrPanels[0].Controls.Add(lblNumbers );
			arrPanels[1].Controls.Add(lblCases1 );arrPanels[1].Controls.Add(lblNumbers1 );
			for(int i=0;i<31;i++)
			{
				arrPanels[0].Controls.Add(arrTextsSpecial[i]);
			}
			for(int i=0;i<3;i++)
			{
				arrPanels[1].Controls.Add(arrTextsRange[i]);
			}
			arrPanels[1].Controls.Add(lblNumberOf);
			arrPanels[1].Controls.Add(lblTo);
			arrPanels[1].Controls.Add(lblFrom);
			arrPanels[1].BringToFront();
			bRange=true;
			PictureView.bDash=false;
			#endregion

		}	
		bool IsNumber(string strIn)
		{
			char[]chDigits={'0','1','2','3','4','5','6','7','8','9'};
			if(strIn.IndexOfAny(chDigits,0,1)!=-1  && (strIn.Length==1 ||strIn.IndexOfAny(chDigits,1,1)!=-1 ))
				return true;
			else
				return false;
		}
		
		void btnAddCases_Click(object sender, System.EventArgs e)
		{
			int nSelectedCases=0;
			for(int i=0;i<31 ;i++)
			{
				if(arrRectsStatus[i])
				{
					nSelectedCases++;
				}
					
			}
			if(nSelectedCases==0)
			{
				MessageBox.Show("·ÿ›« Õœ«ﬁ· Ìò ê“Ì‰Â —« «‰ Œ«» ò‰Ìœ");
				return;
			}
			if(bRange )	
			{
				for(int i =arrTextsRange.Length -1 ;i>=0 ;i--)
				{
						if(arrTextsRange[i].Text =="" || (arrTextsRange[i].Text.Length >2 && IsNumber(arrTextsRange[i].Text)) )
						{
							if((arrTextsRange[i].Text !=""))
							{
								CreateCaret ( arrTextsRange[i].Handle ,(IntPtr.Zero ),30,20);
								SetCaretPos(0,0);
								ShowCaret( arrTextsRange[i].Handle);
								MessageBox.Show(" ⁄œ«œ «—ﬁ«„ œ— ﬁ”„   ⁄ÌÌ‰ ‘œÂ »«Ìœ Ìò Ì« œÊ —ﬁ„ »«‘œ");
							}
							else
							{
								CreateCaret ( arrTextsRange[i].Handle ,(IntPtr.Zero ),30,20);
								SetCaretPos(0,0);
								ShowCaret( arrTextsRange[i].Handle);
								MessageBox.Show(" ·ÿ›« ﬁ”„    ⁄ÌÌ‰ ‘œÂ —« ò«„· ‰„«ÌÌœ");
							}
							return;
						}
						else
						{
							if(!IsNumber(arrTextsRange[i].Text) )
							{
								CreateCaret ( arrTextsRange[i].Handle ,(IntPtr.Zero ),30,20);
								SetCaretPos(0,0);
								ShowCaret( arrTextsRange[i].Handle);
								MessageBox.Show(" ﬁ”„    ⁄ÌÌ‰ ‘œÂ »«Ìœ ›ﬁÿ ‘«„· ⁄œœ »«‘œ");
								return;
							}
						}
					
				}

				if(int.Parse(arrTextsRange[2].Text) > int.Parse(arrTextsRange[1].Text))
				{
					
					CreateCaret ( arrTextsRange[1].Handle ,(IntPtr.Zero ),30,20);
					SetCaretPos(0,0);
					ShowCaret( arrTextsRange[1].Handle);
					MessageBox.Show(" ‘„«—Â «Ê· œ— ﬁ”„  '«“' ‰»«Ìœ «“ ⁄œœ œÊ„ œ— ﬁ”„  ' «' òÊçò — Ì« „”«ÊÌ »«‘œ");
					return ;
				}
				if(int.Parse(arrTextsRange[0].Text)<=0)
				{
					CreateCaret ( arrTextsRange[0].Handle ,(IntPtr.Zero ),30,20);
					SetCaretPos(0,0);
					ShowCaret( arrTextsRange[0].Handle);
					MessageBox.Show(" ⁄œœÌ òÂ œ— ﬁ”„   ⁄Ì‰ ‘œÂ –ò— „Ì ‘Êœ »«Ìœ «“ ’›— »“—ê — »«‘œ");
					return ;
				}
				int numberOf= int.Parse(arrTextsRange[0].Text);
				int Dist=int.Parse(arrTextsRange[1].Text)- int.Parse(arrTextsRange[2].Text)+1;
				int counter=0;
				for(int i=0;i<31 ;i++)
				{
					if(arrRectsStatus[i])
						counter++;
				}
				if(Dist > counter)
				{
					MessageBox.Show("»«“Â –ò— ‘œÂ° »«  ⁄œ«œ ê“Ì‰Â Â«Ì «‰ Œ«» ‘œÂ Â„ŒÊ«‰Ì ‰œ«—œ");
					return ;
				}
				if(numberOf*Dist != counter)
				{
					MessageBox.Show("  ⁄œ«œ –ò— ‘œÂ œ— ﬁ”„  '»Â  ⁄œ«œ' »«  ÊÃÂ »Â »«“Â –ò— ‘œÂ° »«  ⁄œ«œ ê“Ì‰Â Â«Ì «‰ Œ«» ‘œÂ Â„ŒÊ«‰Ì ‰œ«—œ");
					return ;
				}
				int xCounter=15;
				PictureView.PastbmpOriginal=new Bitmap(825,15);
				PictureView.PastbmpOriginal.SetResolution(100,100);
				Graphics g=Graphics.FromImage(PictureView.PastbmpOriginal);
				if(!bLarge )
					g.FillRectangle(new SolidBrush(Color.Black ),xCounter+3,1,20,8);
				else
					g.FillRectangle(new SolidBrush(Color.Black ),xCounter+3,1,20,12);
				xCounter+=24;
				int numberCounter=int.Parse(arrTextsRange[2].Text);
				int columnDist=40;
				Font font=new Font("Tahoma",6);
				string strTemp="",strNumber="";
				for(int i=0;i<31 ;i++)
				{
					if( i>0 && i%5==0 ){xCounter=columnDist+118;columnDist=xCounter;}
					if(arrRectsStatus[i])
					{
						GraphicsPath gp;
						strNumber="";
						strTemp=numberCounter.ToString();
						strNumber+=((char)(int.Parse(strTemp[0].ToString())+1632)).ToString();
						if(strTemp.Length==2)
							strNumber+=((char)(int.Parse(strTemp[1].ToString())+1632)).ToString();
						if(!bLarge )
						{
							CreateRoundRect(new Rectangle(xCounter,1,12,4),out gp,new Size(7,7));
							g.DrawPath(new Pen( PictureView.selectedColor ),gp);
							g.DrawString(strNumber,font ,new SolidBrush(ToolBox.colorLeft),xCounter+7,1);
						}
						else
						{
							CreateRoundRect(new Rectangle(xCounter,1,12,7),out gp,new Size(7,7));
							g.DrawPath(new Pen( PictureView.selectedColor ),gp);
							g.DrawString(strNumber,font ,new SolidBrush(ToolBox.colorLeft),xCounter+7,2);
						}
						
						numberCounter++;
						if(numberCounter == (int.Parse(arrTextsRange[2].Text)+Dist) )numberCounter =int.Parse(arrTextsRange[2].Text);
					}
					xCounter+=24;					
				}			
				if(!bLarge )
					g.FillRectangle(new SolidBrush(Color.Black ),782,1,20,8);
				else
					g.FillRectangle(new SolidBrush(Color.Black ),782,1,20,12);
				PictureView.PastPicture();
				Refresh();
				PictureView.selectedObj=25;
			}
			else
			{
				for(int i = 0 ;i<arrTextsSpecial.Length ;i++)
				{
					if(arrRectsStatus[i])
					{
						if(arrTextsSpecial[i].Text =="" || (arrTextsSpecial[i].Text.Length >2 && IsNumber(arrTextsSpecial[i].Text)) )
						{
							if((arrTextsSpecial[i].Text !=""))
							{
								CreateCaret ( arrTextsSpecial[i].Handle ,(IntPtr.Zero ),20,20);
								SetCaretPos(0,0);
								ShowCaret( arrTextsSpecial[i].Handle);
								MessageBox.Show(" ⁄œ«œ «—ﬁ«„ œ— ﬁ”„   ⁄ÌÌ‰ ‘œÂ »«Ìœ Ìò Ì« œÊ —ﬁ„ »«‘œ");
							}
							else
							{
								CreateCaret ( arrTextsSpecial[i].Handle ,(IntPtr.Zero ),20,20);
								SetCaretPos(0,0);
								ShowCaret( arrTextsSpecial[i].Handle);
								MessageBox.Show(" ·ÿ›« ﬁ”„    ⁄ÌÌ‰ ‘œÂ —« ò«„· ‰„«ÌÌœ");
							}
							return;
						}
						else
						{
							if(!IsNumber(arrTextsSpecial[i].Text) )
							{
								CreateCaret ( arrTextsSpecial[i].Handle ,(IntPtr.Zero ),20,20);
								SetCaretPos(0,0);
								ShowCaret( arrTextsSpecial[i].Handle);
								MessageBox.Show(" ﬁ”„    ⁄ÌÌ‰ ‘œÂ »«Ìœ ›ﬁÿ ‘«„· ⁄œœ »«‘œ");
								return;
							}
						}
					}
				}
				int xCounter=15;
				PictureView.PastbmpOriginal=new Bitmap(825,15);
				PictureView.PastbmpOriginal.SetResolution(100,100);
				Graphics g=Graphics.FromImage(PictureView.PastbmpOriginal);
				if(!bLarge )
					g.FillRectangle(new SolidBrush(Color.Black ),xCounter+3,1,20,8);
				else
					g.FillRectangle(new SolidBrush(Color.Black ),xCounter+3,1,20,12);
				
				xCounter+=24;
				int columnDist=40;
				Font font=new Font("Tahoma",6);
				string strTemp="",strNumber="";
				for(int i=0;i<31 ;i++)
				{
					if( i>0 && i%5==0 ){xCounter=columnDist+118;columnDist=xCounter;}
					if(arrRectsStatus[i])
					{
						GraphicsPath gp;
						strNumber="";
						strTemp=arrTextsSpecial[i].Text ;
						strNumber+=((char)(int.Parse(strTemp[0].ToString())+1632)).ToString();
						if(strTemp.Length==2)
							strNumber+=((char)(int.Parse(strTemp[1].ToString())+1632)).ToString();
						if(!bLarge )
						{
							CreateRoundRect(new Rectangle(xCounter,1,12,4),out gp,new Size(7,7));
							g.DrawPath(new Pen( PictureView.selectedColor ),gp);
							g.DrawString(strNumber,font ,new SolidBrush(ToolBox.colorLeft),xCounter+7,1);
						}
						else
						{
							CreateRoundRect(new Rectangle(xCounter,1,12,7),out gp,new Size(7,7));
							g.DrawPath(new Pen( PictureView.selectedColor ),gp);
							g.DrawString(strNumber,font ,new SolidBrush(ToolBox.colorLeft),xCounter+7,2);
						}						
					}
					xCounter+=24;					
				}			
				if(!bLarge )
					g.FillRectangle(new SolidBrush(Color.Black ),782,1,20,8);
				else
				   g.FillRectangle(new SolidBrush(Color.Black ),782,1,20,12);
				PictureView.PastPicture();
				Refresh();
				PictureView.selectedObj=25;
			}
		}
		void CreateRoundRect(Rectangle rect,out GraphicsPath gp,Size size)
		{
			gp=new GraphicsPath();
			int x1=rect.X ,x2=rect.X+rect.Width ,y1=rect.Y ,y2=rect.Y+rect.Height ;
			if(rect.Width<21)
			{
				size.Width=(int)(Math.Ceiling(rect.Width/3.0));
				if(size.Width==0)size.Width=1;
			}
			if(rect.Height<21)
			{
				size.Height=(int)(Math.Ceiling( rect.Height/3.0));
				if(size.Height==0)size.Height=1;
			}
			gp.AddLine(x1,y1+size.Height ,x1,y2-size.Height );
			
			gp.AddArc(x1, y2,size.Width*2 ,size.Height*2 ,-180,-90);
			gp.AddLine(x1+size.Width ,y2+size.Height*2,x2-size.Width*2 ,y2+size.Height*2);
			gp.AddArc(x2, y2,size.Width*2 ,size.Height*2 ,90,-90);
			gp.AddLine(x2+size.Width*2,y2-size.Height ,x2+size.Width*2,y1+size.Height );
			gp.AddArc(x2, y1,size.Width*2 ,size.Height*2 ,0,-90);
			gp.AddLine(x2-size.Width ,y1,x1+size.Width ,y1);
			gp.AddArc(x1, y1,size.Width*2 ,size.Height*2 ,-90,-91);
			//gp.AddArc(10,10,100,100,180,0);
		}
		void arrPanels_MouseDown(object sender, System.Windows.Forms.MouseEventArgs  e)
		{
			Panel panel=(Panel)sender;
			bool bExist=false;
			for(int i=0;i<31;i++)
			{
				if(arrRectangles[i].Contains(new Point(e.X,e.Y )))
				{
					arrRectsStatus[i]=!arrRectsStatus[i];
					bExist=true;
					break;
				}
			}
			if(bExist)panel.Refresh();
			
		}
		void arrPanels_Paint(object sender, System.Windows.Forms.PaintEventArgs  e)
		{
			Panel panel=(Panel)sender;
			Graphics g=panel.CreateGraphics();
			for(int i=0;i<31;i++)
			{
				if(arrRectsStatus[i])
				{
					g.FillRectangle(new SolidBrush(Color.Black ),arrRectangles[i]);
				}
				else
				{
					g.FillRectangle(new SolidBrush(Color.White ),arrRectangles[i]);
				}
			}
			
		}
		void rbRange_CheckChange(object sender, System.EventArgs e)
		{
			arrPanels[1].BringToFront();
			bRange=true;
		}
		void rbSpecial_CheckChange(object sender, System.EventArgs e)
		{
			if(arrPanels[0].Visible==false)arrPanels[0].Visible=true;
			arrPanels[0].BringToFront();
			bRange=false;
		}

		private void l1_Click(object sender, System.EventArgs e)
		{
			FontDialog fd=new FontDialog();
			fd.Font =PictureView.TextFont;
			if(fd.ShowDialog()==DialogResult.OK )
			{
				PictureView.TextFont=fd.Font;
				PictureView.text.Font=fd.Font;
				l1Parent.Text="›Ê‰  "+fd.Font.FontFamily.Name  +" »« «‰œ«“Â "+fd.Font.Size ;
			}
		}
		private void t1_scroll(object sender, System.EventArgs e)
		{
			PictureView.BrushColor=Color.FromArgb(t4.Value,t1.Value,t2.Value,t3.Value );
		}
		private void t2_scroll(object sender, System.EventArgs e)
		{
			PictureView.BrushColor=Color.FromArgb(t4.Value,t1.Value,t2.Value,t3.Value );
		}
		private void t3_scroll(object sender, System.EventArgs e)
		{
			PictureView.BrushColor=Color.FromArgb(t4.Value,t1.Value,t2.Value,t3.Value );
		}
		private void t4_scroll(object sender, System.EventArgs e)
		{
			PictureView.BrushColor=Color.FromArgb(t4.Value,t1.Value,t2.Value,t3.Value );
		}
		private void t5_scroll(object sender, System.EventArgs e)
		{
			PictureView.BrushWidth=t5.Value;
		}



		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.OpenFileDialog op=new OpenFileDialog();
				DialogResult r= op.ShowDialog();
				if(r==DialogResult.OK )
				{
					PictureView.BMP=new Bitmap(op.FileName);
					PictureView.This.SetBitmap();
				}
			}
			catch(Exception ex){}
			
		}

		private void menuItem2_Click_1(object sender, System.EventArgs e)
		{
			Bitmap bmpNew= new Bitmap(825,1180);;
			bmpNew.SetResolution(100,100);
			Graphics.FromImage(bmpNew).FillRectangle(new SolidBrush(Color.White ),new Rectangle(0,0,825,1180));
			FormView.pictureBox1.Image=bmpNew;						
			PictureView.BMP=bmpNew;
			PictureView.This.SetBitmap();
		}

		

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
		
		}
		
		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.SaveFileDialog op=new SaveFileDialog ();
				DialogResult r= op.ShowDialog();
				if(r==DialogResult.OK )
				{
					FormView.pictureBox1.Image.Save(op.FileName );
				}
			}
			catch(Exception ex){}
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			frmFormView.Hide();
			
		}
		private void chkDash_change(object sender, System.EventArgs e)
		{
			
			PictureView.bDash =true;
		}
		private void chkSolid_change(object sender, System.EventArgs e)
		{
			
			PictureView.bDash =false;
		}
		private void menuItem126_Click(object sender, System.EventArgs e)
		{
			frmFormView.Show();
		}

		private void menuItem21_Click(object sender, System.EventArgs e)
		{
			try
			{
				string path=System.IO.Path.GetTempFileName();
			
				Clipboard.ClipboardImageClass cb=new CLIPBOARDTASKSLib.ClipboardImageClass();
				cb.GetImageFromClipboard(path);
				PictureView.PastbmpOriginal=new Bitmap(path);
				PictureView.PastPicture();
				Refresh();
				PictureView.selectedObj=25;
				
			}
			catch(Exception ex){}
		}

		private void mnuSmall_Click(object sender, System.EventArgs e)
		{
			bLarge=false;
			mnuSmall.Checked=true;
			mnuLarge.Checked=false;
		}

		private void mnuLarge_Click(object sender, System.EventArgs e)
		{
			bLarge=true;
			mnuSmall.Checked=false;
			mnuLarge.Checked=true;
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			mnuVer.Checked=!mnuVer.Checked;
			PictureView.bVertical=mnuVer.Checked;
		}

		private void mnuFarsiNumber_Click(object sender, System.EventArgs e)
		{
			mnuFarsiNumber.Checked=!mnuFarsiNumber.Checked;
			PictureView.bFarsiNumber=mnuFarsiNumber.Checked;
		}



		private void mnuUndo_Click(object sender, System.EventArgs e)
		{
			if(arrPaths[0]!= "")
			{
				MainForm.arrPaths[1]=System.IO.Path.GetTempFileName();PictureView.bmpOriginal.Save(MainForm.arrPaths[1]);
				PictureView.TextbmpOriginal =new Bitmap(arrPaths[0]);
				PictureView.TextbmpOriginal.SetResolution(100,100);
				PictureView.BMP=(Bitmap)PictureView.TextbmpOriginal.Clone();
				PictureView.This.SetBitmap();						
				arrPaths[0]="";
				mnuUndo.Enabled=false;
				PictureView. stampSelected=false;
				PictureView. controlStepMouseDown =false;
				PictureView.TextIsReset=false;
				PictureView.FinishRect=false;
				PictureView.bTextFinish=false;
				PictureView.selectedObj=0;PictureView.selectedCursor=Cursors.Default;
				toolBox1.toolBar1.Buttons[0].Pushed=true;
				toolBox1.toolBar1.Buttons[toolBox1.SelectedIndex].Pushed=false;
				FormView.pictureBox1.Cursor=Cursors.Default;
				mnuRedo.Enabled=true;
			}
		}
		private void mnuRedo_Click(object sender, System.EventArgs e)
		{
			if(arrPaths[1]!= "")
			{
				MainForm.arrPaths[0]=System.IO.Path.GetTempFileName();PictureView.TextbmpOriginal.Save(MainForm.arrPaths[0]);
				PictureView.TextbmpOriginal =new Bitmap(arrPaths[1]);
				PictureView.TextbmpOriginal.SetResolution(100,100);
				PictureView.BMP=(Bitmap)PictureView.TextbmpOriginal.Clone();
				PictureView.This.SetBitmap();								
				arrPaths[1]="";
				mnuRedo.Enabled=false;
				PictureView. stampSelected=false;
				PictureView. controlStepMouseDown =false;
				PictureView.TextIsReset=false;
				PictureView.FinishRect=false;
				PictureView.bTextFinish=false;
				PictureView.selectedObj=0;PictureView.selectedCursor=Cursors.Default;
				toolBox1.toolBar1.Buttons[0].Pushed=true;
				toolBox1.toolBar1.Buttons[toolBox1.SelectedIndex].Pushed=false;
				FormView.pictureBox1.Cursor=Cursors.Default;
				mnuUndo.Enabled=true;
			}
			
		}
		private void munClear_Click(object sender, System.EventArgs e)
		{
			arrPaths[0]="";arrPaths[1]="";
			mnuRedo.Enabled=false;
			mnuUndo.Enabled=false;

		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.SaveFileDialog op=new SaveFileDialog ();
				DialogResult r= op.ShowDialog();
				if(r==DialogResult.OK )
				{
					FormView.pictureBox1.Image.Save(op.FileName );
				}
			}
			catch(Exception ex){}
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
		System.Drawing.Printing.PrintDocument Document;
		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			Graphics g=Graphics.FromImage(PictureView.bmpOriginal );
			PrintPreviewDialog pr=new PrintPreviewDialog();
			
			Document=new System.Drawing.Printing.PrintDocument();
			
			Document.PrintPage += 
				new System.Drawing.Printing.PrintPageEventHandler
				(document_PrintPage);
			Document.DefaultPageSettings.PaperSize=new System.Drawing.Printing.PaperSize("",PictureView.bmpOriginal.Width ,PictureView.bmpOriginal.Height );
			
			pr.Document=Document ;
			pr.ShowDialog();
		}

		private void document_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e)
		{

			Graphics g= e.Graphics ;
		;
			g.DrawImage(PictureView.bmpOriginal,0,0 );

		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("WinWord","Help.doc");
		}

		private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{

				if(e.Shift)PictureView.SetShift();
		
		}



	}		
}
