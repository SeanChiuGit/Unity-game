using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;          // 角色移动速度
    public float dashSpeed = 40f;      // 冲刺速度
    public float dashDuration = 0.3f;  // 冲刺持续时间
    public float dashCooldown = 1f;    // 冲刺冷却时间
    public float jumpHeight = 5f;      // 跳跃高度
    public float gravity = 30f;        // 重力大小
    public Transform head; // Assign "Head" in the Inspector

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private int jumpCount = 0;
    private bool canDoubleJump = false;
    private bool canDash = false;
    private bool isDashing = false;
    private float dashEndTime = 0f;
    private float lastDashTime = -10f;
    private Vector3 dashDirection;

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
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            jumpCount = 0;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = head.forward * moveZ + head.right * moveX;
        
        // 处理冲刺逻辑
        if (canDash && Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + dashCooldown && !isDashing)
        {
            isDashing = true;
            dashEndTime = Time.time + dashDuration;
            lastDashTime = Time.time;
            dashDirection = head.forward.normalized; // 冲刺方向为当前前方方向
        }
        
        if (isDashing)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
            if (Time.time > dashEndTime)
            {
                isDashing = false;
            }
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && (jumpCount < 1 || (canDoubleJump && jumpCount < 2)))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            jumpCount++;
        }

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void UnlockDoubleJump()
    {
        canDoubleJump = true;
    }

    public void UnlockDash()
    {
        canDash = true;
    }
}
