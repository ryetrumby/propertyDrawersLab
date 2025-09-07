using UnityEngine;
using System.Linq;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ShapeBehaviour)), CanEditMultipleObjects]
public class ShapeBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Select all cubes"))
            {
                var allCubeBehaviour = GameObject.FindGameObjectsWithTag("Cube");
                var allCubeGameObjects = allCubeBehaviour
                .Select(shape => shape.gameObject)
                .ToArray();
                Selection.objects = allCubeGameObjects;
            }

            if (GUILayout.Button("Select all spheres"))
            {
                var allSphereBehaviour = GameObject.FindGameObjectsWithTag("Sphere");
                var allSphereGameObjects = allSphereBehaviour
                .Select(shape => shape.gameObject)
                .ToArray();
                Selection.objects = allSphereGameObjects;
            }

            if (GUILayout.Button("Clear Selection"))
            {
                Selection.objects = new Object[] 
                {
                    GameObject.FindWithTag("Shape Controller")
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
            }
        GUI.backgroundColor = cachedColor;


        serializedObject.Update();

        var Size = serializedObject.FindProperty("Size");
        if (Size.floatValue < 0)
        {
            EditorGUILayout.HelpBox("Shapes cannot be smaller than 0!", MessageType.Warning);
        }

        serializedObject.ApplyModifiedProperties();
    }
}

public class ShapeBehaviour : MonoBehaviour
{
    [SerializeField]
    float Size;
}
