using UnityEngine;
using UnityEngine.UI;
using FYFY;

public class GoalSystem : FSystem {

    private Family _GoalSystem = FamilyManager.getFamily(new AllOfComponents(typeof(FeedBack)));
    private Family _StatSystem = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)));

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
            Text display = go_goal.GetComponent<FeedBack>().faucon;
            display.text = "Faucon : " + i;
        }
    }
}