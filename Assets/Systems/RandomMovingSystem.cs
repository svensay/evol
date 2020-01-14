using UnityEngine;
using FYFY;

public class RandomMovingSystem : FSystem
{

    private Family _randomMovingGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move), typeof(RandomTarget)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));

    public RandomMovingSystem()
    {
        foreach (GameObject go in _randomMovingGO)
        {
            onGOEnter(go);
        }

        _randomMovingGO.addEntryCallback(onGOEnter);
    }

    private void onGOEnter(GameObject go)
    {
        go.GetComponent<RandomTarget>().target = go.transform.position;
    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _randomMovingGO)
        {
            RandomTarget rt = go.GetComponent<RandomTarget>();
            Move m = go.GetComponent<Move>();

            if (rt.target.Equals(go.transform.position) || m.lastpos.Equals(go.transform.position))
                rt.target = new Vector3(Random.Range(rt.down.position.x,rt.up.position.x),Random.Range(rt.down.position.y, rt.up.position.y));
            else
                m.lastpos = go.transform.position;
                go.transform.position = Vector3.MoveTowards(go.transform.position, rt.target, m.speed * Time.deltaTime);
               
        }
    }

}