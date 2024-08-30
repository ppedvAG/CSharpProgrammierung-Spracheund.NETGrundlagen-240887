using M000;
using System.Windows;

namespace M000_WPF;

public partial class MainWindow : Window
{
	public List<Fahrzeug> Fzg = [];

	public MainWindow()
	{
		InitializeComponent();
	}

	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult res =
			MessageBox.Show
			(
				"Möchtest du wirklich beeden?",
				"Beenden",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question
			);

		if (res == MessageBoxResult.Yes)
			this.Close();
	}

	private void ButtonAdd(object sender, RoutedEventArgs e)
	{
		Fzg.Add(Fahrzeug.GeneriereFahrzeug(""));
		RefreshLB();
	}

	private void ButtonDelete(object sender, RoutedEventArgs e)
	{
		int auswahl = LBFZG.SelectedIndex;
		if (auswahl != -1)
		{
			Fzg.RemoveAt(auswahl);
			RefreshLB();
			InfoText.Text = "";
		}
	}

	private void LBFZG_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		int auswahl = LBFZG.SelectedIndex;
		if (auswahl != -1)
			InfoText.Text = Fzg[auswahl].Info();
	}

	private void RefreshLB()
	{
		LBFZG.ItemsSource = null;
		LBFZG.ItemsSource = Fzg;
	}
}