using FYFY;
using UnityEngine;

public class TimeSystem : FSystem
{

    private Family _TimeFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Time_Chrono)));
    private Family FactFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));
    private Family ProdFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Production)));
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
            
            foreach (GameObject go_fact in FactFamily)
            {
                go_fact.GetComponent<Factory>().generation = generation;
            }

            foreach(GameObject go_prod in ProdFamily)
            {
                go_prod.GetComponent<Production>().generation = generation;
            }

            c.affichage.text = "generation : " + generation.ToString();
        }
    }
}