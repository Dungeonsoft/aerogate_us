using UnityEngine;
using System.Collections;

public class RedAlert : MonoBehaviour
{


    public enum AlertState
    {
        stable, warn, attacked, recoverFuel
        //0     , 1   , 2       , 3//
    }

    public AlertState state = AlertState.stable;

    public UITexture redScreen;
    Color matColor;
    float aValue;

    GameObject fuelSlider;
    public float arlertSpeed = 1.5f;
    public float arlertMinVal = 0.2f;

    float fuelRemain = 0;

    float alphaTime = 0;

    public GameObject[] Crack;

    // Use this for initialization
    void Start()
    {
        matColor = redScreen.color;
        fuelSlider = GameObject.Find("FuelSlider");
    }

    // Update is called once per frame
    void Update()
    {


        switch (state)
        {
            case AlertState.stable:
                fuelRemain = (1f * ValueDeliverScript.fuelSize) / ValueDeliverScript.fuelSizeOri;
                //Debug.Log("Fuel Size :: " + ValueDeliverScript.fuelSize);
                //Debug.Log("Fuel Size Ori :: " + ValueDeliverScript.fuelSizeOri);
                //Debug.Log("Fuel Remain :: " + fuelRemain);

                if (fuelRemain <= arlertMinVal) state = AlertState.warn;

                //Debug.Log("Fuel State :: " + state);
                break;

            case AlertState.warn:
                alphaTime += Time.deltaTime * arlertSpeed;
                aValue = Mathf.Abs(Mathf.Sin(alphaTime)) * 1f;
                redScreen.color = new Color(matColor.r, matColor.g, matColor.b, aValue);

                //Debug.Log("Alpha Time Sin Value ::: " + Mathf.Sin(alphaTime));

                if (Mathf.Sin(alphaTime) < 0)
                {
                    fuelRemain = (1f * ValueDeliverScript.fuelSize) / ValueDeliverScript.fuelSizeOri;
                    //Debug.Log("fuelRemain Value ::: " + fuelRemain);
                    if (fuelRemain > arlertMinVal)
                    {
                        redScreen.color = new Color(1, 1, 1, 0);

                        state = AlertState.stable;
                        alphaTime = 0;
                    }
                }
                break;

            case AlertState.attacked:
                alphaTime += Time.deltaTime * arlertSpeed;
                aValue = Mathf.Sin(alphaTime) * 0.5f;
                redScreen.color = new Color(matColor.r, matColor.g, matColor.b, aValue);

                if (aValue < 0)
                {
                    fuelRemain = (1f * ValueDeliverScript.fuelSize) / ValueDeliverScript.fuelSizeOri;

                    if (fuelRemain <= 0.1) state = AlertState.warn;
                    else if (fuelRemain > 0.1) state = AlertState.stable;

                    alphaTime = 0;
                    redScreen.color = new Color(matColor.r, matColor.g, matColor.b, 0);

                    Crack[0].SetActive(false);
                    Crack[1].SetActive(false);
                    Crack[2].SetActive(false);
                    Crack[3].SetActive(false);
                    Crack[4].SetActive(false);
                }
                break;

            case AlertState.recoverFuel:

                break;
        }
    }

    public void StateChage(AlertState changeState)
    {
        state = changeState;

        if (state == AlertState.attacked)
        {
            StartCoroutine(ShowCrack());
        }
    }

    IEnumerator ShowCrack()
    {
        Crack[0].SetActive(true);
        yield return new WaitForSeconds(0.05f);

        Crack[1].SetActive(true);
        yield return new WaitForSeconds(0.03f);

        Crack[2].SetActive(true);
        yield return new WaitForSeconds(0.03f);

        Crack[3].SetActive(true);
        yield return new WaitForSeconds(0.05f);

        Crack[4].SetActive(true);
    }
}
