using UnityEngine;
using System.Collections;

public class TestInst02 : MonoBehaviour
{
    // Use this for initialization
    public void Awake()
    {
        //Debug.Log("TempA is " + TestInst.instance.tempNumA);
        //Debug.Log("TempB is " + TestInst.instance.tempNumB);
        //Debug.Log("TempC is " + TestInst.instance.tempNumC);
        //Debug.Log("TempD is " + TestInst.instance.tempNumD);

        TestInst.instance.tempNumA += 10;
        //Debug.Log("TempA is " + TestInst.instance.tempNumA);

        StartCoroutine(AAA());
    }

    IEnumerator AAA()
    {
        yield return new WaitForSeconds(2f);

        Application.LoadLevel(4);
    }
}
