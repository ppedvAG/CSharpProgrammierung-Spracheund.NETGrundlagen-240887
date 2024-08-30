namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		//Debugging

		//Fenster
		//- Locals: Zeigt alle Variablen/Felder + Werte im Programm an
		//-- Debug -> Windows -> Locals (funktioniert nur beim laufendem Programm)
		//- Immediate: Ermöglicht, das ausführen von beliebigem C# Code an der derzeitigen Stelle
		//- Watch: Fixiert eine Variable über den gesamten Debuggingablauf hinweg
		//-- Rechtsklick auf Variable -> Add Watch

		//Steuerung
		//- Step Over: Führt die gesamte Zeile aus
		//- Step Into: Springe in den Code der derzeitigen Anweisung hinein
		//- Step Out: Aus der Methode herausspringen, in Kombination mit Step Into benutzen
		//- Continue: Führt das Programm weiter aus, bis zum nächsten Breakpoint
		Test();

		///////////////////////////////////////////////////////////

		//throw new Exception("Hallo"); //Absturz verursachen

		//Manchmal gibt es Fehler, welche das Programm zum Absturz führen

		//Problematik: Fehlermeldung müssen Plattformunabhängig sein
		//Beispiel: Console.WriteLine() ist in einer GUI (Desktop, Mobile, Web) nicht sichtbar
		//Wenn der User keine Zahl eingibt, haben wir einen undefinierten Zustand
		//Über try-catch kann ein Absturz verhindert werden, und Fehlerbehandlungscode ausgeführt werden

		//Codeblock markieren -> Rechtsklick -> Snippet -> Surround With -> try(f)
		try
		{
			string str = Console.ReadLine(); //Maus über Methode -> Exceptions
			int x = int.Parse(str); //3 mögliche Fehler: ArgumentNullException, FormatException, OverflowException
		}
		catch (FormatException e) //Wenn keine Zahl eingegeben wurde, wird dieser Block komplett ausgeführt
		{
			//Hier ist ein Zugriff auf das Exception-Objekt möglich
            Console.WriteLine("Die Eingabe ist keine Zahl");
			Console.WriteLine(e.Message); //Die C#-interne Nachricht
			Console.WriteLine(e.StackTrace);
			//Rückverfolgung, wo der Fehler aufgetreten ist
			//WICHTIG: Von unten nach oben lesen
        }
		catch (OverflowException e)
		{
            Console.WriteLine("Die Zahl ist zu klein/groß");
        }
		catch (Exception e) //Behandelt alle anderen Fehler
		{
            Console.WriteLine("Anderer Fehler");
			Console.WriteLine(e.Message);
			Console.WriteLine(e.StackTrace);
		}
		finally //finally: Wird immer ausgeführt, egal ob Erfolg/Misserfolg
		{
            Console.WriteLine("Parsen abgeschlossen");
        }
	}

	static void Test()
	{
        Console.WriteLine("Test");
        Console.WriteLine("Test");
        Console.WriteLine("Test");
    }
}
