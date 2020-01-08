using UnityEngine;
using FYFY;

public class PosSystem : FSystem {

	private Family JustBornFamily = FamilyManager.getFamily(new AllOfComponents(typeof(JustBorn)));

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount)
	{
		foreach (GameObject go in JustBornFamily)
		{
			go.transform.position = go.GetComponent<JustBorn>().pos.transform.position;
			GameObjectManager.removeComponent<JustBorn>(go);
		}
	}
}