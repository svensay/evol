using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class UseItemSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void clickUse(UnityEngine.GameObject item)
	{
		MainLoop.callAppropriateSystemMethod ("UseItemSystem", "clickUse", item);
	}

	public void clickChoose(System.Int32 id)
	{
		MainLoop.callAppropriateSystemMethod ("UseItemSystem", "clickChoose", id);
	}

}