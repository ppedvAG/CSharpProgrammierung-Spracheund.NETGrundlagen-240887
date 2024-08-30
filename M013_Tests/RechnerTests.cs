using M013;

namespace M013_Tests;

/// <summary>
/// Rechtsklick auf Dependencies -> Add Project Reference -> Projekt auswählen
///
/// View -> Test Explorer
/// 
/// Unit Testing wird regelmäßig durchgeführt (täglich, wöchentlich)
/// und es wird nach jedem Testlauf evaluiert, ob sich Fehler eingeschlichen haben
/// </summary>
[TestClass]
public class RechnerTests
{
	Rechner r;

	[TestInitialize]
	public void TestSetup() => r = new Rechner();

	[TestCleanup]
	public void TestCleanup() => r = null;

	[TestMethod]
	[TestCategory("Dieser Test testet die Addiere Funktion des Rechners")]
	public void TesteAddiere()
	{
		double ergebnis = r.Addiere(4, 8);

		//Assert: Auswerten eines Tests
		Assert.AreEqual(12, ergebnis);
	}

	[TestMethod]
	[TestCategory("Dieser Test testet die Subtrahiere Funktion des Rechners")]
	public void TesteSubtrahiere()
	{
		double ergebnis = r.Subtrahiere(5, 3);
		Assert.AreEqual(2, ergebnis);
	}
}