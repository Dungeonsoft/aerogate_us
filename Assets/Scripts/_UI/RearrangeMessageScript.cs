using UnityEngine;
using System.Collections;

public class RearrangeMessageScript : MonoBehaviour {

    public void RearrangeTabs(GameObject destroyTab)
    {
        Debug.Log("Rearrange Tabs!!!!");
        Destroy(destroyTab);
        GetComponent<UIGrid>().repositionNow = true;
        Debug.Log("Rearrange Tabs!!!!       ENd!!!!!!!!!!!!!!!!");

        //여기서 리시브 올 버튼과 뉴아이콘 둘다 안보이게 꺼준다.
        Debug.Log("transform.childCount ::: " + transform.childCount);
        if (transform.childCount <= 1)
        {
            GameObject.Find("AllMessageBtn").SetActive(false);
            GameObject.Find("FriendRankWindow").transform.FindChild("NewIcn").gameObject.SetActive(false);
        }

    }
}
