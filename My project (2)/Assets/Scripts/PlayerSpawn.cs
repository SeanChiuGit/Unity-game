using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerSpawn : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 确保 Player 在场景切换时不会被销毁
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 监听场景加载
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 取消监听，防止重复调用
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("Respawn"); // 确保 SpawnPoint 的 Tag 设为 "Respawn"
        Debug.Log("Scene Loaded: " + scene.name);

        if (spawnPoint != null)
        {
            Debug.Log("Found Respawn Point at: " + spawnPoint.transform.position);

            // 获取 PlayerController 并禁用，以防位置被更新覆盖
            PlayerMovement controller = GetComponent<PlayerMovement>();
            if (controller != null)
            {
                controller.enabled = false; 
            }

            // 使用 worldPosition，确保是世界坐标
            Vector3 worldPosition = spawnPoint.transform.position;
            transform.position = worldPosition;

            Debug.Log("Player moved to: " + transform.position);

            // 在下一帧重新启用 PlayerController
            StartCoroutine(EnableControllerAfterDelay(controller));
        }
        else
        {
            Debug.LogWarning("Respawn Point not found! Make sure an object with tag 'Respawn' exists in the scene.");
        }
    }

    private IEnumerator EnableControllerAfterDelay(PlayerMovement controller)
    {
        yield return null; // 等待一帧
        if (controller != null)
        {
            controller.enabled = true; // 重新启用 PlayerController
            Debug.Log("PlayerController re-enabled");
        }
    }
}
