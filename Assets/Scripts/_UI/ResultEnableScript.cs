using UnityEngine;
using System.Collections;

public class ResultEnableScript : MonoBehaviour {

    int addCoin;
    int addMedal;

    void OnEnable()
    {
        transform.FindChild("ResultPanelLeft/LevelBox/AddCoinLabel").GetComponent<UILabel>().text = ValueDeliverScript.coinPlay + addCoin + "";

        transform.FindChild("ResultPanelLeft/LevelBox/AddMedalLabel").GetComponent<UILabel>().text = ValueDeliverScript.medalPlay + addMedal+"";

        transform.FindChild("ResultPanelLeft/LevelBox/PilotLevel/UserLevelLabel").GetComponent<UILabel>().text = ValueDeliverScript.userLevel+"";

    }

    public void AddCoinFromLevelUp(int coin)
    {
        addCoin += coin;
    }

    public void AddMedalFromLevelUp(int medal)
    {
        addMedal += medal;
    }
}
