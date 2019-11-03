using UnityEngine;
public class BackGame : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public GameObject boutique;
    public void onClick()
    {
        BackGameSystem.instanceBG.onClick_back();
    }
}