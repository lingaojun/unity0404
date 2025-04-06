using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerZombieController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public float gravity = -9.81f;
    
    private Vector3 playerVelocity;
    private Vector2 moveInput;
    private Transform mainCamera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main.transform;
        
        // 锁定并隐藏鼠标
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleGravity();
        UpdateAnimations();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            moveInput = context.ReadValue<Vector2>();
            Debug.Log($"Move Input: {moveInput}");
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveInput = Vector2.zero;
        }
    }


    void HandleMovement()
    {
        // 获取相机前方和右方向
        Vector3 forward = mainCamera.forward;
        Vector3 right = mainCamera.right;
        
        // 将y轴分量设为0，保持在水平面上移动
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // 计算移动方向
        Vector3 moveDirection = (forward * moveInput.y + right * moveInput.x).normalized;

        if (moveDirection != Vector3.zero)
        {
            // 计算目标旋转
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            
            // 平滑旋转
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            // 移动角色
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    void HandleGravity()
    {
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void UpdateAnimations()
    {
        if (animator != null)
        {
            // 根据移动输入设置动画
            bool isMoving = moveInput.magnitude > 0;
            animator.SetBool("IsWalking", isMoving);
        }
    }
} 