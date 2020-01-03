using UnityEngine;
using System.Collections.Generic;
using FYFY;

public class BirdFactory : FSystem {

    private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));
	
    // Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        foreach (GameObject go in factory_F)
        {
            Factory fact = go.GetComponent<Factory>();
            fact.reloadProgress += Time.deltaTime;
            if (fact.reloadProgress >= fact.reloadTime)
            {
                if(go.transform.childCount >= 2) { 
                    for(int i = 0; i < go.transform.childCount * 2; i++) { 
                        GameObject g = GameObject.Instantiate<GameObject>(fact.prefab);
                        Attribut a = g.GetComponent<Attribut>();

                        a.gene = new Dictionary<string, float>();

                        a.stat[7] = (fact.generation + 1).ToString();

                        RandomTarget r = g.GetComponent<RandomTarget>();
                        r.down = fact.down;
                        r.up = fact.up;

                        GameObjectManager.bind(g);

                        GameObjectManager.setGameObjectParent(g,go,false);
                    }
                }
                fact.reloadProgress = 0;
            }
        }
	}
}