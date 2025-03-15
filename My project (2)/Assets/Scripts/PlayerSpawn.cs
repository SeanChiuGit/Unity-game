using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerSpawn : MonoBehaviour
{
    public float fallThreshold = -100f; // Y 轴低于 -100 认为玩家掉出地图

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

    private void Update()
    {
        // 检测玩家是否掉出地图
        if (transform.position.y < fallThreshold)
        {
            Debug.Log("Player fell off the map! Respawning...");
            RespawnPlayer();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("Respawn"); // 确保 SpawnPoint 的 Tag 设为 "Respawn"
        
        if (spawnPoint != null)
        {
            Debug.Log("Found Respawn Point at: " + spawnPoint.transform.position);

            // 获取 PlayerMovement 并禁用，防止位置被物理系统覆盖
            PlayerMovement controller = GetComponent<PlayerMovement>();
            if (controller != null)
            {
                controller.enabled = false;
                controller.ResetFallingSpeed(); // 复活时重置掉落速度
            }

            // 设置玩家位置
            Vector3 worldPosition = spawnPoint.transform.position;
            transform.position = worldPosition;

            Debug.Log("Player moved to: " + transform.position);

            // 在下一帧重新启用 PlayerMovement
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
            controller.enabled = true; // 重新启用 PlayerMovement
            Debug.Log("PlayerController re-enabled");
        }
    }
}
