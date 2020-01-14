using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class GoalSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClick_NextStage()
	{
		MainLoop.callAppropriateSystemMethod ("GoalSystem", "onClick_NextStage", null);
	}

}