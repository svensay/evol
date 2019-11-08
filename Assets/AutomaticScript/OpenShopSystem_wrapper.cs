using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class OpenShopSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_shop()
	{
		MainLoop.callAppropriateSystemMethod ("OpenShopSystem", "onClick_shop", null);
	}

}