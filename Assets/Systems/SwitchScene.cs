using UnityEngine.SceneManagement;
using UnityEngine;
using FYFY;

public class SwitchScene : FSystem
{
    private Family EnvGroupFamily = FamilyManager.getFamily(new AllOfComponents(typeof(EnvGroup)));
    private Family EnvActiveFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Env)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));
    private Family EnvFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Env)));
    public void onClick_left()
    {
        EnvGroupFamily.First().GetComponent<EnvGroup>().id = EnvGroupFamily.First().GetComponent<EnvGroup>().id - 1;
        if (EnvGroupFamily.First().GetComponent<EnvGroup>().id < 0) EnvGroupFamily.First().GetComponent<EnvGroup>().id = 3;

        GameObjectManager.setGameObjectState(EnvActiveFamily.First(), false);

        foreach (GameObject go in EnvFamily)
        {
            if(go.GetComponent<Env>().id == EnvGroupFamily.First().GetComponent<EnvGroup>().id)
                GameObjectManager.setGameObjectState(go, true);
        }
    }
    public void onClick_right()
    {
        EnvGroupFamily.First().GetComponent<EnvGroup>().id = (EnvGroupFamily.First().GetComponent<EnvGroup>().id + 1) % 4;

        GameObjectManager.setGameObjectState(EnvActiveFamily.First(), false);

        foreach (GameObject go in EnvFamily)
        {
            if (go.GetComponent<Env>().id == EnvGroupFamily.First().GetComponent<EnvGroup>().id)
                GameObjectManager.setGameObjectState(go, true);
        }
    }
}