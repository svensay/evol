using FYFY;
using UnityEngine;
using UnityEngine.UI;

public class GoalSystem : FSystem
{

    private Family _GoalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Goal)));
    private Family _StatFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)));
    private Family _MessageFamily = FamilyManager.getFamily(new AllOfComponents(typeof(LevelClearMessage)));
    private int goal = 10;

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        int i = 0;
        GameObject go_goal = _GoalFamily.First();

        foreach (GameObject go_att in _StatFamily)
        {
            i += 1;
        }

        Text display = go_goal.GetComponent<Goal>().display;
        display.text = "Pigeon : " + i + " / " + goal;
        if (i >= goal)
        {
            Time.timeScale = 0.0f;
            GameObject go_msg = _MessageFamily.First();
            LevelClearMessage lcm = go_msg.GetComponent<LevelClearMessage>();
            GameObject msg = lcm.msg;
            GameObjectManager.setGameObjectState(msg, true);
        }
    }
}