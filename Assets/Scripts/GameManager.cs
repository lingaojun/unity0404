using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        Debug.Log("正在添加分数: " + value);
        score += value;
        UpdateScoreText();
        SpawnCollectible();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void SpawnCollectible()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-20f, 20f),
            Random.Range(1f, 3f),
            Random.Range(-20f, 20f));

        GameObject collectible = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        collectible.transform.position = spawnPosition;
        collectible.transform.localScale = Vector3.one * 0.5f;
        
        // 确保移除原有的SphereCollider（PrimitiveType.Sphere会自动添加一个）
        Destroy(collectible.GetComponent<SphereCollider>());
        // 添加新的SphereCollider并设置为触发器
        SphereCollider sphereCollider = collectible.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        
        collectible.AddComponent<Collectible>();

        // 设置材质
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = Color.yellow;
        collectible.GetComponent<Renderer>().material = mat;
    }
    void Start()
    {
        SpawnCollectible();
    }
}