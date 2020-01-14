using UnityEngine;
using FYFY;

public class LifeSystem : FSystem {

    //Oiseaux qui ne sont pas dans un nid
    private Family _StatFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut)), new NoneOfComponents(typeof(InNest)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));    
    
    //Oiseaux qui sont dans un nid
    private Family _StatInNestFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(InNest)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));

    //Nid avec oiseau
    private Family _NestBirdFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Nest), typeof(HaveBird)));
    
    //Oiseaux selectionner
    private Family _SelectFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Attribut), typeof(Select)));

    private Family _StatFeedFamily = FamilyManager.getFamily(new AllOfComponents(typeof(StatFeed)));

    private Family _EnvFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Env)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));

    private float time = 0.0f;

    // Use to process your families.
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