using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;
using System;
using Object = UnityEngine.Object;

[CanEditMultipleObjects]
[CustomEditor(typeof(DragDropRoot))]
public class DragDropRootInspector : Editor {
    public override void OnInspectorGUI (){}
}