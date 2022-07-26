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
	public class ButtonIcon : Button
	{
		static ButtonIcon()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonIcon), new FrameworkPropertyMetadata(typeof(ButtonIcon)));
		}
		/// <summary>
		/// Identifies the Value dependency property.
		/// </summary>
		public static readonly DependencyProperty SourceProperty =
				DependencyProperty.Register(
						"Source", typeof(string), typeof(ButtonIcon));

		/// <summary>
		/// Gets or sets the value assigned to the control.
		/// </summary>
		public string Source
		{
			get { return (string)GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }
		}
	}
}
