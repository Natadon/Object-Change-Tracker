# C# Object Changes Tracker

The Object-Change-Tracker is a simple library that you can pass in two objects of the same type and the library will return you a list of all the primative properties that are different between the two.  This is great if you want to build a simple change history to you .NET application.

To use the change library simply instantiate an instance of the ChangeDetector

```c#
ChangeDetector changeDetector = new ChangeDetector();
```

From there, you can get a list of changes by calling the ```GetChanges``` function.

```c#
List<Changes> = changeDetector.GetChanges(originalObject, changedObject, modifiedBy, timestamp);
```

The result of this call will be a list with zero or more changes in it.  If there are no differences between the objects, it returns an empty list.  otherwise, there will be a change object for each property that has changed.

**Note:** This library ignores complex objects that are properties of a passed in object.  It is expected if you want to track changes of child objects, you call the ```GetChanges()``` function for those objects as well.