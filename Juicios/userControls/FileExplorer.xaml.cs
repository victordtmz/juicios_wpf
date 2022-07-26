using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Juicios;
using System.Web;

namespace Juicios.userControls
{
	/// <summary>
	/// Interaction logic for FileExplorer.xaml
	/// </summary>

	public partial class FileExplorer : UserControl
	{
		//Define the delegate for the event handler
		public delegate void onSourceChanged(string value);
		public FileExplorer()
		{
			InitializeComponent();
			//Source = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			
			//On SourceChanged event, set the browser new source. 
			SourceChanged += delegate (string source)
			{
				FilesTreeBrowser.Source = new Uri(source);
			};
			

		}
		

		private string _source = "";
		public string Source
		{
			get { return _source; }
			set 
			{ 
				_source = value; 
				SourceChanged(_source);
			}
		}

		//Declare the event
		public event onSourceChanged SourceChanged;
		private string GetWebBrowserPath()
		{
			string rootPath = this.Source;
			if (!string.IsNullOrEmpty(rootPath))
			{
				
				
				//NEED TO MAKE BROUSER RETURN UTF-8
				string browserSource = FilesTreeBrowser.Source.LocalPath;
				// https://www.w3schools.com/tags/ref_urlencode.ASP - Reference for windows chars to acentos
				if (browserSource.Contains("%"))
				{
					browserSource = browserSource.Replace("%E1", "á");
					browserSource = browserSource.Replace("%C1", "Á");
					browserSource = browserSource.Replace("%E9", "é");
					browserSource = browserSource.Replace("%C9", "É");
					browserSource = browserSource.Replace("%ED", "í");
					browserSource = browserSource.Replace("%CD", "Í");
					browserSource = browserSource.Replace("%F3", "ó");
					browserSource = browserSource.Replace("%D3", "Ó");
					browserSource = browserSource.Replace("%DA", "Ú");
					browserSource = browserSource.Replace("%FA", "ú");
					browserSource = browserSource.Replace("%F1", "ñ");
					browserSource = browserSource.Replace("%D1", "Ñ");
				}





				browserSource = browserSource.Replace(@"/", @"\");
				//Trimm end slashes from startPath 
				rootPath = rootPath.TrimEnd('\\');
				browserSource = browserSource.Replace(rootPath, "");
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

				}

			}

			private void BtnWebBrowserInicio_Click(object sender, RoutedEventArgs e)
			{
				string path = this.Source;
				FilesTreeBrowser.Source = new Uri(path);
			}

			private void BtnWebBrowser1_Click(object sender, RoutedEventArgs e)
			{
				//source => relative path of Selected path
				string source = GetWebBrowserPath();
				source = source.TrimStart('\\');
				//path => root path for current case
				string path = this.Source;
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
				string path = this.Source;
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
				string path = this.Source;
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
				string path = this.Source;
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
				string path = this.Source;
				if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(path))
				{
					string[] sourceparts = source.Split(@"\");
					string newPath = path + @"\" + sourceparts[0] + @"\" + sourceparts[1] + @"\" + sourceparts[2] + @"\" + sourceparts[3] + @"\" + sourceparts[4];
					FilesTreeBrowser.Source = new Uri(newPath);
				}
			}


		}
}
