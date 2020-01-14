using UnityEngine;
using FYFY;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverSystem : FSystem {

	/// <summary>
	/// The factory f
	///  Représente les usines d'instanciation d'oiseaux et le groupe d'espèce
	/// </summary>
	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

	/// <summary>
	/// The game over family
	/// Représente la page de "game over"
	/// </summary>
	private Family GameOverFamily = FamilyManager.getFamily(new AllOfComponents(typeof(GameOver)));

	/// <summary>
	/// The goal family
	/// Représente l'objetif que le joueur doit atteindre
	/// </summary>
	private Family _GoalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Goal)));

	/// <summary>
	/// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
	/// Verifie si lorsuque l'on veut accroître une population il ne faut pas atteindre 0 et si l'on veut décroître une population ne pas atteindre 100.
	/// Sinon active la page de "game over"
	/// </summary>
	/// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
	/// <remarks>
	/// Called only is this <see cref="T:FYFY.FSystem" /> is active.
	/// </remarks>
	protected override void onProcess(int familiesUpdateCount) {
		Goal g = _GoalFamily.First().GetComponent<Goal>();
		foreach(GameObject go in factory_F)
		{
			if (g.act_goal_rouge && !g.reverse_goal_rouge && go.name.Equals("Pigeon_rouge") && go.transform.childCount <= 0
				|| g.act_goal_vert && !g.reverse_goal_vert && go.name.Equals("Pigeon_vert") && go.transform.childCount <= 0
				|| g.act_goal_rouge && g.reverse_goal_rouge && go.name.Equals("Pigeon_rouge") && go.transform.childCount >= 100
				|| g.act_goal_vert && g.reverse_goal_vert && go.name.Equals("Pigeon_vert") && go.transform.childCount >= 100)
			{
				if (GameOverFamily.First().GetComponent<GameOver>().game_over_reach)
				{
					GameObjectManager.setGameObjectState(GameOverFamily.First(), true);
					Time.timeScale = 0.0f;
					GameOverFamily.First().GetComponent<GameOver>().game_over_reach = false;
				}
			}
		}
	}
}