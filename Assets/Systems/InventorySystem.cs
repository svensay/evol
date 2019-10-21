using UnityEngine;
using FYFY;

public class InventorySystem : FSystem {

    public static InventorySystem instanceInv;
    private Family _ActInventoryFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Active_Inventory)));

    public InventorySystem()
    {
        instanceInv = this;
    }

    public void onClick_appears()
    {
        foreach (GameObject go in _ActInventoryFamily)
        {
            Active_Inventory a = go.GetComponent<Active_Inventory>();
            if (a.scroll_view.activeSelf)
                a.scroll_view.SetActive(false);
            else
                a.scroll_view.SetActive(true);
        }
    }
}