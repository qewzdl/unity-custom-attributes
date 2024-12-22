using UnityEngine;
using UnityEditor;

public class LargeHeaderAttribute : PropertyAttribute
{
    public string header;
    public int fontSize;

    public LargeHeaderAttribute(string header, int fontSize = 13)
    {
        this.header = header;
        this.fontSize = fontSize;
    }
}

[CustomPropertyDrawer(typeof(LargeHeaderAttribute))]
public class LargeHeaderDrawer : DecoratorDrawer
{
    private DividerDrawer dividerDrawer = new DividerDrawer();

    public override void OnGUI(Rect position)
    {
        Rect dividerPosition = new Rect(position.x, position.y, position.width, dividerDrawer.GetHeight());
        dividerDrawer.OnGUI(dividerPosition);

        position.y += dividerDrawer.GetHeight();
        LargeHeaderAttribute largeHeader = (LargeHeaderAttribute)attribute;

        GUIStyle style = new GUIStyle(EditorStyles.boldLabel)
        {
            fontSize = largeHeader.fontSize,
            alignment = TextAnchor.MiddleCenter
        };

        EditorGUI.LabelField(position, largeHeader.header, style);
    }

    public override float GetHeight()
    {
        LargeHeaderAttribute largeHeader = (LargeHeaderAttribute)attribute;

        float baseHeight = base.GetHeight() * (largeHeader.fontSize / 10f);
        float dividerHeight = dividerDrawer.GetHeight();
        float spaceBelow = 10f;

        return baseHeight + dividerHeight + spaceBelow;
    }
}