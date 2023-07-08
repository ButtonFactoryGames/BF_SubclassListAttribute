using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BF_SubclassList_Examples
{
    public class ExampleMono : MonoBehaviour
    {
        [BF_SubclassList.SubclassList(typeof(A)), SerializeField] private ABC_Container abc_list;
    }
}