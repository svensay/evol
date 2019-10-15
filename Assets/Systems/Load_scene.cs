using UnityEngine;
using FYFY;
using UnityEngine.SceneManagement;

public class Load_scene : FSystem {

    public Load_scene()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObjectManager.dontDestroyOnLoadAndRebind(canvas);
    }
	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}