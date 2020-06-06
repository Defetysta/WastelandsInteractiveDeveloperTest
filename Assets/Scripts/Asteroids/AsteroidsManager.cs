using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField]
    private int desiredActiveAsteroids = 15;
    internal static int enabledAsteroidsCount = 0;
    private float timer = 0f;
    private float interval = 0.2f;
    private PoolingManager poolingManager;

    private void Awake()
    {
        poolingManager = FindObjectOfType<PoolingManager>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (desiredActiveAsteroids > enabledAsteroidsCount && timer >= interval)
        {
            timer = 0f;
            poolingManager.SpawnFromPool("Asteroids");
        }
    }

    public void DisableSpawningAsteroids()
    {
        desiredActiveAsteroids = 0;
    }
}
