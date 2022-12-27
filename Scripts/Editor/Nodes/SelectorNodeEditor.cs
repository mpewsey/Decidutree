using UnityEditor;
using UnityEngine;

namespace MPewsey.BehaviorTree.Editor
{
    [CustomEditor(typeof(SelectorNode))]
    public class SelectorNodeEditor : UnityEditor.Editor
    {
        [MenuItem("GameObject/Behavior Tree/Selector Node", priority = 20)]
        public static void CreateSelectorNode()
        {
            var obj = new GameObject("Selector Node");
            obj.AddComponent<SelectorNode>();
            obj.transform.SetParent(Selection.activeTransform);
        }
    }
}