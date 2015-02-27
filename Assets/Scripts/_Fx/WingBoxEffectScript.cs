using UnityEngine;
using System.Collections;
using MyDelegateNS;

public class WingBoxEffectScript : MonoBehaviour {

	public Transform startPoint;
	Vector3 endPos;
	float positionValue = 0f;

    bool isBirthFx = false;


    NextFuncV nextFF;

    //여기 메소드를 실행하면 에스자 이펙트가 나오기 시작한다//
    //여기는 정의만 하고 바로 아래 Update에서 실제 움직이게 한다//
    public void Activate(Vector3 targetEndPoint, NextFuncV nextF)
	{
        nextFF = nextF;
		endPos = targetEndPoint;
        transform.FindChild("BirthEffect").gameObject.SetActive(true);
        isBirthFx = true;
	}

    void Update()
    {
        if (isBirthFx == true)
        {
            if (positionValue < 1)
            {
                //25.1327f 값은 수학값 파이에 8을 곱한 근사치이다//
                transform.position = Vector3.Lerp(startPoint.position, endPos, positionValue) + new Vector3(Mathf.Sin(25.1327f * positionValue) * 2, 0, 0);
                positionValue += Time.deltaTime * 0.5f;
            }
            //s자 모양으로 이펙트가 발생되고 나서 최종으로 골든웜홀이 나올 위치까지 도달하면(positionValue이 1이상이 되면) 아래 내용을 실행한다//
            else
            {
                transform.position = endPos;
                isBirthFx = false;
                positionValue = 0f;
                nextFF(endPos);
            }
        }
    }
}
