using FYFY;
using UnityEngine;

public class CoinSystem : FSystem
{

    private Family _CoinFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Coin)));


    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        Coin c = _CoinFamily.First().GetComponent<Coin>();
        c.inc_Time += Time.deltaTime;
        if (c.inc_Time >= c.gainTime)
        {
            c.inc_Time = 0.0f;
            c.money = c.money + c.gain;
            c.value.text = c.money.ToString();
        }

    }
}