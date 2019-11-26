using UnityEngine;
using UnityEngine.UI;
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
                Canvas c = fact.canvas;
                GameObject g = Object.Instantiate<GameObject>(fact.prefab);
                Attribut a = g.GetComponent<Attribut>();

                a.stat[6] = fact.generation.ToString();

                RandomTarget r = g.GetComponent<RandomTarget>();
                r.down = fact.down;
                r.up = fact.up;

                GameObjectManager.bind(g);

                g.transform.SetParent(c.transform, false);

                fact.reloadProgress = 0;
            }
        }
	}
}