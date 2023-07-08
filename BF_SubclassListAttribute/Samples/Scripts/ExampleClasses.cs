using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BF_SubclassList_Examples
{
    [System.Serializable]
    public class A
    {
        [SerializeField] private int myInt;
    }

    [System.Serializable]
    public class B : A
    {
        [SerializeField] private Vector3 myVector;
    }

    [System.Serializable]
    public class C : A
    {
        [SerializeField] private string myString;
    }

    [System.Serializable]
    public class ABC_Container
    {
        [SerializeReference] public List<A> list;
    }
}