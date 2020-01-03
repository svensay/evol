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
        GameObject go_goal = _GoalFamily.First();

        foreach (GameObject go_att in _StatFamily)
        {
            if(go_att.GetComponent<Attribut>().stat[6].Equals("Rouge")) i += 1;
        }

        Text display = go_goal.GetComponent<Goal>().display;
        display.text = "Pigeon Rouge: " + i + " / " + go_goal.GetComponent<Goal>().goal;

        if (i >= go_goal.GetComponent<Goal>().goal)
        {
            Time.timeScale = 0.0f;
            GameObject go_msg = _MessageFamily.First();
            LevelClearMessage lcm = go_msg.GetComponent<LevelClearMessage>();
            GameObject msg = lcm.msg;
            GameObjectManager.setGameObjectState(msg, true);
        }
    }
}