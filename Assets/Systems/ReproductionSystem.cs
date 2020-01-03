using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using FYFY;

public class ReproductionSystem : FSystem
{

    private Family ProductionFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Production)));
    private Family ReproductionFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Reproduction)));
    private Family ParentFamily = FamilyManager.getFamily(new AllOfComponents(typeof(InNest)), new NoneOfComponents(typeof(Move)));
    private List<GameObject> Parent = new List<GameObject>();

    public void onClickRepro(int id)
    {
        foreach (GameObject goProd in ProductionFamily)
        {
            if (goProd.GetComponent<Production>().id == id)
            {
                GameObjectManager.setGameObjectState(goProd, true);
                goProd.transform.GetChild(1).GetComponentInChildren<Slider>().value = 0;
                foreach (GameObject goParent in ParentFamily)
                {
                    if(goParent.GetComponent<InNest>().myNest == id)
                    {
                        Parent.Add(goParent);
                        GameObjectManager.removeComponent<HaveBird>(goParent.GetComponent<InNest>().place);

                        GameObjectManager.addComponent<Move>(goParent);

                        GameObjectManager.removeComponent<InNest>(goParent);
                    }
                }
            }
        }

    }

    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in ProductionFamily)
        {
            if (go.activeSelf)
            {
                foreach (GameObject gotmp in ReproductionFamily)
                {
                    if (gotmp.GetComponent<Reproduction>().id == go.GetComponent<Production>().id)
                        GameObjectManager.setGameObjectState(gotmp, false);
                }

                Slider sl = go.transform.GetChild(1).GetComponentInChildren<Slider>();
                Production prod = go.GetComponent<Production>();
                if (sl.value >= sl.maxValue)
                {
                    GameObject p1 = Parent[0];
                    GameObject p2 = Parent[1];
                    GameObject fam = null;
                    GameObject g = null;

                    if (p1.GetComponent<Attribut>().stat[6].Equals(p2.GetComponent<Attribut>().stat[6]))
                    {
                        if (p1.GetComponent<Attribut>().stat[6].Equals("Rouge"))
                        {
                            fam = prod.fam_rouge;
                            g = GameObject.Instantiate<GameObject>(prod.prefab_rouge);
                        }
                        else
                        {
                            fam = prod.fam_vert;
                            g = GameObject.Instantiate<GameObject>(prod.prefab_vert);
                        }
                    }
                    else
                    {
                        int rand = Random.Range(1, 101);
                        if (rand < 50)
                        {
                            fam = prod.fam_rouge;
                            g = GameObject.Instantiate<GameObject>(prod.prefab_rouge);
                        }
                        else
                        {
                            fam = prod.fam_vert;
                            g = GameObject.Instantiate<GameObject>(prod.prefab_vert);
                        }
                    }

                    Attribut a = g.GetComponent<Attribut>();
                    a.stat[6] = prod.generation.ToString();

                    RandomTarget r = g.GetComponent<RandomTarget>();
                    r.down = prod.down;
                    r.up = prod.up;

                    GameObjectManager.bind(g);

                    GameObjectManager.addComponent<JustBorn>(g, new { pos = prod.pos });

                    GameObjectManager.setGameObjectParent(g, fam, false);

                    GameObjectManager.setGameObjectState(go, false);

                    
                }
                else
                    sl.value = sl.value + Time.deltaTime;
            }
        }
    }
}