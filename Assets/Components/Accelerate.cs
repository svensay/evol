using UnityEngine;

public class Accelerate : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public void onCLick()
    {
        ChangeTimeSystem.instance.onClick_accelerate();
    }
}