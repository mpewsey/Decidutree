using UnityEditor;
using UnityEngine;

namespace MPewsey.Decidutree.Nodes.Editor
{
    /// <summary>
    /// The sequence node custom editor.
    /// </summary>
    [CustomEditor(typeof(SequenceNode))]
    public class SequenceNodeEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Creates a new sequence node.
        /// </summary>
        [MenuItem("GameObject/Behavior Tree/Sequence Node", priority = 20)]
        public static void CreateSequenceNode()
        {
            var obj = new GameObject("Sequence Node");
            obj.AddComponent<SequenceNode>();
            obj.transform.SetParent(Selection.activeTransform);
        }
    }
}