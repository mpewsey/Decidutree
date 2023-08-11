using UnityEditor;
using UnityEngine;

namespace MPewsey.Decidutree.Nodes.Editor
{
    /// <summary>
    /// The selector node custom editor.
    /// </summary>
    [CustomEditor(typeof(SelectorNode))]
    public class SelectorNodeEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Creates a new selector node.
        /// </summary>
        [MenuItem("GameObject/Behavior Tree/Selector Node", priority = 20)]
        public static void CreateSelectorNode()
        {
            var obj = new GameObject("Selector Node");
            obj.AddComponent<SelectorNode>();
            obj.transform.SetParent(Selection.activeTransform);
        }
    }
}