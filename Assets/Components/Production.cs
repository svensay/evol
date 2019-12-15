using UnityEngine;

public class Production : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	public int id;
	
	public GameObject prefab;

	public GameObject fam;

	public int generation = 1;

	public Transform up;
	public Transform down;
}