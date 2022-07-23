using System;
using System.Collections.Generic;
using System.IO;


namespace Juicios.Classes
{
	internal class Cases
	{
		public static void Temp(string[] args)
		{
			string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			string activosFolder = userFolder + @"\OneDrive\enlace\Juicios\";
			string inactivosFolder = userFolder + @"\OneDrive\enlace\Juicios_archivados\";
			string[] activosCategoriePathList = Directory.GetDirectories(activosFolder);
			string[] inactivosCategoriePathList = Directory.GetDirectories(inactivosFolder);
			List<CaseItem> Expedientes = new List<CaseItem>();

		Populate(ref Expedientes, activosCategoriePathList);
			Populate(ref Expedientes, inactivosCategoriePathList, false);
			foreach (CaseItem expediente in Expedientes)
			{
				Console.WriteLine($"Expediente: {expediente.name}, tipo: {expediente.type}, activo: {expediente.active}");
			}
		}


		static void Populate(ref List<CaseItem> Expedientes, string[] categoriesList, bool active = true)
		{


			foreach (string path in categoriesList)
			{
				var type = new DirectoryInfo(path).Name;
				foreach (string dir in Directory.GetDirectories(path))
				{
					var name = new DirectoryInfo(dir).Name;
					Expedientes.Add(new CaseItem(type, name, active));
				}
			}
		}
	}
}
