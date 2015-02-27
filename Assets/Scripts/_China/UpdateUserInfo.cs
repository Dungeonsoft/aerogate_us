using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security;
using MiniJSON;
using SimpleJSON;
using MyDelegateNS;


public class UpdateUserInfo : MonoBehaviour
{

    private string secretKey = "12345";
    public string wwwResult;
    public string UpdateScoreUrl = "http://leessoda.cafe24.com/US/update_score.php";
    public string UpdateGameInfoUrl = "http://leessoda.cafe24.com/US/update_gameinfo.php";
    public string UpdateItemInfoUrl = "http://leessoda.cafe24.com/US/update_iteminfo.php";
    public string UpdateFlightInfoUrl = "http://leessoda.cafe24.com/US/update_flightinfo.php";
    public string UpdatePurchaseInfoUrl = "http://leessoda.cafe24.com/US/update_purchaseinfo.php";
    public string UpdateMailInfoUrl = "http://leessoda.cafe24.com/US/update_mailinfo.php";
    public string UpdateGiftInfoUrl = "http://leessoda.cafe24.com/US/update_giftinfo.php";
    public string GetMailInfoUrl = "http://leessoda.cafe24.com/US/get_mailinfo.php";
    public string GetMailInfoFbid = "http://leessoda.cafe24.com/US/get_mailinfofbid.php";
    float ServerConnectionTimeout = 10.0f;
    public string userUniNumber;

    void Start()
    {
        //StartCoroutine(UpdateSendMailInfo());
    }

    public void UpdateScorevoid()
    {
        StartCoroutine(UpdateScore());
    }


    public void UpdateUserData1(NextFunc nextF = null)
    {
        StartCoroutine(UpdateUserData2(nextF));
    }

    IEnumerator UpdateUserData2(NextFunc nextF = null)
    {
        Debug.Log("UpdateUserData2");
        Debug.Log("ValueDeliverScript.scoreHigh :: " + ValueDeliverScript.scoreHigh);
        Debug.Log("ValueDeliverScript.scorePlay :: " + ValueDeliverScript.scorePlay);
        
        //하이스코어 관련 업뎃은 한번만 따로 하니 여기서 수시로 없뎃을 할 이유가 없음// 
        //yield return StartCoroutine(UpdateScore());
        //하이스코어 관련 업뎃은 한번만 따로 하니 여기서 수시로 없뎃을 할 이유가 없음// 

        yield return StartCoroutine(UpdateGameinfo());
        yield return StartCoroutine(UpdateIteminfo());
        yield return StartCoroutine(UpdateFlightInfo());
        if (nextF != null) nextF();
    }


