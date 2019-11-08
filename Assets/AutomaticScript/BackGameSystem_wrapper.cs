using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class BackGameSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_back()
	{
		MainLoop.callAppropriateSystemMethod ("BackGameSystem", "onClick_back", null);
	}

}