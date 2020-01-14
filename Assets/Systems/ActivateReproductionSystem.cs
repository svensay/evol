using UnityEngine;
using UnityEngine.UI;
using FYFY;

public class ActivateReproductionSystem : FSystem {

    /// <summary>
    /// The nest family
    /// Représente les nids
    /// </summary>
    private Family _NestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(ActivateReproduction)));

    /// <summary>
    /// The bird in nest family
    /// Représente les oiseaux qui sont dans un nid
    /// </summary>
    private Family _BirdInNestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(InNest)));

    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Systéme permettant de vérifié si deux oiseaux sont présent dans un nid
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
    protected override void onProcess(int familiesUpdateCount) {
        foreach(GameObject go1 in _BirdInNestFamily)
        {
            foreach(GameObject go2 in _BirdInNestFamily)
            {
                if (!go1.Equals(go2) && go1.GetComponent<InNest>().myNest == go2.GetComponent<InNest>().myNest)
                {
                    foreach (GameObject go3 in _NestFamily)
                    {
                        if (go1.GetComponent<InNest>().myNest == go3.GetComponent<ActivateReproduction>().id)
                        {
                            GameObjectManager.setGameObjectState(go3.GetComponent<ActivateReproduction>().reproduction, true);
                        }
                            
                    }
                }

            }
        }
	}
}