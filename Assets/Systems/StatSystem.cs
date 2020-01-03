using FYFY;
using FYFY_plugins.PointerManager;
using UnityEngine;
using UnityEngine.UI;

public class StatSystem : FSystem
{
    private Family _StatFeedFamily = FamilyManager.getFamily(new AllOfComponents(typeof(StatFeed)));
    
    private Family _SelectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(PointerOver)), new NoneOfComponents(typeof(Select)));
    
    private Family _UnselectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(Select)), new NoneOfComponents(typeof(PointerOver)));
    private GameObject p;
    private Attribut a;

    public StatSystem()
    {
        this.p = _StatFeedFamily.First();
    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        if (Input.GetMouseButton(0))
        {
            if (_UnselectFamily.Count > 0)
            {
                GameObjectManager.removeComponent<Select>(_UnselectFamily.First());
                GameObjectManager.setGameObjectState(_UnselectFamily.First().transform.GetChild(0).gameObject, false);
                GameObjectManager.setGameObjectState(p, false);
            }
            if (_SelectFamily.First() != null)
            {
                GameObjectManager.addComponent<Select>(_SelectFamily.First());
                GameObjectManager.setGameObjectState(p, true);
                GameObjectManager.setGameObjectState(_SelectFamily.First().transform.GetChild(0).gameObject, true);
                a = _SelectFamily.First().GetComponent<Attribut>();
                p.GetComponentInChildren<Text>().text = a.stat[2] + "\n" + a.stat[3] + "\n" + a.stat[4] + "\n" + a.stat[5] + "\n" + a.stat[6] +"\n generation : " + a.stat[7];
                p.GetComponentInChildren<Slider>().maxValue = int.Parse(a.stat[0]);
            }
        }

        if (p.activeSelf)
            p.GetComponentInChildren<Slider>().value = int.Parse(a.stat[1]);
    }
}