using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;

/// <summary>
/// 重命名 ??器
/// <para>ZhangYu 2018-06-21</para>
/// </summary>
//[CanEditMultipleObjects][CustomEditor(typeof(ClassName))]
public class RenameEditor : Editor
{

    // ?制GUI
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        drawProperties();
        if (EditorGUI.EndChangeCheck()) serializedObject.ApplyModifiedProperties();
    }

    // ?制?性
    protected virtual void drawProperty(string property, string label)
    {
        SerializedProperty pro = serializedObject.FindProperty(property);
        if (pro != null) EditorGUILayout.PropertyField(pro, new GUIContent(label), true);
    }

    // ?制所有?性
    protected virtual void drawProperties()
    {
        // ?取?型和可序列化?性
        Type type = target.GetType();
        List<FieldInfo> fields = new List<FieldInfo>();
        FieldInfo[] array = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        fields.AddRange(array);

        // ?取父?的可序列化?性
        while (IsTypeCompatible(type.BaseType) && type != type.BaseType)
        {
            type = type.BaseType;
            array = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            fields.InsertRange(0, array);
        }

        // ?制所有?性
        for (int i = 0; i < fields.Count; i++)
        {
            FieldInfo field = fields[i];

            // 非公有但是添加了[SerializeField]特性的?性
            if (!field.IsPublic)
            {
                object[] serials = field.GetCustomAttributes(typeof(SerializeField), true);
                if (serials.Length == 0) continue;
            }

            // 公有但是添加了[HideInInspector]特性的?性
            object[] hides = field.GetCustomAttributes(typeof(HideInInspector), true);
            if (hides.Length != 0) continue;

            // ?制符合?件的?性
            RenameInEditorAttribute[] atts = (RenameInEditorAttribute[])field.GetCustomAttributes(typeof(RenameInEditorAttribute), true);
            drawProperty(field.Name, atts.Length == 0 ? field.Name : atts[0].name);
        }

    }

    // ?本?型是否符合序列化?件
    protected virtual bool IsTypeCompatible(Type type)
    {
        if (type == null || !(type.IsSubclassOf(typeof(MonoBehaviour)) || type.IsSubclassOf(typeof(ScriptableObject))))
            return false;
        return true;
    }

}