using UnityEngine;
using FYFY;
using FYFY_plugins.Monitoring;

public class ChangeTimeSystem : FSystem {

    /// <summary>
    /// The accelerate family
    /// Représente le bouton pour accélérer le temps
    /// </summary>
    private Family AccelerateFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Accelerate), typeof(ComponentMonitoring)));

    /// <summary>
    /// The pause family
    /// Représente le bouton pour mettre en pause le temps
    /// </summary>
    private Family PauseFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Pause), typeof(ComponentMonitoring)));

    /// <summary>
    /// The normal family
    /// Représente le bouton pour remettre le temps à une vitesse normal
    /// </summary>
    private Family NormalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(NormalTime), typeof(ComponentMonitoring)));

    /// <summary>
    /// Ons the click accelerate.
    /// Augmente le temps fois 2.
    /// </summary>
    public void onClick_accelerate()
    {
        ComponentMonitoring cm = AccelerateFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);
        Time.timeScale = 2.0f;
    }

    /// <summary>
    /// Ons the click pause.
    /// Arrete le temps
    /// </summary>
    public void onClick_pause()
    {
        ComponentMonitoring cm = PauseFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);
        Time.timeScale = 0.0f;
    }

    /// <summary>
    /// Ons the click normal.
    /// Remet le temps à une vitesse normal
    /// </summary>
    public void onClick_normal()
    {
        ComponentMonitoring cm = NormalFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);
        Time.timeScale = 1.0f;
    }
}