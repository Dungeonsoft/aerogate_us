using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using MiniJSON;
using SimpleJSON;

public class PurchaseManager : MonoBehaviour {

    private string secretKey = "12345";
    public string wwwResult;
    public string UpdatePurchasedLogUrl = "http://leessoda.cafe24.com/US/update_purchaselog.php";
    public GameObject Goods01;
    public GameObject Goods02;
    public GameObject Goods03;
    public GameObject Goods04;
    public GameObject Goods05;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //GameObject.Find("LogText").GetComponent<TextMesh>().text = wwwResult;
	}
#if UNITY_ANDROID
    IEnumerator InitializeIAB()
    {
        yield return null;
        var key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA1o/JdLP5MWZkfgNB1lVmtw0IoTpRT37qiKsYGkNR/w8jFvQh43v9m6LFyacj6v5PomHDTsVFN/2zCfMW4iI9ev8ok6JKUVe0y9oroJpcR+ifUR2s+YthTog6WI+Ihk1CzQfHfh5jUZbbdiJNqcyKq0aH3La3hYwDqsN8bVpil1VwoNOkoz+FDn3ftPI7Wkw0cij5mqq9HyKqTHx5WXF6ubTeB/IVr3DYWbAXmiyRNDC5jrwPU81+jW+yOEudGCWIwQDlLatlzm6vnrA5HpD/mPdqsBP5YTavHw1Sy8BEiQurf0vw6A4ZfTve4NmhQgK80uklnXETIhVncj6nQbqDMQIDAQAB";
        GoogleIAB.init(key);
    }

    public IEnumerator Purchase20()
    {
        yield return StartCoroutine(InitializeIAB());
        GoogleIAB.purchaseProduct("com.joywinggames.maydayaos001");
    }
    public IEnumerator Purchase50()
    {
        yield return StartCoroutine(InitializeIAB());
        GoogleIAB.purchaseProduct("com.joywinggames.maydayaos002");
    }
    public IEnumerator Purchase100()
    {
        yield return StartCoroutine(InitializeIAB());
        GoogleIAB.purchaseProduct("com.joywinggames.maydayaos003");
    }
    public IEnumerator Purchase300()
    {
        yield return StartCoroutine(InitializeIAB());
        GoogleIAB.purchaseProduct("com.joywinggames.maydayaos004");
    }
    public IEnumerator Purchase1000()
    {
        yield return StartCoroutine(InitializeIAB());
        GoogleIAB.purchaseProduct("com.joywinggames.maydayaos005");
    }
