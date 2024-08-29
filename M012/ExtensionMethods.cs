namespace M012;

public static class ExtensionMethods
{
	/// <summary>
	/// Mit this [Typ] kann sich auf einen beliebigen Typen in C# bezogen werden
	/// Alle Objekte von dem gegebenen Typen haben diese Funktion
	/// </summary>
	public static int Quersumme(this int x)
	{
		//int summe = 0;
		//string zahlAlsString = x.ToString();
		//for (int i = 0; i < zahlAlsString.Length; i++)
		//{
		//	summe += (int) char.GetNumericValue(zahlAlsString[i]);
		//}
		//return summe;

		//10232 -> '1', '0', '2', '3', '2' -> mit char.GetNumericValue zu doubles konvertieren -> diese summieren
		return (int) x.ToString().Sum(e => char.GetNumericValue(e));
	}
}