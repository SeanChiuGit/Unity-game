using UnityEngine;
using UnityEditor;

public class MeshColliderCleaner : EditorWindow
{
    [MenuItem("Tools/Clean Up Mesh Colliders")]
    public static void RemoveExtraMeshColliders()
    {
        int cleanedObjects = 0;
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            MeshCollider[] colliders = obj.GetComponents<MeshCollider>();
            if (colliders.Length > 1)
            {
                for (int i = 1; i < colliders.Length; i++)
                {
                    DestroyImmediate(colliders[i]);
                }
                cleanedObjects++;
                Debug.Log($"Removed {colliders.Length - 1} extra Mesh Colliders from '{obj.name}'");
            }
        }

        Debug.Log($"✅ Done! Cleaned {cleanedObjects} object(s).");
    }
}