using UnityEngine;

public class Pause : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public void onCLick()
    {
        ChangeTimeSystem.instance.onClick_pause();
    }
}