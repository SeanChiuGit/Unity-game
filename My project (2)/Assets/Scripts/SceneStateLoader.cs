using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 每个场景有一个loader，每当传送到当前场景时 会调用loader
public class SceneStateLoader : MonoBehaviour
{
    // public GameObject player;
    public GameObject[] objectsToTrack;

    void Start()
    {
        if (GameStateManager.instance != null)
        {
            // 1. 恢复玩家位置
            // player.transform.position = GameStateManager.instance.playerPosition;

            // 2. 恢复物品状态
            foreach (var obj in objectsToTrack)
            {
                string objID = obj.name;
                if (GameStateManager.instance.objectStates.ContainsKey(objID))
                {
                    obj.SetActive(GameStateManager.instance.objectStates[objID]);
                }
            }
        }
    }
}
