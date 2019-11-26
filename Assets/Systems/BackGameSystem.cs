using UnityEngine;
using FYFY;

public class BackGameSystem : FSystem {

    public static BackGameSystem instanceBG;
    private Family _BackGameFamily = FamilyManager.getFamily(new AllOfComponents(typeof(BackGame)));
    public BackGameSystem()
    {
        instanceBG = this;
    }

    public void onClick_back()
    {
        foreach(GameObject go in _BackGameFamily)
        {
            BackGame bg = go.GetComponent<BackGame>();
            GameObject panel = bg.boutique;
            GameObjectManager.setGameObjectState(panel,false);
            Time.timeScale = 1.0f;
        }
    }
}