using UnityEngine;
using UnityEngine.UI;
using FYFY;
using FYFY_plugins.PointerManager;

public class StatSystem : FSystem
{
    private Family _StatSystem = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)));
    private GameObject p;
    private Attribut a;
    private float time = 0.0f;

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
                    a = go.GetComponent<Attribut>();
                    p = a.panel;
                    if (!p.activeSelf)
                        p.SetActive(true);
                    click = true;
                }
            }
            if (click == false && p != null)
            {
                p.SetActive(false);
                p = null;
                a = null;
            }
                
        }

        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            time = 0.0f;
            foreach (GameObject go in _StatSystem)
            {
                Attribut a_all = go.GetComponent<Attribut>();
                int life_point = int.Parse(a_all.stat[1]) - 1;
                a_all.stat[1] = life_point.ToString();
                if (life_point <= 0)
                {
                    GameObjectManager.unbind(go.gameObject);
                    Object.Destroy(go.gameObject);
                }
            }
        }
        if( a != null && p != null)
        {
            p.GetComponentInChildren<Text>().text = a.stat[0];
            p.GetComponentInChildren<Slider>().value = int.Parse(a.stat[1]);
        }
    }
}