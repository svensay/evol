using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class EchapSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClickContinue()
	{
		MainLoop.callAppropriateSystemMethod ("EchapSystem", "onClickContinue", null);
	}

	public void onClickRecomence()
	{
		MainLoop.callAppropriateSystemMethod ("EchapSystem", "onClickRecomence", null);
	}

	public void onClickQuit()
	{
		MainLoop.callAppropriateSystemMethod ("EchapSystem", "onClickQuit", null);
	}

}