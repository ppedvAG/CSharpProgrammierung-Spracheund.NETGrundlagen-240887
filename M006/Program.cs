using M006.Data;
using System.Diagnostics;

namespace M006;

/// <summary>
/// Klasse:
/// 
/// Bauplan für Objekte
/// Innerhalb des Bauplans wird die Struktur der Objekte vorgegeben
/// Mittels Variablen und Funktionen wird die Struktur der Objekte definiert
/// 
/// Beispiel: Person
/// - Eigenschaften: Vorname (string), Nachname (string), Alter (int), ...
/// - Funktionen: Programmieren, Sprechen, Bewegen, ...
/// Mithilfe dieser Eigenschaften/Funktionen kann jetzt die Realität innerhalb unseres Programms dargestellt werden
/// 
/// Warum?
/// z.B. Webseiten haben Personeninformationen, diese Informationen werden in Objekten gespeichert/verwendet
/// In weitere Folge werden diese Informationen in einer Datenbank gespeichert
/// 
/// Datentypen
/// - Was ist ein Int? Ganze Zahl
/// - Was ist ein Double? Kommazahl
/// - Was ist ein String? Zeichenkette/Text
/// - Was ist eine Person? Nicht einfach erklärbar -> komplexer Datentyp
/// 
///////////////////////////////////////////////////////////////////////////////////////
/// 
/// Objekt:
/// Konkrete Instanz von einer Klasse
/// Jede Eigenschaft von der entsprechenden Klasse hat jetzt konkrete Werte
/// 
/// Beispiel: Person
/// Objekt P1: Vorname: Max, Nachname: Mustermann, Alter: 33
/// Über P1 können jetzt auch die Funktionen ausgeführt werden
/// P1 kann Programmieren, Sprechen, Bewegen, ...
/// -> P1 spricht, P1 bewegt sich, P1 programmiert, ...
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		//Person Objekt erstellen
		//Mithilfe von new kann ein neues Objekt erstellt werden
		Person p1 = new Person();
		p1.SetVorname("123"); //Fehlermeldung
		p1.SetVorname("Max");
        Console.WriteLine($"p1 heißt: {p1.GetVorname()}");

		//Zweites Objekt erstellen
		//p2 ist komplett unabhängig von p1
		Person p2 = new Person();
		p2.Nachname = "Mustermann"; //Properties funktionieren wie normale Variablen in der Verwendung
		Console.WriteLine($"p2 heißt: {p2.Nachname}");

        Console.WriteLine(p2.VollerName);
		//p2.VollerName = ""; //Nicht möglich, da read-only

		Console.WriteLine(p2.Alter);
		//p2.Alter = 10; //Nicht möglich, da private set

		///////////////////////////////////////////////

		//Output ist abhängig von dem gegebenen Objekt
		p1.Sprechen("Hallo");
		p2.Sprechen("Welt");

		///////////////////////////////////////////////

		//Person mit Initialwerten (über Konstruktor)
		Person p3 = new Person("Max", "Mustermann der Dritte");
        Console.WriteLine(p3.VollerName); //Max Mustermann der Dritte

		Person p4 = new Person("Max", "Mustermann der Dritte", 33);
		Console.WriteLine(p4.VollerName);

		///////////////////////////////////////////////

		//Namespace
		//Organisationseinheit, um Typen zu gruppieren nach ihrem Nutzen/ihrer Verwendung

		//Beispiele:
		//System: Standarddinge, Console, int, double, float, string, ...
		//System.IO: File, Diretory, Path, ...
		//System.Net: Netzwerke, Unterpaket: System.Net.Http
		//System.Xml: XML

		//Jedes Projekt hat einen Namespace (hier M006)
		//Für größere Projekte unbedingt notwendig
		//Mithilfe von Usings können Typen aus anderen Namespaces importiert werden
		//using <Namespace>;

		Stopwatch sw; //Strg + .: Using erzeugen
	}
}
