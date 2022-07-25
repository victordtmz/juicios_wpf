using System;
using System.Collections.Generic;
using System.IO;
using Juicios;

namespace Juicios.Classes
{
	


	internal class Cases
	{
		
		public List<CaseItem> GetCases(bool Activos)
		{
			
			List<CaseItem> Expedientes = new List<CaseItem>();
			Constants constants = new Constants();
			string UserFolder = constants.GetUserFolder();
			string activosFolder = UserFolder + Constants.activosFolder;

			if (Activos)
			{
				string[] activosCategoriePathList = constants.GetDirectories(activosFolder);
				foreach (string path in activosCategoriePathList)
				{
					var type = new DirectoryInfo(path).Name;
					foreach (string dir in constants.GetDirectories(path))
					{
						var name = new DirectoryInfo(dir).Name;
						Expedientes.Add(new CaseItem(type, name, true));
					}
				}
			}
			else
			{
				string inactivosFolder = UserFolder + Constants.inactivosFolder;
				string[] inactivosCategoriePathList = constants.GetDirectories(inactivosFolder);
				foreach (string path in inactivosCategoriePathList)
				{
					var type = new DirectoryInfo(path).Name;
					foreach (string dir in constants.GetDirectories(path))
					{
						var name = new DirectoryInfo(dir).Name;
						Expedientes.Add(new CaseItem(type, name, false));
					}
				}
			}

			return Expedientes;

		}
	}
}
