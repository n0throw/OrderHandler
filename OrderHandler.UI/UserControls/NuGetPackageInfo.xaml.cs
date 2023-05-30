using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace OrderHandler.UI.UserControls; 

public partial class NuGetPackageInfo : UserControl {
	public NuGetPackageInfo() {
		InitializeComponent();
		DataContext = this;
	}
	
	public Uri Link { get; set; }
	public string PackageName { get; set; }
	public string PackageVersion { get; set; }

	void Hyperlink_OnClick(object sender, RoutedEventArgs e)
		=> Process.Start(Link.ToString());
}