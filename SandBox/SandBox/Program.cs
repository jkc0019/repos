using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SandBox
{
	class Program
	{
		List<clsPipeTile> TileGrid = new List<clsPipeTile>();

		clsPipeTile Tile = new clsPipeTile();
		
		static void Main(string[] args)
		{
			try
			{
				string strPuzzle = @"C:\XamagonXuzzleLP\XamagonXuzzle\XamagonXuzzle.Android\Resources\drawable\";

				if (File.Exists(strPuzzle + "BitmapE40.png"))
				{
					//strFile = strPuzzle + "BitmapE" + row + col + ".png";
					return;
				}
				else
				{
					return;
				}

				string strDirectory = @"C:\XamagonXuzzleLP\pipesegments\FullGrid6x6\Puzzle6\";

				for (Int32 intRow = 0; intRow < 6; intRow++)
				{
					for (Int32 intCol = 0; intCol < 6; intCol++)
					{
						//File.Copy(strDirectory + "Vertical.png", strDirectory + "Bitmap" + intRow + intCol + ".png");
						File.Copy(strDirectory + "Straight.png", strDirectory + "P5Bitmap" + intRow + intCol + ".png");
						//File.Delete(strDirectory + "Bitmap" + intRow + intCol + ".png");
					}
				}
			}
			catch (Exception ex)
			{

				throw (ex);
			}

			
		}

		public class clsPipeTile

		{

			public int xPos { get; set; }

			public int yPos { get; set; }

			public int entryEdge { get; set; }

			public int exitEdge { get; set; }

			public int degreePos { get; set; }

			public int ordinalPos { get; set; }

			public bool isConnected { get; set; }

		}
	}
}
