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
        if (EnvGroupFamily.First().GetComponent<EnvGroup>().id < 0) EnvGroupFamily.First().GetComponent<EnvGroup>().id = EnvFamily.Count - 1;

        GameObjectManager.setGameObjectState(EnvActiveFamily.First(), false);
        GameObjectManager.setGameObjectState(EnvGroupFamily.First().transform.GetChild(EnvGroupFamily.First().GetComponent<EnvGroup>().id).gameObject, true);
    }
    public void onClick_right()
    {
        EnvGroupFamily.First().GetComponent<EnvGroup>().id = (EnvGroupFamily.First().GetComponent<EnvGroup>().id + 1) % EnvFamily.Count;

        GameObjectManager.setGameObjectState(EnvActiveFamily.First(), false);
        GameObjectManager.setGameObjectState(EnvGroupFamily.First().transform.GetChild(EnvGroupFamily.First().GetComponent<EnvGroup>().id).gameObject, true);
    }
}