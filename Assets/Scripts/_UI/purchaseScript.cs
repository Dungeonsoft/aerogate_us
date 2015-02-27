using UnityEngine;
using System.Collections;

public class purchaseScript : MonoBehaviour
{
    public float endTime = 2f;

    public void Activate()
    {
        StartCoroutine(DestroyWindow());
    }

    IEnumerator DestroyWindow()
    {
        //				Debug.Log ("purchase window!!!");
        yield return new WaitForSeconds(endTime);
        this.gameObject.SetActive(false);
    }
}