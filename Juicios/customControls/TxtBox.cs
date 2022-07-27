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
	public class TxtBox : TextBox
	{
		static TxtBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TxtBox), new FrameworkPropertyMetadata(typeof(TxtBox)));
		}
	}
}
