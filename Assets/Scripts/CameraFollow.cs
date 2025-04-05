using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("��������")]
    public Transform target;      // Ҫ�������Ҷ���
    public float followSpeed = 5f; // �����ٶ�
    public Vector3 offset = new Vector3(0f, 2f, -5f); // �����ƫ����

    void LateUpdate()
    {
        if (target == null) return;

        // ����Ŀ��λ�ã����λ��+ƫ������
        Vector3 targetPosition = target.position + offset;

        // ƽ���ƶ������
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );

        // ��������������
        transform.LookAt(target);
    }
}