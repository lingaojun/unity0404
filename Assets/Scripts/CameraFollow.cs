using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("跟随设置")]
    public Transform target;      // 要跟随的玩家对象
    public float followSpeed = 5f; // 跟随速度
    public Vector3 offset = new Vector3(0f, 2f, -5f); // 摄像机偏移量

    void LateUpdate()
    {
        if (target == null) return;

        // 计算目标位置（玩家位置+偏移量）
        Vector3 targetPosition = target.position + offset;

        // 平滑移动摄像机
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );

        // 让摄像机看向玩家
        transform.LookAt(target);
    }
}