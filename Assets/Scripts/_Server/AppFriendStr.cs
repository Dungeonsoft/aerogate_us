using UnityEngine;
using System.Collections;


public struct AppFriendInfo
{
    public string userId;             //유저아이디.
    public string nickName;           //닉네임.
    public string friendNickName;     //친구가 설정한 친구본인 닉네임.
    public string profileImageUrl;    //유저이미지주소.
    public int exp;                   //유저경험치.
    public double lastMessageSentAt;  //마지막메세지보낸시간.
    public bool messageBlocked;       //메세지 수신여부.

    public int rank;                  //순위.
    public int seasonScore;           //최고점수.
    public int lastSeasonScore;       //이전최고점수.
    public int highFlight;            //최고점수기체.
    public int highSkin;              //최고점수스킨.
    public int highBullet;            //최고점수총알              
    public int highChar;              //최고점수캐릭터.
    public int highBomb;              //최고점수폭탄.
    public int highReinforce;         //최고점수강화품.
    public int highAssist;            //최고점수보조품.
    public string maydayUserId;       //우리쪽서버에서확인할때 쓰는유저아이디.

    public Texture profileImage;
}

public struct KakaoFriendInfo
{
    public string userId;             //유저아이디.
    public string nickName;           //닉네임.
    public string profileImageUrl;    //유저이미지주소.
    public double lastMessageSentAt;  //마지막메세지보낸시간.
    public bool messageBlocked;       //메세지 수신여부.
}


