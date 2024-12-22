using UnityEngine;
using UnityEditor;

public class TitleAttribute : PropertyAttribute
{
    public string text;
    public string fontPath;

    public TitleAttribute(string text, string fontPath = "Assets/Fonts/KarmaticArcade.ttf")
    {
        this.text = text;
        this.fontPath = fontPath;
    }
}

[CustomPropertyDrawer(typeof(TitleAttribute))]
public class TitleAttributeDrawer : DecoratorDrawer
{
    public override float GetHeight()
    {
        return EditorGUIUtility.singleLineHeight * 2;
    }

    public override void OnGUI(Rect position)
    {
        position.y += 15;

        TitleAttribute titleAttribute = (TitleAttribute)attribute;

        Font customFont = AssetDatabase.LoadAssetAtPath<Font>(titleAttribute.fontPath);

        GUIStyle style = new GUIStyle(GUI.skin.label)
        {
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter,
            font = customFont 
        };

        Rect labelPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.LabelField(labelPosition, titleAttribute.text, style);
    }
}
