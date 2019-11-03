using UnityEngine;
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
        Family _HaricotFamily = FamilyManager.getFamily(new AllOfComponents(typeof(HaricotComponent)));
        foreach (GameObject go_h in _HaricotFamily)
        {
            HaricotComponent h = go_h.GetComponent<HaricotComponent>();
            RectTransform scroll_view = h.scroll_view;
            GameObject item = Object.Instantiate<GameObject>(h.prefab_haricot);
            item.transform.parent = scroll_view;
            foreach(GameObject go_c in _CoinFamily)
            {
                Coin c = go_c.GetComponent<Coin>();
                int get_value = int.Parse(c.value.text) - h.price;
                c.value.text = get_value.ToString();
            }
        }
    }
}