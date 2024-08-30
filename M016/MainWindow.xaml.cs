using M016.Models;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;

namespace M016;

/// <summary>
/// Datenbank
/// 
/// Zwei Möglichkeiten um auf eine DB zuzugreifen:
/// - DbConnection
/// - EntityFramework
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void ButtonDB(object sender, RoutedEventArgs e)
	{
		//Voraussetzung: DB Treiber (NuGet: System.Data.SqlClient)
		//Connection String: Enthält alle möglichen Informationen die zum Verbindungsaufbau notwendig sind
		//z.B. IP-Adresse, User/Passwort, DB, ...
		using SqlConnection conn = new SqlConnection("Server=WIN10-LK3;Database=Northwind;Trusted_Connection=True;");
		conn.Open(); //Verbindung öffnen

		//Command: Ein SQL Statement
		using SqlCommand command = conn.CreateCommand();
		command.CommandText = "SELECT * FROM Customers";

		//Die Execute Methoden
		//Reader: Datensätze
		//NonQuery/Scalar: Einzelne Werte
		List<object[]> data = new();
		using SqlDataReader reader = command.ExecuteReader();
		while(reader.Read())
		{
			object[] values = new object[reader.VisibleFieldCount]; //Array mit Anzahl Spalten als Länge erstellen
			reader.GetValues(values); //Referenz zu dem Array
			data.Add(values);
		}
		DG.ItemsSource = data;
	}

	private void ButtonEF(object sender, RoutedEventArgs e)
	{
		//Entity Framework
		//Object-Relational-Mapper (ORM)
		//Erzeugt für die SQL-Tabellen jeweils eine Klasse, jeder Datensatz ist in weiterer Folge ein Objekt

		//Voraussetzungen
		//- Microsoft.EntityFrameworkCore
		//- Microsoft.EntityFrameworkCore.SqlServer

		//VS Extension: EF Core Power Tools
		//Rechtsklick aufs Projekt -> EF Core Power Tools -> Reverse Engineer

		//Models: C# Klassen, welche die Tabellen in der DB repräsentieren
		//Context: DB Connector, gibt Zugriff auf die DB
		NorthwindContext db = new NorthwindContext();
		//DG.ItemsSource = db.Customers.ToList(); //WICHTIG: ToList() sorgt dafür, das die Daten von der DB geladen werden
		DG.ItemsSource = db.Customers.Where(e => e.Country == "UK").ToList(); //Für Datenverarbeitung wird hier immer Linq benötigt

		//EF übersetzt alle Linq-Abfragen zu SQL, kann fehlschlagen
	}
}