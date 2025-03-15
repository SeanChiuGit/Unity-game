using UnityEngine;
using System.Collections;

public class TeleportToTeleportedPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 检查是否是玩家触发了传送门
        if (other.CompareTag("Player"))
        {
            TeleportPlayerToTeleportedPoint(other.gameObject);
        }
    }

    private void TeleportPlayerToTeleportedPoint(GameObject player)
    {
        GameObject teleportedPoint = GameObject.FindGameObjectWithTag("Teleported Point");
        Debug.Log("Teleport triggered by player");

        if (teleportedPoint != null)
        {
            Debug.Log("Found Teleported Point at: " + teleportedPoint.transform.position);

            PlayerMovement controller = player.GetComponent<PlayerMovement>();
            CharacterController charController = player.GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.enabled = false;
                Debug.Log("PlayerMovement disabled");
            }

            Vector3 worldPosition = teleportedPoint.transform.position;

            if (charController != null)
            {
                charController.enabled = false; // 先禁用，防止物理更新影响
                charController.transform.position = worldPosition; // 直接修改位置
                charController.enabled = true;  // 重新启用
            }
            else
            {
                player.transform.position = worldPosition;
            }

            Debug.Log("Player teleported to: " + player.transform.position);

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
            controller.enabled = true; // 重新启用PlayerMovement
            Debug.Log("PlayerMovement re-enabled");
        }
    }
}
