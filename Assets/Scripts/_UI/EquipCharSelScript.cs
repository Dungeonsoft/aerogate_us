using UnityEngine;
using System.Collections;

public class EquipCharSelScript : MonoBehaviour {

    int isCharacterBuy;
    CharacterMsgSndConScript characterMsgSndCon;

    void Awake()
    {

        characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();

    }

    public void PlaySound()
    {
        //Debug.Log("PlaySound" + GetComponent<ItemKeyValueScript>().itemNumber);
        characterMsgSndCon.SelectStore(GetComponent<ItemKeyValueScript>().itemNumber);
    }
}
