using UnityEngine;
using UnityEngine.UI;
using FYFY;

public class ReproductionSystem : FSystem
{

    private Family ProductionFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Production)));
    private Family ReproductionFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Reproduction)));

    public void onClickRepro(int id)
    {
        foreach (GameObject goProd in ProductionFamily)
        {
            if (goProd.GetComponent<Production>().id == id)
            {
                GameObjectManager.setGameObjectState(goProd, true);
                goProd.transform.GetChild(1).GetComponentInChildren<Slider>().value = 0;
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
                    GameObject fam = prod.fam;
                    GameObject g = Object.Instantiate<GameObject>(prod.prefab, go.transform.position, Quaternion.identity);

                    Attribut a = g.GetComponent<Attribut>();
                    //Definir les attributs en ajoutant tous les attributs

                    a.stat[6] = prod.generation.ToString();

                    RandomTarget r = g.GetComponent<RandomTarget>();
                    r.down = prod.down;
                    r.up = prod.up;

                    GameObjectManager.bind(g);

                    GameObjectManager.setGameObjectParent(g, fam, false);

                    GameObjectManager.setGameObjectState(go, false);
                }
                else
                    sl.value = sl.value + Time.deltaTime;
            }
        }
    }
}