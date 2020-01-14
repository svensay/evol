using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class SwitchEnv_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_left()
	{
		MainLoop.callAppropriateSystemMethod ("SwitchEnv", "onClick_left", null);
	}

	public void onClick_right()
	{
		MainLoop.callAppropriateSystemMethod ("SwitchEnv", "onClick_right", null);
	}

}