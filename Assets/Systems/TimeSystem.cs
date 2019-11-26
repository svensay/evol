using FYFY;
using UnityEngine;

public class TimeSystem : FSystem
{

    private Family _TimeFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Time_Chrono)));
    private float chronoTime = 1.0f;
    private int generation = 1;

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        GameObject go = _TimeFamily.First();
        Time_Chrono c = go.GetComponent<Time_Chrono>();
        chronoTime += Time.deltaTime;
        int temp = (int)chronoTime;
        if (temp % 30 == 0)
        {
            chronoTime = 1.0f;
            generation++;
            Family FactFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));
            foreach (GameObject go_fact in FactFamily)
            {
                go_fact.GetComponent<Factory>().generation = generation;
            }
            c.affichage.text = "generation : " + generation.ToString();
        }
    }
}