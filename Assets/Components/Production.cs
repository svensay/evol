using UnityEngine;

public class Production : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	public int id;

	public GameObject pos;

	public GameObject prefab_rouge;
	public GameObject prefab_vert;

	public GameObject fam_rouge;
	public GameObject fam_vert;

	public int generation = 1;

	public Transform up;
	public Transform down;

	public bool product = false;
}