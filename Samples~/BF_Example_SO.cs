using BF_SubclassList;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;

namespace BF_SubclassList_Example
{
    public class BF_Example_SO : ScriptableObject
    {
        [SubclassList(typeof(BF_ExampleSuperclass))] public BF_ExampleSuperclassContainer myValues;
    }

}
