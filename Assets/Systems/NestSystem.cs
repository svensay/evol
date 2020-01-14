using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;

public class NestSystem : FSystem {
  
    /// <summary>
    /// The nest no bird family
    /// Représente les places de nids sans oiseau dedans.
    /// </summary>
    private Family _NestNoBirdFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Nest),typeof(PointerOver)), new NoneOfComponents(typeof(HaveBird)));

    /// <summary>
    /// The select family
    /// Représente l'oiseau sélectionné mais pas encore dans le nid
    /// </summary>
    private Family _SelectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut),typeof(Select)), new NoneOfComponents(typeof(InNest)));
   
    /// <summary>
    /// The select nest family
    /// Représente l'oiseau pointer par la souris dans un nid
    /// </summary>
    private Family _SelectNestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(PointerOver), typeof(InNest)));
    
    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Ajoute et enléve les oiseaux d'un nid.
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
    protected override void onProcess(int familiesUpdateCount)
    {
        //Click gauche met l'oiseaux dans le nid
        if (Input.GetMouseButton(0))
        {
            if (_NestNoBirdFamily.Count > 0 && _SelectFamily.Count > 0)
            {
                GameObjectManager.removeComponent<Move>(_SelectFamily.First());

                GameObjectManager.addComponent<InNest>(_SelectFamily.First(), new { place = _NestNoBirdFamily.First(), myNest = _NestNoBirdFamily.First().GetComponent<Nest>().id });

                GameObjectManager.addComponent<HaveBird>(_NestNoBirdFamily.First());

                _SelectFamily.First().transform.position = _NestNoBirdFamily.First().transform.position;
            }
        }

        //Click droit enleve l'oiseaux du nid
        if (Input.GetMouseButton(1))
        {
            if (_SelectNestFamily.Count > 0)
            {
                GameObjectManager.removeComponent<HaveBird>(_SelectNestFamily.First().GetComponent<InNest>().place);

                GameObjectManager.addComponent<Move>(_SelectNestFamily.First());

                GameObjectManager.removeComponent<InNest>(_SelectNestFamily.First());
            }
        }
    }
}