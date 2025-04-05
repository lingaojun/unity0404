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
        // 创建材质
        Material platformMat = new Material(Shader.Find("Standard"));

        for (int i = 0; i < platformCount; i++)
        {
            // 创建平台
            GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platform.name = "Platform_" + i;
            platform.tag = "Ground";

            // 随机位置和大小
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

            // 随机颜色
            platformMat.color = new Color(
                Random.Range(0.2f, 0.8f),
                Random.Range(0.2f, 0.8f),
                Random.Range(0.2f, 0.8f));

            platform.GetComponent<Renderer>().material = platformMat;

            // 添加碰撞体
            platform.AddComponent<BoxCollider>();
        }
    }
}