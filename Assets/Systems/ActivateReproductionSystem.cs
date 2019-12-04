using UnityEngine;
using FYFY;

public class ActivateReproductionSystem : FSystem {

    //Nid
    private Family _NestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(ActivateReproduction)));

    //Oiseaux dans un nid 
    private Family _BirdInNestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(InNest)));

    // Use to process your families.
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
                            GameObjectManager.setGameObjectState(go3.GetComponent<ActivateReproduction>().reproduction,true);
                    }
                }

            }
        }
	}
}