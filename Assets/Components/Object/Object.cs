using UnityEngine;

public class Object : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public GameObject prefab;
    public RectTransform scroll_view;
    public int price;
    public int id;
}