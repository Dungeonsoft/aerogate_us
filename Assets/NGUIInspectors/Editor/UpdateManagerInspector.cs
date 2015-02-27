using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;
using System;
using Object = UnityEngine.Object;

[CanEditMultipleObjects]
[CustomEditor(typeof(UpdateManager))]
public class UpdateManagerInspector : Editor {
    public override void OnInspectorGUI (){}
}