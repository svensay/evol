using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class ClickButtonSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_shop()
	{
		MainLoop.callAppropriateSystemMethod ("ClickButtonSystem", "onClick_shop", null);
	}

	public void onClick_inventory()
	{
		MainLoop.callAppropriateSystemMethod ("ClickButtonSystem", "onClick_inventory", null);
	}

	public void onClick_help()
	{
		MainLoop.callAppropriateSystemMethod ("ClickButtonSystem", "onClick_help", null);
	}

	public void onClick_QuitHelp()
	{
		MainLoop.callAppropriateSystemMethod ("ClickButtonSystem", "onClick_QuitHelp", null);
	}

}