using UnityEngine;
using UnityEngine.UI;
using FYFY;

public class BirdFactory : FSystem {

    private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

    private Factory fact;

    public BirdFactory()
    {
        fact = factory_F.First().GetComponent<Factory>();
    }
	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        fact.reloadProgress += Time.deltaTime;
        if(fact.reloadProgress >= fact.reloadTime)
        {
            GameObject go = Object.Instantiate<GameObject>(fact.prefab);
            Attribut a = go.GetComponent<Attribut>();
            a.panel = fact.panel;

            RandomTarget r = go.GetComponent<RandomTarget>();
            r.down = fact.down;
            r.up = fact.up;

            GameObjectManager.bind(go);
            go.transform.position = new Vector3(Random.Range(fact.down.position.x, fact.up.position.x), Random.Range(fact.down.position.y, fact.up.position.y));

            fact.reloadProgress = 0;
        }
	}
}