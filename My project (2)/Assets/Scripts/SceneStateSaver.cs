using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 每个场景有一个saver，每当传送到其他场景时 调用saver
public class SceneStateSaver : MonoBehaviour
{
    // public GameObject player;
    public GameObject[] objectsToTrack; // 需要保存状态的物品（例如门、宝箱）

    public void SaveState()
    {
        if (GameStateManager.instance != null)
        {
            // 1. 保存玩家位置
            // GameStateManager.instance.playerPosition = player.transform.position;

            // 2. 保存物品状态
            foreach (var obj in objectsToTrack)
            {
                string objID = obj.name;
                bool isActive = obj.activeSelf; // 物品是否激活（例如门是否打开）
                GameStateManager.instance.objectStates[objID] = isActive;
            }
        }
    }

    void OnDestroy() // 确保离开时保存状态
    {
        SaveState();
    }
}
