using UnityEngine;
using System.Collections;

public class FriendRescueScript : MonoBehaviour
{
    string myNick;
    int rLength;

    public GameObject friendScoreShowtab;
    public UILabel rank;
    public UILabel name;
    public UILabel score;
    public UITexture pic;

    bool isFriend;

    int fLength;
    int nowFriendScore;

    void Awake()
    {
        myNick = ValueDeliverScript.Nick;
        Debug.Log("ValueDeliverScript.rankDataFB.Length  ::: " + ValueDeliverScript.rankDataFB.Length);

        if (ValueDeliverScript.rankDataFB.Length == null) rLength = 0;
        else rLength = ValueDeliverScript.rankDataFB.Length;

    }

    void Start()
    {
        fLength = rLength - 1;
        SetFriend();
    }


    // Use this for initialization
    void SetFriend()
    {
        Debug.Log("Set Friend  메소드에 들어오는가? ::: Length는 얼마인가? ::: " + fLength + " ::: " + rLength +" :::");
        do
        {
            isFriend = false;
            if (rLength > 0)
            {
                //이거 고치고 친구 감옥나오고 비행기 나오고 인게임 끝났을때 결과화면에 나오도록 한다.
                //결과화면에선 친구를 구한 수만큼 우정 포인트가 쌓이게 한다.

                while (fLength >= 0)
                {
                    Debug.Log("이 " + fLength + ValueDeliverScript.rankDataFB[fLength].NickName+"의 최고 점수" + ValueDeliverScript.rankDataFB[fLength].TWeekScore);
                    if (myNick != ValueDeliverScript.rankDataFB[fLength].NickName 
                        &&
                        ValueDeliverScript.rankDataFB[fLength].TWeekScore != "0" 
                        &&
                        ValueDeliverScript.rankDataFB[fLength].TWeekScore != "" 
                        &&
                        ValueDeliverScript.rankDataFB[fLength].TWeekScore != null)
                    {
                        rank.text = (fLength + 1).ToString();
                        name.text = ValueDeliverScript.rankDataFB[fLength].NickName;
                        score.text = ValueDeliverScript.rankDataFB[fLength].TWeekScore;
                        pic.mainTexture = ValueDeliverScript.rankDataFB[fLength].FbPic;
                        int.TryParse(ValueDeliverScript.rankDataFB[fLength].TWeekScore, out nowFriendScore);
                        isFriend = true;
                        break;
                    }
                    rank.text = "";
                    fLength--;
                }
                break;
            }
        } while (false);
    }

    public void AnimIn()
    {
        Debug.Log("Anim In 하는가?");
        friendScoreShowtab.animation.Play("InX");
    }

    public void AnimOut()
    {
        Debug.Log("Anim Out 하는가?");
        friendScoreShowtab.animation.Play("OutX");
    }

    public void MinusScore(int myScore, Vector3 ufoPos, bool isUfo)
    {
        do
        {
            if (!isFriend) break;

            if ((nowFriendScore - myScore) > 0)
            {
                score.text = (nowFriendScore - myScore).ToString();
                break;
            }
            else
            {

                isFriend = false;
                score.text = "0";
                fLength--;


                if (fLength == -1)
                {
                    fLength = 0;
                    break;

                }
                else if (isUfo)
                {
                    //Debug.Log("Make Friend!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Debug.Log("fLength ::: " + fLength);
                    RankDataS friend = ValueDeliverScript.rankDataFB[fLength+1];
                    GetComponent<ActivateScript>().FriendJailActivation(ufoPos, 1, friend.FbPic, int.Parse(friend.Flight), int.Parse(friend.Bullet), friend.FbId, int.Parse(friend.Skin), null);
                }

                StartCoroutine(ChangeFriend());
                break;
            }
        } while (false);

    }

    IEnumerator ChangeFriend()
    {
        AnimOut();
        SetFriend();

        rank.gameObject.SetActive(false);
        name.gameObject.SetActive(false);
        score.gameObject.SetActive(false);

        yield return new WaitForSeconds(friendScoreShowtab.animation.clip.length);

        rank.gameObject.SetActive(true);
        name.gameObject.SetActive(true);
        score.gameObject.SetActive(true);

        if (rank.text == "")
        {
            friendScoreShowtab.SetActive(false);
        }


        AnimIn();

    }

}