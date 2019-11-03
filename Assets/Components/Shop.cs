using UnityEngine;

public class Shop : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public GameObject boutique;
    public void onClick()
    {
        OpenShopSystem.instanceOS.onClick_shop();
    }
}