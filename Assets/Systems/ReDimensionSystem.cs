using UnityEngine;
using FYFY;

public class ReDimensionSystem : FSystem {

    private Family _reDimension = FamilyManager.getFamily(new AllOfComponents(typeof(Dimension)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _reDimension)
        {
            RectTransform r = go.GetComponent<RectTransform>();
            Dimension d = go.GetComponent<Dimension>();
            r = d.rect;
        }
    }
}