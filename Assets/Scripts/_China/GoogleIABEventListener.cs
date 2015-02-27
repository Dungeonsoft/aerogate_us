using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class GoogleIABEventListener : MonoBehaviour
{

    public GameObject Manager;
    public string purchasedData;
    public string purchasedSiganture;
#if UNITY_ANDROID
	void OnEnable()
	{
		// Listen to all events for illustration purposes
		GoogleIABManager.billingSupportedEvent += billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent += billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent += purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent += purchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
	}


	void OnDisable()
	{
		// Remove all event handlers
		GoogleIABManager.billingSupportedEvent -= billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent -= billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent -= purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent -= purchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
	}



	void billingSupportedEvent()
	{
		Debug.Log( "billingSupportedEvent" );
        var skus = new string[] { "com.joywinggames.maydayaos001", "com.joywinggames.maydayaos002", "com.joywinggames.maydayaos003", "com.joywinggames.maydayaos004", "com.joywinggames.maydayaos005" };

        GoogleIAB.queryInventory(skus);

	}


	void billingNotSupportedEvent( string error )
	{
		Debug.Log( "billingNotSupportedEvent: " + error );
	}


	void queryInventorySucceededEvent( List<GooglePurchase> purchases, List<GoogleSkuInfo> skus )
	{
		Debug.Log( string.Format( "queryInventorySucceededEvent. total purchases: {0}, total skus: {1}", purchases.Count, skus.Count ) );
		
        if (purchases.Count > 0)
        {
            for (int i = 0; i < purchases.Count; i++)
            {
                GoogleIAB.consumeProduct(purchases[i].productId);
            }
        }
        
        Prime31.Utils.logObject( purchases );
		Prime31.Utils.logObject( skus );
	}


	void queryInventoryFailedEvent( string error )
	{
		Debug.Log( "queryInventoryFailedEvent: " + error );
	}


	void purchaseCompleteAwaitingVerificationEvent( string purchaseData, string signature )
	{
		Debug.Log( "purchaseCompleteAwaitingVerificationEvent. purchaseData: " + purchaseData + ", signature: " + signature );
        purchasedData = purchaseData;
        purchasedSiganture = signature;
	}


	void purchaseSucceededEvent( GooglePurchase purchase )
	{
		Debug.Log( "purchaseSucceededEvent: " + purchase );
        
        if (purchase.productId == "com.joywinggames.maydayaos001")        {

            StartCoroutine(Manager.GetComponent<PurchaseManager>().SendPurchasedLog20(purchasedData, purchasedSiganture));
        }
        if (purchase.productId == "com.joywinggames.maydayaos002")
        {
            StartCoroutine(Manager.GetComponent<PurchaseManager>().SendPurchasedLog50(purchasedData, purchasedSiganture));
        }
        if (purchase.productId == "com.joywinggames.maydayaos003")
        {
            StartCoroutine(Manager.GetComponent<PurchaseManager>().SendPurchasedLog100(purchasedData, purchasedSiganture));
        }
        if (purchase.productId == "com.joywinggames.maydayaos004")
        {
            StartCoroutine(Manager.GetComponent<PurchaseManager>().SendPurchasedLog300(purchasedData, purchasedSiganture));
        }
        if (purchase.productId == "com.joywinggames.maydayaos005")
        {
            StartCoroutine(Manager.GetComponent<PurchaseManager>().SendPurchasedLog1000(purchasedData, purchasedSiganture));
        }
	}


	void purchaseFailedEvent( string error, int response )
	{
		Debug.Log( "purchaseFailedEvent: " + error + ", response: " + response );
	}


	void consumePurchaseSucceededEvent( GooglePurchase purchase )
	{
		Debug.Log( "consumePurchaseSucceededEvent: " + purchase );
	}


	void consumePurchaseFailedEvent( string error )
	{
		Debug.Log( "consumePurchaseFailedEvent: " + error );
	}


#endif
}


