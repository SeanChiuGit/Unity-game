using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // 物品对象
    public GameObject[] items;

    // 记录哪些物品被捡起
    private bool[] itemPickedUp;

    void Start()
    {
        // 初始化物品状态数组
        itemPickedUp = new bool[items.Length];
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
        Debug.Log("所有物品已捡起，执行特定操作！");
        // 在这里添加你希望在所有物品被捡起时执行的操作
    }
}
