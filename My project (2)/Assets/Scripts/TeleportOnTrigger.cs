using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 用于切换场景

public class TeleportOnTrigger : MonoBehaviour
{
    public string targetSceneName = "Scene2"; // 目标场景名称
    // public Vector3 spawnPosition = new Vector3(0, 1, 0); // 目标场景的出生位置

    private void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Player")) // 确保是玩家触碰
        // {
        //     PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
        //     PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
        //     PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);
        //     PlayerPrefs.Save(); // 保存数据
        //     SceneManager.LoadScene(targetSceneName); // 切换场景
        // }
        SceneManager.LoadScene(targetSceneName); // 切换场景
    }
}