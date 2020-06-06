using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private FloatVariable movementSpeed = null;
    private Transform targetToFollow = null;
    private void Start()
    {
        targetToFollow = FindObjectOfType<PlayerMovemement>().gameObject.transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetToFollow.position, movementSpeed.Value * Time.deltaTime);
    }
}
