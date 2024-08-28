namespace M008;

public class AccessModifier
{
	public string Name { get; set; } //public: Von überall angreifbar (innerhalb und außerhalb vom Projekt)

	private int Alter { get; set; } //private: Nur innerhalb der Klasse angreifbar

	internal string Adresse { get; set; } //internal: Von überall angreifbar, aber nur innerhalb des Projekts

	//////////////////////////////////////////////
	
	protected int Gehalt { get; set; } //protected: Wie private, aber auch in Unterklassen sichtbar

	protected private string Job { get; set; } //protected private: Wie protected, aber nur im Projekt sichtbar

	protected internal string Haarfarbe { get; set; } //protected internal: Im gesamten Projekt sichtbar (Internal) und zusätzlich in Unterklassen außerhalb
}