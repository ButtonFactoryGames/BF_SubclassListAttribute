using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BF_SubclassList
{
    public class SubclassListAttribute : PropertyAttribute
    {
        Type type;
        public Type Type => type;

        public SubclassListAttribute(Type type)
        {
            this.type = type;
        }
    }
}