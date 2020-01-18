using FYFY;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : FSystem
{
    /// <summary>
    /// The time family
    /// Représente le temps affiché
    /// </summary>
    private Family _TimeFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Time_Chrono)));

    /// <summary>
    /// The fact family
    ///  Représente les usines d'instanciation d'oiseaux et le groupe d'espèce
    /// </summary>
    private Family FactFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

    /// <summary>
    /// The product family
    /// Représente les nids de reproduction assisté
    /// </summary>
    private Family ProdFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Production)));

    /// <summary>
    /// The generation
    /// Représente la génération a l'instant t
    /// </summary>
    private int generation = 1;

    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Avance d'une génération toute les 15 secs et verifie s'il y a des naissances dû à la reproduction assisté pour les faire naître
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
    protected override void onProcess(int familiesUpdateCount)
    {
        GameObject go = _TimeFamily.First();
        Time_Chrono c = go.GetComponent<Time_Chrono>();
        c.reloadProgress += Time.deltaTime;
        if (c.reloadProgress >= c.generation)
        {
            c.reloadProgress = 0f;
            generation++;
            
            foreach (GameObject go_fact in FactFamily)
            {
                go_fact.GetComponent<Factory>().generation = generation;
            }

            foreach(GameObject go_prod in ProdFamily)
            {
                if (go_prod.activeSelf)
                    go_prod.GetComponent<Production>().product = true;
                go_prod.GetComponent<Production>().generation = generation;
            }

            go.GetComponent<Text>().text = "generation : " + generation.ToString();
        }
    }
}