    IEnumerator UpdateScore()
    {
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", ValueDeliverScript.UserID);
        form.AddField("TWeekScore", ValueDeliverScript.scoreHigh);
        form.AddField("LWeekScore", ValueDeliverScript.lastScoreHigh);
        form.AddField("Flight", ValueDeliverScript.highFlight);
        Debug.Log("High Flight ::::::::   " + ValueDeliverScript.highFlight);
        Debug.Log("High Flight ::::::::   " + ValueDeliverScript.highFlight);
        form.AddField("Skin", ValueDeliverScript.highSkin);
        Debug.Log("High Skin ::::::::   " + ValueDeliverScript.highSkin);
        Debug.Log("High Skin ::::::::   " + ValueDeliverScript.highSkin);
        form.AddField("Bullet", ValueDeliverScript.highBullet);
        Debug.Log("High Bullet ::::::::   " + ValueDeliverScript.highBullet);
        Debug.Log("High Bullet ::::::::   " + ValueDeliverScript.highBullet);
        form.AddField("Bomb", ValueDeliverScript.highBomb);
        Debug.Log("High Bomb ::::::::   " + ValueDeliverScript.highBomb);
        Debug.Log("High Bomb ::::::::   " + ValueDeliverScript.highBomb);
        form.AddField("Rein", ValueDeliverScript.highReinforce);
        Debug.Log("High Reinforce ::::::::   " + ValueDeliverScript.highReinforce);
        Debug.Log("High Reinforce ::::::::   " + ValueDeliverScript.highReinforce);
        form.AddField("Assist", ValueDeliverScript.highAssist);
        Debug.Log("High Assist ::::::::   " + ValueDeliverScript.highAssist);
        Debug.Log("High Assist ::::::::   " + ValueDeliverScript.highAssist);
        form.AddField("Supporter", ValueDeliverScript.highChar);
        Debug.Log("High Supporter ::::::::   " + ValueDeliverScript.highChar);
        Debug.Log("High Supporter ::::::::   " + ValueDeliverScript.highChar);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdateScoreUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "ScoreUpdateSuccess")
            {
                Debug.Log(wwwResult);
            }
            else
            {
                Debug.Log("Score Update Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }
    }



    IEnumerator UpdateGameinfo()
    {
        Debug.Log("저장기능 활성화!!!!");

        string hash = Md5Sum(secretKey).ToLower();
        string userUniNumber = ValueDeliverScript.UserID;//여기에 유저아이디 입력.
        float tempTime = 0;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("Gas", ValueDeliverScript.gasRest);
        form.AddField("LastTime", ValueDeliverScript.gasLastAddTime);
        Debug.Log("LastTime is ::::::::::::" + ValueDeliverScript.gasLastAddTime);
        form.AddField("NextTime", ValueDeliverScript.gasNextAddTime);
        Debug.Log("NextTime is ::::::::::::" + ValueDeliverScript.gasNextAddTime);
        form.AddField("Coin", ValueDeliverScript.coinRest);
        form.AddField("Medal", ValueDeliverScript.medalRest);
        form.AddField("Exp", ValueDeliverScript.userExp);
        form.AddField("FSPoint", ValueDeliverScript.buddyPoint);
        form.AddField("UpPoint", ValueDeliverScript.upgradePoint);
        form.AddField("PointReset", ValueDeliverScript.pointResetCount);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdateGameInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "GameInfoUpdateSuccess")
            {
                Debug.Log(wwwResult);
            }
            else
            {
                Debug.Log("Score Update Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }
    }

    IEnumerator UpdateIteminfo()
    {
        string hash = Md5Sum(secretKey).ToLower();
        string userUniNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        /* 여기에 Bomb 정보를 삽입*/
        Dictionary<string, object> Bombdic = new Dictionary<string, object>();
        Bombdic.Add("Plasma", ValueDeliverScript.EquipBomb01);
        Bombdic.Add("FireStorm", "0");
        Bombdic.Add("Cyclone", "0");
        Bombdic.Add("IceShield", "0");
        Bombdic.Add("TimeSleep", "0");
        Bombdic.Add("Blackhole", ValueDeliverScript.EquipBomb05);
        string bomb = MiniJSON.Json.Serialize(Bombdic);
        form.AddField("Bomb", bomb);
        /* 여기에 Bomb 정보를 삽입*/

        /* 여기에 Rein 정보를 삽입*/
        Dictionary<string, object> Reindic = new Dictionary<string, object>();
        Reindic.Add("SingleUp", ValueDeliverScript.EquipReinforce01);
        Reindic.Add("DoubleUp", ValueDeliverScript.EquipReinforce02);
        Reindic.Add("SkinballUp", ValueDeliverScript.EquipReinforce03);
        Reindic.Add("DartUp", ValueDeliverScript.EquipReinforce04);
        Reindic.Add("ShieldUp", ValueDeliverScript.EquipReinforce05);
        Reindic.Add("DustUp", ValueDeliverScript.EquipReinforce06);
        Reindic.Add("Critical", ValueDeliverScript.EquipReinforce07);
        Reindic.Add("MaxPower", ValueDeliverScript.EquipReinforce08);
        string rein = MiniJSON.Json.Serialize(Reindic);
        form.AddField("Rein", rein);
        /* 여기에 Rein 정보를 삽입*/

        /* 여기에 Assist 정보를 삽입*/
        Dictionary<string, object> Assistdic = new Dictionary<string, object>();
        Assistdic.Add("Shield", ValueDeliverScript.EquipAssist01);
        Assistdic.Add("Magnet", ValueDeliverScript.EquipAssist02);
        Assistdic.Add("BombCool", ValueDeliverScript.EquipAssist03);
        Assistdic.Add("SkillCool", ValueDeliverScript.EquipAssist04);
        Assistdic.Add("WingBox", ValueDeliverScript.EquipAssist05);
        string assist = MiniJSON.Json.Serialize(Assistdic);
        form.AddField("Assist", assist);
        /* 여기에 Assist 정보를 삽입*/

        /* 여기에 Support 정보를 삽입*/
        Dictionary<string, object> Supportdic = new Dictionary<string, object>();
        Supportdic.Add("Yoon", ValueDeliverScript.EquipOper01);
        Supportdic.Add("Aidan", ValueDeliverScript.EquipOper02);
        Supportdic.Add("Dan", ValueDeliverScript.EquipOper03);
        Supportdic.Add("Rechel", ValueDeliverScript.EquipOper04);
        string support = MiniJSON.Json.Serialize(Supportdic);
        form.AddField("Support", support);
        /* 여기에 Support 정보를 삽입*/

        form.AddField("hash", hash);

        WWW www = new WWW(UpdateItemInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "ItemInfoUpdateSuccess")
            {
                Debug.Log(wwwResult);
            }
            else
            {
                Debug.Log("Score Update Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }
    }

    IEnumerator UpdateFlightInfo()
    {
        string hash = Md5Sum(secretKey).ToLower();
        string userUniNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        /* 여기에 Lock 정보를 삽입*/
        Dictionary<string, object> Lockdic = new Dictionary<string, object>();
        Lockdic.Add("AircraftSelect", "0");
        Lockdic.Add("FokkerLock", ValueDeliverScript.FlightLockOff000);
        Lockdic.Add("ComancheLock", ValueDeliverScript.FlightLockOff001);
        Lockdic.Add("PhantomLock", ValueDeliverScript.FlightLockOff002);
        string Lock = MiniJSON.Json.Serialize(Lockdic);
        form.AddField("Lock", Lock);
        /* 여기에 Lock 정보를 삽입*/

        /* 여기에 SkinLock 정보를 삽입*/
        Dictionary<string, object> SkinLockdic = new Dictionary<string, object>();
        SkinLockdic.Add("Fokker001", ValueDeliverScript.FlightLock000Skin001);
        SkinLockdic.Add("Fokker002", ValueDeliverScript.FlightLock000Skin002);
        SkinLockdic.Add("Fokker003", ValueDeliverScript.FlightLock000Skin003);
        SkinLockdic.Add("Fokker004", ValueDeliverScript.FlightLock000Skin004);
        SkinLockdic.Add("Fokker005", ValueDeliverScript.FlightLock000Skin005);
        SkinLockdic.Add("Comanche001", ValueDeliverScript.FlightLock001Skin001);
        SkinLockdic.Add("Comanche002", ValueDeliverScript.FlightLock001Skin002);
        SkinLockdic.Add("Comanche003", ValueDeliverScript.FlightLock001Skin003);
        SkinLockdic.Add("Comanche004", ValueDeliverScript.FlightLock001Skin004);
        SkinLockdic.Add("Comanche005", ValueDeliverScript.FlightLock001Skin005);
        SkinLockdic.Add("Phantom001", ValueDeliverScript.FlightLock002Skin001);
        SkinLockdic.Add("Phantom002", ValueDeliverScript.FlightLock002Skin002);
        SkinLockdic.Add("Phantom003", ValueDeliverScript.FlightLock002Skin003);
        SkinLockdic.Add("Phantom004", ValueDeliverScript.FlightLock002Skin004);
        SkinLockdic.Add("Phantom005", ValueDeliverScript.FlightLock002Skin005);
        string skinLock = MiniJSON.Json.Serialize(SkinLockdic);
        form.AddField("SkinLock", skinLock);
        /* 여기에 SkinLock 정보를 삽입*/

        /* 여기에 Upgrade 정보를 삽입*/
        Dictionary<string, object> Upgradedic = new Dictionary<string, object>();
        Upgradedic.Add("Fokker_PW", ValueDeliverScript.upgradePointF00P01);
        Upgradedic.Add("Fokker_AS", ValueDeliverScript.upgradePointF00P02);
        Upgradedic.Add("Fokker_MS", ValueDeliverScript.upgradePointF00P03);
        Upgradedic.Add("Fokker_SK", ValueDeliverScript.upgradePointF00P04);
        Upgradedic.Add("Comanche_PW", ValueDeliverScript.upgradePointF01P01);
        Upgradedic.Add("Comanche_AS", ValueDeliverScript.upgradePointF01P02);
        Upgradedic.Add("Comanche_MS", ValueDeliverScript.upgradePointF01P03);
        Upgradedic.Add("Comanche_SK", ValueDeliverScript.upgradePointF01P04);
        Upgradedic.Add("Phantom_PW", ValueDeliverScript.upgradePointF02P01);
        Upgradedic.Add("Phantom_AS", ValueDeliverScript.upgradePointF02P02);
        Upgradedic.Add("Phantom_MS", ValueDeliverScript.upgradePointF02P03);
        Upgradedic.Add("Phantom_SK", ValueDeliverScript.upgradePointF02P04);
        string upgrade = MiniJSON.Json.Serialize(Upgradedic);
        form.AddField("Upgrade", upgrade);
        /* 여기에 Upgrade 정보를 삽입*/

        /* 여기에 Support 정보를 삽입*/
        Dictionary<string, object> Detaildic = new Dictionary<string, object>();
        Detaildic.Add("Fokker_BulletLv", ValueDeliverScript.flight000Bullet);
        Detaildic.Add("Fokker_SkillLv", ValueDeliverScript.flight000Skill);
        Detaildic.Add("Fokker_Skin", ValueDeliverScript.flight000Skin);
        Detaildic.Add("Fokker_DuraA", ValueDeliverScript.FlightDura000Skin001);
        Detaildic.Add("Fokker_ExpA", ValueDeliverScript.FlightExp000Skin001);
        Detaildic.Add("Fokker_DuraB", ValueDeliverScript.FlightDura000Skin002);
        Detaildic.Add("Fokker_ExpB", ValueDeliverScript.FlightExp000Skin002);
        Detaildic.Add("Fokker_DuraC", ValueDeliverScript.FlightDura000Skin003);
        Detaildic.Add("Fokker_ExpC", ValueDeliverScript.FlightExp000Skin003);
        Detaildic.Add("Fokker_DuraD", ValueDeliverScript.FlightDura000Skin004);
        Detaildic.Add("Fokker_ExpD", ValueDeliverScript.FlightExp000Skin004);
        Detaildic.Add("Fokker_DuraE", ValueDeliverScript.FlightDura000Skin005);
        Detaildic.Add("Fokker_ExpE", ValueDeliverScript.FlightExp000Skin005);
        Detaildic.Add("Comanche_BulletLv", ValueDeliverScript.flight001Bullet);
        Detaildic.Add("Comanche_SkillLv", ValueDeliverScript.flight001Skill);
        Detaildic.Add("Comanche_Skin", ValueDeliverScript.flight001Skin);
        Detaildic.Add("Comanche_DuraA", ValueDeliverScript.FlightDura001Skin001);
        Detaildic.Add("Comanche_ExpA", ValueDeliverScript.FlightExp001Skin001);
        Detaildic.Add("Comanche_DuraB", ValueDeliverScript.FlightDura001Skin002);
        Detaildic.Add("Comanche_ExpB", ValueDeliverScript.FlightExp001Skin002);
        Detaildic.Add("Comanche_DuraC", ValueDeliverScript.FlightDura001Skin003);
        Detaildic.Add("Comanche_ExpC", ValueDeliverScript.FlightExp001Skin003);
        Detaildic.Add("Comanche_DuraD", ValueDeliverScript.FlightDura001Skin004);
        Detaildic.Add("Comanche_ExpD", ValueDeliverScript.FlightExp001Skin004);
        Detaildic.Add("Comanche_DuraE", ValueDeliverScript.FlightDura001Skin005);
        Detaildic.Add("Comanche_ExpE", ValueDeliverScript.FlightExp001Skin005);
        Detaildic.Add("Phantom_BulletLv", ValueDeliverScript.flight001Bullet);
        Detaildic.Add("Phantom_SkillLv", ValueDeliverScript.flight002Skill);
        Detaildic.Add("Phantom_Skin", ValueDeliverScript.flight002Skin);
        Detaildic.Add("Phantom_DuraA", ValueDeliverScript.FlightDura002Skin001);
        Detaildic.Add("Phantom_ExpA", ValueDeliverScript.FlightExp002Skin001);
        Detaildic.Add("Phantom_DuraB", ValueDeliverScript.FlightDura002Skin002);
        Detaildic.Add("Phantom_ExpB", ValueDeliverScript.FlightExp002Skin002);
        Detaildic.Add("Phantom_DuraC", ValueDeliverScript.FlightDura002Skin003);
        Detaildic.Add("Phantom_ExpC", ValueDeliverScript.FlightExp002Skin003);
        Detaildic.Add("Phantom_DuraD", ValueDeliverScript.FlightDura002Skin004);
        Detaildic.Add("Phantom_ExpD", ValueDeliverScript.FlightExp002Skin004);
        Detaildic.Add("Phantom_DuraE", ValueDeliverScript.FlightDura002Skin005);
        Detaildic.Add("Phantom_ExpE", ValueDeliverScript.FlightExp002Skin005);
        string detail = MiniJSON.Json.Serialize(Detaildic);
        form.AddField("Detail", detail);
        /* 여기에 Support 정보를 삽입*/

        form.AddField("hash", hash);

        WWW www = new WWW(UpdateFlightInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "FlightInfoUpdateSuccess")
            {
                Debug.Log(wwwResult);
            }
            else
            {
                Debug.Log("FlightInfoUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }
    }


    public IEnumerator UpdateMailInfo(MyDelegateNS.NextFunc nextF)
    {
        //yield return StartCoroutine(GetMailInfoBefoeSend());
        string hash = Md5Sum(secretKey).ToLower();
        string userNumber = ValueDeliverScript.myFBid;
        float tempTime = 0;
        WWWForm form = new WWWForm();

        string[] mailData = new string[ValueDeliverScript.messageData.Length];
        string sendMail = "";
        if (ValueDeliverScript.messageData.Length > 0)
        {
            for (int i = 0; i < ValueDeliverScript.messageData.Length; i++)
            {
                Dictionary<string, object> MailDic = new Dictionary<string, object>();

                if (ValueDeliverScript.messageData[i].To == null)
                {
                    ValueDeliverScript.messageData[i].To = "0";
                }
                if (ValueDeliverScript.messageData[i].From == null)
                {
                    ValueDeliverScript.messageData[i].From = "0";
                }
                if (ValueDeliverScript.messageData[i].Type == null)
                {
                    ValueDeliverScript.messageData[i].Type = "0";
                }
                if (ValueDeliverScript.messageData[i].Ea == null)
                {
                    ValueDeliverScript.messageData[i].Ea = "0";
                }
                if (ValueDeliverScript.messageData[i].Time == null)
                {
                    ValueDeliverScript.messageData[i].Time = "0";
                }
                if (ValueDeliverScript.messageData[i].Contents == null)
                {
                    ValueDeliverScript.messageData[i].Contents = "0";
                }
                MailDic.Add("To", ValueDeliverScript.messageData[i].To);
                MailDic.Add("From", ValueDeliverScript.messageData[i].From);
                MailDic.Add("Type", ValueDeliverScript.messageData[i].Type);
                MailDic.Add("Ea", ValueDeliverScript.messageData[i].Ea);
                MailDic.Add("Time", ValueDeliverScript.messageData[i].Time);
                MailDic.Add("Contents", ValueDeliverScript.messageData[i].Contents);
                mailData[i] = MiniJSON.Json.Serialize(MailDic);

                sendMail = sendMail + ',' + mailData[i];

                Debug.Log(mailData[i]);
                Debug.Log(sendMail);

            }
            char[] myChar = { ',', '@' };
            string trimsendMail = sendMail.TrimStart(myChar);

            form.AddField("Unique_number", userNumber);
            form.AddField("Send_Mail", trimsendMail);
            form.AddField("hash", hash);

            WWW www = new WWW(UpdateMailInfoUrl, form);
            yield return www;

            while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
            {
                tempTime += Time.deltaTime;
                yield return 0;
            }
            if (www.error != null || tempTime >= ServerConnectionTimeout)
            {
                //타임아웃처리
                Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            else
            {
                wwwResult = www.text;

                if (wwwResult == "MailInfoUpdateSuccess")
                {
                    Debug.Log(wwwResult);
                    Debug.Log(www.error);
                    //코루틴이 문제없이 끝났을 경우 실행하는 메소드.딜리게이트를 이용하여 실행함//
                    nextF();
                }
                else
                {
                    Debug.Log("MailInfoUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Debug.Log(wwwResult);
                    Debug.Log(www.error);
                }
            }
        }
        else
        {
            Debug.Log("Message is Null");
            form.AddField("Unique_number", userNumber);
            form.AddField("Send_Mail", "");
            form.AddField("hash", hash);

            WWW www = new WWW(UpdateMailInfoUrl, form);
            yield return www;

            while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
            {
                tempTime += Time.deltaTime;
                yield return 0;
            }
            if (www.error != null || tempTime >= ServerConnectionTimeout)
            {
                //타임아웃처리
                Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            else
            {
                wwwResult = www.text;

                if (wwwResult == "MailInfoUpdateSuccess")
                {
                    Debug.Log(wwwResult);
                    Debug.Log(www.error);
                    //코루틴이 문제없이 끝났을 경우 실행하는 메소드.딜리게이트를 이용하여 실행함//
                    nextF();
                }
                else
                {
                    Debug.Log("MailInfoUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Debug.Log(wwwResult);
                    Debug.Log(www.error);
                }
            }
        }
    }


    public IEnumerator UpdateSendMailInfo(string targetNumber, MyDelegateNS.NextFunc nextF)
    {
        yield return StartCoroutine(GetMailInfoBefoeSend2(targetNumber));

        string hash = Md5Sum(secretKey).ToLower();
        //string targetNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        WWWForm form = new WWWForm();

        string[] mailData = new string[ValueDeliverScript.messageData.Length];
        string sendMail = "";
        if (ValueDeliverScript.messageData.Length > 0)
        {
            for (int i = 0; i < ValueDeliverScript.messageData.Length; i++)
            {
                Dictionary<string, object> MailDic = new Dictionary<string, object>();
                if (ValueDeliverScript.messageData[i].To == null)
                {
                    ValueDeliverScript.messageData[i].To = "0";
                }
                if (ValueDeliverScript.messageData[i].From == null)
                {
                    ValueDeliverScript.messageData[i].From = "0";
                }
                if (ValueDeliverScript.messageData[i].Type == null)
                {
                    ValueDeliverScript.messageData[i].Type = "0";
                }
                if (ValueDeliverScript.messageData[i].Ea == null)
                {
                    ValueDeliverScript.messageData[i].Ea = "0";
                }
                if (ValueDeliverScript.messageData[i].Time == null)
                {
                    ValueDeliverScript.messageData[i].Time = "0";
                }
                if (ValueDeliverScript.messageData[i].Contents == null)
                {
                    ValueDeliverScript.messageData[i].Contents = "0";
                }
                MailDic.Add("To", ValueDeliverScript.messageData[i].To);
                MailDic.Add("From", ValueDeliverScript.messageData[i].From);
                MailDic.Add("Type", ValueDeliverScript.messageData[i].Type);
                MailDic.Add("Ea", ValueDeliverScript.messageData[i].Ea);
                MailDic.Add("Time", ValueDeliverScript.messageData[i].Time);
                MailDic.Add("Contents", ValueDeliverScript.messageData[i].Contents);
                mailData[i] = MiniJSON.Json.Serialize(MailDic);

                sendMail = sendMail + ',' + mailData[i];

                Debug.Log(mailData[i]);
                Debug.Log(sendMail);

            }
        }
        char[] myChar = { ',', '@' };
        string trimsendMail = sendMail.TrimStart(myChar);
        string sendData;

        Dictionary<string, object> SendMailDic = new Dictionary<string, object>();

        SendMailDic.Add("To", targetNumber);
        SendMailDic.Add("From", ValueDeliverScript.myFBid);
        SendMailDic.Add("Type", "1");
        SendMailDic.Add("Ea", "1");
        SendMailDic.Add("Time", DateTime.UtcNow.ToBinary().ToString());
        SendMailDic.Add("Contents", "1");
        sendData = MiniJSON.Json.Serialize(SendMailDic);

        if (ValueDeliverScript.messageData.Length == 0)
        {
            sendMail = sendData;
        }
        else
        {
            sendMail = trimsendMail + ',' + sendData;
        }

        Debug.Log(sendMail);
        form.AddField("Unique_number", targetNumber);
        form.AddField("Send_Mail", sendMail);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdateMailInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "MailInfoUpdateSuccess")
            {
                Debug.Log(wwwResult);
                Debug.Log(www.error);

                //코루틴이 다 끝나고 실행될 메소드//딜리게이트로 작성됨//
                nextF();
            }
            else
            {
                Debug.Log("MailInfoUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }

    }

    public IEnumerator UpdateGiftInfo(MyDelegateNS.NextFunc nextF = null)
    {
        string hash = Md5Sum(secretKey).ToLower();
        string userNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userNumber);
        form.AddField("Gift_Time", ValueDeliverScript.myRewardTime);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdateGiftInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.Log(www.error);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "GiftInfoUpdateSuccess")
            {
                Debug.Log(wwwResult);
                Debug.Log(www.error);
                //코루틴이 문제없이 끝났을 경우 실행하는 메소드.딜리게이트를 이용하여 실행함//
                if (nextF != null) nextF();
            }
            else
            {
                Debug.Log("MailInfoUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }
    }

    public IEnumerator GetMailInfoBefoeSend(MyDelegateNS.NextFunc nextF = null)
    {
        userUniNumber = ValueDeliverScript.UserID;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetMailInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
            var mailInfo = SimpleJSON.JSON.Parse(wwwResult);
            ValueDeliverScript.messageData = new MessageDataS[mailInfo["MailInfo"].Count];
            Debug.Log("Mail Info Count " + mailInfo["MailInfo"].Count);
            int count = 0;

            if (ValueDeliverScript.messageData.Length > 0)
            {
                while (count < mailInfo["MailInfo"].Count)
                {
                    ValueDeliverScript.messageData[count].To = mailInfo["MailInfo"][count]["To"];
                    ValueDeliverScript.messageData[count].From = mailInfo["MailInfo"][count]["From"];
                    ValueDeliverScript.messageData[count].Type = mailInfo["MailInfo"][count]["Type"];
                    ValueDeliverScript.messageData[count].Ea = mailInfo["MailInfo"][count]["Ea"];
                    ValueDeliverScript.messageData[count].Time = mailInfo["MailInfo"][count]["Time"];
                    ValueDeliverScript.messageData[count].Contents = mailInfo["MailInfo"][count]["Contents"];

                    Debug.Log("MailInfo " + count + " To ===> " + ValueDeliverScript.messageData[count].To);
                    Debug.Log("MailInfo " + count + " From ===> " + ValueDeliverScript.messageData[count].From);
                    Debug.Log("MailInfo " + count + " Type ===> " + ValueDeliverScript.messageData[count].Type);
                    Debug.Log("MailInfo " + count + " Ea ===> " + ValueDeliverScript.messageData[count].Ea);
                    Debug.Log("MailInfo " + count + " Time ===> " + ValueDeliverScript.messageData[count].Time);
                    Debug.Log("MailInfo " + count + " Contents ===> " + ValueDeliverScript.messageData[count].Contents);
                    count++;
                }
            }
            else
            {
                Debug.Log("Message is Null");
            }
            if (nextF != null) nextF();
        }
    }


    public IEnumerator GetMailInfoBefoeSend2(string targetNumber, MyDelegateNS.NextFunc nextF = null)
    {
        Debug.Log("Tartget Number is      " + targetNumber);
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", targetNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetMailInfoFbid, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
            var mailInfo = SimpleJSON.JSON.Parse(wwwResult);
            ValueDeliverScript.messageData = new MessageDataS[mailInfo["MailInfo"].Count];
            Debug.Log("Mail Info Count " + mailInfo["MailInfo"].Count);
            int count = 0;

            if (ValueDeliverScript.messageData.Length > 0)
            {
                while (count < mailInfo["MailInfo"].Count)
                {
                    ValueDeliverScript.messageData[count].To = mailInfo["MailInfo"][count]["To"];
                    ValueDeliverScript.messageData[count].From = mailInfo["MailInfo"][count]["From"];
                    ValueDeliverScript.messageData[count].Type = mailInfo["MailInfo"][count]["Type"];
                    ValueDeliverScript.messageData[count].Ea = mailInfo["MailInfo"][count]["Ea"];
                    ValueDeliverScript.messageData[count].Time = mailInfo["MailInfo"][count]["Time"];
                    ValueDeliverScript.messageData[count].Contents = mailInfo["MailInfo"][count]["Contents"];

                    Debug.Log("MailInfo " + count + " To ===> " + ValueDeliverScript.messageData[count].To);
                    Debug.Log("MailInfo " + count + " From ===> " + ValueDeliverScript.messageData[count].From);
                    Debug.Log("MailInfo " + count + " Type ===> " + ValueDeliverScript.messageData[count].Type);
                    Debug.Log("MailInfo " + count + " Ea ===> " + ValueDeliverScript.messageData[count].Ea);
                    Debug.Log("MailInfo " + count + " Time ===> " + ValueDeliverScript.messageData[count].Time);
                    Debug.Log("MailInfo " + count + " Contents ===> " + ValueDeliverScript.messageData[count].Contents);
                    count++;
                }
            }
            else
            {
                Debug.Log("Message is Null");
            }
            if (nextF != null) nextF();
        }
    }

    public string Md5Sum(string strToEncrypt)
    {

        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }
        return hashString.PadLeft(32, '0');
    }
}
