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
	public partial class MainWindow : Window
	{
		List<CaseItem> CasesList { get; set; }
		string UserFolder { get; set; }
		string EnlaceFolder { get; set; }
		string JuiciosActivos{ get; set; }
		string JuiciosInactivos { get; set; }
		Cases Cases { get; set; }
		//string Juicios
		public MainWindow()
		{
			
			
			Cases = new Cases();
			Constants constants = new Constants();
			UserFolder = constants.GetUserFolder();
			EnlaceFolder = UserFolder + Constants.enlaceFolder;
			JuiciosActivos = UserFolder + Constants.activosFolder;
			JuiciosInactivos = UserFolder + Constants.inactivosFolder;

			InitializeComponent();
			CasesList = Cases.GetCases(true);
			ExpedientesList.ItemsSource = CasesList;
		}

		
		private bool ExpedienteFilter(object obj)
		{
			string searchValue = SearchBox.Text;
			var FilteredObj = obj as CaseItem;
			if (FilteredObj != null)
			{
				string Name = FilteredObj.Name;
				return Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
			}
			else { return false; }
		}

		private string GetSelectedCasePath()
		{
			CaseItem caseItem = (CaseItem)ExpedientesList.SelectedItem;
			if(caseItem == null)
			{
				return EnlaceFolder;
			}
			string type = caseItem.Type;
			string name = caseItem.Name;
			bool active = caseItem.Active;
			string root;
			if (active)
			{
				root = JuiciosActivos;
			}
			else
			{
				root = JuiciosInactivos;
			}
			string path = root + type + @"\" + name;
			return path;
		}


		private void ExpedientesList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{

		}

		
		private void ExpedientesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string path = GetSelectedCasePath();
			if (String.IsNullOrEmpty(path)){
				path = JuiciosActivos;
			}
			FilesTreeBrowser.Source = new Uri(path);
			//TxtWebBrowserSource.Text = path;
		}


		private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			 
			if (string.IsNullOrEmpty(SearchBox.Text))
			{
				ExpedientesList.Items.Filter = null;

			}
			else
			{
				ExpedientesList.Items.Filter = ExpedienteFilter;
			}
			
		}

		private void BtnClearSearch_Click(object sender, RoutedEventArgs e)
		{
			SearchBox.Text = string.Empty;
		}
		
		
		private string GetWebBrowserPath()
		{
			string startPath = GetSelectedCasePath();
			if (!string.IsNullOrEmpty(startPath))
			{
				//NEED TO MAKE BROUSER RETURN UTF-8
				string browserSource = FilesTreeBrowser.Source.ToString();
				browserSource = browserSource.Replace(@"file:///", "");
				browserSource = browserSource.Replace(@"/", @"\");
				//Trimm end slashes from startPath 
				startPath = startPath.TrimEnd('\\');
				browserSource = browserSource.Replace(startPath, "");
				return browserSource;
			}
			return string.Empty;

		}
		private void FilesTreeBrowser_LoadCompleted(object sender, NavigationEventArgs e)
		{
			//Always verify visibility of all items is collapsed
			//TxtWebBrowserSource.Text = FilesTreeBrowser.Source.ToString();
			BtnWebBrowser5.Visibility = Visibility.Collapsed;
			BtnWebBrowser4.Visibility = Visibility.Collapsed;
			BtnWebBrowser3.Visibility = Visibility.Collapsed;
			BtnWebBrowser2.Visibility = Visibility.Collapsed;
			BtnWebBrowser1.Visibility = Visibility.Collapsed;
			TxtWebBrowser5.Visibility = Visibility.Collapsed;
			TxtWebBrowser4.Visibility = Visibility.Collapsed;
			TxtWebBrowser3.Visibility = Visibility.Collapsed;
			TxtWebBrowser2.Visibility = Visibility.Collapsed;
			TxtWebBrowser1.Visibility = Visibility.Collapsed;
			
			string source = GetWebBrowserPath();
			source = source.TrimStart('\\');
			if (!string.IsNullOrEmpty(source))
			{
				string[] sourceparts = source.Split(@"\");
				int len = sourceparts.Length;
				switch (len)
				{
					case >= 5:
						BtnWebBrowser5.Visibility = Visibility.Visible;
						BtnWebBrowser5.Content = sourceparts[4];
						TxtWebBrowser5.Visibility = Visibility.Visible;
						goto case 4;
					case 4:
						BtnWebBrowser4.Visibility = Visibility.Visible;
						BtnWebBrowser4.Content = sourceparts[3];
						TxtWebBrowser4.Visibility = Visibility.Visible;
						goto case 3;

					case 3:
						BtnWebBrowser3.Visibility = Visibility.Visible;
						BtnWebBrowser3.Content = sourceparts[2];
						TxtWebBrowser3.Visibility = Visibility.Visible;
						goto case 2;
				
					case 2:
						BtnWebBrowser2.Visibility = Visibility.Visible;
						BtnWebBrowser2.Content = sourceparts[1];
						TxtWebBrowser2.Visibility = Visibility.Visible;
						goto case 1;
				
					case 1:
						BtnWebBrowser1.Visibility = Visibility.Visible;
						BtnWebBrowser1.Content = sourceparts[0];
						TxtWebBrowser1.Visibility = Visibility.Visible;
						break;
				}
				
				//SolidColorBrush orangeBrush = (SolidColorBrush)new BrushConverter().ConvertFrom(Constants.OrangeCustom);
				//SolidColorBrush blueBrush = (SolidColorBrush)new BrushConverter().ConvertFrom(Constants.LightBlueCustom);
				SolidColorBrush orangeBrush = new SolidColorBrush(Colors.DarkOrange);
				SolidColorBrush blueBrush = new SolidColorBrush(Colors.SkyBlue);
				BtnWebBrowser5.Foreground = blueBrush;
				BtnWebBrowser4.Foreground = blueBrush;
				BtnWebBrowser3.Foreground = blueBrush;
				BtnWebBrowser2.Foreground = blueBrush;
				BtnWebBrowser1.Foreground = blueBrush;
				switch (len)
				{
					case 5:
						BtnWebBrowser5.Foreground = orangeBrush;
						break;
					case 4:
						BtnWebBrowser4.Foreground = orangeBrush;
						break;

					case 3:
						BtnWebBrowser3.Foreground = orangeBrush;
						break;

					case 2:
						BtnWebBrowser2.Foreground = orangeBrush;
						break;

					case 1:
						BtnWebBrowser1.Foreground = orangeBrush;
						break;
				}



			}
			
		}

		private void BtnWebBrowserInicio_Click(object sender, RoutedEventArgs e)
		{
			string path = GetSelectedCasePath();
			FilesTreeBrowser.Source = new Uri(path);
		}

		private void BtnWebBrowser1_Click(object sender, RoutedEventArgs e)
		{
			//source => relative path of Selected path
			string source = GetWebBrowserPath();
			source = source.TrimStart('\\');
			//path => root path for current case
			string path = GetSelectedCasePath();
			if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(path))
			{
				string[] sourceparts = source.Split(@"\");
				//this is Button 1, only add 1 element to path
				string newPath = path + @"\" + sourceparts[0];
				FilesTreeBrowser.Source = new Uri(newPath);
			}
		}

		private void BtnWebBrowser2_Click(object sender, RoutedEventArgs e)
		{
			//source => relative path of Selected path
			string source = GetWebBrowserPath();
			source = source.TrimStart('\\');
			//path => root path for current case
			string path = GetSelectedCasePath();
			if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(path))
			{
				string[] sourceparts = source.Split(@"\");
				string newPath = path + @"\" + sourceparts[0] + @"\" + sourceparts[1];
				FilesTreeBrowser.Source = new Uri(newPath);
			}

		}

		private void BtnWebBrowser3_Click(object sender, RoutedEventArgs e)
		{
			//source => relative path of Selected path
			string source = GetWebBrowserPath();
			source = source.TrimStart('\\');
			//path => root path for current case
			string path = GetSelectedCasePath();
			if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(path))
			{
				string[] sourceparts = source.Split(@"\");
				string newPath = path + @"\" + sourceparts[0] + @"\" + sourceparts[1] + @"\" + sourceparts[2];
				FilesTreeBrowser.Source = new Uri(newPath);
			}
		}

		private void BtnWebBrowser4_Click(object sender, RoutedEventArgs e)
		{
			//source => relative path of Selected path
			string source = GetWebBrowserPath();
			source = source.TrimStart('\\');
			//path => root path for current case
			string path = GetSelectedCasePath();
			if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(path))
			{
				string[] sourceparts = source.Split(@"\");
				string newPath = path + @"\" + sourceparts[0] + @"\" + sourceparts[1] + @"\" + sourceparts[2] + @"\" + sourceparts[3];
				FilesTreeBrowser.Source = new Uri(newPath);
			}
		}

		private void BtnWebBrowser5_Click(object sender, RoutedEventArgs e)
		{
			//source => relative path of Selected path
			string source = GetWebBrowserPath();
			source = source.TrimStart('\\');
			//path => root path for current case
			string path = GetSelectedCasePath();
			if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(path))
			{
				string[] sourceparts = source.Split(@"\");
				string newPath = path + @"\" + sourceparts[0] + @"\" + sourceparts[1] + @"\" + sourceparts[2] + @"\" + sourceparts[3] + @"\" + sourceparts[4];
				FilesTreeBrowser.Source = new Uri(newPath);
			}
		}

		private void ToggleActivos_Checked(object sender, RoutedEventArgs e)
		{
			ToggleActivos.HorizontalAlignment = HorizontalAlignment.Left;
			ToggleActivos.MinHeight = 0;
			if(ExpedientesList != null)
			{
				CasesList = Cases.GetCases(true);
				ExpedientesList.ItemsSource = CasesList;
			}
		}

		private void ToggleActivos_Unchecked(object sender, RoutedEventArgs e)
		{
			ToggleActivos.HorizontalAlignment = HorizontalAlignment.Right;
			ToggleActivos.MinHeight = 1;
			if (ExpedientesList != null)
			{
				CasesList = Cases.GetCases(false);
				ExpedientesList.ItemsSource = CasesList;
			}
		}
	}
}
