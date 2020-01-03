using UnityEngine;
using FYFY;

public class GameOverSystem : FSystem {

	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

	private Family GameOverFamily = FamilyManager.getFamily(new AllOfComponents(typeof(GameOver)));

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach(GameObject go in factory_F)
		{
			if (go.name.Equals("Pigeon_rouge") && go.transform.childCount <= 1)
			{
				GameObjectManager.setGameObjectState(GameOverFamily.First(), true);
				Time.timeScale = 0.0f;
			}
		}
	}
}