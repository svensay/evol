using UnityEngine;

public class HaricotComponent : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public GameObject prefab_haricot;
    public RectTransform scroll_view;
    public int price;

    public void onClick()
    {
        AddInventory.instanceAddInv.onClick_addHaricot();
    }
}