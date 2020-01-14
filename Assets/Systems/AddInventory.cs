using UnityEngine;
using UnityEngine.UI;
using FYFY;

public class AddInventory : FSystem
{
    /// <summary>
    /// The coin family
    /// Représente les piéces que posséde le joueur
    /// </summary>
    private Family _CoinFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Coin)));

    /// <summary>
    /// The object family/
    /// Représante les objets dans le magasin
    /// </summary>
    private Family _ObjectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Object)));

    /// <summary>
    /// The message shop family
    /// Représente le texte d'affichage dans le magasin
    /// </summary>
    private Family _MessageShopFamily = FamilyManager.getFamily(new AllOfComponents(typeof(MessageShop)));

    /// <summary>
    /// The back game family
    /// Représente le bouton de retour dans le magasin
    /// </summary>
    private Family _BackGameFamily = FamilyManager.getFamily(new AllOfComponents(typeof(BackGame)));


    /// <summary>
    /// Ons the click add item.
    /// Ajoute l'item dans l'inventaire dont l'identifiant est égale à id et vérifie si le joueur a assez d'argent
    /// </summary>
    /// <param name="id">The identifier.</param>
    public void onClick_addItem(int id)
    {
        foreach (GameObject go in _ObjectFamily)
        {
            Object o = go.GetComponent<Object>();
            if (o.id == id)
            {
                MessageShop ms = _MessageShopFamily.First().GetComponent<MessageShop>();
                Text d = ms.display;

                Coin c = _CoinFamily.First().GetComponent<Coin>();
                int tmp_money = c.money - o.price;
                if (tmp_money < 0)
                {
                    d.text = "Tu n'a pas " + o.price + " piéce pour acheté.";
                }
                else
                {
                    d.text = "Acheté.";
                    c.money = tmp_money;
                    c.value.text = tmp_money.ToString();
                    RectTransform scroll_view = o.scroll_view;
                    GameObject item = Object.Instantiate<GameObject>(o.prefab);

                    GameObjectManager.bind(item);

                    GameObjectManager.setGameObjectParent(item, scroll_view.gameObject, true);
                }
            }
        }
    }

    /// <summary>
    /// Ons the click back.
    /// Retourne dans le jeu quand on est dans le magasin
    /// </summary>
    public void onClick_back()
    {
        BackGame bg = _BackGameFamily.First().GetComponent<BackGame>();
        GameObject panel = bg.boutique;
        GameObjectManager.setGameObjectState(panel, false);
        Time.timeScale = 1.0f;

    }
}