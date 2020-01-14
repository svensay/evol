using FYFY;
using FYFY_plugins.PointerManager;
using UnityEngine;
using UnityEngine.UI;

public class StatSystem : FSystem
{
    /// <summary>
    /// The stat feed family
    /// Représente la fenêtre d'affichage des attributs de l'oiseau sélectionné
    /// </summary>
    private Family _StatFeedFamily = FamilyManager.getFamily(new AllOfComponents(typeof(StatFeed)));

    /// <summary>
    /// The select family
    /// Représente l'oiseaux pointer par la souris mais pas sélectionné
    /// </summary>
    private Family _SelectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(PointerOver)), new NoneOfComponents(typeof(Select)));

    /// <summary>
    /// The unselect family
    /// Représente l'oiseaux qui est sélectionner mais pas pointer par la souris
    /// </summary>
    private Family _UnselectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(Select)), new NoneOfComponents(typeof(PointerOver)));

    /// <summary>
    /// The p
    /// Représente la fenêtre d'affichage des attributs de l'oiseau sélectionné
    /// </summary>
    private GameObject p;

    /// <summary>
    /// a
    /// Représente les attributs de l'oiseau sélectionné
    /// </summary>
    private Attribut a;

    /// <summary>
    /// Initializes a new instance of the <see cref="StatSystem"/> class.
    /// Initialise la fenêtre d'affichage des attributs de l'oiseau sélectionné
    /// </summary>
    public StatSystem()
    {
        this.p = _StatFeedFamily.First();
    }

    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Récupere les attributs de l'oiseaux sélectionner pour les afficher sur la fenêtre d'affichage
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
    protected override void onProcess(int familiesUpdateCount)
    {
        if (Input.GetMouseButton(0))
        {
            if (_UnselectFamily.Count > 0)
            {
                GameObjectManager.removeComponent<Select>(_UnselectFamily.First());
                GameObjectManager.setGameObjectState(_UnselectFamily.First().transform.GetChild(0).gameObject, false);
                GameObjectManager.setGameObjectState(p, false);
            }
            if (_SelectFamily.First() != null)
            {
                GameObjectManager.addComponent<Select>(_SelectFamily.First());
                GameObjectManager.setGameObjectState(p, true);
                GameObjectManager.setGameObjectState(_SelectFamily.First().transform.GetChild(0).gameObject, true);
                a = _SelectFamily.First().GetComponent<Attribut>();
                p.GetComponentInChildren<Text>().text = a.stat[2] + "\n" + a.stat[3] + "\n" + a.stat[4] + "\n" + a.stat[5] + "\n" + a.stat[6] +"\n generation : " + a.stat[7];
                p.GetComponentInChildren<Slider>().maxValue = int.Parse(a.stat[0]);
            }
        }

        if (p.activeSelf)
            p.GetComponentInChildren<Slider>().value = int.Parse(a.stat[1]);
    }
}