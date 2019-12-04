using UnityEngine;
using FYFY;

public class ReproductionSystem : FSystem {

    public static ReproductionSystem instanceReproduction;
    
    //Nid
    private Family _NestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(ActivateReproduction)));
    
    public ReproductionSystem()
    {
        instanceReproduction = this;
    }

    public void onClick(int id)
    {

    }
}