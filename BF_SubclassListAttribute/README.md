#What is this asset for:
This asset allows you to have add and display different subclasses in one list of the superclass type, in the inspector.

#How to:

Create your superclass. Ensure it is [System.Serializable].
[System.Serializable]
public class TestBase
{
    public int myInteger;
}



Create your derived classes. Ensure they are [System.Serializable].
[System.Serializable]
public class TestDerivedA : TestBase
{
    public List<int> myIntegerList;
}


[System.Serializable]
public class TestDerivedB : TestBase
{
    public string myString;
    public NestedClass myNestedClass; //Any nested classes or lists will be dispalyed too, to any depth.
}

Then create your container. This is a class that simply holds the list. Ensure it is [System.Serializable]. Make sure the list has the attribute [SerializeReference] 

[System.Serializable]
public class TestBaseListContainer
{
    [SerializeReference] public List<TestBase> constraints;
}

Then use in any monobehaviour or scriptableobject, with the attribute SubclassList, and the type of the superclass.

[CreateAssetMenu(fileName = "Test", menuName = Constants.scriptableObjectHeader + "Test/Test2"), ]
public class ScriptableObjectTest2 : ScriptableObject
{
    [SubclassList(typeof(TestBase))] public TestBaseListContainer testList;
    [SubclassList(typeof(TestBase))] public TestBaseListContainer testList2;
}