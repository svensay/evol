using FYFY;
using UnityEngine;
using UnityEngine.UI;

public class GoalSystem : FSystem
{

    private Family _GoalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Goal)));
    private Family _StatFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)));
    private Family _MessageFamily = FamilyManager.getFamily(new AllOfComponents(typeof(LevelClearMessage)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        int i = 0;
        int j = 0;
        GameObject go_goal = _GoalFamily.First();

        foreach (GameObject go_att in _StatFamily)
        {
            if (go_att.GetComponent<Attribut>().stat[6].Equals("Rouge")) i += 1;
            else j += 1;
        }
        Goal g = go_goal.GetComponent<Goal>();

        Text display = g.display;
        if(g.act_goal_rouge && !g.act_goal_vert) 
        { 
            display.text = "Pigeon Rouge: " + i + " / " + g.goal_rouge;
        }
        else if(!g.act_goal_rouge && g.act_goal_vert)
        {
            display.text = "Pigeon Vert: " + j + " / " + g.goal_vert;
        }
        else
        {
            display.text = "Pigeon Rouge: " + i + " / " + g.goal_rouge + "\n" 
                + "Pigeon Vert: " + j + " / " + g.goal_vert;
        }

        if (( g.act_goal_rouge && !g.act_goal_vert && !g.reverse_goal_rouge && i >= g.goal_rouge ) // Condition objectif seulement pigeon rouge >= 
            || ( g.act_goal_rouge && !g.act_goal_vert && g.reverse_goal_rouge && i <= g.goal_rouge) // Condition objectif seulement pigeon rouge <= 
            || ( g.act_goal_vert && !g.act_goal_rouge && !g.reverse_goal_vert && j >= g.goal_vert ) // Condition objectif seulement pigeon vert >=
            || ( g.act_goal_vert && !g.act_goal_rouge && g.reverse_goal_vert && j <= g.goal_vert ) // Condition objectif seulement pigeon vert <=
            || (g.act_goal_rouge && g.act_goal_vert && g.reverse_goal_rouge && g.reverse_goal_vert && i <= g.goal_rouge && j <= g.goal_vert) // Condition tous les pigeons <=
            || (g.act_goal_rouge && g.act_goal_vert && !g.reverse_goal_rouge && g.reverse_goal_vert && i >= g.goal_rouge && j <= g.goal_vert) // Condition pigeon rouge >= et pigeon vert <=
            || (g.act_goal_rouge && g.act_goal_vert && g.reverse_goal_rouge && !g.reverse_goal_vert && i <= g.goal_rouge && j >= g.goal_vert) // Condition pigeon rouge <= et pigeon vert >=
            || (g.act_goal_rouge && g.act_goal_vert && !g.reverse_goal_rouge && !g.reverse_goal_vert && i >= g.goal_rouge && j >= g.goal_vert)) // Condition tous les pigeons >=
        {
            Time.timeScale = 0.0f;
            GameObject go_msg = _MessageFamily.First();
            LevelClearMessage lcm = go_msg.GetComponent<LevelClearMessage>();
            GameObject msg = lcm.msg;
            GameObjectManager.setGameObjectState(msg, true);
        }
    }
}