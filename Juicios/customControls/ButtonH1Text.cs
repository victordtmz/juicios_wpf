using System;
using System.Collections.Generic;
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

namespace EnlaceCustomControls
{
	/// <summary>
	///
	/// </summary>
	public class ButtonH1Text : Button
	{
		static ButtonH1Text()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonH1Text), new FrameworkPropertyMetadata(typeof(ButtonH1Text)));
		}
	}
}
