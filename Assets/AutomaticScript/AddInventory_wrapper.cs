using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class AddInventory_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_addHaricot()
	{
		MainLoop.callAppropriateSystemMethod ("AddInventory", "onClick_addHaricot", null);
	}

	public void onClick_addSesame()
	{
		MainLoop.callAppropriateSystemMethod ("AddInventory", "onClick_addSesame", null);
	}

}