using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BF_SubclassList_Example
{
    //Example classes
    [System.Serializable]
    public class BF_ExampleSuperclass
    {
        public int myInteger;
    }

    [System.Serializable]
    public class BF_ExampleSubclassA : BF_ExampleSuperclass
    {
        public List<int> myIntegerList;
    }

    [System.Serializable]
    public class BF_ExampleSubclassB : BF_ExampleSuperclass
    {
        public string myString;
    }

    [System.Serializable]
    public class BF_ExampleSubclassC : BF_ExampleSubclassB
    {
        public NestedClass myNestedClass;
    }

    [System.Serializable]
    public class NestedClass
    {
        public int myInteger;
        public string myString;
    }



    //This is a wrapper you must create to group the list, and package will do the rest.
    [System.Serializable]
    public class BF_ExampleSuperclassContainer
    {
        [SerializeReference] public List<BF_ExampleSuperclass> myList;
    }

}
