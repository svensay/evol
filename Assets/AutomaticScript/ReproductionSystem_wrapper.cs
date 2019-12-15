using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class ReproductionSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void onClickRepro(System.Int32 id)
	{
		MainLoop.callAppropriateSystemMethod ("ReproductionSystem", "onClickRepro", id);
	}

}