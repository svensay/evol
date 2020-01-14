using UnityEngine;
using FYFY;

public class RandomMovingSystem : FSystem
{
    /// <summary>
    /// The random moving go
    /// Représente les oiseaux qui se déplace aléatoirement
    /// </summary>
    private Family _randomMovingGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move), typeof(RandomTarget)), new AllOfProperties(PropertyMatcher.PROPERTY.ACTIVE_IN_HIERARCHY));

    /// <summary>
    /// Initializes a new instance of the <see cref="RandomMovingSystem"/> class.
    /// Initialise la position d'arrivé des oiseaux lors de leur déplacement alétoire.
    /// </summary>
    public RandomMovingSystem()
    {
        foreach (GameObject go in _randomMovingGO)
        {
            onGOEnter(go);
        }

        _randomMovingGO.addEntryCallback(onGOEnter);
    }

    /// <summary>
    /// Ons the go enter.
    /// </summary>
    /// <param name="go">The go.</param>
    private void onGOEnter(GameObject go)
    {
        go.GetComponent<RandomTarget>().target = go.transform.position;
    }

    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Choisit aléaoirement la positions d'arrivé des oiseaux si l'ancienne position est atteinte ou si l'oiseau ne bouge plus.
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
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