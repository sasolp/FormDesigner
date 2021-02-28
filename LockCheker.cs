using System;

namespace FormDesigner
{
	/// <summary>
	/// Summary description for LockCheker.
	/// </summary>
	public class LockCheker
	{
		public LockCheker()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public  bool IsCorrect()
		{
			//AxTINYLib.AxTiny axTiny=new AxTINYLib.AxTiny();
			TINYLib.TinyClass axTiny=new TINYLib.TinyClass();
			try
			{
				
				axTiny.Initialize = true;
				if (axTiny.TinyErrCode == 0)
				{
					axTiny.FirstTinyHID("521C4FEA6F4ABE68415FD9247EA1DC");
					if (axTiny.TinyErrCode == 0)
					{
						string strData = axTiny.GetDataPartitionHID(0, 149);
						if(strData=="‘—ò Å— Êê” —ÿ·Ê⁄_»«ﬁ—Ì")
							return true;
					}
					int a555=axTiny.TinyErrCode;
					System.Windows.Forms.MessageBox.Show(a555.ToString());
					return false;
				}
			
				return false;
			}
			catch(Exception e1)
			{
				int a555=axTiny.TinyErrCode;
				System.Windows.Forms.MessageBox.Show("Error:"+a555.ToString());
				return false;
			}
		}
	}
}
