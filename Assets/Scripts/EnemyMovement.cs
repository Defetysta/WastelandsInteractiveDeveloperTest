using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

#pragma warning disable 0649
    [SerializeField]
    private FloatVariable movementSpeed;
    private Transform targetToFollow;
#pragma warning restore 0649
    private void Start()
    {
        targetToFollow = FindObjectOfType<PlayerMovemement>().gameObject.transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetToFollow.position, movementSpeed.Value * Time.deltaTime);
    }
}
