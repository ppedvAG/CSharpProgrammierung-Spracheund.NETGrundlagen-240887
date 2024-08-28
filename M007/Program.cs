namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		//Enumerable.Range(0, 1_000_000_000).ToList(); //Nach dieser Anweisung kommt der GC und sammelt die Zahlen wieder ein

		#region Static
		//Static
		//= global
		//Wenn ein Member static ist, kann dieser überall und immer angegriffen werden

		//Beispiel: Person hat keine statischen Member (Vorname, Nachname, Alter) weil jeder Member sich auf die bestimmte Person bezieht
		//-> Jede Person ist unterschiedlich alt

		//Beispiele in C#:
		Console.WriteLine(); //WriteLine ist static, kein new Console() notwendig
                             //Console c = new Console(); //Nicht möglich

        Console.WriteLine(DateTime.Now);

        //Eigenes Beispiel für static: Personenzähler (siehe Person.cs)
        Console.WriteLine(Person.Zaehler); //Zugriff über Klassenname.Variablenname
		#endregion

		#region Arbeiten mit Datumswerten
		//DateTime: Zeitpunkt mit Jahr, Monat, Tag, Stunde, Minute, Sekunde
		DateTime dt = new DateTime(2000, 01, 01); //Zeitpunkt 1.1.2000 00:00:00
        Console.WriteLine(dt);

        Console.WriteLine(DateTime.Now - dt); //Abstand zw. zwei Datumswerten finden (Ergebnis: TimeSpan)

        //TimeSpan: Zeitspanne
        Console.WriteLine(DateTime.Now + TimeSpan.FromDays(12));

        Console.WriteLine(dt < DateTime.Now); //Liegt das gegebene Datum in der Vergangenheit?

        Console.WriteLine(DateTime.Now.Day); //28
        Console.WriteLine(DateTime.Now.DayOfWeek); //Wednesday
        Console.WriteLine(DateTime.Now.DayOfYear); //241, Tage seit dem 01.01.

        Console.WriteLine(DateTime.Now.ToLongDateString());

		//Weitere Klassen: DateOnly, TimeOnly, DateTimeOffset (Zeitzonen)
		#endregion

		#region Werte- und Referenztypen
		//class und struct

		//Wertetyp
		//struct
		//Beispiele: int, double, bool, ...

		//Zuweisungen: Wenn ein Wertetyp zugewiesen wird, wird der Inhalt kopiert
		//Vergleiche: Wenn zwei Wertetypen verglichen werden, werden die Inhalte verglichen

		int x = 10;
		int y = x; //x wird in y kopiert
		x = 20; //x wird 20, y bleibt 10

        Console.WriteLine(x == y); //false


		//Referenztyp
		//class
		//Beispiele: alles was etwas komplexer ist, ist ein Referenztyp

		//Zuweisungen: Wenn ein Referenztyp zugewiesen wird, wird eine Referenz erzeugt
		//- Wenn ein Objekt erzeugt wird mit new, wird im RAM das Objekt abgelegt
		//- Auf dieses Objekt werden Zeiger gelegt
		//Vergleiche: Wenn zwei Referenztypen verglichen werden, werden die Speicheradressen verglichen

		Person p = new Person();
		p.Nachname = "Max";
		Person p2 = p; //Hier wird ein Zeiger auf Objekt unter p gelegt
		p.Nachname = "Mustermann";

        Console.WriteLine(p == p2);
        Console.WriteLine(p.GetHashCode()); //Speicheradresse des Objektes
        Console.WriteLine(p2.GetHashCode());
        Console.WriteLine(p.GetHashCode() == p2.GetHashCode()); //Hintergrund von Vergleich (p == p2)

		//Das ref Keyword
		//Wertetypen referenzierbar machen

		//Wertetyp Beispiel mit ref
		int a = 10;
		ref int b = ref a;
		a = 20;
		#endregion

		#region Null
		//Null
		//Standardwert, wenn ein Feld keinen Inhalt hat
		Person p3 = null;
        //Console.WriteLine(p3.GetVorname()); //Absturz, weil das Objekt nicht existiert
		if (p3 is not null)
            Console.WriteLine(p3.GetVorname());

		//Wertetyp sind nicht Nullable
		//int z = null; //Nicht möglich
		int? z = null; //Mit ? am Ende eines Typens diesen Nullable machen

		Console.ReadLine(); //string?
        #endregion
    }
}
