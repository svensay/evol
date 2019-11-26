using FYFY;
using UnityEngine;

public class InventorySystem : FSystem
{

    public static InventorySystem instanceInv;
    private Family _ActInventoryFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Active_Inventory)));

    public InventorySystem()
    {
        instanceInv = this;
    }

    public void onClick_appears()
    {
        GameObject go = _ActInventoryFamily.First();
        Active_Inventory a = go.GetComponent<Active_Inventory>();
        if (a.scroll_view.activeSelf)
            GameObjectManager.setGameObjectState(a.scroll_view,false);
        else
            GameObjectManager.setGameObjectState(a.scroll_view, true);

    }
}