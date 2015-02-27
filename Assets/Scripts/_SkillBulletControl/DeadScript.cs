using UnityEngine;
using System.Collections;

public class DeadScript : MonoBehaviour
{

    void ActShotSound() // 애니메이션 커브에서 이벤트를 이용하여 접근
    {
        GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().ComancheSkilshot();
    }


    void DeadActivate() // 애니메이션 커브에서 이벤트를 이용하여 접근
    {
        transform.parent.localEulerAngles = new Vector3(0, 0, 0);
        transform.parent.gameObject.SetActive(false);
    }

}
