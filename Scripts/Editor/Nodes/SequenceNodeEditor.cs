using UnityEditor;
using UnityEngine;

namespace MPewsey.BehaviorTree.Editor
{
    [CustomEditor(typeof(SequenceNode))]
    public class SequenceNodeEditor : UnityEditor.Editor
    {
        [MenuItem("GameObject/Behavior Tree/Sequence Node", priority = 20)]
        public static void CreateSequenceNode()
        {
            var obj = new GameObject("Sequence Node");
            obj.AddComponent<SequenceNode>();
            obj.transform.SetParent(Selection.activeTransform);
        }
    }
}