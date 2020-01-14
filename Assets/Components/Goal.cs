using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public Text display;
    public bool act_goal_rouge = true;
    public bool reverse_goal_rouge = false;
    public int goal_rouge = 10;
    public bool act_goal_vert = false;
    public bool reverse_goal_vert = false;
    public int goal_vert = 10;

    public bool goal_reach = true;
}