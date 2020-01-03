using UnityEngine;
using System.Collections.Generic;

public class Attribut : MonoBehaviour
{
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public string[] stat;
    public Dictionary<string, float> gene;
}