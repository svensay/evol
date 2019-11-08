using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class ChangeTimeSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_accelerate()
	{
		MainLoop.callAppropriateSystemMethod ("ChangeTimeSystem", "onClick_accelerate", null);
	}

	public void onClick_pause()
	{
		MainLoop.callAppropriateSystemMethod ("ChangeTimeSystem", "onClick_pause", null);
	}

	public void onClick_normal()
	{
		MainLoop.callAppropriateSystemMethod ("ChangeTimeSystem", "onClick_normal", null);
	}

}