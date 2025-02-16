using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint"); // 在新场景查找 "SpawnPoint"
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position; // 传送到该点
        }
    }
}

