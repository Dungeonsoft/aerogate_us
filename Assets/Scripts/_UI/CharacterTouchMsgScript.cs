using UnityEngine;
using System.Collections;

public class CharacterTouchMsgScript : MonoBehaviour
{

    int touchMsg;

    CharacterMsgSndConScript characterMsgSndCon;

    void Awake()
    {
        characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();
    }

    public void CharacterTouchMsg()
    {
        touchMsg++;
        int activeOper = ValueDeliverScript.activeOper;

        switch (touchMsg)
        {

            case 1:
                characterMsgSndCon.Touch01(activeOper);
                break;
            case 2:
                characterMsgSndCon.Touch02(activeOper);
                break;
            case 3:
                characterMsgSndCon.Touch03(activeOper);
                break;
            case 4:
                characterMsgSndCon.Touch04(activeOper);
                break;
            case 5:
                characterMsgSndCon.Touch05(activeOper);
                break;
        }
        if (touchMsg == 5) touchMsg = 0;
    }
}
