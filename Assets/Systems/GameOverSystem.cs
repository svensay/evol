using UnityEngine;
using FYFY;

public class GameOverSystem : FSystem {

	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

	private Family GameOverFamily = FamilyManager.getFamily(new AllOfComponents(typeof(GameOver)));

	private Family _GoalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Goal)));

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		Goal g = _GoalFamily.First().GetComponent<Goal>();
		foreach(GameObject go in factory_F)
		{
			if (g.act_goal_rouge && !g.reverse_goal_rouge && go.name.Equals("Pigeon_rouge") && go.transform.childCount <= 0
				|| g.act_goal_vert && !g.reverse_goal_vert && go.name.Equals("Pigeon_vert") && go.transform.childCount <= 0)
			{
				GameObjectManager.setGameObjectState(GameOverFamily.First(), true);
				Time.timeScale = 0.0f;
			}
		}
	}
}