using UnityEngine;
using FYFY;

public class RandomMovingSystem : FSystem
{

    private Family _randomMovingGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move), typeof(RandomTarget)));

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

            if (rt.target.Equals(go.transform.position))
                rt.target = new Vector3(Random.Range(rt.down.position.x,rt.up.position.x),Random.Range(rt.down.position.y, rt.up.position.y));
            else
                go.transform.position = Vector3.MoveTowards(go.transform.position, rt.target, go.GetComponent<Move>().speed * Time.deltaTime);
        }
    }

}