using UnityEditor;
using UnityEngine;

namespace MPewsey.BehaviorTree.Editor
{
    [CustomEditor(typeof(BehaviorTree))]
    public class BehaviorTreeEditor : UnityEditor.Editor
    {
        [MenuItem("GameObject/Behavior Tree/Behavior Tree", priority = 20)]
        public static void CreateBehaviorTree()
        {
            var obj = new GameObject("Behavior Tree");
            obj.AddComponent<BehaviorTree>();
            obj.transform.SetParent(Selection.activeTransform);
        }
    }
}