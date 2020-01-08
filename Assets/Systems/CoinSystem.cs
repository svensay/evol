using FYFY;
using UnityEngine;

public class CoinSystem : FSystem
{

    private Family _CoinFamily = FamilyManager.getFamily(new AllOfComponents(typeof(Coin)));


    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        Coin go = _CoinFamily.First().GetComponent<Coin>();
        go.inc_Time += Time.deltaTime;
        if (go.inc_Time >= go.gainTime)
        {
            go.inc_Time = 0.0f;
            Coin c = go.GetComponent<Coin>();
            go.money = go.money + 2;
            c.value.text = go.money.ToString();
        }

    }
}