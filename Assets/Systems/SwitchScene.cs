using UnityEngine.SceneManagement;
using UnityEngine;
using FYFY;

public class SwitchScene : FSystem
{ 
    public static SwitchScene instance;
    public static int ind = 0;

    public SwitchScene()
    {
        instance = this;
        GameObject canvas = GameObject.Find("Canvas");
        GameObjectManager.dontDestroyOnLoadAndRebind(canvas);
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