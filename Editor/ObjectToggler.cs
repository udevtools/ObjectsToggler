using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class ObjectToggler
{
    static ObjectToggler()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
    }

    static void OnHierarchyWindowItemOnGUI(int instanceId, Rect rect)
    {
        GameObject go = (GameObject)EditorUtility.InstanceIDToObject(instanceId);

        if (go == null) return;

        Rect toggle = new Rect(rect);
        bool active = EditorGUI.Toggle(rect, go.activeSelf);

        if (active != go.activeSelf)
            go.SetActive(active);
    }
}
