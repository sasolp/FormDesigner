using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Management;
//using XShower;
/// XShower2 ;
//using XShower3;
namespace FormDesigner
{
	/// <summary>
	/// Summary description for FormView.
	/// </summary>
	/// 
	public class FormView : System.Windows.Forms.Form
	{
		//private System.Windows.Forms.PictureBox pictureBox1;
		
		public static  FormDesigner.PictureView pictureBox1;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormView()
		{
			//
			// Required for Windows Form Designer support
			//
			p=new ArrayList();
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// FormView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(549, 344);
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.KeyPreview = true;
			this.Name = "FormView";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormView";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormView_KeyDown);
			this.MaximizedBoundsChanged += new System.EventHandler(this.FormView_MaximizedBoundsChanged);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormView_Closing);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormView_KeyPress);
			this.Load += new System.EventHandler(this.FormView_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormView_KeyUp);
			this.Closed += new System.EventHandler(this.FormView_Closed);
			this.Activated += new System.EventHandler(this.FormView_Activated);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormView_Paint);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormView());
		}
		
		private void button2_Click(object sender, System.EventArgs e)
		{

		}
		ArrayList  p;
		private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{

		}

		private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		

		}

		private void FormView_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

		}
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{

			base.OnPaintBackground (pevent);
		}

		protected override  void OnPaint(PaintEventArgs e)
		{

			base.OnPaint (e);	
		}
		//xmagic3.xmagic3classClass      xim;
		private void FormView_Load(object sender, System.EventArgs e)
		{

			// 
			// pictureBox1
			// 
			pictureBox1 =new PictureView();
			Controls.Add(pictureBox1);
			pictureBox1.ControlPoly = true;
			pictureBox1.Location = new System.Drawing.Point(8, 8);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(672, 448);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.SourceFileName = null;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			PictureView.controlStepMouse=false;
			PictureView.selectedObj=0;
			//pictureBox1.SourceFileName="mainpic.jpg";
			//pictureBox1.Image.Dispose();
			Bitmap bmpNew= new Bitmap(825,1180);;
			bmpNew.SetResolution(100,100);
			Graphics.FromImage(bmpNew).FillRectangle(new SolidBrush(Color.White ),new Rectangle(0,0,825,1180));
			pictureBox1.Image=bmpNew;
			
			
			PictureView.BMP=bmpNew;

			PictureView.This.SetBitmap();
			Graphics g=Graphics.FromImage(pictureBox1.Image);
			//pictureBox1.=true;

		}

		private void pictureBox1_VisibleChanged(object sender, System.EventArgs e)
		{
			
		}

		private void FormView_Activated(object sender, System.EventArgs e)
		{

		}

		private void FormView_MaximizedBoundsChanged(object sender, System.EventArgs e)
		{
			int x=1;
		}
		protected override void WndProc(ref Message m)
		{

			base.WndProc (ref m);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{

			PictureView.selectedObj=6;
			PictureView.controlStepMouse=false;
		}

		private void FormView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.Shift)PictureView.SetShift();
				if(((char)e.KeyValue=='X')&&(e.Control==true))
				{
					//CUT
					
					
				}
				else
				{
					if(((char)e.KeyValue=='C')&&(e.Control==true))
					{

					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("d");
			}

		}

		private void FormView_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			

		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void FormView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		
			PictureView.CancelShift ();
		}

		private void button2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
		}

		private void pictureBox1_MouseDown_1(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			
		}

		private void button4_Click(object sender, System.EventArgs e)
		{


		}

		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
	
		}

		private void trackBar2_Scroll(object sender, System.EventArgs e)
		{

		}

		private void pictureBox1_Click_1(object sender, System.EventArgs e)
		{
		
		}

		private void FormView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel=true;
			Hide();
		}

		private void FormView_Closed(object sender, System.EventArgs e)
		{
		
		}

	}
}
