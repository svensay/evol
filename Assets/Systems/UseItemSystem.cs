using UnityEngine;
using FYFY;

public class UseItemSystem : FSystem {

	/// <summary>
	/// The choose family
	/// Représente l'objet sélectionné dans l'inventaire
	/// </summary>
	private Family ChooseFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Choose)));

	/// <summary>
	/// The factory f
	/// Représente les usines d'instanciation d'oiseaux et le groupe d'espèce
	/// </summary>
	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

	/// <summary>
	/// The inventory family
	/// Représente la page d'inventaire
	/// </summary>
	private Family _InventoryFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Inventory)));

	/// <summary>
	/// Clicks the use.
	/// Choisit un objet dans l'inventaire et le supprime de l'inventaire
	/// </summary>
	/// <param name="item">The item.</param>
	public void clickUse(GameObject item)
	{
		ChooseFamily.First().GetComponent<Choose>().plus_life_point = item.GetComponent<Item>().life_point;
		
		GameObjectManager.unbind(item);
		Object.Destroy(item);

		GameObjectManager.setGameObjectState(ChooseFamily.First(), true);
		GameObjectManager.setGameObjectState(_InventoryFamily.First(), false);
		
	}

	/// <summary>
	/// Clicks the choose.
	/// Choisit une espèce auquel on applique les effets de l'objet choisit dans l'inventaire
	/// </summary>
	/// <param name="id">The identifier.</param>
	public void clickChoose(int id)
	{
		foreach (GameObject go in factory_F)
		{
			switch (id)
			{
				case 0:
					if (go.name.Equals("Pigeon_rouge"))
					{
						foreach(Transform child in go.transform)
						{
							child.gameObject.GetComponent<Attribut>().stat[0] = (int.Parse(child.gameObject.GetComponent<Attribut>().stat[0]) + ChooseFamily.First().GetComponent<Choose>().plus_life_point).ToString();
							child.gameObject.GetComponent<Attribut>().stat[1] = (int.Parse(child.gameObject.GetComponent<Attribut>().stat[1]) + ChooseFamily.First().GetComponent<Choose>().plus_life_point).ToString();
						}
					}
					break;
				case 1:
					if (go.name.Equals("Pigeon_vert"))
					{
						foreach (Transform child in go.transform)
						{
							child.gameObject.GetComponent<Attribut>().stat[0] = (int.Parse(child.gameObject.GetComponent<Attribut>().stat[0]) + ChooseFamily.First().GetComponent<Choose>().plus_life_point).ToString();
							child.gameObject.GetComponent<Attribut>().stat[1] = (int.Parse(child.gameObject.GetComponent<Attribut>().stat[1]) + ChooseFamily.First().GetComponent<Choose>().plus_life_point).ToString();
						}
					}
					break;
			}
		}
		GameObjectManager.setGameObjectState(ChooseFamily.First(), false);
	}
}