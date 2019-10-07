using UnityEngine;
using FYFY;

public class AffichageAttributSystem : FSystem {

    private Family _AffichageAttribut = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)));

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
       /** foreach(GameObject go in _AffichageAttribut)
        {
            Attribut a = go.GetComponent<Attribut>();
            a.nom_aff.text = a.nom;
        }
    */
    }
    public void OnMouseDown()
    {
        foreach (GameObject go in _AffichageAttribut)
        {
            Attribut a = go.GetComponent<Attribut>();
            a.nom_aff.text = a.nom;
            Debug.Log("OnMouse");
        }
    }
}