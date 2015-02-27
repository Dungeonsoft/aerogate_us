using UnityEngine;
using System.Collections;
using System.Text;
using System.Security;

public class GetFriendInfo : MonoBehaviour {

	public string GetFriendScoreURL = "http://leessoda.cafe24.com/get_friendscore.php";
	public string GetFriendNameURL = "http://leessoda.cafe24.com/get_friendname.php";
	private string secretKey = "12345"; 
	string result;	
	
	public int userUniqueNum;

    public static GetFriendInfo instance;

    void Awake()
    {
        GetFriendInfo.instance = this;
    }

	public void SetStart () 
	{
		userUniqueNum = PlayerPrefs.GetInt("UserUnique");
		StartCoroutine(GetFriendScoreInfo());
	}
	
	IEnumerator GetFriendScoreInfo()
	{
		yield return StartCoroutine(GetFriendNameInfo());
		
		string hash = Md5Sum(secretKey).ToLower();	
		int userUniqueNumber = userUniqueNum;
		
		WWWForm form = new WWWForm();
		
		form.AddField("hash",hash);
		form.AddField("User_Number", userUniqueNumber);
		
		WWW www = new WWW(GetFriendScoreURL,form);
		yield return www;
		
		result = www.text;
        //ValueDeliverScript.serverFriendScoreInfo = result.Split(new char[] {'?'});
				
 		Debug.Log("============= Get Friender Score Info Get =============");		
	}	
	
	IEnumerator GetFriendNameInfo()
	{
		yield return null;
		string hash = Md5Sum(secretKey).ToLower();	
		int userUniqueNumber = userUniqueNum;
		
		WWWForm form = new WWWForm();
		
		form.AddField("hash",hash);
		form.AddField("User_Number", userUniqueNumber);
		
		WWW www = new WWW(GetFriendNameURL,form);
		yield return www;
		
		result = www.text;
        //ValueDeliverScript.serverFriendNameInfo = result.Split(new char[] {'?'});
		
		Debug.Log("============= Get Friender Name Info Get =============");		
	}

    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

    /*
	public string Md5Sum(string input)
	{
    	// step 1, calculate MD5 hash from input
    	System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
    	byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
    	byte[] hash = md5.ComputeHash(inputBytes);
 
    	// step 2, convert byte array to hex string
    	StringBuilder sb = new StringBuilder();
    	for (int i = 0; i < hash.Length; i++)
    	{
    	    sb.Append(hash[i].ToString("X2"));
    	}
    	return sb.ToString();
	}
     */

    ////내가 인터넷에서 긁어온 Md5메소드.
    //public string Md5Sum(string input)
    //{
    //    //ForKaKao.instance._ui.text += "Md5Sum00";
    //    byte[] data = Encoding.ASCII.GetBytes(input);
    //    //ForKaKao.instance._ui.text += "Md5Sum01";
    //    System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
    //    //ForKaKao.instance._ui.text += "Md5Sum02";
    //    byte[] result = md5.ComputeHash(data);
    //    //ForKaKao.instance._ui.text += "Md5Sum03";

    //    ForKaKao.instance._ui.text += " Md5SumCompl_";

    //    //return Encoding.ASCII.GetString(result);
    //    return System.Convert.ToBase64String(result);
    //}


}