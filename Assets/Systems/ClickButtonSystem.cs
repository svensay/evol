using UnityEngine;
using FYFY;
using FYFY_plugins.Monitoring;

public class ClickButtonSystem : FSystem 
{
    private Family _ShopFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Shop)));
    private Family _InventoryFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Inventory)));
    private Family _HelpFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Help)));

    private Family _ShopMonitFamily = FamilyManager.getFamily(new AllOfComponents(typeof(ShopMonitoring), typeof(ComponentMonitoring)));
    private Family _InventoryMonitFamily = FamilyManager.getFamily(new AllOfComponents(typeof(InventoryMonitoring), typeof(ComponentMonitoring)));
    private Family _HelpMonitFamily = FamilyManager.getFamily(new AllOfComponents(typeof(HelpMonitoring), typeof(ComponentMonitoring)));
    public void onClick_shop()
    {
        GameObject go = _ShopFamily.First();

        ComponentMonitoring cm = _ShopMonitFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);


        GameObjectManager.setGameObjectState(go, true);
        Time.timeScale = 0.0f;
    }

    public void onClick_inventory()
    {
        GameObject go = _InventoryFamily.First();

        ComponentMonitoring cm = _InventoryMonitFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);

        if (go.activeSelf)
            GameObjectManager.setGameObjectState(go, false);
        else
            GameObjectManager.setGameObjectState(go, true);
    }

    public void onClick_help()
    {
        GameObject go = _HelpFamily.First();

        ComponentMonitoring cm = _HelpMonitFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);

        GameObjectManager.setGameObjectState(go, true);
        Time.timeScale = 0.0f;
    }

    public void onClick_QuitHelp()
    {
        GameObject go = _HelpFamily.First();

        GameObjectManager.setGameObjectState(go, false);
        Time.timeScale = 1.0f;
    }
}