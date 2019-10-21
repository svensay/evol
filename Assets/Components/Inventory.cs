using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public GameObject prefab_object;
    public RectTransform scroll_view;

    public void onClick()
    {
        AddInventory.instanceAddInv.onClick_add();
    }
}