namespace M007;

/// <summary>
/// Bauplan für Personen
/// Mithilfe von new kann hier ein (oder mehrere) Objekt(e) erstellt werden
/// 
/// - Eigenschaften: Vorname (string), Nachname (string), Alter (int), ...
/// - Funktionen: Programmieren, Sprechen, Bewegen, ...
/// </summary>
public class Person
{
	#region Variable
	//Behälter für den von Vornamen der Person
	//private: Von außen nicht angreifbar
	private string vorname;

	/// <summary>
	/// Get-Methode
	/// Ermöglicht Lesezugriff auf das dahinterliegende Feld
	/// Haben generell nur return [Feld] als Code
	/// </summary>
	public string GetVorname()
	{
		return vorname;
	}

	/// <summary>
	/// Set-Methode
	/// Ermöglicht Schreibezugriff auf das dahinterliegende Feld
	/// 
	/// Hat immer einen Parameter, der mit dem dahinterliegenden Feld übereinstimmt
	/// Gibt generell keinen Wert zurück (void)
	/// </summary>
	public void SetVorname(string vorname)
	{
		//Nimm den per Parameter gegebenen Wert und schreibe ihn in das Feld hinein

		//Prüfe für jedes Zeichen im String, ob dieser ein Buchstabe ist
		//Prüfe zusätzlich, ob der gegebene vorname zw. 3 und 15 Zeichen hat
		if (vorname.All(char.IsLetter) && vorname.Length >= 3 && vorname.Length <= 15)
		{
			//Problem: vorname hier und vorname oben heißen gleich
			//Lösung: this
			//this: Greife aus den derzeitigen Klammern nach oben
			this.vorname = vorname;
		}
		else
            Console.WriteLine("Vorname darf nur aus Buchstaben bestehen und muss zw. 3 und 15 Zeichen lang sein!");
    }
	#endregion

	#region Eigenschaft/Property
	//Private Feld wie bei Vorname
	private string nachname;

	/// <summary>
	/// Eigenschaft/Property
	/// </summary>
	public string Nachname
	{
		//Get-Accessor: Äquivalent zur Get-Methode
		get
		{
			return nachname;
		}

		//Set-Accesor: Äquivalent zur Set-Methode
		//Der Parameter des Set-Accessors heißt value (Keyword)
		set
		{
			if (value.All(char.IsLetter) && value.Length >= 3 && value.Length <= 15)
				nachname = value;
			else
				Console.WriteLine("Nachname darf nur aus Buchstaben bestehen und muss zw. 3 und 15 Zeichen lang sein!");
		}
	}

	//Drei Formen von Properties
	//- Full Property (siehe oben), private Feld mit public Property davor
	//- Get-Only Property: Property mit einem Get-Accessor, aber ohne Set-Accessor
	//- Auto-Property: Einfaches Feld mit { get; set; } (Fortgeschrittene Anwendung)

	///////////////////////////////////////////////////

	//Get-Only Property
	//Kann nicht gesetzt werden
	public string VollerName
	{
		get
		{
			return vorname + " " + nachname;
		}
	}

	public string VollerName2
	{
		get => vorname + " " + nachname;
	}

	public string VollerName3 => vorname + " " + nachname;

	///////////////////////////////////////////////////

	//Auto-Property
	public string Vorname2;

	public string Vorname3 { get; set; } //Äquivalent zu Vorname2

	//Bei Accessoren von Auto-Properties können auch Access Modifier gesetzt werden
	//Alter kann von außen gelesen werden, aber nur innerhalb gesetzt werden
	public int Alter { get; private set; }
	#endregion

	#region	Funktionen
	/// <summary>
	/// Diese Funktion hängt an jedem Objekt -> jedes Objekt kann sprechen
	/// Wenn diese Funktion benutzt wird, bezieht sie sich auf das Objekt
	/// z.B. VollerName kommt vom entsprechenden Objekt
	/// 
	/// WICHTIG: Kein static benutzen
	/// </summary>
	public void Sprechen(string text)
	{
        Console.WriteLine($"{VollerName} sagt: {text}");
    }
	#endregion

	#region Konstruktor
	/// <summary>
	/// Konstruktor
	/// Code, welcher bei Erstellung(new) des Objekts ausgeführt wird(= Startcode)
	/// Vom Aufbau her vergleichbar mit einer Methode, hat aber keinen Rückgabewert
	/// Der Name des Konstruktors muss mit dem Namen der Klasse übereinstimmen
	/// </summary>
	public Person()
	{
        Console.WriteLine("Person erstellt");
		Zaehler++;
    }

	/// <summary>
	/// Generell sollte bei Objekterstellung einen Startzustand vorhanden sein -> Parameter im Konstruktor
	/// </summary>
    public Person(string vorname, string nachname) : this() //Verkettung mit dem Standardkonstruktor herstellen
    {
		this.vorname = vorname;
		this.nachname = nachname;
    }

	/// <summary>
	/// Konstruktoren verketten
	/// Innerhalb dieses Konstruktors einen anderen Konstruktor zusätzlich verwenden
	/// Nutzen: Wenn sich ein Konstruktor verändert, wird auch dieser Konstruktor angepasst
	/// </summary>
	public Person(string vorname, string nachname, int alter) : this(vorname, nachname) //: this(...): Verkettung herstellung
	{
		this.Alter = alter;
	}
    #endregion

	//Destruktor
	//Code, welcher beim Einsammeln des GC ausgeführt wird
	~Person()
	{
        Console.WriteLine("Person eingesammelt");
    }

	/// <summary>
	/// Zähler soll immer erhöht werden, wenn eine Person erstellt wird (per new)
	/// </summary>
	public static int Zaehler { get; private set; }
}