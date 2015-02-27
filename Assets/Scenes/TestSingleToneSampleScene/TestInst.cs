using UnityEngine;
using System.Collections;

public class TestInst : MonoBehaviour {

    public int tempNumA = 0;
    public int tempNumB = 1;
    public int tempNumC = 2;
    public int tempNumD = 3;

    static TestInst _instance;
    public static TestInst instance
    {
        get
        {
            if (!_instance)
                _instance = GameObject.FindObjectOfType(typeof(TestInst)) as TestInst;
            DontDestroyOnLoad(_instance);
            return _instance;
        }
    }
}
