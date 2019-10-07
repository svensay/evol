using UnityEngine;
using FYFY;

public class TimeSystem : FSystem {

    private Family _TimeFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Time_Chrono)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _TimeFamily)
        {
            Time_Chrono c = go.GetComponent<Time_Chrono>();
            float chronoTime = float.Parse(c.affichage.text);
            chronoTime += Time.deltaTime;
            c.affichage.text = chronoTime.ToString();
        }
    }
}