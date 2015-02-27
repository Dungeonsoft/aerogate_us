using UnityEngine;
using System.Collections;

public class ItemHilightScript : MonoBehaviour
{

    public GameObject hilightIcon;
    public GameObject mountIcon;

    public GameObject CharacterLeftImage;

    public void HilightIconAct(Vector3 targetPosition)
    {
        //Debug.Log("Now Hilight Icon Act Script is Working On!");
        hilightIcon.SetActive(true);
        hilightIcon.transform.localPosition = targetPosition + transform.FindChild("Item").localPosition + new Vector3(-1, 3, -1) - hilightIcon.transform.parent.localPosition;

        string itemCount = ValueDeliverScript.SelectedItem.transform.FindChild("Label").gameObject.GetComponent<UILabel>().text;

        if (int.Parse(itemCount) != 0)
        {
            //Debug.Log(ValueDeliverScript.SelectedItem.name + "  ::  Mount Icon is Working On!");
            mountIcon.SetActive(true);
            mountIcon.transform.position = hilightIcon.transform.position;
        }
        else
        {
            //Debug.Log("MountIcon to Temp :::");
            GameObject.Find("GameManager").GetComponent<HangarManager>().mountIconTemp = mountIcon;
            GameObject.Find("GameManager").GetComponent<HangarManager>().mountIconPositionTemp = hilightIcon.transform.localPosition;

        }
    }
}
