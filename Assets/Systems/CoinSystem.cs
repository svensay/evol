using FYFY;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : FSystem
{
    /// <summary>
    /// The coin family
    /// Représente les piéces du joueur
    /// </summary>
    private Family _CoinFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Coin)));


    /// <summary>
    /// Function called each time when FYFY enter in the update block where this <see cref="T:FYFY.FSystem" /> is.
    /// Incrémente le nombre de piéce de "Coin.gain" tout les "Coin.gainTime"
    /// </summary>
    /// <param name="familiesUpdateCount">Number of times the families have been updated.</param>
    /// <remarks>
    /// Called only is this <see cref="T:FYFY.FSystem" /> is active.
    /// </remarks>
    protected override void onProcess(int familiesUpdateCount)
    {
        Coin c = _CoinFamily.First().GetComponent<Coin>();
        c.inc_Time += Time.deltaTime;
        if (c.inc_Time >= c.gainTime)
        {
            c.inc_Time = 0.0f;
            c.money = c.money + c.gain;
            _CoinFamily.First().GetComponent<Text>().text = c.money.ToString();
        }

    }
}