using UnityEngine;
using FYFY;

public class DelayActivateSystem : FSystem {

	/// <summary>
	/// The delay family
	/// Représente une espèce d'oiseaux qui apparaît à certaine condition
	/// </summary>
	private Family DelayFamily = FamilyManager.getFamily(new AllOfComponents(typeof(DelayActivate)));

	/// <summary>
	/// The goal family
	/// Représente l'objetif que le joueur doit atteindre
	/// </summary>
	private Family GoalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Goal)));

	/// <summary>
	/// The env group family
	/// Représente le groupe d'environnement
	/// </summary>
	private Family EnvGroupFamily = FamilyManager.getFamily(new AllOfComponents(typeof(EnvGroup)));

	/// <summary>
	/// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
	/// Active une espèce d'oiseaux sous certaine condition, soit lorque l'on atteint une génération donné, soit quand on change d'environnement et que l'on reste dans cette environnement pendant un nombre de génération donné
	/// Cela permet de simuler un adaptation, une migration ou une dérivé génétique
	/// On met alors à jour l'objectif
	/// </summary>
	/// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
	/// <remarks>
	/// Called only is this <see cref="T:FYFY.FSystem" /> is active.
	/// </remarks>
	protected override void onProcess(int familiesUpdateCount) {
		Goal g = GoalFamily.First().GetComponent<Goal>();
		EnvGroup eg = EnvGroupFamily.First().GetComponent<EnvGroup>();

		foreach(GameObject go in DelayFamily)
		{
			DelayActivate da = go.GetComponent<DelayActivate>();
			int generation = go.GetComponent<Factory>().generation;
			if (da.env < 0)
			{
				if (generation >= da.generationActivate)
				{
					GameObjectManager.setGameObjectState(go, true);
					GameObjectManager.removeComponent<DelayActivate>(go);

					g.act_goal_rouge = da.act_goal_rouge;
					g.reverse_goal_rouge = da.reverse_goal_rouge;
					g.goal_rouge = da.goal_rouge;
					g.act_goal_vert = da.act_goal_vert;
					g.reverse_goal_vert = da.reverse_goal_vert;
					g.goal_vert = da.goal_vert;
				}
			}
			else
			{
				if(da.env == eg.id)
				{
					if (da.change_delay)
					{
						da.generation_plus_env = da.generationActivate + generation;
						da.change_delay = false;
					}
					if (generation >= da.generation_plus_env)
					{
						GameObjectManager.setGameObjectState(go, true);
						GameObjectManager.removeComponent<DelayActivate>(go);

						g.act_goal_rouge = da.act_goal_rouge;
						g.reverse_goal_rouge = da.reverse_goal_rouge;
						g.goal_rouge = da.goal_rouge;
						g.act_goal_vert = da.act_goal_vert;
						g.reverse_goal_vert = da.reverse_goal_vert;
						g.goal_vert = da.goal_vert;
					}
				}
				else
				{
					da.change_delay = true;
				}
			}
		}
	}
}