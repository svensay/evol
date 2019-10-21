using UnityEngine;
using FYFY;

public class AddInventory : FSystem {
    public static AddInventory instanceAddInv;
    private Family _AddInventoryFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Inventory)));

    public AddInventory()
    {
        instanceAddInv = this;
    }
    public void onClick_add()
    {
        foreach(GameObject go in _AddInventoryFamily)
        {
            Inventory inv = go.GetComponent<Inventory>();
            RectTransform scroll_view = inv.scroll_view;
            GameObject item = Object.Instantiate<GameObject>(inv.prefab_object);
            item.transform.parent = scroll_view;
        }
    }
}