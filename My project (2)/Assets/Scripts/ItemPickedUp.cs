using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickedUp : MonoBehaviour
{
    public int itemIndex; // 用于区分每个物品的索引
    public int collideRadius;
    public ItemManager itemManager; // 引用物品管理器

    // void OnMouseDown()
    // {
    //     // 当点击物品时，物品消失并通知物品管理器
    //     itemManager.ItemPickedUp(itemIndex);
    //     Destroy(gameObject);
    // }

    // // 如果你想使用触发器检测
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         // 如果物品与标签为"Player"的对象碰撞，物品消失并通知物品管理器
    //         itemManager.ItemPickedUp(itemIndex);
    //         Debug.Log("Picked Item");
    //         Destroy(gameObject);
    //     }
    // }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, collideRadius); // 半径
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                itemManager.ItemPickedUp(itemIndex);
                Debug.Log("Picked Item");
                // Destroy(gameObject);
                gameObject.SetActive(false); // 让当前对象变为 Inactive
                break;
            }
        }
    }
}
