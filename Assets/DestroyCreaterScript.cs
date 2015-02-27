using UnityEngine;
using System.Collections;

public class DestroyCreaterScript : MonoBehaviour
{

    float spendTime = 0;
    int portalStage = -1;

    public int groupInterval = 1;
    public int waveInterval = 15;

    public int[] numberinGroup = { 2, 3, 4, 5, 6, 7, 8 };

    ActivateScript activateScript;

    void Start()
    {
        activateScript = GameObject.Find("GameManager").GetComponent<ActivateScript>();
    }

    public void Activate(int portalNumber)
    {
        spendTime = 0;
        portalStage = portalNumber;
    }

    void Update()
    {
        if (portalStage < 0) return;

        if (spendTime > waveInterval)
        {
            StartCoroutine(createDestroyer());
            spendTime = 0;
        }
        else
        {
            spendTime += Time.deltaTime;
        }
    }

    bool isCreateDestroyer = false;
    int cPortalStage;
    IEnumerator createDestroyer()
    {
        cPortalStage = portalStage;
        Debug.Log("Portal Stage :: " + cPortalStage);
        Debug.Log(" :: Valued :: " + numberinGroup[portalStage]);
        isCreateDestroyer = true;
        for (int i = 0; i < numberinGroup[cPortalStage]; i++)
        {
            Debug.Log("IIII Value :::: " + i +" :::::");
            activateScript.DestroyerActivation(this.transform.position, cPortalStage + 1);
            yield return new WaitForSeconds(groupInterval);
        }
    }
}
