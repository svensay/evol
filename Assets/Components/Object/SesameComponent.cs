using UnityEngine;

public class SesameComponent : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public GameObject prefab_sesame;
    public RectTransform scroll_view;
    public int price;

    public void onClick()
    {
        AddInventory.instanceAddInv.onClick_addSesame();
    }
}