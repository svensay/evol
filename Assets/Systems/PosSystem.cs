using UnityEngine;
using FYFY;

public class PosSystem : FSystem {

	/// <summary>
	/// The just born family
	/// Représente un oiseau née par reproduction assité
	/// </summary>
	private Family JustBornFamily = FamilyManager.getFamily(new AllOfComponents(typeof(JustBorn)));

	/// <summary>
	/// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
	/// Place l'oiseau qui vient de naître d'une reproduction assité au bonne endroit
	/// </summary>
	/// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
	/// <remarks>
	/// Called only is this <see cref="T:FYFY.FSystem" /> is active.
	/// </remarks>
	protected override void onProcess(int familiesUpdateCount)
	{
		foreach (GameObject go in JustBornFamily)
		{
			go.transform.position = go.GetComponent<JustBorn>().pos.transform.position;
			GameObjectManager.removeComponent<JustBorn>(go);
		}
	}
}