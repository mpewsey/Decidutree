using UnityEditor;
using UnityEngine;

namespace MPewsey.BehaviorTree.Nodes.Editor
{
    /// <summary>
    /// The selector node custom editor.
    /// </summary>
    [CustomEditor(typeof(RandomSelectorNode))]
    public class RandomSelectorNodeEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Creates a new selector node.
        /// </summary>
        [MenuItem("GameObject/Behavior Tree/Random Selector Node", priority = 20)]
        public static void CreateRandomSelectorNode()
        {
            var obj = new GameObject("Random Selector Node");
            obj.AddComponent<RandomSelectorNode>();
            obj.transform.SetParent(Selection.activeTransform);
        }
    }
}