using FYFY;
using UnityEngine;

public class OpenShopSystem : FSystem
{
    public static OpenShopSystem instanceOS;
    private Family _ShopFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Shop)));
    public OpenShopSystem()
    {
        instanceOS = this;
    }

    public void onClick_shop()
    {
        GameObject go = _ShopFamily.First();
        Shop s = go.GetComponent<Shop>();
        GameObject panel = s.boutique;
        GameObjectManager.setGameObjectState(panel, true);
        Time.timeScale = 0.0f;
    }
}