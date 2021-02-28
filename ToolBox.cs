using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FormDesigner
{
	/// <summary>
	/// Summary description for ToolBox.
	/// </summary>
	public class ToolBox :  System.Windows.Forms.UserControl
	{
		public bool bDisposed;
		public static Color colorLeft;
		public int SelectedIndex;
		public System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ImageList imageList1;
		public System.Windows.Forms.Label lblLeftColor;
		public System.Windows.Forms.Label lblRightColor;
		private System.Windows.Forms.ToolBarButton toolBarButton22;
		private System.Windows.Forms.ToolBarButton toolBarButton23;
		private System.Windows.Forms.ToolBarButton toolBarButton24;
		private System.Windows.Forms.ToolBarButton toolBarButton26;
		private System.Windows.Forms.ToolBarButton toolBarButton27;
		private System.Windows.Forms.ToolBarButton toolBarButton29;
		private System.Windows.Forms.ToolBarButton toolBarButton30;
		private System.Windows.Forms.ToolBarButton toolBarButton32;
		private System.Windows.Forms.ToolBarButton toolBarButton33;
		private System.Windows.Forms.ToolBarButton toolBarButton34;
		private System.Windows.Forms.ToolBarButton toolBarButton36;
		private System.Windows.Forms.ToolBarButton toolBarButton38;
		private System.Windows.Forms.ToolBarButton toolBarButton40;
		private System.Windows.Forms.ToolBarButton toolBarButton41;
		private System.Windows.Forms.ToolBarButton toolBarButton42;
		private System.Windows.Forms.ToolBarButton toolBarButton43;
		private System.Windows.Forms.ToolBarButton toolBarButton44;
		private System.Windows.Forms.ToolBarButton toolBarButton45;
		private System.Windows.Forms.ToolBarButton toolBarButton46;
		private System.Windows.Forms.ToolBarButton toolBarButton47;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.ComponentModel.IContainer components;

		public ToolBox()
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
			bDisposed=true;
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ToolBox));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton22 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton23 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton24 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton26 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton27 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton29 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton30 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton32 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton33 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton34 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton36 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton38 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton40 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton41 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton42 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton43 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton44 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton45 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton46 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton47 = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lblLeftColor = new System.Windows.Forms.Label();
			this.lblRightColor = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.AllowDrop = true;
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton22,
																						this.toolBarButton23,
																						this.toolBarButton24,
																						this.toolBarButton26,
																						this.toolBarButton27,
																						this.toolBarButton1,
																						this.toolBarButton29,
																						this.toolBarButton30,
																						this.toolBarButton32,
																						this.toolBarButton33,
																						this.toolBarButton34,
																						this.toolBarButton36,
																						this.toolBarButton38,
																						this.toolBarButton40,
																						this.toolBarButton41,
																						this.toolBarButton42,
																						this.toolBarButton43,
																						this.toolBarButton44,
																						this.toolBarButton45,
																						this.toolBarButton46,
																						this.toolBarButton47});
			this.toolBar1.Divider = false;
			this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(8, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(48, 268);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.TabStop = true;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton22
			// 
			this.toolBarButton22.ImageIndex = 4;
			this.toolBarButton22.Pushed = true;
			// 
			// toolBarButton23
			// 
			this.toolBarButton23.ImageIndex = 0;
			// 
			// toolBarButton24
			// 
			this.toolBarButton24.ImageIndex = 1;
			// 
			// toolBarButton26
			// 
			this.toolBarButton26.ImageIndex = 2;
			// 
			// toolBarButton27
			// 
			this.toolBarButton27.ImageIndex = 3;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 21;
			// 
			// toolBarButton29
			// 
			this.toolBarButton29.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton30
			// 
			this.toolBarButton30.ImageIndex = 5;
			// 
			// toolBarButton32
			// 
			this.toolBarButton32.ImageIndex = 6;
			// 
			// toolBarButton33
			// 
			this.toolBarButton33.ImageIndex = 8;
			// 
			// toolBarButton34
			// 
			this.toolBarButton34.ImageIndex = 9;
			// 
			// toolBarButton36
			// 
			this.toolBarButton36.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton38
			// 
			this.toolBarButton38.ImageIndex = 12;
			// 
			// toolBarButton40
			// 
			this.toolBarButton40.ImageIndex = 15;
			// 
			// toolBarButton41
			// 
			this.toolBarButton41.ImageIndex = 16;
			// 
			// toolBarButton42
			// 
			this.toolBarButton42.ImageIndex = 19;
			// 
			// toolBarButton43
			// 
			this.toolBarButton43.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton44
			// 
			this.toolBarButton44.ImageIndex = 18;
			// 
			// toolBarButton45
			// 
			this.toolBarButton45.ImageIndex = 17;
			// 
			// toolBarButton46
			// 
			this.toolBarButton46.ImageIndex = 13;
			// 
			// toolBarButton47
			// 
			this.toolBarButton47.Visible = false;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// lblLeftColor
			// 
			this.lblLeftColor.BackColor = System.Drawing.Color.OrangeRed;
			this.lblLeftColor.Location = new System.Drawing.Point(8, 312);
			this.lblLeftColor.Name = "lblLeftColor";
			this.lblLeftColor.Size = new System.Drawing.Size(32, 32);
			this.lblLeftColor.TabIndex = 4;
			this.lblLeftColor.Click += new System.EventHandler(this.lblLeftColor_Click);
			// 
			// lblRightColor
			// 
			this.lblRightColor.BackColor = System.Drawing.Color.Orange;
			this.lblRightColor.Location = new System.Drawing.Point(24, 328);
			this.lblRightColor.Name = "lblRightColor";
			this.lblRightColor.Size = new System.Drawing.Size(32, 32);
			this.lblRightColor.TabIndex = 5;
			this.lblRightColor.Click += new System.EventHandler(this.lblRightColor_Click);
			// 
			// label3
			// 
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.Location = new System.Drawing.Point(40, 312);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 6;
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// ToolBox
			// 
			this.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.Controls.Add(this.lblLeftColor);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblRightColor);
			this.Controls.Add(this.toolBar1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Name = "ToolBox";
			this.Size = new System.Drawing.Size(66, 384);
			this.Load += new System.EventHandler(this.ToolBox_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolBox_KeyDown);
			this.ResumeLayout(false);

		}
		#endregion

		private void ToolBox_Load(object sender, System.EventArgs e)
		{
			bDisposed=false;
			BackColor=Color.FromArgb(228,226,214);
			PictureView.selectedColor=Color.OrangeRed  ;
			colorLeft=Color .Orange ;
			PictureView.toolBox=this;

		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			int index=toolBar1.Buttons.IndexOf(e.Button );
			SelectedIndex=index;
			for( int i=0;i<toolBar1.Buttons.Count;i++)
			{
				if (i != index)
					toolBar1.Buttons[i].Pushed=false;
			}
			toolBar1.Buttons[index ].Pushed=true;
			//MessageBox.Show(index.ToString());
			byte selectedIndex=(byte)index;
			if(index<=5)
			{
				PictureView.SelectedCursor=new Cursor(GetType(),(selectedIndex+1).ToString()+".cur");
			}
			else
			{
				if(index <=10)
				{
					PictureView.SelectedCursor=new Cursor(GetType(),(selectedIndex).ToString()+".cur");
				}
				else
				{
					if(index <=16)
					{
						PictureView.SelectedCursor=new Cursor(GetType(),(selectedIndex-1).ToString()+".cur");
					}
					else
					{
						PictureView.SelectedCursor=new Cursor(GetType(),(selectedIndex-2).ToString()+".cur");
					}
				}
			}
			PictureView.bHand=false;
			if(index>=6){index--;selectedIndex--;}
			if(index==16){selectedIndex=0;PictureView.bHand=true;}
			if(index==7)selectedIndex=9;
			if(index==9)selectedIndex=90;
			if(index==8)selectedIndex=10;
			if(index==6)selectedIndex=99;
			if(index==12)selectedIndex=17;
			if(index==17)selectedIndex=15;
			if(index==14)selectedIndex=140;
			if(index==11)selectedIndex=110;
			if(index==5)selectedIndex=50;
			PictureView. stampSelected=false;
			PictureView. controlStepMouseDown =false;
			PictureView.TextIsReset=false;
			PictureView.CancelShift();
			if(selectedIndex!=0)
			{
				PictureView.FinishRect=false;
			}
			else
			{
				MainForm.mnuUndo.Enabled=true;						
				if(PictureView.lastUndoPath != "")
				{
					PictureView.MovingbmpOriginal=new Bitmap(MainForm.arrPaths[0] );
					PictureView.MovingbmpOriginal.SetResolution(100,100);
					
				}
				MainForm.arrPaths[0]=System.IO.Path.GetTempFileName();PictureView.TextbmpOriginal.Save(MainForm.arrPaths[0]);
				
				
				
			}

			PictureView.bTextFinish=false;
			if(selectedIndex!=0 &&PictureView.points.Count>0)PictureView.points.Clear();
			switch(index)
			{
				case 0:{selectedIndex=0;break;}
				case 1:{selectedIndex=3;break;}
				case 2:{selectedIndex=5;break;}
				case 3:{selectedIndex=2;break;}
				case 4:{selectedIndex=4;break;}
			}
			PictureView.TextbmpOriginal=(Bitmap)PictureView.bmpOriginal.Clone();
			PictureView.TextbmpOriginal.SetResolution(100,100);
			if(selectedIndex ==4 || selectedIndex==5)PictureView.controlStepMouse=true;
		PictureView.selectedObj=(byte)selectedIndex;
		}

		private void lblLeftColor_Click(object sender, System.EventArgs e)
		{
		
			ColorDialog dlgColor=new ColorDialog();
			dlgColor.Color=lblLeftColor.BackColor;
			if(dlgColor.ShowDialog()==DialogResult.OK )
			{
				lblLeftColor.BackColor=dlgColor.Color;
				PictureView.selectedColor=dlgColor.Color;
			}
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblRightColor_Click(object sender, System.EventArgs e)
		{
			ColorDialog dlgColor=new ColorDialog();
			dlgColor.Color=lblRightColor.BackColor;
			if(dlgColor.ShowDialog()==DialogResult.OK )
			{
				lblRightColor.BackColor=colorLeft=dlgColor.Color;
			}
		}

		private void ToolBox_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

		private void ToolBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			PictureView.SetShift();
		}
	}
}
