using UnityEngine;
using UnityEditor;

public class ReadOnlyAttribute : PropertyAttribute
{
}

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float labelWidth = EditorGUIUtility.labelWidth;
        float readOnlyLabelWidth = 70f;
        position.width -= readOnlyLabelWidth;

        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = true;

        Rect readOnlyLabelPosition = new Rect(position.xMax + 5, position.y, readOnlyLabelWidth, position.height);
        EditorGUI.LabelField(readOnlyLabelPosition, "Read Only");
    }
}
