using UnityEngine;
using System.Collections;

public class ChinaAddLifeTest : MonoBehaviour {

    public UILabel TextLabel;

    void Awake()
    {
        ValueDeliverScript.fuelSize = 2;
    }
    void AddLife()
    {
        do
        {
            if (ValueDeliverScript.fuelSize < 50)
            {
                ValueDeliverScript.fuelSize += 1;

                TextLabel.text = "壁垒 +" + (ValueDeliverScript.fuelSize + 1);
            }
        } while (false);
    }
}
