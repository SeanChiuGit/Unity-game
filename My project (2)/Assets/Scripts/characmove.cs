using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;          // 角色移动速度
    public float jumpHeight = 5f;     // 跳跃高度
    public float gravity = 30f;     // 重力大小
    public Transform head; // Assign "Head" in the Inspector

    private CharacterController controller;
    private Vector3 velocity;         // 用于处理角色的 y 轴运动（重力 & 跳跃）
    private bool isGrounded;          // 是否接触地面
    private int jumpCount = 0;  // 记录跳跃次数
    private bool canDoubleJump = false;  // 是否解锁二段跳


     void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); // 让 Player 在切换场景时不被销毁
    }


    void Update()
    {
        // 1. 检测是否在地面上
        // isGrounded = Physics.Raycast(transform.position, Vector3.down, controller.height / 2 + 0.1f);
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            jumpCount = 0;  // 重置跳跃次数
        }

        // 2. 处理水平移动（WASD / 方向键）
        float moveX = Input.GetAxis("Horizontal");  // 左右移动 (A/D)
        float moveZ = Input.GetAxis("Vertical");    // 前后移动 (W/S)
        Vector3 move = head.forward * moveZ + head.right * moveX;  // Move relative to the head's forward direction
        controller.Move(move * speed * Time.deltaTime);
        
        // 3. 处理跳跃
        if (Input.GetButtonDown("Jump") && (jumpCount < 1 || (canDoubleJump && jumpCount < 2)))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            jumpCount++;  // 记录跳跃次数
        }

        // 4. 施加重力（让角色下落）
        velocity.y -= gravity * Time.deltaTime;  

        // 5. 应用重力
        controller.Move(velocity * Time.deltaTime);  

        
    }

        // 6. 让外部调用此方法解锁二段跳（例如捡到道具）
        public void UnlockDoubleJump()
        {
            canDoubleJump = true;
        }

}