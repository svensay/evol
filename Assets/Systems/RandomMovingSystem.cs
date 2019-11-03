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
        Transform tr = go.GetComponent<Transform>();
        RandomTarget rt = go.GetComponent<RandomTarget>();

        rt.target = tr.position;
    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _randomMovingGO)
        {
            Transform tr = go.GetComponent<Transform>();
            Move mv = go.GetComponent<Move>();
            RandomTarget rt = go.GetComponent<RandomTarget>();

            if (rt.target.Equals(tr.position))
                rt.target = new Vector3(Random.Range(rt.down.position.x,rt.up.position.x), Random.Range(rt.down.position.y, rt.up.position.y));
            else
                tr.position = Vector3.MoveTowards(tr.position, rt.target, mv.speed * Time.deltaTime);
        }
    }

}