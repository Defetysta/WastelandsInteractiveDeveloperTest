using UnityEngine;

public class SpawningController : MonoBehaviour
{
    [SerializeField]
    private IntVariable desiredActiveObjects = null;
    [SerializeField]
    internal IntVariable enabledAsteroidsCount = null;
    [SerializeField]
    private FloatVariable interval = null;
    [SerializeField]
    private string desiredTag = null;
    private float timer = 0;
    private PoolingManager poolingManager;

    private void Awake()
    {
        poolingManager = FindObjectOfType<PoolingManager>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (desiredActiveObjects.Value > enabledAsteroidsCount.Value && timer >= interval.Value)
        {
            timer = 0f;
            poolingManager.SpawnFromPool(desiredTag);
        }
    }

    public void DisableSpawningObjects()
    {
        desiredActiveObjects.SetValue(0);
    }
}
