using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security;
using MiniJSON;
using MyDelegateNS;

public class GetGameData : MonoBehaviour {

    private string secretKey = "12345";
    public string wwwResult;    
    public string GetResetTimeUrl = "http://leessoda.cafe24.com/US/gamedata/rankingtime.php";
   
    float ServerConnectionTimeout = 15.0f;

    void Start()
    {
        if (Application.internetReachability == 0)
        {
            Debug.Log("Internet Nonnection has been Lost!!!!!!!!!!!!!!!!!!!!!!!!!!");

        }
    }

    public IEnumerator GetRankResetTime()
    {
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("hash", hash);

        WWW www = new WWW(GetResetTimeUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }

        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.Log(www.error);
        }
        else
        {
            wwwResult = www.text;
            var resetTime = SimpleJSON.JSON.Parse(wwwResult);
            Debug.Log(wwwResult);
            ValueDeliverScript.fRankDefaultTime = resetTime[0];
            ValueDeliverScript.wRankDefaultTime = resetTime[1];
            ValueDeliverScript.fRankInterDay = int.Parse(resetTime[2]);
            ValueDeliverScript.wRankInterDay = int.Parse(resetTime[3]);

            Debug.Log("fRankDefaultTime ::::::::   " + ValueDeliverScript.fRankDefaultTime);
            Debug.Log("wRankDefaultTime ::::::::   " + ValueDeliverScript.wRankDefaultTime);
            Debug.Log("fRankInterDay ::::::::   " + ValueDeliverScript.fRankInterDay);
            Debug.Log("wRankInterDay ::::::::   " + ValueDeliverScript.wRankInterDay);
            
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
