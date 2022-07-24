using System;
using System.Collections.Generic;
using System.IO;


namespace Juicios.Classes
{
	


	internal class Cases
	{
		//protected string _userFolder { get; set; }
		//public string UserFolder 
		//{ 
		//	get 
		//	{ 
		//		return _userFolder; 
		//	} 
		//	set 
		//	{
		//		_userFolder = value;
		//	} 
		//}

		public List<CaseItem> GetCases()
		{
			List<CaseItem> Expedientes = new List<CaseItem>();
			Constants constants = new Constants();
			string UserFolder = constants.GetUserFolder();
			string activosFolder = UserFolder + Constants.activosFolder;
			string inactivosFolder = UserFolder + Constants.inactivosFolder;
			string[] activosCategoriePathList = constants.GetDirectories(activosFolder);
			string[] inactivosCategoriePathList = constants.GetDirectories(inactivosFolder);
			foreach (string path in activosCategoriePathList)
			{
				var type = new DirectoryInfo(path).Name;
				foreach (string dir in constants.GetDirectories(path))
				{
					var name = new DirectoryInfo(dir).Name;
					Expedientes.Add(new CaseItem(type, name, true));
				}
			}
			foreach (string path in inactivosCategoriePathList)
			{
				var type = new DirectoryInfo(path).Name;
				foreach (string dir in constants.GetDirectories(path))
				{
					var name = new DirectoryInfo(dir).Name;
					Expedientes.Add(new CaseItem(type, name, false));
				}
			}
			return Expedientes;


		}
	}
}
