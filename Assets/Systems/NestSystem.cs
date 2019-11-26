using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;

public class NestSystem : FSystem {

    //Nid choisit vide
    private Family _NestNoBirdFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Nest),typeof(PointerOver)), new NoneOfComponents(typeof(HaveBird)));
   
    //Oieaux selectionner pas encore dans un nid
    private Family _SelectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut),typeof(Select)), new NoneOfComponents(typeof(InNest)));
   
    //Oiseau choisit dans un nid 
    private Family _SelectNestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(PointerOver), typeof(InNest)));

    //Nid avec oiseau
    private Family _NestBirdFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Nest), typeof(HaveBird)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        //Click gauche met l'oiseaux dans le nid
        if (Input.GetMouseButton(0))
        {
            if (_NestNoBirdFamily.Count > 0 && _SelectFamily.Count > 0)
            {
                GameObjectManager.removeComponent<Move>(_SelectFamily.First());
                GameObjectManager.addComponent<InNest>(_SelectFamily.First());

                GameObjectManager.addComponent<HaveBird>(_NestNoBirdFamily.First());

                _SelectFamily.First().transform.position = _NestNoBirdFamily.First().transform.position;
            }
        }

        //Click droit enleve l'oiseaux du nid
        if (Input.GetMouseButton(1))
        {
            if (_SelectNestFamily.Count > 0)
            {
                foreach (GameObject go in _NestBirdFamily)
                {
                    if (_SelectNestFamily.First().transform.position.Equals(go.transform.position))
                    {
                        GameObjectManager.removeComponent<HaveBird>(go);
                    }
                }
                GameObjectManager.addComponent<Move>(_SelectNestFamily.First());
                GameObjectManager.removeComponent<InNest>(_SelectNestFamily.First());
            }
        }
    }
}