using System;
using System.Collections;
using System.Drawing;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;
namespace FormDesigner
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class PictureView:System.Windows.Forms.PictureBox 
	{
		
		Graphics graphicMain;
		IntPtr graphicMainHdc;
		public static bool bHand;
		GraphicsPath lastGraphicPath;
		public static string lastUndoPath;//for movement of  aslice of pic
		public static Bitmap  bmpOriginal;
		public static Bitmap  TextbmpOriginal;
		public static Bitmap  PastbmpOriginal;
		public static Bitmap  MovingbmpOriginal;
		private System.Drawing.Drawing2D.GraphicsPath externPath;
		public  Color[,] pixels;
		public static TextBox text;
		public static Rectangle TextRectangle;
		public static Font TextFont;
		public static Color selectedColor;
		Color lastColor;
		bool bIsDigit;
		public static Color BrushColor;
		public static System.Windows.Forms.Cursor  selectedCursor;
		public static float BrushWidth;
		public static ToolBox toolBox;

		public ArrayList magicSelectedPoints;
		public static  ArrayList points;
		public ArrayList pointsCoped;
		private Point prevpnt;
		public static byte selectedObj;
		public byte lastSelectedObj;
		public static  bool bVertical;
		public static  bool initPixelSelected;
		private static  bool shiftOccured;
		public static bool TextIsReset;
		public static bool bPloyFinished;
		private bool shiftOccuredMove;
		public static bool bFarsiNumber;
		public static bool bIsFarsi;
		public bool controlPloy;public static bool bTextFinish;
		public static bool bDash;
		public static bool controlStepMouse;
		public static bool controlStepMouseDown;
		public  static bool FinishRect;
		private int maxX;
		private int maxY;
		private int minX;
		private int minY;
		private string srcFileName;
		private string path;
		private int orginalx;
		private int orginaly;
		private bool con;
		private bool destroied;
		private bool moving;
		private bool NoMovingStill;
		private System.Drawing.Image tempImage;
		public static bool stampSelected;
		private float ZoomLenght;
		private bool FillCircle;
		private bool FillRect;
		public static  PictureView This;
		public PictureView()
		{
			controlPloy=true;
			destroied=false;
			moving=false;
			con=true;
			TextFont=new Font("Tahoma",8.25f);
			minX=this.Width ;
			minY=this.Height;
			maxX=0;
			maxY=0;
			 text=new TextBox();
			text.Click+=new EventHandler(Text_Fixed);
			if (selectedCursor!=null)Cursor=selectedCursor;
			orginalx=0;
			orginaly=0;
			points=new ArrayList();
			ZoomLenght=1;
			externPath=new System.Drawing.Drawing2D.GraphicsPath();
			This=this;

			lastGraphicPath=new GraphicsPath();

		}
		public void SetBitmap()
		{
			
			Image= bmpOriginal;
		}
		public static System.Windows.Forms.Cursor  SelectedCursor
		{
			set
			{
				selectedCursor=value;
			}
		}
		public static Bitmap  BMP
		{
			set
			{
				bmpOriginal=value;
			}
			get
			{
				return (Bitmap)bmpOriginal.Clone();
			}
		}
		public void magicWandd(Point p)
		{
			ArrayList  q=new ArrayList();
			int x,y,row=(short)p.Y,col=(short)p.X;
			q.Add(p);
			int counter=0,counter1=0,con=0;
			magicSelectedPoints=new ArrayList();
			magicSelectedPoints.Add(p);
			Color color=pixels[row,col];
			

			while(true)
			{
				
				if(counter1 >=magicSelectedPoints .Count )break;

				p=(Point)magicSelectedPoints [counter1];counter1++;
				x=p.X ;
				y=p.Y;
				for(int i=1;i<=8;i++)
				{
					switch(i)
					{
						case 1:{row=y-1;col=x-1;break;}
						case 2:{row=y;col=x-1;break;}
						case 3:{row=y+1;col=x-1;break;}
						case 4:{row=y+1;col=x;break;}
						case 5:{row=y+1;col=x+1;break;}
						case 6:{row=y;col=x+1;break;}
						case 7:{row=y-1;col=x+1;break;}
						case 8:{row=y-1;col=x;break;}

					}
					Point newpnt=new Point(col,row);
					//if((col>=0)&&(col<577)&&(row>=0)&&(row<483))
					
						if(!magicSelectedPoints .Contains(newpnt))
						{
						
							if(pixels[row,col].Equals (color))
							{
								magicSelectedPoints.Add(newpnt);
								//q.Add(newpnt);
								break;
							}
						}
					else 
							con++;
							counter++;
				}
				
			}
		}
		string ToFarsi(string strIn)
		{
			string strTemp,strOut="";
			
			
			for(int i = 0 ;i<strIn.Length ;i++)
			{
				if(strIn[i]>122)
				{
					bIsFarsi =true;					
				}
				else
					if(!char.IsDigit(strIn,i))bIsDigit=false;

			}
			if((bIsFarsi||bIsDigit)&&bFarsiNumber )
			{
				char[]chDigits={'0','1','2','3','4','5','6','7','8','9'};
				strOut="";
				for(int i = 0 ;i<strIn.Length ;i++)
				{
					strTemp=strIn[i].ToString();
					//if()
					strOut+=(strTemp.IndexOfAny (chDigits ,0,1)!=-1)?((char)(int.Parse(strTemp[0].ToString())+1632)).ToString():strTemp;
				}
				return strOut;
			}
			else
				return strIn;
		}
		public void magicWand(Point p)
		{
			
			int x,y,row=(short)p.Y,col=(short)p.X;
			int counter=0,index=0,prevColor=0,direct=1;//1:left;2:right;3:up;4:down;5:leftup;6:leftdown;
											   //7:rightdown;8:rightup;
			magicSelectedPoints=new ArrayList();
			Color color=pixels[row,col];
			bool notFound=false;
			bool founded=false;
			Point newpnt;
			Point prevpnt=p;
			
			while(!notFound)
			{
				if(pixels[row,col].ToArgb()==(color.ToArgb()))
				{
					col--;
				}
				else
					notFound=true;
			}
			col++;
			notFound=false;
			magicSelectedPoints.Add(new Point(row,col));int xd=7;
			while(!notFound)
			{
				if(counter == magicSelectedPoints.Count)
					break;
				p=(Point)magicSelectedPoints[counter];
				counter++;
				x=p.Y;y=p.X ;
				
				founded=false;
				for(int i=1;i<=8;i++)
				{
					
					switch(xd)
					{
						//1:left;2:right;3:up;4:down;5:leftup;6:leftdown;
						//7:rightdown;8:rightup;
						case 1:{if(direct!=1){row=y;col=x+1;direct=2;xd=7;}else continue;break;}
						case 2:{if(direct!=2){row=y;col=x-1;direct=1;xd=3;}else continue;break;}
						case 3:{if(direct!=8){row=y+1;col=x-1;direct=6;xd=4;}else continue;break;}
						case 4:{if(direct!=3){row=y+1;col=x;direct=4;xd=5;}else continue;break;}
						case 5:{if(direct!=5){row=y+1;col=x+1;direct=7;xd=1;}else continue;break;}
						case 6:{if(direct!=7){row=y-1;col=x-1;direct=5;xd=2;}else continue;break;}
						case 7:{if(direct!=6){row=y-1;col=x+1;direct=8;xd=8;}else continue;break;}
						case 8:{if(direct!=4){row=y-1;col=x;direct=3;xd=6;}else continue;break;}

					}
					
					if( pixels[row,col].ToArgb()!=color.ToArgb()&&(i>1) )
					{
						if(prevColor==0)
						{
							//newpnt=new Point(row,col);
							if(!magicSelectedPoints.Contains(prevpnt))
							{
								magicSelectedPoints.Add(prevpnt);
								index++;
								if(magicSelectedPoints[0].Equals(prevpnt))notFound=true;
							
							
								founded=true;
							break;
							}
						}
						else
							prevColor=1;
					}
					else
					{
						if(prevColor==1)
						{
							newpnt=new Point(row,col);
							if(!magicSelectedPoints.Contains(newpnt))
							{
								magicSelectedPoints.Add(newpnt);
								index++;
								if(magicSelectedPoints[0].Equals(newpnt))notFound=true;
							
								founded=true;
								break;
							}
						}
						else
						{
							prevColor=0;
							prevpnt=new Point(row,col);
						}
					}
					
				}
	
				if((!founded)&&(index >0))
				{
					//magicSelectedPoints.Add(magicSelectedPoints[index]);
					//index--;
					switch(direct)
					{
							//1:left;2:right;3:up;4:down;5:leftup;6:leftdown;
							//7:rightdown;8:rightup;
						case 1:{direct=2;break;}
						case 2:{direct=1;break;}
						case 3:{direct=4;break;}
						case 4:{direct=3;break;}
						case 5:{direct=7;break;}
						case 6:{direct=8;break;}
						case 7:{direct=5;break;}
						case 8:{direct=6;break;}

					}	
				}
				switch(direct)
				{
						//1:left;2:right;3:up;4:down;5:leftup;6:leftdown;
						//7:rightdown;8:rightup;
					case 1:{xd=7;break;}
					case 2:{xd=3;break;}
					case 3:{xd=5;break;}
					case 4:{xd=6;break;}
					case 5:{xd=1;break;}
					case 6:{xd=8;break;}
					case 7:{xd=2;break;}
					case 8:{xd=4;break;}

				}
			}
			//System.Windows.Forms.MessageBox.Show(col.ToString());
		}

		public void Colorized(Color c)
		{
			try
			{
				//Bitmap bit=new Bitmap(this.Image );
				
				//this.
				//Image=System.Drawing.Image.FromHbitmap(bit.GetHbitmap ());
			}
			catch(Exception ex)
			{
				int f=1;
			}
		}
		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick (e);
		}
		bool colorBW;
		byte OneTime;
		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			
			byte lastSelectedObject=110;
			byte firstInput=selectedObj;
			if(selectedObj == 110 && !FinishRect   )
			{lastSelectedObject=selectedObj;selectedObj=3;}
			if(selectedObj == 110 && FinishRect &&TextRectangle.Contains(new Point( e.X ,e.Y )) )
			{
				Cursor =Cursors.SizeAll ;
			}
			else
				if(selectedObj == 110)
				Cursor=selectedCursor   ;
			
			switch(selectedObj)
			{
				case 0:
				{

					if( (FinishRect)&&(!bHand)&&
						((e.X>minX )&&(e.X< maxX) && (e.Y>minY )&&(e.Y<maxY)))
						{
							Cursor=System.Windows.Forms.Cursors.SizeAll;
						}
						else
						{
							if( (FinishRect)&&
								((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
							{
								Cursor=selectedCursor ;
							}
						}
					if(FinishRect && controlStepMouseDown )
					{
						
						
						int count=points.Count;

						int xDist,yDist;
						moving=true;
						xDist=e.X -prevpnt.X;
						yDist=e.Y -prevpnt.Y;
						minX+=xDist;
						maxX+=xDist;
						minY+=yDist;
						maxY+=yDist;

						//////////////////////////
						Point p;
						Point []ps=new Point[points .Count ];


						for(int i=0;i<points.Count ;i++)
						{
							p=(Point)points[i];
							p.X += xDist;
							p.Y += yDist;
							points[i]=p;
						}
						for(int i=0;i<points.Count ;i++)
						{
							ps[i]=(Point)points[i];
						}
						//////////////////////////
						//						externPath.Reset();	
						System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();
						
						
						switch(lastSelectedObj)
						{
							case 2:
							{
								if(shiftOccuredMove )
								{
									gp.AddEllipse (minX,minY,maxX-minX,maxX-minX);
								}
								else
								{
									gp.AddEllipse(minX,minY,maxX-minX,maxY-minY);
								}
								break;}
							case 3:
							{
								if(shiftOccuredMove )
								{
									gp.AddRectangle (new Rectangle (minX,minY,maxX-minX,maxX-minX));
								}
							
								else
								{
									gp.AddRectangle(new Rectangle (minX,minY,maxX-minX,maxY-minY));
								}
								break;}
							case 4:
							{
								gp.AddPolygon(ps);
								break;}
							case 5:
							{
								gp.AddPolygon(ps);
								break;}

							case 50:
							{
								CreateRoundRect(new Rectangle(minX,minY,maxX-minX,maxY-minY),out gp,new Size(7,7));
								break;
							}
						}

						//Image Drawing	
						System.Drawing.Graphics g=Graphics.FromImage(Image);
	
						
						g.DrawImage(MovingbmpOriginal   ,0,0);
						g.SetClip (gp);
						g.DrawImage(TextbmpOriginal  ,minX -orginalx   ,minY-orginaly  );
						g.ResetClip();
						CancelShift();
						/*if(NoMovingStill)
						{
							if(shiftOccured)
							{								
								g.FillPath(Brushes.White ,lastGraphicPath );
								
							}
						}*/
						Refresh();
	
						
					}
					prevpnt=new Point(e.X,e.Y );
					break;
				}
				case 1:{;break;}
				case 13:
				case 2:
				{
					int x=0,y=0,width=0,height=0;
					int count=points.Count;
					if( (FinishRect)&&
						((e.X>minX )&&(e.X< maxX) && (e.Y>minY )&&(e.Y<maxY)))
					{
						Cursor=System.Windows.Forms.Cursors.SizeAll;
					}
					else
					{
						if( (FinishRect)&&
							((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
						{
							Cursor=selectedCursor;
						}
					}
					if(initPixelSelected &&(!FinishRect ))
					{
						colorBW=!colorBW;
						Pen p=new Pen(selectedColor );
						p.Width=(BrushWidth);
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;
						if(bDash)p.DashPattern=new float[2]{2,3};
						System.Drawing.Graphics g=Graphics.FromImage(Image);
						Refresh();

						if(e.X<minX)
						{
							if(e.Y <minY)
							{
								x=e.X;
								y=e.Y;
								width=minX-e.X;
								height=minY -e.Y;
							}
							else
							{
								x=e.X;
								y=minY;
								width=minX-x;
								height=e.Y-y;
							}
						}
						else
						{
							if(e.Y <minY)
							{
								x=minX ;
								y=e.Y;
								width=e.X-x;
								height=minY -y;
							}
							else
							{
								x=minX ;
								y=minY ;
								width=e.X-x;
								height=e.Y -y;
							}
						}
						if(shiftOccured )
						{
							g.DrawImage(TextbmpOriginal,0,0);
							g.DrawEllipse( p,x,y,width,width);
						}
						else
						{
							g.DrawImage(TextbmpOriginal,0,0);
							g.DrawEllipse( p,x,y,width,height);
						}
					}
					else
					{
						if(initPixelSelected &&(FinishRect ) )
						{
							
							int xDist,yDist;
							moving=true;
							xDist=e.X -prevpnt.X;
							yDist=e.Y -prevpnt.Y;
							minX+=xDist;
							maxX+=xDist;
							minY+=yDist;
							maxY+=yDist;
							
							

							Pen p=new Pen(selectedColor );
							p.Width=(BrushWidth);
							p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
							if(bDash)p.DashPattern=new float[2]{2,3};
							System.Drawing.Graphics g=Graphics.FromImage(Image);
							if(selectedObj==13)
							{
								Bitmap bmpNew=new Bitmap(maxX-minX,maxY-minY);
								Graphics gBmpNew=Graphics.FromImage(bmpNew);
								gBmpNew.FillEllipse(new SolidBrush(selectedColor   ),0,0 ,(maxX-minX),(maxY-minY) );
								System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();
								gp.AddEllipse (minX,minY ,(maxX-minX),(maxY-minY));
								g.ExcludeClip(new Region(gp));
								g.DrawImage(TextbmpOriginal ,0,0);
								g.SetClip(gp);//g.DrawImage(TextbmpOriginal ,0,0);
								g.DrawImage (bmpNew,minX ,minY,maxX-minX,maxY-minY);Refresh();
							}
							else
							{
								g.DrawImage(TextbmpOriginal ,0,0);
								if(shiftOccuredMove )

									g.DrawEllipse(p,minX,minY,maxX-minX,maxX-minX);
							
								else
									g.DrawEllipse(p,minX,minY,maxX-minX,maxY-minY);
								Refresh();
							}
							
							
						}
					}prevpnt=new Point(e.X,e.Y );
					break;
				}
				case 17:
				case 3:
				{
					if(!controlStepMouseDown )
					{
						base.OnMouseMove (e);
						if(firstInput == 110){selectedObj=lastSelectedObject;}
						return;
					}
					int x=0,y=0,width=0,height=0;
					int count=points.Count;
					if( (FinishRect)&&
						((e.X>minX )&&(e.X< maxX) && (e.Y>minY )&&(e.Y<maxY)))
					{
						Cursor=System.Windows.Forms.Cursors.SizeAll;
					}
					else
					{
						if( (FinishRect)&&
							((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
						{
							Cursor=selectedCursor;
						}
					}
					if(initPixelSelected &&(!FinishRect ))
					{
						colorBW=!colorBW;
						Pen p=new Pen(selectedColor );
						p.Width=(BrushWidth);
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
						if(bDash)p.DashPattern=new float[2]{2,3};
						System.Drawing.Graphics g=Graphics.FromImage(Image);
						Refresh();

						if(e.X<minX)
						{
							if(e.Y <minY)
							{
								x=e.X;
								y=e.Y;
								width=minX-e.X;
								height=minY -e.Y;
							}
							else
							{
								x=e.X;
								y=minY;
								width=minX-x;
								height=e.Y-y;
							}
						}
						else
						{
							if(e.Y <minY)
							{
								x=minX ;
								y=e.Y;
								width=e.X-x;
								height=minY -y;
							}
							else
							{
								x=minX ;
								y=minY ;
								width=e.X-x;
								height=e.Y -y;
							}
						}
						if(width > 0 && height > 0)
						{
							if(shiftOccured )
							{
								if(selectedObj!=17 )
								{
									g.DrawImage(TextbmpOriginal ,0,0);
									g.DrawRectangle( p,x,y,width,width);
								}
							
							}
							else
							if(selectedObj!=17 )
							{
								g.DrawImage(TextbmpOriginal ,0,0);
								g.DrawRectangle( p,x,y,width,height);
							}
							else
							{
								g.DrawImage(TextbmpOriginal ,0,0);
								g.FillRectangle(new SolidBrush(selectedColor),x,y,width,height);
							}
						}
					}
					else
					{
						if(initPixelSelected &&(FinishRect ) )
						{
							
							int xDist,yDist;
							moving=true;
							xDist=e.X -prevpnt.X;
							yDist=e.Y -prevpnt.Y;
							minX+=xDist;
							maxX+=xDist;
							minY+=yDist;
							maxY+=yDist;
							
							

							Pen p=new Pen(selectedColor );
							p.Width=(BrushWidth);
							p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
							if(bDash)p.DashPattern=new float[2]{2,3};
							System.Drawing.Graphics g=Graphics.FromImage(Image);
							//g.SetClip (new Rectangle(minX,minY,maxX-minX,maxY-minY));
							
							
							

							if(shiftOccured )
							{
								if(selectedObj!=17 )
								{
									g.DrawImage(TextbmpOriginal ,0,0);
									g.DrawRectangle( p,minX,minY,maxX-minX,maxX-minX);
								}
								else
								{
									g.DrawImage(TextbmpOriginal ,0,0);
									g.FillRectangle( new SolidBrush(selectedColor ),minX,minY,maxX-minX,maxX-minX);
								}
							}
							else
							if(selectedObj!=17 )
							{
								g.DrawImage(TextbmpOriginal ,0,0);
								
								g.DrawRectangle( p,minX,minY,maxX-minX,maxY-minY);
								
							}
							else
							{
								Bitmap bmpNew=new Bitmap(maxX-minX,maxY-minY);
								Graphics gBmpNew=Graphics.FromImage(bmpNew);
								gBmpNew.FillRectangle(new SolidBrush(selectedColor   ),0,0,maxX-minX,maxY-minY);
								g.ExcludeClip(new Region(new Rectangle(minX ,minY,maxX-minX,maxY-minY) ));
								g.DrawImage(TextbmpOriginal ,0,0);
								g.SetClip(new Rectangle(minX ,minY,maxX-minX,maxY-minY));
								if(selectedColor.A <200)
									g.DrawImage(TextbmpOriginal ,0,0);
								g.DrawImage (bmpNew,minX ,minY,maxX-minX,maxY-minY);
							}
							
							
						Refresh();	
						}
					}prevpnt=new Point(e.X,e.Y );
					break;
				}
				case 50:
				{
					if(!controlStepMouseDown )
					{
						base.OnMouseMove (e);
						if(firstInput == 110){selectedObj=lastSelectedObject;}
						return;
					}
					int x=0,y=0,width=0,height=0;
					int count=points.Count;
					if( (FinishRect)&&
						((e.X>minX )&&(e.X< maxX) && (e.Y>minY )&&(e.Y<maxY)))
					{
						Cursor=System.Windows.Forms.Cursors.SizeAll;
					}
					else
					{
						if( (FinishRect)&&
							((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
						{
							Cursor=selectedCursor;
						}
					}
					if(initPixelSelected &&(!FinishRect ))
					{
						colorBW=!colorBW;
						Pen p=new Pen(selectedColor );
						p.Width=(BrushWidth);
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
						if(bDash)p.DashPattern=new float[2]{2,3};
						System.Drawing.Graphics g=Graphics.FromImage (Image);
						//Refresh();

						if(e.X<minX)
						{
							if(e.Y <minY)
							{
								x=e.X;
								y=e.Y;
								width=minX-e.X;
								height=minY -e.Y;
							}
							else
							{
								x=e.X;
								y=minY;
								width=minX-x;
								height=e.Y-y;
							}
						}
						else
						{
							if(e.Y <minY)
							{
								x=minX ;
								y=e.Y;
								width=e.X-x;
								height=minY -y;
							}
							else
							{
								x=minX ;
								y=minY ;
								width=e.X-x;
								height=e.Y -y;
							}
						}
						
						if(shiftOccured )
						{
							GraphicsPath gp;
							CreateRoundRect(new Rectangle(x,y,width,width ),out gp,new Size(7,7));
							g.DrawImage(TextbmpOriginal,0,0);
							if(BrushWidth >= width)
								g.FillPath(new SolidBrush( selectedColor ),gp);						
							else
								g.DrawPath(new Pen( selectedColor ,BrushWidth ),gp);
							Refresh();
							
						}
						else
						{
								GraphicsPath gp;
								CreateRoundRect(new Rectangle(x,y,width,height),out gp,new Size(7,7));
								g.DrawImage(TextbmpOriginal,0,0);
								if(BrushWidth >= width)
									g.FillPath(new SolidBrush( selectedColor ),gp);						
								else
									g.DrawPath(new Pen( selectedColor ,BrushWidth ),gp);
								Refresh();
									
						}
						
					}
					else
					{
						if(initPixelSelected &&(FinishRect ) )
						{
							
							int xDist,yDist;
							moving=true;
							xDist=e.X -prevpnt.X;
							yDist=e.Y -prevpnt.Y;
							minX+=xDist;
							maxX+=xDist;
							minY+=yDist;
							maxY+=yDist;
							
							

							Pen p=new Pen(selectedColor );
							p.Width=(BrushWidth);
							p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
							if(bDash)p.DashPattern=new float[2]{2,3};
							System.Drawing.Graphics g=Graphics.FromImage (Image);
							
								
							if(shiftOccured )
							{																
								GraphicsPath gp;
								CreateRoundRect(new Rectangle(minX,minY,maxX-minX,maxX-minX),out gp,new Size(7,7));
								g.DrawImage(TextbmpOriginal,0,0);
								if(BrushWidth >= maxX-minX)
									g.FillPath(new SolidBrush( selectedColor ),gp);						
								else
									g.DrawPath(new Pen( selectedColor ,BrushWidth ),gp);
								Refresh();
								//ReleaseDC((System.IntPtr )null ,g.GetHdc());
							}
							else
							{
								//Refresh();
								//RoundRect(graphicMainHdc,minX,minY,maxX-minX,maxY-minY,5,5);																
								GraphicsPath gp;
								CreateRoundRect(new Rectangle(minX,minY,maxX-minX,maxY-minY),out gp,new Size(7,7));
								g.DrawImage(TextbmpOriginal,0,0);
								if(BrushWidth >= maxX-minX)
									g.FillPath(new SolidBrush( selectedColor ),gp);						
								else
									g.DrawPath(new Pen( selectedColor ,BrushWidth ),gp);
								Refresh();
								//ReleaseDC((System.IntPtr )null ,g.GetHdc());
							}
							
							
						}
					}
					prevpnt=new Point(e.X,e.Y );
					break;
				}
				case 4:
				{
					if( (FinishRect)&&
						((e.X>minX )&&(e.X< maxX) && (e.Y>minY )&&(e.Y<maxY)))
					{
						Cursor=System.Windows.Forms.Cursors.SizeAll;
					}
					else
					{
						if( (FinishRect)&&
							((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
						{
							Cursor=selectedCursor;
						}
					}
					if(FinishRect && controlStepMouseDown && controlStepMouse)
					{
						Refresh();
						int xDist,yDist;
						moving=true;
						xDist=e.X -prevpnt.X;
						yDist=e.Y -prevpnt.Y;
						minX+=xDist;
						maxX+=xDist;
						minY+=yDist;
						maxY+=yDist;
						Point p;
						Point []ps=new Point[points .Count ];


						for(int i=0;i<points.Count ;i++)
						{
							p=(Point)points[i];
							p.X += xDist;
							p.Y += yDist;
							points[i]=p;
						}
						for(int i=0;i<points.Count ;i++)
						{
							ps[i]=(Point)points[i];
						}
						System.Drawing.Graphics g=Graphics.FromImage(Image);
						Pen p1=new Pen(selectedColor ,(BrushWidth));
						p1.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
						if(ps.Length>2)
						{
							g.DrawImage(TextbmpOriginal,0,0);
							g.DrawPolygon(p1,ps);
						}
						Refresh();
							
					}
					else
					{
						if(controlStepMouse && controlStepMouseDown  )this.MouseMoveStepMouse(e);
					}
					prevpnt=new Point(e.X,e.Y );
					break;
				}
				case 5:
				{
					if( (bPloyFinished)&&
						((e.X>minX )&&(e.X< maxX) && (e.Y>minY )&&(e.Y<maxY)))
					{
						Cursor=System.Windows.Forms.Cursors.SizeAll;
					}
					else
					{
						if( (bPloyFinished)&&
							((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
						{
							Cursor=selectedCursor;
						}
					}
					Refresh();
					int xDist,yDist;
					moving=true;
					if(!controlPloy)
					{
						if(!con)
						{
							xDist=e.X -prevpnt.X;
							yDist=e.Y -prevpnt.Y;
							minX+=xDist;
							maxX+=xDist;
							minY+=yDist;
							maxY+=yDist;
							Point p;
							Point []ps=new Point[points .Count ];

							
							for(int i=0;i<points.Count ;i++)
							{
								p=(Point)points[i];
								p.X += xDist;
								p.Y += yDist;
								points[i]=p;
							}
							for(int i=0;i<points.Count ;i++)
							{
								ps[i]=(Point)points[i];
							}
							System.Drawing.Graphics g=Graphics.FromImage(Image);
							Pen p1=new Pen(selectedColor ,(BrushWidth));
							p1.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
							g.DrawImage(TextbmpOriginal,0,0);
							g.DrawPolygon(p1,ps);
						}
					}
					prevpnt=new Point(e.X,e.Y );
					break;
				}
				case 140:
				{
					if( (bPloyFinished)&&
						((e.X>minX )&&(e.X< maxX) && (e.Y>minY )&&(e.Y<maxY)))
					{
						Cursor=System.Windows.Forms.Cursors.SizeAll;
					}
					else
					{
						if( (bPloyFinished)&&
							((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
						{
							Cursor=selectedCursor;
						}
					}
					int xDist,yDist;
					moving=true;
					if(!controlPloy)
					{
						if(!con)
						{
							xDist=e.X -prevpnt.X;
							yDist=e.Y -prevpnt.Y;
							minX+=xDist;
							maxX+=xDist;
							minY+=yDist;
							maxY+=yDist;
							Point p;
							Point []ps=new Point[points .Count ];


							for(int i=0;i<points.Count ;i++)
							{
								p=(Point)points[i];
								p.X += xDist;
								p.Y += yDist;
								points[i]=p;
							}
							for(int i=0;i<points.Count ;i++)
							{
								ps[i]=(Point)points[i];
							}
							
							System.Drawing.Graphics g=Graphics.FromImage(Image);
							{
								Bitmap bmpNew=new Bitmap(maxX-minX,maxY-minY);
								Graphics gBmpNew=Graphics.FromImage(bmpNew);
								gBmpNew.FillRectangle(new SolidBrush(selectedColor   ),0,0 ,(maxX-minX),(maxY-minY) );
								System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();
								gp.AddPolygon(ps);
								g.ExcludeClip(new Region(gp));
								g.DrawImage(TextbmpOriginal ,0,0);
								g.SetClip(gp);//g.DrawImage(TextbmpOriginal ,0,0);
								g.DrawImage (bmpNew,minX ,minY,maxX-minX,maxY-minY);
							}
							
						}
					}
					Refresh();
					prevpnt=new Point(e.X,e.Y );
					break;
				}
				case 20:
				{
					if(controlStepMouseDown && controlStepMouse )
					{
				
						if(FinishRect)
						{
							int xDist,yDist;
							moving=true;
							xDist=e.X -prevpnt.X;
							yDist=e.Y -prevpnt.Y;
							minX+=xDist;
							maxX+=xDist;
							minY+=yDist;
							maxY+=yDist;
							Point p;
							Point []ps=new Point[points .Count ];


							for(int i=0;i<points.Count ;i++)
							{
								p=(Point)points[i];
								p.X += xDist;
								p.Y += yDist;
								points[i]=p;
							}
							for(int i=0;i<points.Count ;i++)
							{
								ps[i]=(Point)points[i];
							}
							
							System.Drawing.Graphics g=Graphics.FromImage(Image);
							Bitmap Tempbmp=new Bitmap(Image); Image im=Tempbmp;
							System.Drawing.Drawing2D.GraphicsPath P = new System.Drawing.Drawing2D.GraphicsPath();
							g.ResetClip();
							P.AddPolygon(ps);
							g.ExcludeClip (new Region(P));
							g.DrawImage(im  ,0,0);
							g.SetClip(P);
					
							g.DrawImage(im  ,minX -orginalx ,minY -orginaly );
							
						}
						else
						{
							this.MouseMoveStepMouse(e);
						}
						prevpnt=new Point(e.X,e.Y );
					}
					else
					{
						int xDist,yDist;
						moving=true;
						if(!controlPloy)
						{
							if(!con)
							{
								xDist=e.X -prevpnt.X;
								yDist=e.Y -prevpnt.Y;
								minX+=xDist;
								maxX+=xDist;
								minY+=yDist;
								maxY+=yDist;
								Point p;
								Point []ps=new Point[points .Count ];


								for(int i=0;i<points.Count ;i++)
								{
									p=(Point)points[i];
									p.X += xDist;
									p.Y += yDist;
									points[i]=p;
								}
								for(int i=0;i<points.Count ;i++)
								{
									ps[i]=(Point)points[i];
								}
								System.Drawing.Graphics g=Graphics.FromImage(Image);
								Bitmap Tempbmp=new Bitmap(Image);Image im=Tempbmp;
								System.Drawing.Drawing2D.GraphicsPath P = new System.Drawing.Drawing2D.GraphicsPath();
								g.ResetClip();
								P.AddPolygon(ps);
								g.ExcludeClip (new Region(P));
								g.DrawImage(im ,0,0);
								g.SetClip(P);
					
								g.DrawImage(im ,minX -orginalx ,minY -orginaly );
					
							}
						}
						prevpnt=new Point(e.X,e.Y );
					}
					break;
				}
				case 7:
				{
					if(controlStepMouseDown)
					{
						float[][] matrixItems ={ 
												   new float[] {0.5f, 0, 0, 0, 0},
												   new float[] {0, 0.5f, 0, 0, 0},
												   new float[] {0, 0, 1, 0, 0},
												   new float[] {0, 0, 0, 1f, 0}, 
												   new float[] {0, 0, 0, 0, 1}}; 
						matrixItems[0][0]=(float)selectedColor.R  /255; // Red
						matrixItems[1][1]=(float)selectedColor.G /255; // Green
						matrixItems[2][2]=(float)selectedColor.B/255; // Blue
						matrixItems[3][3]=(float)selectedColor.A/255;; // alpha
						matrixItems[4][4]=1F; // w
						System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(matrixItems);
						System.Drawing.Imaging.ImageAttributes imageAttr=new System.Drawing.Imaging.ImageAttributes();
						imageAttr.SetColorMatrix(colorMatrix);
						System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();
					gp.AddEllipse(e.X -BrushWidth/2,e.Y-BrushWidth/2,BrushWidth ,BrushWidth );
					Bitmap Tempbmp=new Bitmap(Image);Image im=Tempbmp;
					System.Drawing.Graphics g=Graphics.FromImage(Image);//Graphics.FromImage(Image);
					
					Rectangle rect = new Rectangle(0, 0, Image.Width ,Image.Height );
					g.SetClip(gp );
					g.DrawImage(Image,         // Image
						rect,            // Dest. rect.
						0,               // srcX
						0,               // srcY
						Image.Width ,             // srcWidth
						Image.Height,             // srcHeight
						GraphicsUnit.Pixel, // srcUnit
						imageAttr);

						
					}
					break;
					
				}
				case 9:
				case 90:
				case 99:
				{
					if(controlStepMouseDown )
					{
						Graphics g=Graphics.FromImage(Image );
						System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();
						
						gp.AddEllipse(e.X-BrushWidth/2 ,e.Y-BrushWidth/2 ,BrushWidth ,BrushWidth );
						
						Pen p=new Pen(Color.FromArgb(255,selectedColor.R,selectedColor.G,selectedColor.B)  );
						if(selectedObj==99)
						{
						p.Width=BrushWidth;
						}
						if(selectedObj==90)
						{
							p.Width=BrushWidth;
							p.Color = Color.White;
						}
						p.StartCap=System.Drawing.Drawing2D.LineCap.Round       ;
						p.EndCap =System.Drawing.Drawing2D.LineCap.Round   ;
						//p.LineJoin=System.Drawing.Drawing2D.LineJoin.MiterClipped ;
						points.Add(new Point(e.X,e.Y ));
						Point []ps=new Point[2 ];
						
						ps[0]=(Point)points[points.Count-2];
						ps[1]=(Point)points[points.Count-1];
						g.DrawLine(p,ps[0],ps[1]);
						
						Refresh();
					}
					break;			
				}
				case 10:
				{
					/*if(stampSelected)
					{*/
						Graphics g=CreateGraphics();
						Pen p=new Pen(Color.White  ,1);
						
						
						g.DrawEllipse(p,e.X-BrushWidth/2,e.Y-BrushWidth/2,BrushWidth ,BrushWidth );
					Refresh();
					//}
					break;
				}
				case 14:
				{
					/*if(stampSelected)
					{*/
					Graphics gg=CreateGraphics();
					Pen p1=new Pen(Color.White  ,1);
					if(controlStepMouseDown )
					{
						System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();
						gp.AddEllipse(e.X -BrushWidth/2,e.Y-BrushWidth/2,BrushWidth ,BrushWidth );
						Bitmap Tempbmp=new Bitmap(Image);Image im=Tempbmp;
						System.Drawing.Graphics g=Graphics.FromImage(Image);//Graphics.FromImage(Image);
					
						System.Drawing.Imaging.ImageAttributes imageAttr = new System.Drawing.Imaging.ImageAttributes();
						imageAttr.SetGamma(((float)selectedColor .A )/255,System.Drawing.Imaging.ColorAdjustType.Bitmap   );
						// Draw the image with gamma set to 2.2.
						Rectangle rect = new Rectangle(0, 0, Image.Width ,Image.Height );
						g.SetClip(gp );
						g.DrawImage(Image,         // Image
							rect,            // Dest. rect.
							0,               // srcX
							0,               // srcY
							Image.Width ,             // srcWidth
							Image.Height,             // srcHeight
							GraphicsUnit.Pixel, // srcUnit
							imageAttr);
					}
					break;
				}
				case 11:
				{
					if(controlStepMouseDown )
					{
						Graphics g=Graphics.FromImage(Image );
						System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();

						gp.AddEllipse(e.X-BrushWidth/2 ,e.Y-BrushWidth/2 ,BrushWidth ,BrushWidth );
						g.SetClip(gp);
						g.Clear(Color.White );
						Refresh();
					}
					break;			
				}
				case 15:
				{
					if(controlStepMouseDown )
					{
						Graphics g=Graphics.FromImage(Image);
						Pen p=new Pen(selectedColor  ,1);
						p.Width=BrushWidth;
						g.DrawImage(TextbmpOriginal,0,0);
						g.DrawLine(p,new Point (prevpnt.X ,prevpnt.Y),new Point(e.X,e.Y ));						
						Refresh();
					}
					break;
				}
				
				case 110:
				{
					if(controlStepMouseDown  )
					{
						Graphics g=Graphics.FromImage(Image );
						int xDist,yDist;
						moving=true;
						xDist=e.X -prevpnt.X;
						yDist=e.Y -prevpnt.Y;
						minX+=xDist;
						minY+=yDist;
						xDist=TextRectangle.Width;yDist=TextRectangle.Height;
						TextRectangle=new Rectangle(minX,minY,xDist,yDist);
						g.DrawImage(TextbmpOriginal,0,0);
						string str=ToFarsi(text.Text);
						if(!bVertical)
						{
							if(!bIsFarsi&&!bFarsiNumber&&bIsDigit)
								g.DrawString(str,TextFont,new SolidBrush(selectedColor ),TextRectangle );
							else
								g.DrawString(str,TextFont,new SolidBrush(selectedColor ),TextRectangle , new StringFormat(StringFormatFlags.DirectionRightToLeft   ));
						}
						else
							g.DrawString(str,TextFont,new SolidBrush(selectedColor ),TextRectangle , new StringFormat(StringFormatFlags.DirectionVertical    ));
						Refresh();
						prevpnt=new Point(e.X,e.Y );
					}
					break;
				}
				case 25:
				{
					if(controlStepMouseDown)
					{
						Graphics g=Graphics.FromImage(Image);
						int xDist,yDist;
						moving=true;
						minX=TextRectangle.X;
						minY=TextRectangle.Y;
						xDist=e.X -prevpnt.X;
						yDist=e.Y -prevpnt.Y;
						minX+=xDist;
						minY+=yDist;
						xDist=TextRectangle.Width;
						yDist=TextRectangle.Height;
						Pen pen=new Pen(Color.Black);
						pen.DashStyle=DashStyle.Dash;
						TextRectangle=new Rectangle(minX,minY,PastbmpOriginal.Width ,PastbmpOriginal.Height );
						g.DrawImage(TextbmpOriginal  ,0,0);
						g.DrawImage(PastbmpOriginal,TextRectangle);
						g.DrawLine(pen,minX+17,0,minX+17,minY);
						g.DrawLine(pen,0,minY,minX+17,minY);
						prevpnt=new Point(e.X,e.Y );

						Refresh();
					}
					else
					{
						Rectangle rect=new Rectangle(TextRectangle.X ,TextRectangle.Y,PastbmpOriginal.Width,PastbmpOriginal.Height);
						if(rect.Contains(new Point(e.X,e.Y )))
						{
							Cursor=Cursors.SizeAll;
						}
						else
						{
							Cursor=selectedCursor;
						}
						prevpnt=new Point(e.X,e.Y );
					}
					break;

				}
				

			}
			base.OnMouseMove (e);
			if(firstInput == 110){selectedObj=lastSelectedObject;}
		}
		public string SourceFileName
		{
			get{return srcFileName;}
			set{
				srcFileName=value;
				if (System.IO.File.Exists(srcFileName))
				{
					System.Drawing.Image im=Image.FromFile(srcFileName);
					TempFileCollection tf=new TempFileCollection();
					 path=tf.BasePath +Guid.NewGuid().ToString();
					im.Save(path);
					srcFileName=path;
				}
				}
		}
		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			
			
			
			NoMovingStill=true;
			switch(selectedObj)
			{
				case 0:{
					
					if(FinishRect && controlStepMouseDown )
					{
						
						
						int count=points.Count;

						int xDist,yDist;
						moving=true;
						xDist=e.X -prevpnt.X;
						yDist=e.Y -prevpnt.Y;
						minX+=xDist;
						maxX+=xDist;
						minY+=yDist;
						maxY+=yDist;
						
						if(maxX<minX)
						{
							int temp=minX;
							minX=maxX;
							maxX=temp;
						}
						if(maxY<minY)
						{
							int temp=minY;
							minY=maxY;
							maxY=temp;
						}
						//////////////////////////
						Point p;
						Point []ps=new Point[points .Count ];


						for(int i=0;i<points.Count ;i++)
						{
							p=(Point)points[i];
							p.X += xDist;
							p.Y += yDist;
							points[i]=p;
						}
						for(int i=0;i<points.Count ;i++)
						{
							ps[i]=(Point)points[i];
						}
						//////////////////////////
						//						externPath.Reset();	
						System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();
						
						
						switch(lastSelectedObj)
						{
							case 2:
							{
								if(shiftOccuredMove )
								{
									gp.AddEllipse (minX,minY,maxX-minX,maxX-minX);
								}
								else
								{
									gp.AddEllipse(minX,minY,maxX-minX,maxY-minY);
								}
								break;}
							case 3:
							{
								if(shiftOccuredMove )
								{
									gp.AddRectangle (new Rectangle (minX,minY,maxX-minX,maxX-minX));
								}
							
								else
								{
									gp.AddRectangle(new Rectangle (minX,minY,maxX-minX,maxY-minY));
								}
								break;}
							case 4:
							{
								gp.AddPolygon(ps);
								break;}
							case 5:
							{
								gp.AddPolygon(ps);
								break;}
							case 50:
							{
								CreateRoundRect(new Rectangle(minX,minY,maxX-minX,maxY-minY),out gp,new Size(7,7));
								break;
							}
						}
						System.Drawing.Graphics g=Graphics.FromImage(Image);
					
						g.DrawImage(MovingbmpOriginal   ,0,0);
						
						g.SetClip(gp );
						g.DrawImage(TextbmpOriginal  ,minX -orginalx   ,minY-orginaly  );						
						if(NoMovingStill)
							{
								if(shiftOccured)
								{									
									g.FillPath(Brushes.White ,lastGraphicPath );
								}
							}
						
					}
					prevpnt=new Point(e.X,e.Y );
					Refresh();
					controlStepMouseDown=false;break;}
				case 1:{;break;}
				case 13:
				case 2:
				{
					OneTime=0;
					if(shiftOccured)shiftOccuredMove=true;
					
					
					Pen p=new Pen(selectedColor );
					p.Width=(BrushWidth);
					p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
					if(bDash)p.DashPattern=new float[2]{2,3};
					
					if(initPixelSelected &&(!FinishRect ))
					{
						maxX = e.X ;
						maxY =e.Y ;FinishRect=true;
						int x,y,width,height;
						System.Drawing.Graphics g=Graphics.FromImage(this.Image);
						
						if(e.X<minX)
						{
							if(e.Y <minY)
							{
								x=e.X;
								y=e.Y;
								width=minX-e.X;
								height=minY -e.Y;
							}
							else
							{
								x=e.X;
								y=minY;
								width=minX-x;
								height=e.Y-y;
							}
						}
						else
						{
							if(e.Y <minY)
							{
								x=minX ;
								y=e.Y;
								width=e.X-x;
								height=minY -y;
							}
							else
							{
								x=minX ;
								y=minY ;
								width=e.X-x;
								height=e.Y -y;
							}
						}
						if(selectedObj==13)
						{
							//g.FillEllipse ( new SolidBrush(selectedColor ),minX,minY,maxX-orginalx ,maxY-orginaly );
						}
						else
						{
							if(shiftOccured )
							{
								g.DrawEllipse( p,x,y,width,width);
								externPath.AddEllipse(x,y,width,width);
							}
							else
							{
								g.DrawEllipse( p,x,y,width,height);
								externPath.AddEllipse(x,y,width,height);
							}
						}
						Refresh();
						
						
						
					}
					System.Drawing.Graphics g1=Graphics.FromImage(Image);
					p.Color=selectedColor ;
					int xDist,yDist,WIDTH=0,HEIGHT=0;
					
						
					xDist=e.X -prevpnt.X;
					yDist=e.Y -prevpnt.Y;
					minX+=xDist;
					maxX+=xDist;
					minY+=yDist;
					maxY+=yDist;
					
					if(maxX<minX)
					{
						int temp=minX;
						minX=maxX;
						maxX=temp;
					}
					if(maxY<minY)
					{
						int temp=minY;
						minY=maxY;
						maxY=temp;
					}
					if(shiftOccuredMove )
					{
						if(selectedObj == 13)
						{
							g1.DrawImage(TextbmpOriginal ,0,0);
							g1.FillEllipse(new SolidBrush(selectedColor ),minX,minY,maxX-minX ,maxY -minY);
							Refresh();
						}
						//else
						//	g1.DrawRectangle(p,minX,minY,maxX-orginalx ,maxY -orginaly );

					}
					else
					{
						if(selectedObj == 13)
						{
							g1.DrawImage(TextbmpOriginal ,0,0);
							g1.FillEllipse(new SolidBrush(selectedColor ), minX,minY ,maxX-minX ,maxY -minY);
							Refresh();
						}
						//else
						//g1.DrawRectangle(p,minX,minY,maxX-orginalx ,maxY -orginaly );
						initPixelSelected=false;
					}
					orginalx=minX;
					orginaly=minY;
					break;
				}
				case 50:
				{
					OneTime=0;
					if(shiftOccured)shiftOccuredMove=true;
					
					
					Pen p=new Pen(selectedColor );
					p.Width=(BrushWidth);
					p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
					if(bDash)p.DashPattern=new float[2]{2,3};
					
					if(initPixelSelected)
					{
						if(!FinishRect){maxX = e.X ;maxY =e.Y ;}
						FinishRect=true;
						System.Drawing.Graphics g=Graphics.FromImage(Image);											
						int xDist,yDist;
						moving=true;
						xDist=e.X -prevpnt.X;
						yDist=e.Y -prevpnt.Y;
						minX+=xDist;
						maxX+=xDist;
						minY+=yDist;
						maxY+=yDist;
						
						if(maxX<minX)
						{
							int temp=minX;
							minX=maxX;
							maxX=temp;
						}
						if(maxY<minY)
						{
							int temp=minY;
							minY=maxY;
							maxY=temp;
						}
						if(shiftOccured )
						{

							//RoundRect(graphicMainHdc,minX,minY,maxX-minX,maxY-minY,5,5);																	
							GraphicsPath gp;
							CreateRoundRect(new Rectangle(minX,minY,maxX-minX,maxX-minX),out gp,new Size(7,7));
							if(BrushWidth >= maxX-minX)
								g.FillPath(new SolidBrush( selectedColor ),gp);						
							else
								g.DrawPath(new Pen( selectedColor ,BrushWidth ),gp);
							Refresh();
							//ReleaseDC((System.IntPtr )null ,g.GetHdc());
						}
						else
						{
							
							//RoundRect(graphicMainHdc,minX,minY,maxX-minX,maxY-minY,5,5);																	
							GraphicsPath gp;
							CreateRoundRect(new Rectangle(minX,minY,maxX-minX,maxY-minY),out gp,new Size(7,7));

							g.DrawImage(TextbmpOriginal ,0,0);
							if(BrushWidth >= maxX-minX)
								g.FillPath(new SolidBrush( selectedColor ),gp);						
							else
								g.DrawPath(new Pen( selectedColor ,BrushWidth ),gp);
							Refresh();
							//ReleaseDC((System.IntPtr )null ,g.GetHdc());
						}
						
					}
					lastSelectedObj=50;
					initPixelSelected=false;
					orginalx=minX;
					orginaly=minY;
					prevpnt=new Point(e.X,e.Y );
					break;
					
				}
				case 17:
				case 3:
				{
					OneTime=0;
						if(shiftOccured)shiftOccuredMove=true;
					
					
					Pen p=new Pen(selectedColor );
					p.Width=(BrushWidth);
					p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
					if(bDash)p.DashPattern=new float[2]{2,3};
					
					if(initPixelSelected /*&&(!FinishRect )*/)
					{
						if(!FinishRect){maxX = e.X ;maxY =e.Y ;}
						FinishRect=true;
						int x=0,y=0,width=0,height=0;
						System.Drawing.Graphics g=Graphics.FromImage(this.Image);
		
						int xDist,yDist;
						moving=true;
						xDist=e.X -prevpnt.X;
						yDist=e.Y -prevpnt.Y;
						minX+=xDist;
						maxX+=xDist;
						minY+=yDist;
						maxY+=yDist;

						if(maxX<minX)
						{
							int temp=minX;
							minX=maxX;
							maxX=temp;
						}
						if(maxY<minY)
						{
							int temp=minY;
							minY=maxY;
							maxY=temp;
						}
						if(shiftOccured )
							if(selectedObj!=17 )
								g.DrawRectangle( p,x,y,width,width);
							else
								g.FillRectangle( new SolidBrush(selectedColor ),x,y,width,width);
						else
							if(selectedObj!=17 )
						{
							//Refresh();
							g.DrawRectangle( p,x,y,width,height );
						}
						else
						{
							Bitmap bmpNew=new Bitmap(maxX-minX,maxY-minY);
							Graphics gBmpNew=Graphics.FromImage(bmpNew);
							gBmpNew.FillRectangle(new SolidBrush(selectedColor   ),0,0,maxX-minX,maxY-minY);
							g.ExcludeClip(new Region(new Rectangle(minX ,minY,maxX-minX,maxY-minY) ));
							g.DrawImage(TextbmpOriginal ,0,0);
							g.SetClip(new Rectangle(minX ,minY,maxX-minX,maxY-minY));
							if(selectedColor.A <200)
								g.DrawImage(TextbmpOriginal ,0,0);
							g.DrawImage (bmpNew,minX ,minY,maxX-minX,maxY-minY);
							Refresh();
						}
						
						
						
						
					}

					initPixelSelected=false;
					orginalx=minX;
					orginaly=minY;
					break;
					
				}
				case 4:
				{
					OneTime=0;
					if(controlStepMouseDown && controlStepMouse)			
					{
						System.Drawing.Graphics g=Graphics.FromImage(Image );
						Pen p=new Pen(selectedColor ,1);
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
						//g.DrawRectangle(p,minX-1,minY-1,maxX-minX+1 ,maxY-minY+1);
					}
					if(controlStepMouseDown && controlStepMouse &&(!FinishRect ))
					{
						controlStepMouseDown=false;
						FinishRect=true;
						points.Add(new Point(e.X,e.Y));
						maxX = (maxX > e.X )?maxX:e.X ;
						maxY = (maxY > e.Y )?maxY:e.Y ;
						minX = (minX < e.X )?minX:e.X ;
						minY = (minY < e.Y )?minY:e.Y ;
						int count=points.Count;
						points.Add((Point)points[0]);
						System.Drawing.Graphics g=Graphics.FromImage(Image );
						Pen p=new Pen(selectedColor ,(float)BrushWidth);
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ; ;
						
						orginalx=minX;
						orginaly=minY;
						moving=false;

					}
					System.Drawing.Graphics g1=Graphics.FromImage(Image );
					Pen p1=new Pen(selectedColor ,(float)BrushWidth);
					p1.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
					Point []ps=new Point[points .Count ];
					for(int i=0;i<points.Count ;i++)
					{
						ps[i]=(Point)points[i];
					}
					if(ps.Length<3)return;		
					g1.DrawPolygon(p1,ps);
					p1.Width=(BrushWidth);
					p1.Color=selectedColor;
					//g1.DrawRectangle(p1,minX-1,minY-1,maxX-minX+1 ,maxY-minY+1);
					controlStepMouseDown=false;

					Refresh();
					
					break;
				}
				case 140:
				{
						OneTime=0;
					if(!con)
					{
						Cursor=selectedCursor;
						System.Drawing.Graphics g=Graphics.FromImage(Image );
					
						Pen p=new Pen(selectedColor ,1);
						//p.DashOffset=2;
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
							
						con=true;
						
						Point []ps=new Point[points .Count ];


					
						for(int i=0;i<points.Count ;i++)
						{
							ps[i]=(Point)points[i];
						}
						//System.Drawing.Graphics g=Graphics.FromImage(Image);
						Pen p1=new Pen(selectedColor ,(BrushWidth));
						p1.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
						g.FillPolygon(new SolidBrush (selectedColor)  ,ps);
						
						
					}
					orginalx=minX;
					orginaly=minY;
					FinishRect=true;
					moving=false;
					break;
				}
				case 5:
				{OneTime=0;
					if(!con)
					{
						Cursor=selectedCursor;
						System.Drawing.Graphics g=Graphics.FromImage(Image );
					
						Pen p=new Pen(selectedColor ,1);
						//p.DashOffset=2;
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
							
						con=true;
						
						Point []ps=new Point[points .Count ];


					
						for(int i=0;i<points.Count ;i++)
						{
							ps[i]=(Point)points[i];
						}
						//System.Drawing.Graphics g=Graphics.FromImage(Image);
						Pen p1=new Pen(selectedColor ,(BrushWidth));
						p1.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
						g.DrawPolygon(p1,ps);
						
						//g.DrawRectangle(p,minX,minY,maxX-minX ,maxY-minY);
						
					}
					orginalx=minX;
					orginaly=minY;
					FinishRect=true;
					moving=false;
					break;
				}
				case 20:
				{
					//controlStepMouseDown=false;
					if(controlStepMouseDown && controlStepMouse)			
					{
						System.Drawing.Graphics g=Graphics.FromImage(Image);
						Pen p=new Pen(selectedColor ,1);
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
						g.DrawRectangle(p,minX-1,minY-1,maxX-minX+1 ,maxY-minY+1);
					}
					if(controlStepMouseDown && controlStepMouse &&(!FinishRect ))
					{
						controlStepMouseDown=false;
						FinishRect=true;
						points.Add(new Point(e.X,e.Y));
						maxX = (maxX > e.X )?maxX:e.X ;
						maxY = (maxY > e.Y )?maxY:e.Y ;
						minX = (minX < e.X )?minX:e.X ;
						minY = (minY < e.Y )?minY:e.Y ;
						int count=points.Count;
						points.Add((Point)points[0]);
						System.Drawing.Graphics g=Graphics.FromImage(Image);;
				
						for(int i=0;i<points.Count-1 ;i++)
						{
						
							g.DrawLine(new System.Drawing.Pen(Color.White ,1)  ,(Point )points[i],(Point )points[i+1]);
						}
						Pen p=new Pen(selectedColor ,1);
						p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
						
						
						g.DrawRectangle(p,minX-1,minY-1,maxX-minX+1 ,maxY-minY+1);
						orginalx=minX;
						orginaly=minY;
						moving=false;

					}
					else
					{
						if(!con)
						{
							Cursor=selectedCursor;
							System.Drawing.Graphics g=Graphics.FromImage(Image);
							for(int i=0;i<points.Count-1 ;i++)
							{
						
								g.DrawLine(new System.Drawing.Pen(Color.White ,2),(Point)points[i],(Point)points[i+1]);
							}
							Pen p=new Pen(selectedColor ,1);
							//p.DashOffset=2;
							p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
							
							con=true;
							Point []ps=new Point[points .Count ];
							for(int i=0;i<points.Count ;i++)
							{
								ps[i]=(Point)points[i];
							}
							
							System.Drawing.Graphics g1=Graphics.FromImage(Image );
							//Image.Save("exam.bmp");
							Bitmap Tempbmp=new Bitmap(Image);Image im=Tempbmp;
							System.Drawing.Drawing2D.GraphicsPath P = new System.Drawing.Drawing2D.GraphicsPath();
							g1.ResetClip();
							P.AddPolygon(ps);
							g1.ExcludeClip (new Region(P));
							g1.DrawImage(im ,0,0);
							g1.SetClip(P);
					
							g1.DrawImage(im ,minX -orginalx ,minY -orginaly );
							Refresh();g.DrawRectangle(p,minX,minY,maxX-minX ,maxY-minY);
						}
						moving=false;
					}
					if(controlStepMouse && controlStepMouseDown )
					{
						Point []ps=new Point[points .Count ];
						for(int i=0;i<points.Count ;i++)
						{
							ps[i]=(Point)points[i];
						}
							
						System.Drawing.Graphics g1=Graphics.FromImage(Image );
						//Image.Save("exam.bmp");
						Bitmap Tempbmp=new Bitmap(Image);Image im=Tempbmp;
						System.Drawing.Drawing2D.GraphicsPath P = new System.Drawing.Drawing2D.GraphicsPath();
						g1.ResetClip();
						P.AddPolygon(ps);
						g1.ExcludeClip (new Region(P));
						g1.DrawImage(im ,0,0);
						g1.SetClip(P);
					
						g1.DrawImage(im ,minX -orginalx ,minY -orginaly );
						Refresh();this.CreateGraphics().DrawRectangle(Pens.DarkRed ,minX-1,minY-1,maxX-minX+1 ,maxY-minY+1);
					}
					controlStepMouseDown=false;
					break;
				}
				case 7:
				{
					controlStepMouseDown=false;
					break;
				}				
				case 9:
				case 90:
				case 99:
				{
					controlStepMouseDown=false;
					break;
				}
				case 10:
				{
					if(stampSelected )
					{
						System.Drawing.Drawing2D.GraphicsPath gp=new System.Drawing.Drawing2D.GraphicsPath();
						gp.AddEllipse(e.X -BrushWidth/2,e.Y-BrushWidth/2,BrushWidth ,BrushWidth );
						/*Bitmap Tempbmp=new Bitmap ( Image );
						Image im=Tempbmp;*/
						System.Drawing.Graphics g=Graphics.FromImage(Image);
						//g.DrawImage(TextbmpOriginal,0,0);
						g.SetClip(gp );
						g.DrawImage(TextbmpOriginal  , e.X -orginalx  ,e.Y  -orginaly  );
						
						Refresh();
					}
					else
						stampSelected=true;
					break;
				}

				case 11:
				{
					controlStepMouseDown=false;
					break;
				}
				case 14:
				{
					controlStepMouseDown=false;
					break;
				}
				case 18:
				{									
					toolBox.lblLeftColor.BackColor=selectedColor=bmpOriginal.GetPixel(e.X,e.Y );
					break;
				}
				case 15:
				{					
					Graphics g=Graphics.FromImage (Image);
					Pen p=new Pen(selectedColor  ,1);	
					p.Width=BrushWidth;
					//Refresh();
					g.DrawImage(TextbmpOriginal,0,0);
					g.DrawLine(p,new Point (prevpnt.X ,prevpnt.Y),new Point(e.X,e.Y ));						
					controlStepMouseDown=false;
					Refresh();
					break;
				}
				case 110:
				{
					
					if(!TextIsReset && !bTextFinish && controlStepMouseDown)
					{
						Graphics g=Graphics.FromImage(Image);
						g.DrawImage(TextbmpOriginal,0,0);
						Refresh();
						if(!FinishRect){maxX = e.X ;maxY =e.Y ;}
						FinishRect=true;
						int xDist,yDist;
						moving=true;
						xDist=e.X -prevpnt.X;
						yDist=e.Y -prevpnt.Y;
						minX+=xDist;
						maxX+=xDist;
						minY+=yDist;
						maxY+=yDist;
						
						if(maxX<minX)
						{
							int temp=minX;
							minX=maxX;
							maxX=temp;
						}
						if(maxY<minY)
						{
							int temp=minY;
							minY=maxY;
							maxY=temp;
						}
						initPixelSelected=false;
						orginalx=minX;
						orginaly=minY;
						text.AutoSize =true;
						text.Text="";
						text.ForeColor=selectedColor;
						text.Font=TextFont;
						TextRectangle=new Rectangle(minX,minY ,maxX-minX,maxY-minY);
						text.Location =new Point(minX,minY );
						text.Multiline=true;
						
						
						text.Size =new Size(maxX-minX,maxY-minY);
						
						text.BorderStyle=BorderStyle.FixedSingle ;
						Controls.Add(text);
						text.Focus();
					}
					/*else
					{
						PictureView. controlStepMouseDown =false;
						PictureView.TextIsReset=false;
						PictureView.FinishRect=false;
						PictureView.bTextFinish=false;
						TextbmpOriginal=(Bitmap)Image.Clone();
						TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
					}*/
					controlStepMouseDown=false;
					break;
				}
				case 25:
				{
					Graphics g=Graphics.FromImage(Image);
					int xDist,yDist;
					moving=true;
					minX=TextRectangle.X;
					minY=TextRectangle.Y;
					xDist=e.X -prevpnt.X;
					yDist=e.Y -prevpnt.Y;
					minX+=xDist;
					minY+=yDist;
					xDist=TextRectangle.Width;
					yDist=TextRectangle.Height;
					Pen pen=new Pen(Color.Black);
					pen.DashStyle=DashStyle.Dash;
					TextRectangle=new Rectangle(minX,minY,PastbmpOriginal.Width ,PastbmpOriginal.Height );
					g.DrawImage(TextbmpOriginal  ,0,0);
					g.DrawImage(PastbmpOriginal,TextRectangle);
					
					prevpnt=new Point(e.X,e.Y );

					Refresh();
					controlStepMouseDown=false;
					break;
				}
			}
			if(e.Button == System.Windows.Forms.MouseButtons.Right){selectedColor= lastColor;}
			Cursor=selectedCursor ;
					base.OnMouseUp (e);
		}
		

		void Text_Fixed(object sender,EventArgs e)
		{
			
		
			if(text.Text !="")
			{
				TextIsReset=false;
				TextbmpOriginal=new Bitmap( Image);bTextFinish=true;
				TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
				lastUndoPath=MainForm.arrPaths[0];
				MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
				Graphics g=Graphics.FromImage(Image );
				TextRectangle=text.Bounds;
				string str=ToFarsi(text.Text);
				if(!bVertical)
				{
					if(!bIsFarsi&&!bFarsiNumber&&bIsDigit)
						g.DrawString(str,TextFont,new SolidBrush(selectedColor ),TextRectangle );
					else
						g.DrawString(str,TextFont,new SolidBrush(selectedColor ),TextRectangle , new StringFormat(StringFormatFlags.DirectionRightToLeft   ));
				}
				else
					g.DrawString(str,TextFont,new SolidBrush(selectedColor ),TextRectangle , new StringFormat(StringFormatFlags.DirectionVertical    ));
				Controls.Remove(text);

				Refresh();
			}
		}
		public bool ControlPoly
		{
			get{return this.controlPloy;}
			set{this.controlPloy=value;}

		}
	
		private void MouseMoveStepMouse(System.Windows.Forms.MouseEventArgs e)
		{

			switch(selectedObj)
			{
				case 0:{break;}
				case 1:{;break;}
				case 2:{;break;}
				case 3:{;break;}
				case 4:
				{
					int count=points.Count;
					points.Add(new Point(e.X,e.Y));
					maxX = (maxX > e.X )?maxX:e.X ;
					maxY = (maxY > e.Y )?maxY:e.Y ;
					minX = (minX < e.X )?minX:e.X ;
					minY = (minY < e.Y )?minY:e.Y ;
					System.Drawing.Graphics g=CreateGraphics();
					
					for(int i=0;i<points.Count ;i++)
					{
						//g.DrawImage(TextbmpOriginal,0,0);
						g.DrawLine(Pens.Goldenrod ,(Point )points[count-1],(Point )points[count]);
					}
					
					break;
				}
				case 5:
				{
					break;
				}
				case 20:
				{
					int count=points.Count;
					points.Add(new Point(e.X,e.Y));
					maxX = (maxX > e.X )?maxX:e.X ;
					maxY = (maxY > e.Y )?maxY:e.Y ;
					minX = (minX < e.X )?minX:e.X ;
					minY = (minY < e.Y )?minY:e.Y ;
					System.Drawing.Graphics g=Graphics.FromImage(Image);
					
					for(int i=0;i<points.Count ;i++)
					{
						
						g.DrawLine(Pens.Goldenrod ,(Point )points[count-1],(Point )points[count]);
					}
					break;
				}
			}
					
		}
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			
			
			if(e.Button == System.Windows.Forms.MouseButtons.Right){lastColor=selectedColor ;selectedColor=ToolBox.colorLeft;}
			switch(selectedObj)
			{
				case 0:{
						//tempImage=new Bitmap(Image);
						controlStepMouseDown=true;
					if( (FinishRect)&&
						((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
					{
						minX=0 ;minY=0;maxX=0;maxY=0;
						points.Clear();

						initPixelSelected=false;shiftOccuredMove=false;FinishRect=false;return;}
					if(FinishRect && !TextIsReset  )
					{
						
						
						int count=points.Count;
						TextIsReset=true;
						TextbmpOriginal=new Bitmap(PictureView.MovingbmpOriginal );
						TextbmpOriginal.SetResolution(100,100);
						if(shiftOccured )
						{
							Graphics g=Graphics.FromImage (MovingbmpOriginal);
							lastGraphicPath=new GraphicsPath();
							int xDist,yDist;
							moving=true;
							xDist=e.X -prevpnt.X;
							yDist=e.Y -prevpnt.Y;
							minX+=xDist;
							maxX+=xDist;
							minY+=yDist;
							maxY+=yDist;

							//////////////////////////
							Point p;
							Point []ps=new Point[points .Count ];


							for(int i=0;i<points.Count ;i++)
							{
								p=(Point)points[i];
								p.X += xDist;
								p.Y += yDist;
								points[i]=p;
							}
							for(int i=0;i<points.Count ;i++)
							{
								ps[i]=(Point)points[i];
							}
							switch(lastSelectedObj)
							{
								case 2:
								{
									if(shiftOccuredMove )
									{
										lastGraphicPath.AddEllipse (minX,minY,maxX-minX,maxX-minX);
									}
									else
									{
										lastGraphicPath.AddEllipse(minX,minY,maxX-minX,maxY-minY);
									}
									break;}
								case 3:
								{
									if(shiftOccuredMove )
									{
										lastGraphicPath.AddRectangle (new Rectangle (minX,minY,maxX-minX,maxX-minX));
									}
							
									else
									{
										lastGraphicPath.AddRectangle(new Rectangle (minX,minY,maxX-minX,maxY-minY));
									}
									break;}
								case 4:
								{
									lastGraphicPath.AddPolygon(ps);
									break;}
								case 5:
								{
									lastGraphicPath.AddPolygon(ps);
									break;}

								case 50:
								{
									CreateRoundRect(new Rectangle(minX,minY,maxX-minX,maxY-minY),out lastGraphicPath,new Size(7,7));
									break;
								}
							}
							
							g.FillPath(new SolidBrush(Color.White ),lastGraphicPath);
						}
					}
					
					break;
				}
				case 1:{break;}
				case 13:
				case 2:
				{	
					tempImage=new Bitmap(Image);
					lastSelectedObj=2;
					prevpnt=new Point(e.X,e.Y );
					initPixelSelected=true;

					if( (FinishRect)&&
						((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
					{
						minX=0 ;minY=0;maxX=0;maxY=0;
						initPixelSelected=false;shiftOccuredMove=false;FinishRect=false;TextIsReset=false;}
					if(!FinishRect)
					{
						
						maxX = e.X ;
						maxY =e.Y ;
						minX = e.X ;
						minY =e.Y ;
					}
					if(!TextIsReset)
					{
						TextbmpOriginal=new Bitmap(Image );
						TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
						lastUndoPath=MainForm.arrPaths[0];
						MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
						TextIsReset=true;
					}
					break;
				}
				case 17:
				case 3:
				{
					tempImage=new Bitmap(Image);
					controlStepMouseDown=true;
					lastSelectedObj=3;
					prevpnt=new Point(e.X,e.Y );
					initPixelSelected=true;
					if( (FinishRect)&&
						((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
					{
						minX=0 ;minY=0;maxX=0;maxY=0;
						initPixelSelected=false;shiftOccuredMove=false;TextIsReset=false;FinishRect=false;}
					if(!FinishRect)
					{
						
						maxX = e.X ;
						maxY =e.Y ;
						minX = e.X ;
						minY =e.Y ;
					}
					if(!TextIsReset)
					{
							
						TextbmpOriginal=new Bitmap(Image );
						TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
						
						MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
						lastUndoPath=MainForm.arrPaths[0];
						TextIsReset=true;
					}
					break;
				}
				case 50:
				{
					controlStepMouseDown=true;
					tempImage=new Bitmap(Image);
					prevpnt=new Point(e.X,e.Y );
					initPixelSelected=true;

					if( (FinishRect)&&
						((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
					{
						minX=0 ;minY=0;maxX=0;maxY=0;TextIsReset=false; initPixelSelected=true;shiftOccuredMove=false;FinishRect=false;}
					if(!FinishRect)
					{
						
						maxX = e.X ;
						maxY =e.Y ;
						minX = e.X ;
						minY =e.Y ;
					}
					if(!TextIsReset)
					{
						TextbmpOriginal=new Bitmap(Image );
						TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
						lastUndoPath=MainForm.arrPaths[0];
						MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
						TextIsReset=true;
					}
					prevpnt=new Point(e.X,e.Y );
					break;
				}
				case 4:
				{
					
					lastSelectedObj=4;
					if( (FinishRect) && (points.Count >=2)&&
						((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
					{
						minX=this.Width ;minY=this.Height;maxX=0;maxY=0;points.Clear();
						FinishRect=false;TextIsReset=false;
						
					}
					if(!FinishRect)
					{
						points.Add(new Point(e.X,e.Y));
						maxX = e.X ;
						maxY =e.Y ;
						minX = e.X ;
						minY =e.Y ;
					}
					
					if(!TextIsReset)
					{
						TextbmpOriginal=new Bitmap(Image );
						TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
						lastUndoPath=MainForm.arrPaths[0];
						MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
						TextIsReset=true;
					}
					controlStepMouseDown=true;
					break;
				}
				case 140:
				case 5:
				{
					lastSelectedObj=5;
					prevpnt=new Point(e.X,e.Y );
					if((!controlPloy)&&(destroied))
					{
						orginalx=minX ;orginaly=minY ;
					}
					destroied=false;
					if(!controlPloy)
					{
			
						base.OnMouseDown (e);
						if( (e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY))
						{
							minX=this.Width ;minY=this.Height;maxX=0;maxY=0;points.Clear();
							this.Refresh();controlPloy=true;con=true;bPloyFinished=false;destroied=false;
							TextbmpOriginal=(Bitmap)Image.Clone();
							TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
							lastUndoPath=MainForm.arrPaths[0];
							MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);goto Label1;
						}
						con=false;						
						Cursor=System.Windows.Forms.Cursors.SizeAll ;return;	
					}
				Label1:	if(
						( points.Count > 2 )
						&&
						( (((Point)points[0] ).X-3 <e.X)&&(( (Point)points[0] ).X+3 >e.X)  )
						&& 
						( (((Point)points[0] ).Y-3 <e.Y)&&(( (Point)points[0] ).Y+3 >e.Y)  )
						)
					{
						points.Add(points[0] );
						if(points.Count !=0)
						{
							System.Drawing.Graphics g=Graphics.FromImage(Image );
							Point []ps=new Point[points .Count ];
							bPloyFinished=true;
							for(int i=0;i<points.Count ;i++)
							{
								ps[i]=(Point)points[i];
							}
								
							Pen p=new Pen(selectedColor ,(float)BrushWidth);

							//p.DashOffset=2;
							p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
							if(selectedObj == 140)
								g.FillPolygon(new SolidBrush (selectedColor ),ps);
							else
                                 g.DrawPolygon(p,ps);
								
							Refresh();
						//	this.CreateGraphics().DrawRectangle(Pens.DarkRed ,minX,minY,maxX-minX ,maxY-minY);
							pointsCoped=(ArrayList )points.Clone();
							destroied=true;
							
						}
						controlPloy=false;
					}
					else
					{
						bPloyFinished=false;
						System.Drawing.Graphics g=Graphics.FromImage(Image );;
						points.Add(new Point(e.X,e.Y));
						maxX = (maxX > e.X )?maxX:e.X ;
						maxY = (maxY > e.Y )?maxY:e.Y ;
						minX = (minX < e.X )?minX:e.X ;
						minY = (minY < e.Y )?minY:e.Y ;
						if(points.Count >=2)
							g.DrawLine(new System.Drawing.Pen(Color.Gray ,2),(Point )points[points.Count-2],new Point(e.X,e.Y));
						else
							g.DrawLine(new System.Drawing.Pen(Color.Gray ,2),(Point )points[points.Count-1],new Point(e.X,e.Y));
						Refresh();
					}
					lastSelectedObj=5;
					
					break;
				}
				case 20:
				{
					lastSelectedObj=6;
					if(controlStepMouse )
					{
						if( (FinishRect) && (points.Count >=2)&&
							((e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)))
						{
								minX=this.Width ;minY=this.Height;maxX=0;maxY=0;points.Clear();
							FinishRect=false;}
						if(!FinishRect)
						{
							points.Add(new Point(e.X,e.Y));
							maxX = e.X ;
							maxY =e.Y ;
							minX = e.X ;
							minY =e.Y ;
						}
						
						controlStepMouseDown=true;
					}
					else
					{
			
						prevpnt=new Point(e.X,e.Y );
						if((!controlPloy)&&(destroied))
						{
							orginalx=minX ;orginaly=minY ;}
						destroied=false;
						if(!controlPloy)
						{
			
							base.OnMouseDown (e);
							if( (e.X<minX )||(e.X> maxX) || (e.Y<minY )||(e.Y> maxY)){minX=this.Width ;minY=this.Height;maxX=0;maxY=0;points.Clear();
							
								
								this.Refresh();controlPloy=true;return;}
							con=false;Cursor=System.Windows.Forms.Cursors.SizeAll ; return;}
						if(
							( points.Count > 2 )
							&&
							( (((Point)points[0] ).X-3 <e.X)&&(( (Point)points[0] ).X+3 >e.X)  )
							&& 
							( (((Point)points[0] ).Y-3 <e.Y)&&(( (Point)points[0] ).Y+3 >e.Y)  )
							)
						{
							points.Add(points[0] );
							if(points.Count !=0)
							{
								System.Drawing.Graphics g=Graphics.FromImage(Image );
								Point []ps=new Point[points .Count ];
								for(int i=0;i<points.Count ;i++)
								{
									ps[i]=(Point)points[i];
								}
								
								Pen p=new Pen(Color.White ,2);
								//p.DashOffset=2;
								//p.DashStyle=(bDash)?System.Drawing.Drawing2D.DashStyle.Custom:System.Drawing.Drawing2D.DashStyle.Solid ;;
								g.DrawPolygon(p,ps);
								
								Refresh();
								this.CreateGraphics().DrawRectangle(Pens.DarkRed ,minX,minY,maxX-minX ,maxY-minY);
								pointsCoped=(ArrayList )points.Clone();
								destroied=true;
								
							}
							controlPloy=false;
						}
						else
						{
							System.Drawing.Graphics g=Graphics.FromImage(Image );;
							points.Add(new Point(e.X,e.Y));
							maxX = (maxX > e.X )?maxX:e.X ;
							maxY = (maxY > e.Y )?maxY:e.Y ;
							minX = (minX < e.X )?minX:e.X ;
							minY = (minY < e.Y )?minY:e.Y ;
							if(points.Count >=2)
								g.DrawLine(new System.Drawing.Pen(Color.Gray ,2),(Point )points[points.Count-2],new Point(e.X,e.Y));
							else
								g.DrawLine(new System.Drawing.Pen(Color.Gray ,2),(Point )points[points.Count-1],new Point(e.X,e.Y));
							Refresh();
						}
					}
				}
					break;
				case 7:
				{
//					tempImage=new Bitmap(Image);
					points.Add(new Point(e.X,e.Y ));
					controlStepMouseDown=true;
					break;
				}				
				case 9:	
				case 90:
				case 99:
				{
					points.Add(new Point(e.X,e.Y ));
					controlStepMouseDown=true;lastUndoPath=MainForm.arrPaths[0];
					MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
					MainForm.mnuUndo.Enabled=true;
					break;
				}
				case 10:
				{
					//stampSelected=true;
					if(!stampSelected )
					{
						orginalx=e.X;
						orginaly=e.Y;
						Cursor=selectedCursor;lastUndoPath=MainForm.arrPaths[0];
						MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
						MainForm.mnuUndo.Enabled=true;
					}
					break;
				}
				case 11:
				{
					controlStepMouseDown=true;
					break;
				}
				case 14:
					points.Add(new Point(e.X,e.Y ));
				{
					controlStepMouseDown=true;
					break;
				}
				case 16:
				{
					
					try
					{
						if(BrushWidth>=(512))
							ZoomLenght=ZoomLenght+0.2f;
						else
							ZoomLenght=ZoomLenght-0.2f;
						if(ZoomLenght>0 && ZoomLenght<16)
						{
							
							int w=this.Width ;
							int h=this.Height;
							this.Size=new Size((int)(w*ZoomLenght),(int)(w*ZoomLenght));
						}
					
					
						//Refresh();		
					}
					catch(Exception ex){}
					
					break;			
				}
				case 23:
				{
					Bitmap b=new Bitmap(Image );

					selectedColor=b.GetPixel(e.X,e.Y );
					break;
				}
				case 15:
				{
					if(!controlStepMouseDown  )
					{
							
						prevpnt=new Point(e.X,e.Y );
					}
					TextbmpOriginal=(Bitmap)Image.Clone();
					TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
					lastUndoPath=MainForm.arrPaths[0];
					MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
					controlStepMouseDown=true;
					break;
				}

				case 110:
				{
					if(!TextRectangle .Contains(new Point(e.X,e.Y ))&&FinishRect )
					{
						PictureView. controlStepMouseDown =false;
						PictureView.TextIsReset=false;
						PictureView.FinishRect=false;
						PictureView.bTextFinish=false;
						TextbmpOriginal=(Bitmap)Image.Clone();
						TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
						lastUndoPath=MainForm.arrPaths[0];
						MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
							Controls.Remove(text);
							Refresh();
						return;
						
					}
					if(!TextIsReset )
					{
						controlStepMouseDown=true;
						prevpnt=new Point(e.X,e.Y );
						initPixelSelected=true;
						if(!FinishRect)
						{
						
							maxX = e.X ;
							maxY =e.Y ;
							minX = e.X ;
							minY =e.Y ;
						}
					}
					break;
				}
				case 25:
				{
					
					Rectangle rect=new Rectangle(TextRectangle.X ,TextRectangle.Y,PastbmpOriginal.Width,PastbmpOriginal.Height);
					if(rect.Contains(new Point(e.X,e.Y )))
					{
						controlStepMouseDown=true;
						
					}
					prevpnt=new Point(e.X,e.Y);
					break;
				}
			}
				base.OnMouseDown (e);
		}

		public static void SetShift()
		{
			shiftOccured=true;
		}
		public static  void CancelShift()
		{
			shiftOccured=false;
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			if (selectedCursor!=null)Cursor=selectedCursor;
			switch(selectedObj )
			{
				case 10:
				{
					if(!stampSelected )
						Cursor=System.Windows.Forms.Cursors.NoMove2D;
					
					break;
				}
				default:{stampSelected=false;break;}
					
			}
			base.OnMouseEnter (e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			;
		switch(selectedObj )
			{
				case 10:
				{
					Refresh();
					break;
				}
				
					
			}
				
			
			base.OnMouseLeave (e);
		}
		void CreateRoundRect(Rectangle rect,out GraphicsPath gp,Size size)
		{
			int temp;
			gp=new GraphicsPath();
			if(rect.Height <0)
			{
				rect.Y +=rect.Height;
				rect.Height*=-1;
				temp=minX;
				minX =maxX;
				maxX=temp;
			}
			if(rect .Width <0)
			{
				rect.X +=rect.Width;
				rect.Width*=-1;
				temp=minY;
				minY =maxY;
				maxY=temp;
			}
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
		public static void PastPicture()
		{
			TextbmpOriginal=(Bitmap)bmpOriginal.Clone();
			TextbmpOriginal.SetResolution(100,100);MainForm.mnuUndo.Enabled=true;
			lastUndoPath=MainForm.arrPaths[0];
			MainForm.arrPaths[0]=Path.GetTempFileName();TextbmpOriginal.Save(MainForm.arrPaths[0]);
			Graphics g=Graphics.FromImage(bmpOriginal );
			g.DrawImage(PastbmpOriginal,00,0);
			TextRectangle=new Rectangle(0,0,PastbmpOriginal.Width,PastbmpOriginal.Height );
			controlStepMouseDown=false;
			
		}

		/*
		 * 	RoundRect(CreateGraphics().GetHdc(),10,10,30,20,5,5);		
		 * 	Point []pnts={new Point(10,10),new Point(30,10),new Point(30,20),new Point(10,20)};

			g.DrawClosedCurve(Pens.Black,pnts,0.6f,System.Drawing.Drawing2D.FillMode.Alternate );
			//g.DrawEllipse(Pens.Black,100,100,20,10); */
	}
}
