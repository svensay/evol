using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class InventorySystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_appears()
	{
		MainLoop.callAppropriateSystemMethod ("InventorySystem", "onClick_appears", null);
	}

}