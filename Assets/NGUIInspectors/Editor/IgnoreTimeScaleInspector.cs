using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;
using System;
using Object = UnityEngine.Object;

[CanEditMultipleObjects]
[CustomEditor(typeof(IgnoreTimeScale))]
public class IgnoreTimeScaleInspector : Editor {
    public override void OnInspectorGUI (){}
}