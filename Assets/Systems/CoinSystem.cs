using UnityEngine;
using FYFY;

public class CoinSystem : FSystem {

    private Family _CoinFamily= FamilyManager.getFamily(new AllOfComponents(typeof(Coin)));
    private float gainTime = 5.0f;
    private float inc_Time = 0.0f;
    
    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount) {
        inc_Time += Time.deltaTime;
        if(inc_Time >= gainTime)
        {
            inc_Time = 0.0f;
            foreach (GameObject go in _CoinFamily)
            {
                Coin c = go.GetComponent<Coin>();
                int get_value = int.Parse(c.value.text) + 2;
                c.value.text = get_value.ToString();
            }
        }

    }
}