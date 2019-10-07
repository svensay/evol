using UnityEngine.SceneManagement;
using UnityEngine;
using FYFY;

public class SwitchScene : FSystem {

    private Family _SwitchScene = FamilyManager.getFamily(new AllOfComponents(typeof(right_button), typeof(left_button)));
    public static SwitchScene instance;
    public static int ind = 0;


    public SwitchScene()
    {
        instance = this;
    }

    public void onClick_left()
    {
        ind = (ind - 1) % 4;
        if (ind < 0) ind = 3;
        Debug.Log(ind);
        SceneManager.LoadScene(ind, LoadSceneMode.Single);
    }
    public void onClick_right()
    {
        ind = (ind + 1) % 4;
        Debug.Log(ind);
        SceneManager.LoadScene(ind, LoadSceneMode.Single);
    }
}