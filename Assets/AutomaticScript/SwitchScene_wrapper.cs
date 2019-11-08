using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class SwitchScene_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_left()
	{
		MainLoop.callAppropriateSystemMethod ("SwitchScene", "onClick_left", null);
	}

	public void onClick_right()
	{
		MainLoop.callAppropriateSystemMethod ("SwitchScene", "onClick_right", null);
	}

}