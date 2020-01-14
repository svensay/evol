using UnityEngine;
using System.Collections.Generic;
using FYFY;

public class BirdFactory : FSystem {
    /// <summary>
    /// The factory f
    ///  Représente les usines d'instanciation d'oiseaux et le groupe d'espèce
    /// </summary>
    private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Instancie des prefabs de pigeon chaque génération.
    /// Le nombre de prefabs de pigeon instancié est compris entre 2 et le nombre pigeons déjà présent. ( Cela devrait être entre 10 et 14 par couple de pigeon car un couple de piegon donnae naissance un à deux bébé dans 5 à 7 nid )
    /// Les vie des pigeons sont initialisé entre 3 génération et 6 génération ( car un pigeon vie entre 3 à 6 ans et une génération représente 1 ans) 
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
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
                    int nb_child = Random.Range(2, go.transform.childCount);
                    for(int i = 0; i < nb_child; i++) { 
                        GameObject g = GameObject.Instantiate<GameObject>(fact.prefab);
                        Attribut a = g.GetComponent<Attribut>();
                        
                        g.transform.position = new Vector3(Random.Range(fact.down.position.x/2, fact.up.position.x / 2), Random.Range(fact.down.position.y / 2, fact.up.position.y / 2), Random.Range(fact.down.position.z / 2, fact.up.position.z / 2));

                        a.gene = new Dictionary<string, float>();

                        int vie = Random.Range(3 * (int)fact.reloadTime, 6 * (int)fact.reloadTime); // Vie entre 3 à 6 ans ( 1 generation = 1 ans)
                        a.stat[0] = vie.ToString();
                        a.stat[1] = vie.ToString();

                        a.stat[7] = (fact.generation + 1).ToString();

                        RandomTarget r = g.GetComponent<RandomTarget>();
                        r.down = fact.down;
                        r.up = fact.up;

                        r.target = g.transform.position;

                        GameObjectManager.bind(g);

                        GameObjectManager.setGameObjectParent(g,go,false);
                    }
                }
                fact.reloadProgress = 0;
            }
        }
	}
}