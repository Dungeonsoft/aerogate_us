using UnityEngine;
using System.Collections;
//배행기 우상단에 발풍선으로 증가나 적용된 효과를 표시해줌.
public class SpeechBubbleScript : MonoBehaviour {

    string[] itemGetScript;

    GameObject characterMessageUI;

    CharacterSpeakManagerScript characterManagerScript;

	void Awake ()
    {
        characterMessageUI = GameObject.Find("CharacterMessageUI");
   }

    void Start()
    {
        characterManagerScript = GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>();
        //itemGetScript = ValueDeliverScript.characterSpeakScript[ValueDeliverScript.activeOper];
    }

	public void ToggleBombReady ()
	{
		if(Time.timeSinceLevelLoad >2)
		{
            characterManagerScript.CharacterMessageShow(4);
		}
	}

	public void TogglePowerUp ()
	{
		if(Time.timeSinceLevelLoad >2)
		{
            characterManagerScript.CharacterMessageShow(5);
		}
	}

	public void ToggleSkillReady ()
	{
		if(Time.timeSinceLevelLoad >2)
		{
            characterManagerScript.CharacterMessageShow(6);
		}
	}

	public void ToggleMaxPower ()
	{
		if(Time.timeSinceLevelLoad >2)
		{
            characterManagerScript.CharacterMessageShow(7);
		}
	}




    //void CharacterMessageShow(int scriptNum)
    //{
    //    characterMessageUI.animation.Play("CharSpeakLabelAnim01");
    //    characterMessageUI.transform.FindChild("Label").GetComponent<UILabel>().text = itemGetScript[scriptNum];
    //    if (scriptNum == 4 || scriptNum == 6)
    //    {
    //        int num = 0;
    //        if (scriptNum == 4) num = 8;
    //        else if (scriptNum == 6) num = 9;
    //        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(num);
    //    }
    //}
}
