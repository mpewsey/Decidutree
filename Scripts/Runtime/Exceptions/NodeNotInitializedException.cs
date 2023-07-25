namespace MPewsey.BehaviorTree.Exceptions
{
    /// <summary>
    /// Exception thrown when a behaviour node or subnode is not initialized.
    /// </summary>
    public class NodeNotInitializedException : System.Exception
    {
        public NodeNotInitializedException(string message) : base(message)
        {

        }
    }
}