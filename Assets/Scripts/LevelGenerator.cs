using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int platformCount = 20;
    public float levelSize = 30f;
    public float minHeight = 1f;
    public float maxHeight = 5f;
    public float minSize = 1f;
    public float maxSize = 4f;

    void Start()
    {
        GeneratePlatforms();
    }

    void GeneratePlatforms()
    {
        // ��������
        Material platformMat = new Material(Shader.Find("Standard"));

        for (int i = 0; i < platformCount; i++)
        {
            // ����ƽ̨
            GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platform.name = "Platform_" + i;
            platform.tag = "Ground";

            // ���λ�úʹ�С
            Vector3 position = new Vector3(
                Random.Range(-levelSize, levelSize),
                Random.Range(minHeight, maxHeight),
                Random.Range(-levelSize, levelSize));

            Vector3 scale = new Vector3(
                Random.Range(minSize, maxSize),
                0.5f,
                Random.Range(minSize, maxSize));

            platform.transform.position = position;
            platform.transform.localScale = scale;

            // �����ɫ
            platformMat.color = new Color(
                Random.Range(0.2f, 0.8f),
                Random.Range(0.2f, 0.8f),
                Random.Range(0.2f, 0.8f));

            platform.GetComponent<Renderer>().material = platformMat;

            // �����ײ��
            platform.AddComponent<BoxCollider>();
        }
    }
}