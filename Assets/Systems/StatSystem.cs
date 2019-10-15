using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;

public class StatSystem : FSystem
{

    private Family _StatSystem = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)));
    private GameObject p;

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        if (Input.GetMouseButton(0))
        {
            bool click = false;
            foreach (GameObject go in _StatSystem)
            {  
                if (go.gameObject.GetComponent<PointerOver>() != null)
                {
                    p = go.gameObject.GetComponent<Attribut>().panel;
                    Attribut a = go.GetComponent<Attribut>();
                    if (!p.activeSelf)
                        p.SetActive(true);
                    a.nom.text = a.stat[0];
                    click = true;
                }
            }
            if (click == false)
                p.SetActive(false);
        }
    }
}