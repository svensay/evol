using UnityEngine;
using UnityEngine.UI;
using FYFY;
using FYFY_plugins.PointerManager;

public class StatSystem : FSystem
{

    private Family _StatSystem = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(AttributDisplay)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        if (Input.GetMouseButton(0))
        {
            foreach (GameObject go in _StatSystem)
            {
                if (go.gameObject.GetComponent<PointerOver>() != null)
                {
                    Attribut a = go.GetComponent<Attribut>();
                    AttributDisplay ad = go.GetComponent<AttributDisplay>();
                    if (!ad.panel.activeSelf)
                        ad.panel.SetActive(true);
                    ad.nom.text = a.nom;
                }
            }
        }
    }
}