using UnityEngine;
using System.Collections;

public class TestLoadLevelScript : MonoBehaviour
{
    void Awake()
    {
        //Debug.Log("Awake!!!   " + Time.time);
    }


    void Start()
    {
        Application.LoadLevel("InGame01");
    }


    void Update()
    {
        //Debug.Log("Time is " + Time.time);
    }




    // Use this for initialization
    //IEnumerator Start()
    //{
    //    Debug.Log("Start!!!   " + Time.time);
    //    AsyncOperation async = Application.LoadLevelAsync("InGame01");

    //    while (async.isDone == false)
    //    {
    //        Debug.Log("Percent :::: " + async.progress * 100f);
    //        yield return null;
    //    }
    //}
}
