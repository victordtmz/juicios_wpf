using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juicios.Classes
{
	public class Constants
	{
		
		public const string enlaceFolder =  @"\OneDrive\enlace\";
		public const string activosFolder = enlaceFolder + @"Juicios\";
		public const string inactivosFolder = enlaceFolder + @"Juicios_archivados\";
		public const string OrangeCustom = "#F29850";
		public const string DarkBlueCustom = "#002142";
		public const string LightBlueCustom = "#7EAED9";
		public const string LightWhite = "#ebe6e3";

		public string GetUserFolder()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		}
		public string[] GetDirectories(string path)
		{
			return Directory.GetDirectories(path);
		}


	}
}
