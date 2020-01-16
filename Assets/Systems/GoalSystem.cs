using FYFY;
using FYFY_plugins.Monitoring;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalSystem : FSystem
{

    /// <summary>
    /// The goal family
    /// Représente l'objetif que le joueur doit atteindre
    /// </summary>
    private Family _GoalFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Goal)));

    /// <summary>
    /// The fact family
    ///  Représente les usines d'instanciation d'oiseaux et le groupe d'espèce
    /// </summary>
    private Family _FactFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));
    
    /// <summary>
    /// The message family
    /// Représente la page de réussite
    /// </summary>
    private Family _MessageFamily = FamilyManager.getFamily(new AllOfComponents(typeof(LevelClearMessage)));

    /// <summary>
    /// The next monit family
    /// Composant pour tracer le clique sur "Niveau suivant" du joueur
    /// </summary>
    private Family _NextMonitFamily = FamilyManager.getFamily(new AllOfComponents(typeof(NextLevelMonitoring), typeof(ComponentMonitoring)));

    /// <summary>
    /// Ons the click next stage.
    /// Permet de passer au niveau suivant
    /// </summary>
    public void onClick_NextStage()
    {
        ComponentMonitoring cm = _NextMonitFamily.First().GetComponent<ComponentMonitoring>();
        MonitoringManager.trace(cm, "perform", MonitoringManager.Source.PLAYER);

        Time.timeScale = 1.0f;
        int sceneID = SceneManager.GetActiveScene().buildIndex;
        GameObjectManager.loadScene(sceneID + 1);
    }

    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Définie les objectifs et vérifie si les objectifs sont atteint.
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
    protected override void onProcess(int familiesUpdateCount)
    {
        int i = 0;
        int j = 0;
        GameObject go_goal = _GoalFamily.First();

        foreach (GameObject go in _FactFamily)
        {
            if (go.name.Equals("Pigeon_rouge")) i = go.transform.childCount;
            else j = go.transform.childCount;
        }
        Goal g = go_goal.GetComponent<Goal>();

        Text display = go_goal.GetComponent<Text>();
        if(g.act_goal_rouge && !g.act_goal_vert) // Affiche de l'objectif 
        { 
            if(g.reverse_goal_rouge)
                display.text = "Pigeon Rouge: " + i + " / " + g.goal_rouge + " (-)";
            else
                display.text = "Pigeon Rouge: " + i + " / " + g.goal_rouge + " (+)";
        }
        else if(!g.act_goal_rouge && g.act_goal_vert)
        {
            if (g.reverse_goal_vert)
                display.text = "Pigeon Vert: " + j + " / " + g.goal_vert + " (-)";
            else
                display.text = "Pigeon Vert: " + j + " / " + g.goal_vert + " (+)";

        }
        else
        {
            if(!g.reverse_goal_rouge && !g.reverse_goal_vert)
                display.text = "Pigeon Rouge: " + i + " / " + g.goal_rouge + " (+)\n" + "Pigeon Vert: " + j + " / " + g.goal_vert + " (+)";
            else if(!g.reverse_goal_rouge && g.reverse_goal_vert)
                display.text = "Pigeon Rouge: " + i + " / " + g.goal_rouge + " (+)\n" + "Pigeon Vert: " + j + " / " + g.goal_vert + " (-)";
            else if (g.reverse_goal_rouge && !g.reverse_goal_vert)
                display.text = "Pigeon Rouge: " + i + " / " + g.goal_rouge + " (-)\n" + "Pigeon Vert: " + j + " / " + g.goal_vert + " (+)";
            else
                display.text = "Pigeon Rouge: " + i + " / " + g.goal_rouge + " (-)\n" + "Pigeon Vert: " + j + " / " + g.goal_vert + " (-)";
        }

        if (( g.act_goal_rouge && !g.act_goal_vert && !g.reverse_goal_rouge && i >= g.goal_rouge ) // Condition objectif seulement pigeon rouge >= 
            || ( g.act_goal_rouge && !g.act_goal_vert && g.reverse_goal_rouge && i <= g.goal_rouge) // Condition objectif seulement pigeon rouge <= 
            || ( g.act_goal_vert && !g.act_goal_rouge && !g.reverse_goal_vert && j >= g.goal_vert ) // Condition objectif seulement pigeon vert >=
            || ( g.act_goal_vert && !g.act_goal_rouge && g.reverse_goal_vert && j <= g.goal_vert ) // Condition objectif seulement pigeon vert <=
            || (g.act_goal_rouge && g.act_goal_vert && g.reverse_goal_rouge && g.reverse_goal_vert && i <= g.goal_rouge && j <= g.goal_vert) // Condition tous les pigeons <=
            || (g.act_goal_rouge && g.act_goal_vert && !g.reverse_goal_rouge && g.reverse_goal_vert && i >= g.goal_rouge && j <= g.goal_vert) // Condition pigeon rouge >= et pigeon vert <=
            || (g.act_goal_rouge && g.act_goal_vert && g.reverse_goal_rouge && !g.reverse_goal_vert && i <= g.goal_rouge && j >= g.goal_vert) // Condition pigeon rouge <= et pigeon vert >=
            || (g.act_goal_rouge && g.act_goal_vert && !g.reverse_goal_rouge && !g.reverse_goal_vert && i >= g.goal_rouge && j >= g.goal_vert)) // Condition tous les pigeons >=
        {
            if (g.goal_reach)
            {
                Time.timeScale = 0.0f;
                GameObjectManager.setGameObjectState(_MessageFamily.First(), true);
                g.goal_reach = false;
            }
        }
    }
}