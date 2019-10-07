using UnityEngine;

public class left_button : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public void onCLick()
    {
        SwitchScene.instance.onClick_left();
    }
}