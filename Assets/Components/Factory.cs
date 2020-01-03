using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public float reloadTime = 29f;
    public float reloadProgress = 0f;

    public int generation = 1;

    public Transform up;
    public Transform down;

    public GameObject prefab;
}