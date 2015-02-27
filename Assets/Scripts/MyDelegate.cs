using UnityEngine;
using System.Collections;

//델리게이트는 이쪽으로 모아둔다.

namespace MyDelegateNS
{
    public delegate void PicDataInput(Texture2D pic);
    public delegate void UsercheckDele();
    public delegate void NextFunc();
    public delegate void NextFuncD(NextFunc nextF);
    public delegate void NextFuncV(Vector3 nextF);
}
