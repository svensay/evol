using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public float reloadTime = 2f;
    public float reloadProgress = 0f;

    public Transform up;
    public Transform down;

    public GameObject prefab;

    public Text nom;
    public GameObject panel;
}