using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class AddInventory_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_addItem(System.Int32 id)
	{
		MainLoop.callAppropriateSystemMethod ("AddInventory", "onClick_addItem", id);
	}

	public void onClick_back()
	{
		MainLoop.callAppropriateSystemMethod ("AddInventory", "onClick_back", null);
	}

}