using UnityEngine.SceneManagement;
using UnityEngine;
using FYFY;
using FYFY_plugins.Monitoring;

public class SwitchEnv : FSystem
{
    private Family EnvGroupFamily = FamilyManager.getFamily(new AllOfComponents(typeof(EnvGroup)));
    private Family EnvActiveFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Env)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));
    private Family EnvFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Env)));

    private Family LeftFamily = FamilyManager.getFamily(new AllOfComponents(typeof(leftClickChangeEnv), typeof(ComponentMonitoring)));
    private Family RightFamily = FamilyManager.getFamily(new AllOfComponents(typeof(rightClickChangeEnv), typeof(ComponentMonitoring)));

    public void onClick_left()
    {
        ComponentMonitoring cm = LeftFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);

        EnvGroupFamily.First().GetComponent<EnvGroup>().id = EnvGroupFamily.First().GetComponent<EnvGroup>().id - 1;
        if (EnvGroupFamily.First().GetComponent<EnvGroup>().id < 0) EnvGroupFamily.First().GetComponent<EnvGroup>().id = EnvFamily.Count - 1;

        GameObjectManager.setGameObjectState(EnvActiveFamily.First(), false);
        GameObjectManager.setGameObjectState(EnvGroupFamily.First().transform.GetChild(EnvGroupFamily.First().GetComponent<EnvGroup>().id).gameObject, true);
    }
    public void onClick_right()
    {
        ComponentMonitoring cm = RightFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);

        EnvGroupFamily.First().GetComponent<EnvGroup>().id = (EnvGroupFamily.First().GetComponent<EnvGroup>().id + 1) % EnvFamily.Count;

        GameObjectManager.setGameObjectState(EnvActiveFamily.First(), false);
        GameObjectManager.setGameObjectState(EnvGroupFamily.First().transform.GetChild(EnvGroupFamily.First().GetComponent<EnvGroup>().id).gameObject, true);
    }
}