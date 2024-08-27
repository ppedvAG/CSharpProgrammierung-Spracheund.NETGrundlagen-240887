#region Arrays
//Array
//Variable, die nicht nur einen Wert halten kann, sondern mehrere
//Syntax: <Typ>[] <Name>
int[] zahlen = new int[5]; //new: Objekt erzeugen, wird hier für Array verwendet
						   //Array mit Länge 5, Index 0-4
zahlen[1] = 10; //[0, 10, 0, 0, 0]
Console.WriteLine(zahlen[1]); //[...]: An der Stelle

//Standardwerte bei Arrays
zahlen = new int[] { 1, 2, 3, 4, 5 }; //Zahlen mit Länge 5 und den gegebenen Elementen erstellen
zahlen = new[] { 1, 2, 3, 4, 5 };
int[] z = { 1, 2, 3, 4, 5 };
zahlen = [1, 2, 3, 4, 5]; //Ab C# 12, .NET 8

//Andere Typen
string[] texte = ["Hallo", "Welt", "!"];
double[] kommazahlen = [1.2, 3.4, 5.6, 7.8];

Console.WriteLine(texte.Length); //3
Console.WriteLine(kommazahlen.Length); //4

//Contains: Prüfen, ob ein Element im Array enthalten ist
Console.WriteLine(zahlen.Contains(10)); //true
Console.WriteLine(texte.Contains("Hallo")); //true

//Mehrdimensionale Arrays
//Mehrere Dimensionen mithilfe von Kommas in der Arrayklammer [,]
int[,] matrix = new int[3, 5];
matrix[0, 1] = 1;
Console.WriteLine(matrix[2, 2]);
#endregion

#region Bedingungen
//Vergleichsoperatoren
//==, !=, <, >, <=, >=

//Logische Operatoren
//&&, ||, ^, !

//Vergleichsoperatoren werden für eine if immer benötigt
//Logische Operatoren können einzelne Bedingungen verknüpfen

int zahl1 = 7;
int zahl2 = 4;
if (zahl1 != zahl2) //Wenn die Bedingung zu true evaluiert wird, führe den Code innerhalb aus
{
    Console.WriteLine("zahl1 ist nicht gleich zahl2");
}
else //Wenn die Bedingung nicht wahr ist
{

}

if (zahl1 != zahl2)
	Console.WriteLine("zahl1 ist nicht gleich zahl2");
else
	Console.WriteLine("zahl1 ist gleich zahl2");

if (zahl1 < zahl2) { }
else
{
	if (zahl1 > zahl2) { }
	else { }
}

//->

if (zahl1 < zahl2) { }
else if (zahl1 > zahl2)
{

}
else
{

}

//Ternary-Operator (?-Operator): If/Else Bäume kompakt machen

//Beispiel:
if (zahl1 != zahl2)
	Console.WriteLine("zahl1 ist nicht gleich zahl2");
else
	Console.WriteLine("zahl1 ist gleich zahl2");

//Nach ? kommt die if, nach : kommt die else
Console.WriteLine(zahl1 != zahl2 ? "zahl1 ist nicht gleich zahl2" : "zahl1 ist gleich zahl2");
//zahl1 != zahl2 ? Console.WriteLine("zahl1 ist nicht gleich zahl2") : Console.WriteLine("zahl1 ist gleich zahl2"); //Ternary-Operator muss immer ein Ergebnis haben
Console.WriteLine($"zahl1 ist {(zahl1 != zahl2 ? "nicht" : "")} gleich zahl2");

//^ (XOR): Wenn die beiden Bedingungen ungleich sind
if (zahl1 > 5 ^ zahl2 > 5) //Es dürfen nicht beide Zahlen kleiner oder größer 5 sein (gleichzeitig)
{

}

if (zahlen.Contains(10))
{
	//...
}
#endregion