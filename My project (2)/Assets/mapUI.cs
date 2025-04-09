using UnityEngine;

public class MapToggle : MonoBehaviour
{
    [SerializeField] private GameObject mapUI;  // 指向刚才的 Image 对象或其父 Canvas

    void Update()
    {
        // 监听 M 键
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 切换地图激活
            bool isActive = mapUI.activeSelf;
            mapUI.SetActive(!isActive);
        }
    }
}