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

To create a tree, create the root `BehaviorTree` component via `GameObject > Behavior Tree > Behavior Tree`.

Next, add behavior nodes as children of the tree (and children of those children, as the behavior requires) via the `GameObject > Behavior Tree` menu.

In addition, behavior subnode components may be attached to the nodes of the tree. The node will evaluate the attached subnodes like a Sequence node prior to performing its normal `OnTick` operation. Therefore, subnodes are usually best used as conditions that must be satisfied for a node to run.

Since the behavior tree is no different than any other Unity component, it may be saved as a prefab and instantiated accordingly.

To use the tree, you must first call the `Initialize` method. Then, evaluating the tree is only a matter of calling the `Tick` method. Depending on the tree, this may be something you do every frame, such as through an Update method, or more infrequently, only when you need it, such as with turn-based battle AI.
