using UnityEngine;
using System.Collections;
using System.Text;
using System.Security;

public class GetKakaoFriends : MonoBehaviour {

    public string GetFriendsURL = "http://211.110.154.129/get_friendsnumber.php";
    public string GetFriendsDataURL = "http://211.110.154.129/get_friendsdata.php";
	public string[] serverFriendNumber;
	public string[] serverFriendsData;
	private string secretKey = "12345"; 
	string result;


    /*//싱글톤을 위해서 만든것. 현재 이 스크립트는 쓰이지 않으니 주석처리하여 생성과 실행이 되지 않도록 함.
    public static GetKakaoFriends _instance;


    public static GetKakaoFriends instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(GetKakaoFriends)) as GetKakaoFriends;
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "GetFriendInfoManager";
                    _instance = container.AddComponent(typeof(GetKakaoFriends)) as GetKakaoFriends;
                    DontDestroyOnLoad(_instance);
                }
            }
            return _instance;
        }
    }
    //*///싱글톤을 위해서 만든것. 현재 이 스크립트는 쓰이지 않으니 주석처리하여 생성과 실행이 되지 않도록 함.

	
	public IEnumerator GetFriendsNumber()
	{
		string hash = Md5Sum(secretKey).ToLower();
        string kakaoUniqueNumber = ValueDeliverScript.appFriendsUserId;
		
		WWWForm form = new WWWForm();
		
		form.AddField("hash",hash);
        form.AddField("User_Friends", kakaoUniqueNumber);
		
		WWW www = new WWW(GetFriendsURL,form);
		yield return www;
		
		result = www.text;
		serverFriendNumber = result.Split(new char[] {'?'});


        Debug.Log("result :: " + result);
		
		for(int i =0; i < serverFriendNumber.Length; i++)
		{
			Debug.Log(serverFriendNumber[i]);	
		}
		Debug.Log("<<<<<<<<<<<<============= Get Friends DATA Get 1 =============>>>>>>>>>>>>>");
        //ForKakao.instance._ui.text += "= Get Friends DATA Get =";
        Debug.Log("<<<<<<<<<<<<============= Get Friends DATA Get 2 =============>>>>>>>>>>>>>");

        yield return StartCoroutine(GetFriendsData());
        //ForKakao.instance._ui.text += "= GetFriendsNumber End =";
        ValueDeliverScript.isGetFriend = true;
    }

    IEnumerator GetFriendsData()
    {
        Debug.Log("__GetFriendsData__01");
        //ForKakao.instance._ui.text += "= GetFriendsData =";
        yield return null;

        Debug.Log("__GetFriendsData__02");
        string hash = Md5Sum(secretKey).ToLower();
        //ForKakao.instance._ui.text += "= GetFriendsData01 =";

        Debug.Log("__GetFriendsData__03");
        WWWForm form = new WWWForm();
        //ForKakao.instance._ui.text += "= GetFriendsData02 =";

        Debug.Log("__GetFriendsData__04");
        serverFriendsData = new string[serverFriendNumber.Length];
        //ForKakao.instance._ui.text += "= GetFriendsData03 =";

        Debug.Log("__GetFriendsData__05");
        for (int j = 0; j < serverFriendNumber.Length; j++)
        {
            form.AddField("hash", hash);
            form.AddField("Friends_Number", serverFriendNumber[j]);

            WWW www = new WWW(GetFriendsDataURL, form);

            yield return www;
            Debug.Log(www.text);
            Debug.Log(www.text.GetType());

            serverFriendsData[j] = www.text;

            Debug.Log(serverFriendsData[j]);
            //ForKakao.instance._ui.text += "= GetFriendsData03 =" + j + " = ";

        }
        Debug.Log("__GetFriendsData__06");
        //ForKakao.instance._ui.text += "= GetFriendsData04 =";
    }
	
	public  string Md5Sum(string strToEncrypt)
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

}
