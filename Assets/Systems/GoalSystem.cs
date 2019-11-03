using UnityEngine;
using UnityEngine.UI;
using FYFY;

public class GoalSystem : FSystem {

    private Family _GoalSystem = FamilyManager.getFamily(new AllOfComponents(typeof(FeedBack)));
    private Family _StatSystem = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)));
    private Family _MessageFamily = FamilyManager.getFamily(new AllOfComponents(typeof(LevelClearMessage)));
    private int goal = 10;

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        int i = 0;
        foreach (GameObject go_goal in _GoalSystem)
        {
            foreach (GameObject go_att in _StatSystem)
            {
                i += 1;
            }
            
            Text display = go_goal.GetComponent<FeedBack>().display;
            display.text = "Pigeon : " + i + " / " + goal;
            if (i >= goal)
            {
                Time.timeScale = 0.0f;
                foreach (GameObject go_msg in _MessageFamily)
                {
                    LevelClearMessage lcm = go_msg.GetComponent<LevelClearMessage>();
                    GameObject msg = lcm.msg;
                    msg.SetActive(true);
                }
            }
        }
    }
}