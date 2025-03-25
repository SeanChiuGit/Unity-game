using UnityEngine;
using UnityEditor;

public class AddMeshCollidersToScene : MonoBehaviour
{
    [MenuItem("Tools/Add Mesh Colliders To All Scene Objects")]
    static void AddMeshColliders()
    {
        int added = 0;

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            // Ignore inactive objects
            if (!obj.activeInHierarchy)
                continue;

            // Check if it has a MeshFilter and no MeshCollider
            MeshFilter mf = obj.GetComponent<MeshFilter>();
            if (mf != null && mf.sharedMesh != null && obj.GetComponent<MeshCollider>() == null)
            {
                obj.AddComponent<MeshCollider>();
                added++;
            }
        }

        Debug.Log($"✅ Added Mesh Colliders to {added} GameObject(s) in the scene.");
    }
}

