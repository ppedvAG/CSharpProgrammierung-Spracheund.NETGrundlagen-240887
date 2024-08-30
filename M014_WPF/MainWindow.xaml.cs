using System.Windows;

namespace M014_WPF;

public partial class MainWindow : Window
{
	public int Counter { get; set; } = 0;

	public MainWindow()
	{
		InitializeComponent();

		Dropdown.ItemsSource = new int[] { 1, 2, 3, 4 };
		LB.ItemsSource = new string[] { "Hallo", "Welt", "!" };
	}

	/// <summary>
	/// Event
	/// Ermöglichen Kommunikation zw. Frontend und Backend
	/// 
	/// Zweigeteilte Programmierung: Entwicklerseite, Anwenderseite
	/// 
	/// Entwicklerseite: Definiert den Eventpunkt, und definiert, wann das Event gefeuert wird
	/// 
	/// Beispiel: Click-Event
	/// - Button muss aktiviert sein
	/// - Cursor muss im Button sein
	/// - Linksklick
	/// - keine anderen UI Elemente dürfen darüber sein
	/// - ...
	/// 
	/// Anwenderseite: Definiert die Funktion/den Code, welcher beim feuern des Event ausgeführt wird
	/// </summary>
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//Counter++;
		//Output.Text = Counter.ToString();

		//Aufgabe: Wenn der Button geklickt wird, soll der Input des Users im Textfeld angezeigt werden
		Output.Text = Eingabe.Text;
	}

	private void Dropdown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		Output.Text = Dropdown.SelectedItem.ToString();
	}

	private void LB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		//Output.Text = LB.SelectedItem.ToString();
		Output.Text = string.Join(", ", LB.SelectedItems.OfType<string>()); //OfType: Finde alle Elemente, welche den entsprechenden Typen haben
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{

	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{

	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
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
			//Environment.Exit(0);
			this.Close();
		else
		{
			MainWindow mw = new MainWindow();
			mw.Show();
		}
	}
}