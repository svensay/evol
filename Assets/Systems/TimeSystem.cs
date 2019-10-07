using UnityEngine;
using FYFY;

public class TimeSystem : FSystem {

    private Family _TimeFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Time_Chrono)));
    private float chronoTime;

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _TimeFamily)
        {
            Time_Chrono c = go.GetComponent<Time_Chrono>();
            
            chronoTime += Time.deltaTime;
            int temp = (int)chronoTime;
            int min = temp / 60;
            int sec = temp % 60;
            c.affichage.text = min.ToString() + ":" + sec.ToString();
        }
    }
}