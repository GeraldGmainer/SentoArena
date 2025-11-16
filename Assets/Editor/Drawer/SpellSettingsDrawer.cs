using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(SpellSettingsBase))]
public class SpellSettingsDrawer : PropertyDrawer {

    private bool uncollapsed = false;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return !uncollapsed ? 32 : 16;
    }

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        //uncollapsed = EditorGUI.Foldout(position, uncollapsed, label);

        //if (uncollapsed) {
            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            var amountRect = new Rect(position.x, position.y + 15, 100, 16);
            var unitRect = new Rect(position.x + 100, position.y + 15, 100, 16);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("animationDuration"), GUIContent.none);
            EditorGUI.Slider(unitRect, property.FindPropertyRelative("nextAnimationCanBeFiredAtPercent"), 0, 1, GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;
        //}

        EditorGUI.EndProperty();

    }
}
