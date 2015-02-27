using UnityEngine;
using System.Collections;

public class LoadingPanelScript : MonoBehaviour {

    //public Transform Icon01;
    //public Transform Icon02;
	

	// Update is called once per frame
    //void Update () {
    //    //Debug.Log("UP   UP   UP");
    //    Icon01.localEulerAngles += new Vector3(0, 0, Time.deltaTime * 30);
    //    Icon02.localEulerAngles -= new Vector3(0, 0, Time.deltaTime * 30);
    //}

    public UISprite charImg;
    public UISprite tipImg;
    public UILabel tipLabel;

    string[] tipLabelText;

    //public string[] ch01TipLabelText;
    //public string[] ch02TipLabelText;
    //public string[] ch03TipLabelText;
    //public string[] ch04TipLabelText;

    string[] ch01TipLabelText;
    string[] ch02TipLabelText;
    string[] ch03TipLabelText;
    string[] ch04TipLabelText;


    int tipRnd;
    int charNum;

    void Awake()
    {
        ch01TipLabelText = new string[]{
            "[Rank] If you press [Friend] button, you'll get to see your Rank or your mails.",//"点击[排名]好友按钮时，可以确认排名或邮件",
            "[Wormhole]'s made up of 7 different levels.",//"[虫洞]由7个等级构成",
            "[Seed] don't move, but shot bullets when Exploded.",//"[壁垒]的耐久性强，用核弹或技能来攻击会更加有效哦",
            "[Dart] totally rushes toward the aircraft fast. Always watch out!",//"[飞镖]会非常敏捷的飞向战机，可要时刻留意哦",
            "[Spinball] bounces off the wall to get to you, so, it's easily predictable.",//"[旋球]利用气垫在墙面上移动，是可以提前预测的",
            "[Dust] is so not durable, but attacks you in a bunch. You better watch out! ",//"[残骸]虽然耐久性弱，但会由大量来攻击需要留意哦",
            "In [Special Sortie] mode, Coin, pilot's XP, and aircraft's XP are additional.",//"[特殊出击]状态下，可另外获取硬币、驾驶经验值、战机经验值",
            "If you get a [Power-Up], the aircraft will be fortified to the max level of 3. ",//"获取[增强能量]时，战机最多可加强五个级别",
            "If you get a [Skill], some o' the skill gauge will be refilled.",//"获取[技能]时，可恢复一定能量哦",
            "If you press the [Skill Button], you'll shoot the special skill of each aircraft.",//"点击[技能按钮]时，可发射战机固有技能",
            "One sortie uses one Nuclear Bomb. Remember it!",//"要记住[核弹]每发射一次消耗一枚",
            "[Wormhole] levels up when it takes some damage right after its appearance.",//"[虫洞]出现后如果有一定受损，会更新到上一级",
            "[Angel's Box] drops powerful items when shot down or when some time's passed. Mark that!",//"[天使宝箱]出现后，会在射击或逃跑时降落强大的道具",
            "[Item: Friend] If you rescue kidnapped buddies, they will help you for 3 seconds.",//"[好友道具]救出被绑架的好友时，会持续3秒帮助你",
            "[Skin] gets stronger as it levels up. You better work hard on it!",//"[装甲]进阶时，功能会变得更强。要努力升级哦",
            "[Locked Aircraft] If conditions are met, you can buy aircrafts with Coin.",//"[战机加锁]满足条件时，可以用硬币购买战机",
            "Don't forget to fulfill accomplishments of each skin if you wanna get them!"//"要记住若要获取[装甲]，要达到满足各装甲的得分"
        };

        ch02TipLabelText = new string[]{
            "[Rank] If you press [Friend] button, you can check your Rank or your mails.",//"点击[排名]好友按钮时，可以确认排名或邮件",
            "[Wormhole] consists of 7 different levels; please remember.",//"[虫洞]由7个等级构成",
            "[Seed] don't move, but shot bullets when Exploded.",//"[壁垒]的耐久性强，用核弹或技能来攻击会更加有效",
            "[Dart] rushes toward the aircraft fast. Please watch out for it at all times.",//"[飞镖]会非常敏捷的飞向战机，要时刻留意",
            "[Spinball] approaches bouncing off the wall; sould be predictable enough.",//"[旋球]是利用气垫在墙面上移动，是可以提前预测的",
            "[Dust] is the least durable, but attacks you in large groups. Please keep your eyes open.",//"[残骸]虽然耐久性弱，但会由大量来攻击需要留意",
            "In [Special Sortie] mode, you can win Coin, pilot's XP, and aircraft's XP additionally.",//"[特殊出击按钮] 状态下，可另外获取硬币、驾驶经验值、战机经验值",
            "Acquiring [Power-Up] would reinforce the aircraft to the maximum level of 3.",//"[增强能量]时，战机最多可加强五个级别",
            "Acquiring [Skill] replenishes the skill gauge moderately; please remember.",//"获取[技能]时，可恢复一定能量",
            "Pressing the [Skill Button] discharges the special skill of each aircraft.",//"点击[技能按钮]时，可发射战机固有技能",
            "Each sortie consumes 1 [Nuclear Bomb], and it can be used every one minute.",//"[核弹]每发射一次消耗一枚",
            "[Wormhole] evolves to the upper class when damage's taken; please take advantage of it.",//"[虫洞]出现后如果有一定受损，会更新到上一级",
            "When [Angel's Box] gets shot down or runs away, it drops powerful items.",//"[天使宝箱]出现后，会在射击或逃跑时降落强大的道具",
            "[Item: Friend] When rescued, [Friend] will help you in return for 3 seconds.",//"[好友道具]救出被绑架的好友时，会持续3秒帮助你",
            "[Skin] gets stronger as its level moves up.",//"[装甲]的级别上升时，功能会加强",
            "[Locked Aircraft] If conditions are met, you can purchase aircrafts with Coin.",//"[战机加锁图像]满足条件时，可以用硬币购买战机",
            "You need to fulfill accomplishments of each skin to acquire it."//"要获取[装甲]，一定要满足各装甲的得分"
        };


        ch03TipLabelText = new string[]{
            "[Rank] Press [Friend] button, and check your Rank and mails.",//"点击[排名]好友(按键图标)，可查看排名或邮件。",
            "[Wormhole] has maximum level of 7",//"[冲动]由7个等级构成。",
            "[Seed] don't move, but shot bullets when Exploded.",//"[壁垒]的耐久性强，用核弹或技能来攻击较有效。",
            "[Dart] rushes toward the aircraft so fast. You'd better watch out for it at all times.",//"[飞镖]会非常敏捷的飞向战机，要时刻留意。",
            "[Spinball] approaches through bouncing off the wall; predict, and evade.",//"[旋球]是利用气垫在墙面上移动，因此可提前预测来提防。",
            "[Dust] is the least durable, but attacks you in large groups. Take caution.",//"[残骸]虽然耐久性弱，但会由大量来攻击需要留意。",
            "In [Special Sortie] mode, you can acquire Coin, pilot's XP, and aircraft's XP additionally.",//"[特殊出击]状态下，可另外获取硬币、驾驶经验值、战机经验值。",
            "Remember. Acquiring [Power-Up] can reinforce the aircraft to the maximum level of 3.",//"获取[增强能量]时，战机最多可加强五个级别。",
            "Acquiring [Skill] replenishes the skill gauge moderately.",//"获取[技能]时，可恢复一定能量。",
            "Pressing the [Skill Button] discharges the special skill of each aircraft.",//"点击[技能按钮]时，可发射战机固有技能。",
            "Remember. Each sortie consumes 1 [Nuclear Bomb].",//"[核弹]每发射一次消耗一枚。",
            "When some damage is dealt to the [Wormhole], it's strengthened.",//"[虫洞]出现后若马上就有一定受损，则会变得更加强大。",
            "When [Angel's Box] gets shot down or runs away, it drops powerful items.",//"[天使宝箱]出现后，会在射击或逃跑时降落强大的道具。",
            "[Item: Friend] When rescued, [Friend] will be your reinforcement for 3 seconds.",//"[好友道具]救出被绑架的好友时，会持续3秒成为强大的援军。",
            "[Skin] gets stronger as its level moves up.",//"[装甲]进阶时，技能会被强化。",
            "[Locked Aircraft] If conditions are met, aircrafts can be purchased with coin.",//"[战机加锁]满足条件时，可以用硬币购买战机。",
            "You need to fulfill accomplishments of each skin to acquire it."//"若要获取[装甲]，要达到满足各装甲的得分。"
        };

        ch04TipLabelText = new string[]{
            "[Rank] If you press [Friend] button, you can check your Rank or your mails.",//"点击[排名]好友按键时，可以确认排名或邮件。",
            "[Wormhole] consists of 7 different levels; please remember.",//"[虫洞]由7个等级构成。",
            "[Seed] don't move, but shot bullets when Exploded.",//"[壁垒]的耐久性强，用核弹或技能来攻击较有效。",
            "[Dart] rushes toward the aircraft fast. Please watch out for it at all times.",//"[飞镖]会非常敏捷的飞向战机，请时刻留意。",
            "[Spinball] approaches bouncing off the wall; sould be predictable enough.",//"[旋球]是利用气垫在墙面上移动，因此可提前预测来提防。",
            "[Dust] is the least durable, but attacks you in large groups. Please keep your eyes open.",//"[残骸]虽然耐久性弱，但会由大量来攻击请留意。",
            "In [Special Sortie] mode, you can win Coin, pilot's XP, and aircraft's XP additionally.",//"[特殊出击]状态下，可另外获取硬币、驾驶经验值、战机经验值。",
            "Acquiring [Power-Up] would reinforce the aircraft to the maximum level of 3.",//"获取[增强能量]时，战机最多可加强五个级别。",
            "Acquiring [Skill] replenishes the skill gauge moderately; please remember.",//"获取[技能]时，可恢复一定能量。",
            "Pressing the [Skill Button] discharges the special skill of each aircraft.",//"点击[技能按钮]时，可发射战机固有技能。",
            "Each sortie consumes 1 [Nuclear Bomb], and it can be used every one minute.",//"[核弹]每次发射一枚，以一分钟间隔使用。",
            "[Wormhole] evolves to the upper class when damage's taken; please take advantage of it.",//"[虫洞]出现后如果有一定受损会更新到上一级，要注意哦。",
            "When [Angel's Box] gets shot down or runs away, it drops powerful items.",//"[天使宝箱]出现后，会在射击或逃跑时降落强大的道具。",
            "[Item: Friend] When rescued, [Friend] will help you in return for 3 seconds.",//"[好友道具]救出被绑架的好友时，作为答谢会帮助你持续3秒钟。",
            "[Skin] gets stronger as its level moves up.",//"[装甲]的级别上升时，功能会变得更强。",
            "[Locked Aircraft] If conditions are met, you can purchase aircrafts with Coin.",//"[战机加锁]满足条件时，可以用硬币购买战机。",
            "You need to fulfill accomplishments of each skin to acquire it."//"若要获取[装甲]，要达到满足各装甲的得分。"
        };
    }

    void OnEnable()
    {
        if (ValueDeliverScript.isTutComplete != 2)
        {
            charNum = 4;
            tipLabelText = ch04TipLabelText;
        }
        else
        {
            int activeOper = ValueDeliverScript.activeOper;

            switch (activeOper)
            {
                case 1:
                    charNum = 1;
                    tipLabelText = ch01TipLabelText;
                    break;
                case 2:
                    charNum = 2;
                    tipLabelText = ch02TipLabelText;
                    break;
                case 3:
                    charNum = 3;
                    tipLabelText = ch03TipLabelText;
                    break;
                case 4:
                    charNum = 4;
                    tipLabelText = ch04TipLabelText;
                    break;
            }
        }

        tipRnd = Random.Range(0, tipLabelText.Length);  //랜덤으로 보여줄 게임팁을 선정.
        tipImg.spriteName = "Img_GameTip" + (tipRnd+1).ToString("00");  //게임팁이미지 장착.
        tipImg.MakePixelPerfect();
        tipLabel.text = tipLabelText[tipRnd];   //게임팁 텍스트 장착.

        charImg.spriteName = "Img_OperatorBig" + (charNum); //선택된 캐릭터 장착.
        charImg.MakePixelPerfect();
    }
}