using UnityEngine;
using FYFY;
using FYFY_plugins.Monitoring;

public class ChangeTimeSystem : FSystem {
    private Family AccelerateFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Accelerate), typeof(ComponentMonitoring)));
    private Family PauseFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Pause), typeof(ComponentMonitoring)));
    private Family NormalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(NormalTime), typeof(ComponentMonitoring)));

    public void onClick_accelerate()
    {
        ComponentMonitoring cm = AccelerateFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);
        Time.timeScale = 2.0f;
    }
    public void onClick_pause()
    {
        ComponentMonitoring cm = PauseFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);
        Time.timeScale = 0.0f;
    }
    public void onClick_normal()
    {
        ComponentMonitoring cm = NormalFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);
        Time.timeScale = 1.0f;
    }
}