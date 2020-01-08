using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public Text value;
    public float gainTime = 5.0f;
    public float inc_Time = 0.0f;
    public int money = 0;
}