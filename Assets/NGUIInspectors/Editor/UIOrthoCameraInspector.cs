using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;
using System;
using Object = UnityEngine.Object;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIOrthoCamera))]
public class UIOrthoCameraInspector : Editor {
    public override void OnInspectorGUI (){}
}