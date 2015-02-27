using UnityEngine;
using System.Collections;

public class AlphaEndScript : MonoBehaviour {

    public void AlphaEnd()
    {
        Debug.Log("AlphaEnd");
        GetComponent<UITexture>().color = new Color(1, 1, 1, 0);
    }
}
