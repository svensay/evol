using UnityEngine;
using FYFY;

public class LifeSystem : FSystem 
{

    /// <summary>
    /// The stat family
    /// Représente les oiseaux qui ne sont pas dans un nid    
    /// </summary>
    private Family _StatFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)), new NoneOfComponents(typeof(InNest)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));


    /// <summary>
    /// The stat in nest family
    /// Représente les oiseaux qui sont dans un nid.
    /// </summary>
    private Family _StatInNestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(InNest)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));
    
    /// <summary>
    /// The nest bird family
    /// Représente les nids avec au moins un oiseau
    /// </summary>
    private Family _NestBirdFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Nest), typeof(HaveBird)));
    
    /// <summary>
    /// The select family
    /// Représente un oiseaux sélectionné
    /// </summary>
    private Family _SelectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(Select)));

    /// <summary>
    /// The stat feed family
    /// Représente la page d'affichage des attribut
    /// </summary>
    private Family _StatFeedFamily = FamilyManager.getFamily(new AllOfComponents(typeof(StatFeed)));

    /// <summary>
    /// The env family
    /// Représente l'environnement actif
    /// </summary>
    private Family _EnvFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Env)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));

    /// <summary>
    /// The time
    /// Représente le temps
    /// </summary>
    private float time = 0.0f;

    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Selon l'environnement, diminue les points de vie des oiseaux et si les points de vie atteigne 0, on supprime l'oiseaux
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
    protected override void onProcess(int familiesUpdateCount) {

        // Diminution des points vie de l'oiseaux
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            time = 0.0f;
            foreach (GameObject go in _StatFamily)
            {
                Attribut a = go.GetComponent<Attribut>();
                int life_point;
                int.TryParse(a.stat[1], out life_point);

                if (go.GetComponent<Attribut>().stat[6].Equals("Rouge"))
                    life_point = life_point - _EnvFamily.First().GetComponent<Env>().minus_rouge;
                else
                    life_point = life_point - _EnvFamily.First().GetComponent<Env>().minus_vert;

                a.stat[1] = life_point.ToString();
                if (life_point <= 0)
                {
                    if (_SelectFamily.contains(go.GetInstanceID()))
                        GameObjectManager.setGameObjectState(_StatFeedFamily.First(), false);

                    GameObjectManager.unbind(go.gameObject);
                    Object.Destroy(go.gameObject);
                }
            }

            foreach (GameObject go in _StatInNestFamily)
            {
                Attribut a = go.GetComponent<Attribut>();
                int life_point;
                int.TryParse(a.stat[1], out life_point);

                if (go.GetComponent<Attribut>().stat[6].Equals("Rouge"))
                    life_point = life_point - _EnvFamily.First().GetComponent<Env>().minus_rouge;
                else
                    life_point = life_point - _EnvFamily.First().GetComponent<Env>().minus_vert;

                a.stat[1] = life_point.ToString();
                if (life_point <= 0)
                {
                    foreach (GameObject goN in _NestBirdFamily)
                    {
                        if (go.transform.position.Equals(goN.transform.position))
                        {
                            GameObjectManager.removeComponent<HaveBird>(goN);
                        }
                    }

                    if (_SelectFamily.contains(go.GetInstanceID()))
                        GameObjectManager.setGameObjectState(_StatFeedFamily.First(), false);

                    GameObjectManager.unbind(go.gameObject);
                    Object.Destroy(go.gameObject);
                }
            }
        }
    }
}