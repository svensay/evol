using UnityEngine;
using UnityEngine.UI;
using FYFY;

public class AddInventory : FSystem {
    public static AddInventory instanceAddInv;
    private Family _CoinFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Coin)));

    public AddInventory()
    {
        instanceAddInv = this;
    }
    public void onClick_addHaricot()
    {
        foreach (GameObject go_c in _CoinFamily)
        {
            Family _HaricotFamily = FamilyManager.getFamily(new AllOfComponents(typeof(HaricotComponent)));
            foreach (GameObject go_h in _HaricotFamily)
            {
                HaricotComponent h = go_h.GetComponent<HaricotComponent>();

                Coin c = go_c.GetComponent<Coin>();
                int get_value = int.Parse(c.value.text) - h.price;
                if (get_value < 0)
                {
                    Family _MessageShopFamily = FamilyManager.getFamily(new AllOfComponents(typeof(MessageShop)));
                    foreach (GameObject go_ms in _MessageShopFamily)
                    {
                        MessageShop ms = go_ms.GetComponent<MessageShop>();
                        Text d = ms.display;
                        d.text = "Tu n'a pas " + h.price + " piéce pour acheté un haricot.";
                    }
                }
                else
                {
                    c.value.text = get_value.ToString();
                    RectTransform scroll_view = h.scroll_view;
                    GameObject item = Object.Instantiate<GameObject>(h.prefab_haricot);
                    item.transform.SetParent(scroll_view, false);
                }
            }
        }
    }

    public void onClick_addSesame()
    {
        foreach (GameObject go_c in _CoinFamily)
        {
            Family _SesameFamily = FamilyManager.getFamily(new AllOfComponents(typeof(SesameComponent)));
            foreach (GameObject go_s in _SesameFamily)
            {
                SesameComponent s = go_s.GetComponent<SesameComponent>();

                Coin c = go_c.GetComponent<Coin>();
                int get_value = int.Parse(c.value.text) - s.price;
                if (get_value < 0)
                {
                    Family _MessageShopFamily = FamilyManager.getFamily(new AllOfComponents(typeof(MessageShop)));
                    foreach (GameObject go_ms in _MessageShopFamily)
                    {
                        MessageShop ms = go_ms.GetComponent<MessageShop>();
                        Text d = ms.display;
                        d.text = "Tu n'a pas " + s.price + " piéce pour acheté une sesame.";
                    }
                }
                else
                {
                    c.value.text = get_value.ToString();
                    RectTransform scroll_view = s.scroll_view;
                    GameObject item = Object.Instantiate<GameObject>(s.prefab_sesame);
                    item.transform.SetParent(scroll_view, false);
                }
            }
        }
    }
}