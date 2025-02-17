using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // 物品对象
    public GameObject[] items;
    public GameObject teleport_point; // 传送门对象

    // 记录哪些物品被捡起
    private bool[] itemPickedUp;

    void Start()
    {
        // 初始化物品状态数组
        itemPickedUp = new bool[items.Length];
        if (teleport_point != null)
        {
            teleport_point.SetActive(false);
        }
    }

    public void ItemPickedUp(int itemIndex)
    {
        // 标记该物品已被捡起
        itemPickedUp[itemIndex] = true;

        // 检查所有物品是否都已被捡起
        CheckAllItemsPickedUp();
    }

    void CheckAllItemsPickedUp()
    {
        // 检查是否所有物品都被捡起
        foreach (bool pickedUp in itemPickedUp)
        {
            if (!pickedUp)
                return; // 如果有物品还没捡起，则返回
        }

        // 如果所有物品都被捡起，执行特定操作
        PerformSpecialAction();
    }

    void PerformSpecialAction()
    {
        if (teleport_point != null)
        {
            Debug.Log("所有物品已收集，传送门出现！");
            Debug.Log("提示：食材以集齐");
            teleport_point.SetActive(true);
        }
    }
}
