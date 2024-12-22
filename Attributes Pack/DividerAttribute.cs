using UnityEngine;
using UnityEditor;

public class DividerAttribute : PropertyAttribute
{
}

[CustomPropertyDrawer(typeof(DividerAttribute))]
public class DividerDrawer : DecoratorDrawer
{
    public override float GetHeight()
    {
        return 4;
    }

    public override void OnGUI(Rect position)
    {
        position.y += 10;
        position.height = 1;
        EditorGUI.DrawRect(position, Color.gray);
    }
}
