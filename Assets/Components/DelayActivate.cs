using UnityEngine;

public class DelayActivate : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	public int generationActivate;
    public int generation_plus_env;

    public bool act_goal_rouge = false;
    public bool reverse_goal_rouge = false;
    public int goal_rouge = 10;
    public bool act_goal_vert = false;
    public bool reverse_goal_vert = false;
    public int goal_vert = 10;

    public bool change_delay = true;
    public int env = -1;
}