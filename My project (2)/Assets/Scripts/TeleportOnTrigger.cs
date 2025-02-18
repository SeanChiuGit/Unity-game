using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 用于切换场景

public class TeleportOnTrigger : MonoBehaviour
{
    public string targetSceneName = "Scene2"; // 目标场景名称

    private void OnTriggerEnter(Collider other)
    {
        SceneStateSaver saver = FindObjectOfType<SceneStateSaver>();
        if (saver != null) 
        {
            saver.SaveState();
        }
        else 
        {
            Debug.LogWarning("SceneStateSaver not found! Skipping SaveState.");
        }
        SceneManager.LoadScene(targetSceneName); // 切换场景
    }
}