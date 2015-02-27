using UnityEngine;
using System.Collections;

public class DebrisMoveScript : DebrisAct
{

    public GameObject warningPanel;
    public int endPosZ = -20;


    public int[] posX = { -10, 0, 10 };
    int posXL;
    int posRnd;
    public float[] moveSpeed;

    public bool isOn;
    // Use this for initialization

    GameObject gameManager;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Start()
    {
        posXL = posX.Length;
        posRnd = Random.Range(0, posXL);
        transform.position = new Vector3(posX[posRnd], 0, 100);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == false) return;
        //Debug.Log("진짜 액티베이트 데브리4");
        transform.position -= new Vector3(0, 0, moveSpeed[ValueDeliverScript.portalUpLevel] * Time.deltaTime);

        if (transform.position.z < endPosZ)
        {
            isOn = false;
            posRnd = Random.Range(0, posXL);
            transform.position = new Vector3(posX[posRnd], 0, 70);
            gameObject.SetActive(false);
        }
    }

    public override void Activate()
    {
        gameManager.GetComponent<SoundUiControlScript>().EffectWarningVoice();
        //Debug.Log("진짜 액티베이트 데브리");
        warningPanel.animation.Play("WarningAnim01");
        StartCoroutine(MoveDebris());
        
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    IEnumerator MoveDebris()
    {
        //Debug.Log("진짜 액티베이트 데브리2");
        //yield return new WaitForSeconds(2f);
        //Debug.Log("진짜 액티베이트 데브리3");
        isOn = true;
        yield return null;
    }
}
