using UnityEngine;
using FYFY;

public class ChangeTimeSystem : FSystem {

    public static ChangeTimeSystem instanceChTime;

    public ChangeTimeSystem()
    {

        instanceChTime = this;
    }

    public void onClick_accelerate()
    {
        Time.timeScale = 2.0f;
    }
    public void onClick_pause()
    {
        Time.timeScale = 0.0f;
    }
    public void onClick_normal()
    {
        Time.timeScale = 1.0f;
    }
}