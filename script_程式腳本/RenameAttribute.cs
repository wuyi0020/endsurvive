using UnityEngine;
#if UNITY_EDITOR
using System;
using UnityEditor;
using System.Reflection;
using System.Text.RegularExpressions;
#endif

/// <summary>
/// ���R�W?��
/// <para>ZhangYu 2018-06-21</para>
/// </summary>

#if UNITY_EDITOR
[AttributeUsage(AttributeTargets.Field)]
#endif
public class RenameAttribute : PropertyAttribute
{

    /// <summary> �T?�W? </summary>
    public string name = "";
    /// <summary> �奻?�� </summary>
    public string htmlColor = "#ffffff";

    /// <summary> ���R�W?�� </summary>
    /// <param name="name">�s�W?</param>
    public RenameAttribute(string name)
    {
        this.name = name;
    }

    /// <summary> ���R�W?�� </summary>
    /// <param name="name">�s�W?</param>
    /// <param name="htmlColor">�奻?�� �Ҧp�G"#FFFFFF" �� "black"</param>
    public RenameAttribute(string name, string htmlColor)
    {
        this.name = name;
        this.htmlColor = htmlColor;
    }

}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(RenameAttribute))]
public class RenameDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // ��??�ʦW?
        RenameAttribute rename = (RenameAttribute)attribute;
        label.text = rename.name;

        // ��?GUI
        Color defaultColor = EditorStyles.label.normal.textColor;
        EditorStyles.label.normal.textColor = htmlToColor(rename.htmlColor);
        bool isElement = Regex.IsMatch(property.displayName, "Element \\d+");
        if (isElement) label.text = property.displayName;
        if (property.propertyType == SerializedPropertyType.Enum)
        {
            drawEnum(position, property, label);
        }
        else
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
        EditorStyles.label.normal.textColor = defaultColor;
    }

    // ?��T??��
    private void drawEnum(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();

        // ?���T?��??��
        Type type = fieldInfo.FieldType;
        string[] names = property.enumNames;
        string[] values = new string[names.Length];
        Array.Copy(names, values, names.Length);
        while (type.IsArray) type = type.GetElementType();

        // ?���T?��??��RenameAttribute
        for (int i = 0; i < names.Length; i++)
        {
            FieldInfo info = type.GetField(names[i]);
            RenameAttribute[] atts = (RenameAttribute[])info.GetCustomAttributes(typeof(RenameAttribute), true);
            if (atts.Length != 0) values[i] = atts[0].name;
        }

        // ��?GUI
        int index = EditorGUI.Popup(position, label.text, property.enumValueIndex, values);
        if (EditorGUI.EndChangeCheck() && index != -1) property.enumValueIndex = index;
    }

    /// <summary> Html?��???Color </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public static Color htmlToColor(string hex)
    {
        // ??���q??��
        if (string.IsNullOrEmpty(hex)) return new Color(0.705f, 0.705f, 0.705f);

#if UNITY_EDITOR
        // ???��
        hex = hex.ToLower();
        if (hex.IndexOf("#") == 0 && hex.Length == 7)
        {
            int r = Convert.ToInt32(hex.Substring(1, 2), 16);
            int g = Convert.ToInt32(hex.Substring(3, 2), 16);
            int b = Convert.ToInt32(hex.Substring(5, 2), 16);
            return new Color(r / 255f, g / 255f, b / 255f);
        }
        else if (hex == "red")
        {
            return Color.red;
        }
        else if (hex == "green")
        {
            return Color.green;
        }
        else if (hex == "blue")
        {
            return Color.blue;
        }
        else if (hex == "yellow")
        {
            return Color.yellow;
        }
        else if (hex == "black")
        {
            return Color.black;
        }
        else if (hex == "white")
        {
            return Color.white;
        }
        else if (hex == "cyan")
        {
            return Color.cyan;
        }
        else if (hex == "gray")
        {
            return Color.gray;
        }
        else if (hex == "grey")
        {
            return Color.grey;
        }
        else if (hex == "magenta")
        {
            return Color.magenta;
        }
        else if (hex == "orange")
        {
            return new Color(1, 165 / 255f, 0);
        }
#endif

        return new Color(0.705f, 0.705f, 0.705f);
    }

}
#endif

/// <summary>
/// �K�[???��
/// <para>ZhangYu 2018-06-21</para>
/// </summary>
#if UNITY_EDITOR
[AttributeUsage(AttributeTargets.Field)]
#endif
public class TitleAttribute : PropertyAttribute
{

    /// <summary> ??�W? </summary>
    public string title = "";
    /// <summary> �奻?�� </summary>
    public string htmlColor = "#B3B3B3";

    /// <summary> �b?�ʤW��K�[�@??? </summary>
    /// <param name="title">??�W?</param>
    public TitleAttribute(string title)
    {
        this.title = title;
    }

    /// <summary> �b?�ʤW��K�[�@??? </summary>
    /// <param name="title">??�W?</param>
    /// <param name="htmlColor">�奻?�� �Ҧp�G"#FFFFFF" �� "black"</param>
    public TitleAttribute(string title, string htmlColor)
    {
        this.title = title;
        this.htmlColor = htmlColor;
    }

}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(TitleAttribute))]
public class TitleAttributeDrawer : DecoratorDrawer
{

    // �奻?��
    private GUIStyle style = new GUIStyle(EditorStyles.label);

    public override void OnGUI(Rect position)
    {
        // ?��Attribute
        TitleAttribute rename = (TitleAttribute)attribute;
        style.fixedHeight = 18;
        style.normal.textColor = RenameDrawer.htmlToColor(rename.htmlColor);

        // ��?GUI
        position = EditorGUI.IndentedRect(position);
        GUI.Label(position, rename.title, style);
    }

    public override float GetHeight()
    {
        return base.GetHeight() - 3;
    }

}
#endif

/// <summary>
/// ���R�W?��??������?�ʦW?
/// <para>ZhangYu 2018-06-21</para>
/// </summary>
#if UNITY_EDITOR
[AttributeUsage(AttributeTargets.Field)]
#endif
public class RenameInEditorAttribute : PropertyAttribute
{

    /// <summary> �s�W? </summary>
    public string name = "";

    /// <summary> ���R�W?�� </summary>
    /// <param name="name">�s�W?</param>
    public RenameInEditorAttribute(string name)
    {
        this.name = name;
    }

}