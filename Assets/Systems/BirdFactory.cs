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
                int childSafe = 0;
                foreach(Transform child in go.transform)
                {
                    if (child.position.x >= fact.down.position.x && child.position.x <= fact.up.position.x || child.position.y >= fact.down.position.y && child.position.y <= fact.up.position.y)
                        childSafe++;
                }

                if(go.activeSelf && childSafe >= 2) {
                    int nb_child = Random.Range((go.transform.childCount/2)*5, (go.transform.childCount/2)*14); // les piegeons se reproduisent tous les ans et une femelle possede 5 à 7 nichée qui comporte 1 à 2 bébé 
                    for(int i = 0; i < nb_child; i++) { 
                        GameObject g = GameObject.Instantiate<GameObject>(fact.prefab);
                        Attribut a = g.GetComponent<Attribut>();

                        a.gene = new Dictionary<string, float>();

                        int vie = Random.Range(3 * (int)fact.reloadTime, 6 * (int)fact.reloadTime); // Vie entre 3 à 6 ans ( 1 generation = 1 ans)
                        a.stat[0] = vie.ToString();
                        a.stat[1] = vie.ToString();

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