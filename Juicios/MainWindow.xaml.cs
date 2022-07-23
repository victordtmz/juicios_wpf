using Juicios.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Collections.Specialized;
using System.ComponentModel;

namespace Juicios
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<CaseItem> Cases { get; set; }
		public ICollectionView CasesView { get; set; }
			//Expedientes = new List<CaseItem>();
		public MainWindow()
		{
			Cases = GetCases();
			
			//CasesView.Filter(CasesView,true);
			CasesView = CollectionViewSource.GetDefaultView(Cases);
			
			
			InitializeComponent();
			//var Cases = this.Cases;
			ExpedientesList.ItemsSource = CasesView;
			//foreach(CaseItem item in Cases)
			//{

			//ExpedientesList.Items.Add(item);
			//}

		}
		//private List<CaseItem> GetCases()
		private List<CaseItem> GetCases()
		{
			List<CaseItem> Expedientes = new List<CaseItem>();
			string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			string activosFolder = userFolder + @"\OneDrive\enlace\Juicios\";
			string inactivosFolder = userFolder + @"\OneDrive\enlace\Juicios_archivados\";
			string[] activosCategoriePathList = Directory.GetDirectories(activosFolder);
			string[] inactivosCategoriePathList = Directory.GetDirectories(inactivosFolder);
			foreach (string path in activosCategoriePathList)
			{
				var type = new DirectoryInfo(path).Name;
				foreach (string dir in Directory.GetDirectories(path))
				{
					var name = new DirectoryInfo(dir).Name;
					Expedientes.Add(new CaseItem(type, name, true));
				}
			}
			foreach (string path in inactivosCategoriePathList)
			{
				var type = new DirectoryInfo(path).Name;
				foreach (string dir in Directory.GetDirectories(path))
				{
					var name = new DirectoryInfo(dir).Name;
					Expedientes.Add(new CaseItem(type, name, false));
				}
			}
			return Expedientes;


		}

		private void ExpedientesList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{

		}

		private void ExpedientesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
