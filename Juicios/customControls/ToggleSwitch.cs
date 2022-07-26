using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnlaceCustomControls
{
	/// <summary>
	
	/// </summary>
	public class ToggleSwitch : ToggleButton
	{
		//string _source = "";
		static ToggleSwitch()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSwitch), new FrameworkPropertyMetadata(typeof(ToggleSwitch)));
		}
		public string Source { get; set; }
		//{
		//	get
		//	{
		//		return _source;
		//	}
		//	set
		//	{
		//		_source = value;
		//	}
		//}

	}
}
