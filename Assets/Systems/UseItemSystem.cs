using UnityEngine;
using FYFY;

public class UseItemSystem : FSystem {

	private Family ChooseFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Choose)));

	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

	private Family _ActInventoryFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Active_Inventory)));

	public void clickUse(GameObject item)
	{
		ChooseFamily.First().GetComponent<Choose>().plus_life_point = item.GetComponent<Item>().life_point;
		
		GameObjectManager.unbind(item);
		Object.Destroy(item);

		GameObjectManager.setGameObjectState(ChooseFamily.First(), true);
		GameObjectManager.setGameObjectState(_ActInventoryFamily.First().GetComponent<Active_Inventory>().scroll_view, false);
		
	}

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