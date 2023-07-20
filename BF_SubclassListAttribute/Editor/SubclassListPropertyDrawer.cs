using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System.Linq;

namespace BF_SubclassList
{
    [CustomPropertyDrawer(typeof(SubclassListAttribute))]
    public class SubclassListPropertyDrawer : PropertyDrawer
    {
        SubclassListAttribute subclassAttribute;
        ReorderableList list;
        bool initialized;
        Type[] derivedTypes;
        float lineHeight => EditorGUIUtility.singleLineHeight * 1.1f;
        List<float> heights = new List<float>();
        string name;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            if (!initialized)
            {
                Debug.Log("init" + property.propertyPath);
                name = property.displayName;
                heights.AddRange(new float[10]);
                subclassAttribute = attribute as SubclassListAttribute;
                SerializedProperty listProperty = null;
                foreach (var child in property.GetChildren())
                {
                    if (child.type == subclassAttribute.Type.Name)
                    {
                        listProperty = child;
                        break;
                    }
                }
                list = new ReorderableList(property.serializedObject, listProperty, true, true, true, true);
                list.drawElementCallback = DrawListItems;
                list.drawHeaderCallback = DrawHeader;
                initialized = true;
                derivedTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(domainAssembly => domainAssembly.GetTypes())
                    .Where(type => subclassAttribute.Type.IsAssignableFrom(type) && type != subclassAttribute.Type
                    ).ToArray();
            }
            list.DoList(position);
            list.onAddDropdownCallback = (Rect buttonRect, ReorderableList l) =>
            {
                var menu = new GenericMenu();

                foreach (var type in derivedTypes)
                {
                    menu.AddItem(new GUIContent(type.ToString()), false, clickHandler, Activator.CreateInstance(type));
                }
                menu.ShowAsContext();
            };
            list.elementHeightCallback = (index) =>
            {
                return heights[index];
            };


            void clickHandler(object target)
            {
                var index = list.serializedProperty.arraySize;
                list.serializedProperty.arraySize++;
                list.index = index;
                var element = list.serializedProperty.GetArrayElementAtIndex(index);
                element.managedReferenceValue = target;
                property.serializedObject.ApplyModifiedProperties();
            }


            EditorGUI.EndProperty();
            //if (EditorGUI.EndChangeCheck())
            //{
            //    property.serializedObject.ApplyModifiedProperties();
            //}

        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (list != null)
            {
                return list.GetHeight();
            }
            else
            {
                return base.GetPropertyHeight(property, label);
            }
        }

        void DrawListItems(Rect position, int index, bool isActive, bool isFocused)
        {
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index); //The element in the list
            EditorGUI.indentLevel++;
            Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);
            element.isExpanded = EditorGUI.Foldout(rectFoldout, element.isExpanded, element.type.GetMiddleString("<", ">"));
            float height = lineHeight;
            if (element.isExpanded)
            {
                EditorGUI.indentLevel++;
                foreach (var child in element.GetChildren())
                {
                    float childHeight = EditorGUI.GetPropertyHeight(child, true);
                    Rect rectWeight = new Rect(position.min.x, position.min.y + height, position.size.x, lineHeight);
                    height += childHeight;
                    EditorGUI.PropertyField(rectWeight, child, true);
                }

                EditorGUI.indentLevel--;
                list.elementHeight = height;
            }
            if (index >= heights.Count)
            {
                heights.AddRange(new float[10]);
            }
            heights[index] = height;
            EditorGUI.indentLevel--;
        }

        void DrawHeader(Rect rect)
        {
            string name1 = name + "<" + subclassAttribute.Type.ToString() + ">";
            EditorGUI.LabelField(rect, name1);
        }
    }
}