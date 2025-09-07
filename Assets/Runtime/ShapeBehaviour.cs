using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(ShapeBehaviour)), CanEditMultipleObjects]
public class ShapeBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Select all shapes"))
            {
                var allShapeBehaviour = GameObject.FindObjectsOfType
                <ShapeBehaviour>();
                var allShapeGameObjects = allShapeBehaviour
                .Select(shape => shape.gameObject)
                .ToArray();
                Selection.objects = allShapeGameObjects;
            }

            if (GUILayout.Button("Clear Selection"))
            {
                Selection.objects = new Object[] 
                {
                    (target as ShapeBehaviour).gameObject
                };
            }

        }
        var cachedColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Disable/Enable all shapes", GUILayout.Height(40)))
            {
                foreach (var shape in GameObject.FindObjectsOfType<ShapeBehaviour>(true))
                {
                shape.gameObject.SetActive(!shape.gameObject.activeSelf);
                }
                GUI.backgroundColor = Color.red;
            }
        GUI.backgroundColor = cachedColor;
    }
}
#endif

public class ShapeBehaviour : MonoBehaviour
{
    public class CubeBehaviour
    {
        int size;

    }

    public class SphereBehaviour
    {
        int size;
    }
}
