using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    public int desiredActiveAsteroids = 15;
    public static int enabledAsteroidsCount = 0;
    private PoolingManager poolingManager;

    private void Awake()
    {
        poolingManager = FindObjectOfType<PoolingManager>();
    }
    private void Update()
    {
        if (desiredActiveAsteroids > enabledAsteroidsCount)
        {
            poolingManager.SpawnFromPool("Asteroids");
        }
    }
}
