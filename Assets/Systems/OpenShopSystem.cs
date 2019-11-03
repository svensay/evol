using UnityEngine;
using FYFY;

public class OpenShopSystem : FSystem {
    public static OpenShopSystem instanceOS;
    private Family _ShopFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Shop)));
    public OpenShopSystem()
    {
        instanceOS = this;
    }

    public void onClick_shop()
    {
        foreach (GameObject go in _ShopFamily)
        {
            Shop s = go.GetComponent<Shop>();
            GameObject panel = s.boutique;
            panel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}