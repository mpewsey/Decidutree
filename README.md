# Behavior Tree

## Installation

To add the package to a project, in Unity, select `Window > Package Manager`.

![Unity Package Manager](https://user-images.githubusercontent.com/23442063/163601100-191d8699-f4fd-42cc-96d4-f6aa5a8ae29b.png)

Select `Add package from git URL...` and paste the following URL:

```
https://github.com/mpewsey/BehaviorTree.git
```

RECOMMENDED: To lock into a specific version, append `#{VERSION_TAG}` to the end of the URL. For example:

```
https://github.com/mpewsey/BehaviorTree.git#v1.0.0
```

## Usage

The behavior tree in this library consists of component behavior nodes and behavior subnodes that are added to Game Objects in the Unity hierarchy view.

* To create a tree, create the root behavior tree component via `GameObject > Behavior Tree > Behavior Tree`.
* Next, add behavior nodes as children of the tree (and children of those children, as the behavior requires) via the `GameObject > Behavior Tree` menu.
* In addition, behavior subnode components may be attached to the nodes of the tree. The node will evaluate the attached subnodes like a Sequence node prior to performing its normal `OnTick` operation. Therefore, subnodes are usually best used as conditions that must be satisfied for a node to run.
* Since the behavior tree is no different than any other Unity component, it may be saved as a prefab and instantiated accordingly.
* To use the tree, you must first call the `Initialize` method on the tree. Then, evaluating the tree is only a matter of calling its `Tick` method. Depending on the tree, this may be something you choose to do every frame, such as through an Update method, or more infrequently, only when you need it, such as with turn-based battle AI.

## Creating Custom Behavior

The library provides some generic nodes. However, to capture any unique behavior you will need to create your own behavior nodes and subnodes.

* Custom behavior node components should inherit the `BehaviorNode` class and implement the required abstract methods.
* Custom behavior subnode components should inherit the `BehaviorSubnode` class and implement the required abstract methods.
* The nodes of a tree instance share a Blackboard, an object with entries for shared variables. In the node and subnode `OnInitialize` method, it is often useful to acquire the blackboard entries for the shared variables used by the node, and cache them as properties on the component.
* The `OnTick` method should implement any operations performed by the node. For subnodes, this may simply amount to evaluating a condition, then returning either Success or Failure.

The below example, taken from the library, implements a custom behavior subnode. The purpose of the subnode is to evaluate whether the current number of ticks called on the tree is even, returning Success if it is, and Failure if it isn't. In the `OnInitialize` method, it caches the blackboard entry for the tick count, which is incremented separately by another component.

```TickCountIsEvenSubnode.cs
public class TickCountIsEvenSubnode : BehaviorSubnode
{
    public BlackboardEntry<uint> TickCount { get; private set; }

    protected override void OnInitialize()
    {
        TickCount = Blackboard.EnsureSetValue("Tick Count", 0u);
    }

    protected override BehaviorStatus OnTick()
    {
        if (TickCount.Value % 2 == 0)
            return BehaviorStatus.Success;
        return BehaviorStatus.Failure;
    }
}
```
