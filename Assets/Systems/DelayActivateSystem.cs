using UnityEngine;
using FYFY;

public class DelayActivateSystem : FSystem {

	private Family DelayFamily = FamilyManager.getFamily(new AllOfComponents(typeof(DelayActivate)));
	
	private Family GoalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Goal)));

	private Family EnvGroupFamily = FamilyManager.getFamily(new AllOfComponents(typeof(EnvGroup)));

	// Use to process your families.
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
						da.generationActivate = da.generationActivate + generation;
						da.change_delay = false;
					}
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
					da.change_delay = true;
				}
			}
		}
	}
}