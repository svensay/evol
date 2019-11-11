using UnityEngine;
using FYFY;

public class TimeSystem : FSystem {

    private Family _TimeFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Time_Chrono)));
    private float chronoTime = 1.0f;
    private int generation = 1;

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _TimeFamily)
        {
            Time_Chrono c = go.GetComponent<Time_Chrono>();
            
            chronoTime += Time.deltaTime;
            int temp = (int)chronoTime;
            if(temp % 30 == 0)
            {
                chronoTime = 1.0f;
                generation++;
                Family FactFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));
                foreach (GameObject go_fact in FactFamily)
                {
                    go_fact.GetComponent<Factory>().generation = generation;
                }
                c.affichage.text = "generation : "+generation.ToString();
            }
            /**
            int min = temp / 60;
            int sec = temp % 60;
            c.affichage.text = min.ToString() + ":" + sec.ToString();
            */
        }
    }
}