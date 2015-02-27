using UnityEngine;
using System.Collections;
using System.Text;

public class HelpUiObjPool : MonoBehaviour
{

    public GameObject helpObj;
    public int helpObjNum;



    // Use this for initialization
    void Start()
    {
        InstantiatePool(helpObj, helpObjNum, "HelpObj");
    }

    void InstantiatePool(GameObject obj, int objNum, string objName)
    {
        for (int i = 0; i < objNum; i++)
        {
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.parent = this.transform;
            go.name = objName + i;
            go.SetActive(false);
        }
    }

    //액티베이션.
    public void HelpObjActivation(GameObject parentObj)
    {
        int HelpObjCount = transform.GetChildCount();
        for (int j = 0; j < HelpObjCount; j++)
        {
            GameObject helpObjGO = transform.GetChild(j).gameObject;
            if (helpObjGO.activeSelf == false)
            {
                helpObjGO.SetActive(true);
                helpObjGO.transform.localScale = new Vector3(30, 30, 30);
                helpObjGO.GetComponent<HelpTextScript>().Activate(parentObj);
                return;
            }
        }
    }

}
