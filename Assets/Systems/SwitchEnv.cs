using UnityEngine.SceneManagement;
using UnityEngine;
using FYFY;
using FYFY_plugins.Monitoring;

public class SwitchEnv : FSystem
{
    /// <summary>
    /// The env group family
    /// Représente le groupe d'environnement
    /// </summary>
    private Family EnvGroupFamily = FamilyManager.getFamily(new AllOfComponents(typeof(EnvGroup)));

    /// <summary>
    /// The env active family
    /// Représente l'environnement activé
    /// </summary>
    private Family EnvActiveFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Env)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));

    /// <summary>
    /// The env family
    /// Représente tous les environnements
    /// </summary>
    private Family EnvFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Env)));

    /// <summary>
    /// The left family
    /// Composant permettant de tracer les cliques du joueurs pour changer d'environnement
    /// </summary>
    private Family LeftFamily = FamilyManager.getFamily(new AllOfComponents(typeof(leftClickChangeEnv), typeof(ComponentMonitoring)));

    /// <summary>
    /// The right family
    /// Composant permettant de tracer les cliques du joueurs pour changer d'environnement
    /// </summary>
    private Family RightFamily = FamilyManager.getFamily(new AllOfComponents(typeof(rightClickChangeEnv), typeof(ComponentMonitoring)));

    /// <summary>
    /// Ons the click left.
    /// Change l'environnement
    /// </summary>
    public void onClick_left()
    {
        ComponentMonitoring cm = LeftFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);

        EnvGroupFamily.First().GetComponent<EnvGroup>().id = EnvGroupFamily.First().GetComponent<EnvGroup>().id - 1;
        if (EnvGroupFamily.First().GetComponent<EnvGroup>().id < 0) EnvGroupFamily.First().GetComponent<EnvGroup>().id = EnvFamily.Count - 1;

        GameObjectManager.setGameObjectState(EnvActiveFamily.First(), false);
        GameObjectManager.setGameObjectState(EnvGroupFamily.First().transform.GetChild(EnvGroupFamily.First().GetComponent<EnvGroup>().id).gameObject, true);
    }

    /// <summary>
    /// Ons the click right.
    /// Change l'environnement
    /// </summary>
    public void onClick_right()
    {
        ComponentMonitoring cm = RightFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);

        EnvGroupFamily.First().GetComponent<EnvGroup>().id = (EnvGroupFamily.First().GetComponent<EnvGroup>().id + 1) % EnvFamily.Count;

        GameObjectManager.setGameObjectState(EnvActiveFamily.First(), false);
        GameObjectManager.setGameObjectState(EnvGroupFamily.First().transform.GetChild(EnvGroupFamily.First().GetComponent<EnvGroup>().id).gameObject, true);
    }
}