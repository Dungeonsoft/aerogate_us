using UnityEngine;
using System.Collections;

public class SoundWindowOpenScript : MonoBehaviour {

    public GameObject bgOnBtn;
    public GameObject bgOnLabel;

    public GameObject bgOffBtn;
    public GameObject bgOffLabel;




    public GameObject fxOnBtn;
    public GameObject fxOnLabel;

    public GameObject fxOffBtn;
    public GameObject fxOffLabel;




    public Color onLabelClr;
    public Color offLabelClr;



    void OnEnable()
    {
        if(ValueDeliverScript.bgSound == 0.5f)
        {
            bgOnBtn.GetComponent<UISprite>().spriteName = bgOnBtn.GetComponent<UISprite>().spriteName.ToString().Replace("_o", "_n"); //켜짐.
            bgOnLabel.GetComponent<UILabel>().color = onLabelClr;     //켜진 색깔.

            bgOffBtn.GetComponent<UISprite>().spriteName = bgOffBtn.GetComponent<UISprite>().spriteName.ToString().Replace("_n", "_o"); //꺼짐.
            bgOffLabel.GetComponent<UILabel>().color = offLabelClr;   //꺼진 색깔.
        }
        else
        {
            bgOnBtn.GetComponent<UISprite>().spriteName = bgOnBtn.GetComponent<UISprite>().spriteName.ToString().Replace("_n", "_o");   //꺼짐.
            bgOnLabel.GetComponent<UILabel>().color = offLabelClr;     //꺼진 색깔.

            bgOffBtn.GetComponent<UISprite>().spriteName = bgOffBtn.GetComponent<UISprite>().spriteName.ToString().Replace("_o", "_n"); //켜짐.
            bgOffLabel.GetComponent<UILabel>().color = onLabelClr;   //켜진 색깔.
        }

        if(ValueDeliverScript.fxSound  == 0.3f)
        {
            fxOnBtn.GetComponent<UISprite>().spriteName = fxOnBtn.GetComponent<UISprite>().spriteName.ToString().Replace("_o", "_n"); //켜짐.
            fxOnLabel.GetComponent<UILabel>().color = onLabelClr;     //켜진 색깔.

            fxOffBtn.GetComponent<UISprite>().spriteName = fxOffBtn.GetComponent<UISprite>().spriteName.ToString().Replace("_n", "_o"); //꺼짐.
            fxOffLabel.GetComponent<UILabel>().color = offLabelClr;   //꺼진 색깔.
        }
        else
        {
            fxOnBtn.GetComponent<UISprite>().spriteName = fxOnBtn.GetComponent<UISprite>().spriteName.ToString().Replace("_n", "_o");   //꺼짐.
            fxOnLabel.GetComponent<UILabel>().color = offLabelClr;     //꺼진 색깔.

            fxOffBtn.GetComponent<UISprite>().spriteName = fxOffBtn.GetComponent<UISprite>().spriteName.ToString().Replace("_o", "_n"); //켜짐.
            fxOffLabel.GetComponent<UILabel>().color = onLabelClr;   //켜진 색깔.
        }

    }

}
