using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;
    public float rotationSpeed = 50f;

    void Update()
    {
        // 旋转速度
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("触发碰撞，碰撞对象标签: " + other.tag);  // 添加调试日志
        if (other.CompareTag("Player"))  // 确保玩家对象已设置"Player"标签
        {
            Debug.Log("检测到玩家，添加分数");  // 添加调试日志
            GameManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}