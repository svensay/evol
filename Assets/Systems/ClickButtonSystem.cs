using UnityEngine;
using FYFY;
using FYFY_plugins.Monitoring;

public class ClickButtonSystem : FSystem 
{
    /// <summary>
    /// The shop family
    /// Représente la page du magasin
    /// </summary>
    private Family _ShopFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Shop)));
    
    /// <summary>
    /// The inventory family
    /// Représente la page de l'inventaire
    /// </summary>
    private Family _InventoryFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Inventory)));

    /// <summary>
    /// The help family
    /// Représente la page d'aide
    /// </summary>
    private Family _HelpFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Help)));

    /// <summary>
    /// The shop monit family
    /// Utilisé pour avoir une trace du joueur lorsqu'il clique sur le bouton pour ouvrir le magasin
    /// </summary>
    private Family _ShopMonitFamily = FamilyManager.getFamily(new AllOfComponents(typeof(ShopMonitoring), typeof(ComponentMonitoring)));

    /// <summary>
    /// The inventory monit family
    /// Utilisé pour avoir une trace du joueur lorsqu'il clique sur le bouton pour ouvrir l'inventaire
    /// </summary>
    private Family _InventoryMonitFamily = FamilyManager.getFamily(new AllOfComponents(typeof(InventoryMonitoring), typeof(ComponentMonitoring)));

    /// <summary>
    /// The help monit family
    /// Utilisé pour avoir une trace du joueur lorsqu'il clique sur le bouton pour ouvrir la page d'aide
    /// </summary>
    private Family _HelpMonitFamily = FamilyManager.getFamily(new AllOfComponents(typeof(HelpMonitoring), typeof(ComponentMonitoring)));

    /// <summary>
    /// Ons the click shop.
    /// Ouvre la page du magasin
    /// </summary>
    public void onClick_shop()
    {
        GameObject go = _ShopFamily.First();

        ComponentMonitoring cm = _ShopMonitFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);


        GameObjectManager.setGameObjectState(go, true);
        Time.timeScale = 0.0f;
    }

    /// <summary>
    /// Ons the click inventory.
    /// Ouvre la page de l'inventaire
    /// </summary>
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

    /// <summary>
    /// Ons the click help.
    /// Ouvre la page d'aide
    /// </summary>
    public void onClick_help()
    {
        GameObject go = _HelpFamily.First();

        ComponentMonitoring cm = _HelpMonitFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);

        GameObjectManager.setGameObjectState(go, true);
        Time.timeScale = 0.0f;
    }

    /// <summary>
    /// Ons the click quit help.
    /// Ferme la page d'aide
    /// </summary>
    public void onClick_QuitHelp()
    {
        GameObject go = _HelpFamily.First();

        GameObjectManager.setGameObjectState(go, false);
        Time.timeScale = 1.0f;
    }
}