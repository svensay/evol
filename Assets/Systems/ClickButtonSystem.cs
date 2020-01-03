using UnityEngine;
using FYFY;

public class ClickButtonSystem : FSystem 
{
    private Family _ShopFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Shop)));
    private Family _ActInventoryFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Active_Inventory)));
    private Family _HelpFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Help)));

    public void onClick_shop()
    {
        GameObject go = _ShopFamily.First();
        Shop s = go.GetComponent<Shop>();
        GameObject panel = s.boutique;
        GameObjectManager.setGameObjectState(panel, true);
        Time.timeScale = 0.0f;
    }

    public void onClick_inventory()
    {
        GameObject go = _ActInventoryFamily.First();
        Active_Inventory a = go.GetComponent<Active_Inventory>();
        if (a.scroll_view.activeSelf)
            GameObjectManager.setGameObjectState(a.scroll_view, false);
        else
            GameObjectManager.setGameObjectState(a.scroll_view, true);
    }

    public void onClick_help()
    {
        GameObject go = _HelpFamily.First();
        Help s = go.GetComponent<Help>();
        GameObject panel = s.help;
        GameObjectManager.setGameObjectState(panel, true);
        Time.timeScale = 0.0f;
    }

    public void onClick_QuitHelp()
    {
        GameObject go = _HelpFamily.First();
        Help s = go.GetComponent<Help>();
        GameObject panel = s.help;
        GameObjectManager.setGameObjectState(panel, false);
        Time.timeScale = 1.0f;
    }
}