#endif

    public IEnumerator SendPurchasedLog(string price, string purchasedData, string signature)
    {
        string hash = Md5Sum(secretKey).ToLower();
        string userUniNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        float ServerConnectionTimeout = 10.0f;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("Price", price);
        form.AddField("Detail_Data", purchasedData);
        form.AddField("Signature", signature);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdatePurchasedLogUrl, form);
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
            
            if (wwwResult == "PurchaseLogUpdateSuccess")
            {
                Debug.Log(wwwResult);
                //여기에 결제 이후 처리내역 기입.               
                if(price == "1.99")
                {
                    Goods01.GetComponent<StoreCoinGoodScript>().Purchase();
                    GoogleIAB.consumeProduct("com.joywinggames.maydayaos001");
                }
                if (price == "4.99")
                {
                    Goods02.GetComponent<StoreCoinGoodScript>().Purchase();
                    GoogleIAB.consumeProduct("com.joywinggames.maydayaos002");
                }
                if (price == "9.99")
                {
                    Goods03.GetComponent<StoreCoinGoodScript>().Purchase();
                    GoogleIAB.consumeProduct("com.joywinggames.maydayaos003");
                }
                if (price == "29.99")
                {
                    Goods04.GetComponent<StoreCoinGoodScript>().Purchase();
                    GoogleIAB.consumeProduct("com.joywinggames.maydayaos004");
                }
                if (price == "99.99")
                {
                    Goods05.GetComponent<StoreCoinGoodScript>().Purchase();
                    GoogleIAB.consumeProduct("com.joywinggames.maydayaos005");
                }
                
            }
            else
            {
                Debug.Log("PurchaseLogUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }

    }

    public IEnumerator SendPurchasedLog20(string purchasedData, string signature)
    {
        Debug.Log(purchasedData);
        Debug.Log(signature);
        string hash = Md5Sum(secretKey).ToLower();
        string price = "1.99";
        string userUniNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        float ServerConnectionTimeout = 10.0f;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("Price", price);
        form.AddField("Detail_Data", purchasedData);
        form.AddField("Signature", signature);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdatePurchasedLogUrl, form);
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

            if (wwwResult == "PurchaseLogUpdateSuccess")
            {
                Debug.Log(wwwResult);                
                Goods01.GetComponent<StoreCoinGoodScript>().Purchase();
                GoogleIAB.consumeProduct("com.joywinggames.maydayaos001");
            }
            else
            {
                Debug.Log("PurchaseLogUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }

    }

    public IEnumerator SendPurchasedLog50(string purchasedData, string signature)
    {
        string hash = Md5Sum(secretKey).ToLower();
        string price = "4.99";
        string userUniNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        float ServerConnectionTimeout = 10.0f;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("Price", price);
        form.AddField("Detail_Data", purchasedData);
        form.AddField("Signature", signature);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdatePurchasedLogUrl, form);
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

            if (wwwResult == "PurchaseLogUpdateSuccess")
            {
                Debug.Log(wwwResult);
                Goods02.GetComponent<StoreCoinGoodScript>().Purchase();
                GoogleIAB.consumeProduct("com.joywinggames.maydayaos002");
            }
            else
            {
                Debug.Log("PurchaseLogUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }
    }

    public IEnumerator SendPurchasedLog100(string purchasedData, string signature)
    {
        string hash = Md5Sum(secretKey).ToLower();
        string price = "9.99";
        string userUniNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        float ServerConnectionTimeout = 10.0f;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("Price", price);
        form.AddField("Detail_Data", purchasedData);
        form.AddField("Signature", signature);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdatePurchasedLogUrl, form);
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

            if (wwwResult == "PurchaseLogUpdateSuccess")
            {
                Debug.Log(wwwResult);
                Goods03.GetComponent<StoreCoinGoodScript>().Purchase();
                GoogleIAB.consumeProduct("com.joywinggames.maydayaos003");
            }
            else
            {
                Debug.Log("PurchaseLogUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }
    }

    public IEnumerator SendPurchasedLog300(string purchasedData, string signature)
    {
        string hash = Md5Sum(secretKey).ToLower();
        string price = "29.99";
        string userUniNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        float ServerConnectionTimeout = 10.0f;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("Price", price);
        form.AddField("Detail_Data", purchasedData);
        form.AddField("Signature", signature);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdatePurchasedLogUrl, form);
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

            if (wwwResult == "PurchaseLogUpdateSuccess")
            {
                Debug.Log(wwwResult);
                Goods04.GetComponent<StoreCoinGoodScript>().Purchase();
                GoogleIAB.consumeProduct("com.joywinggames.maydayaos004");
            }
            else
            {
                Debug.Log("PurchaseLogUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
        }
    }

    public IEnumerator SendPurchasedLog1000(string purchasedData, string signature)
    {
        string hash = Md5Sum(secretKey).ToLower();
        string price = "99.99";
        string userUniNumber = ValueDeliverScript.UserID;
        float tempTime = 0;
        float ServerConnectionTimeout = 10.0f;
        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("Price", price);
        form.AddField("Detail_Data", purchasedData);
        form.AddField("Signature", signature);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdatePurchasedLogUrl, form);
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

            if (wwwResult == "PurchaseLogUpdateSuccess")
            {
                Debug.Log(wwwResult);
                Goods05.GetComponent<StoreCoinGoodScript>().Purchase();
                GoogleIAB.consumeProduct("com.joywinggames.maydayaos005");
            }
            else
            {
                Debug.Log("PurchaseLogUpdate Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                Debug.Log(www.error);
            }
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
