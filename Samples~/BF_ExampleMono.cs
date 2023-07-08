using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BF_SubclassList_Example
{
    public class BF_ExampleMono : MonoBehaviour
    {
        [SerializeField, BF_SubclassList.SubclassList(typeof(BF_ExampleSuperclass))] private BF_ExampleSuperclassContainer myFirstValues;
        [SerializeField, BF_SubclassList.SubclassList(typeof(BF_ExampleSuperclass))] private BF_ExampleSuperclassContainer mySecondValues;
    }
}