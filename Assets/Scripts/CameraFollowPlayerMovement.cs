using UnityEngine;

public class CameraFollowPlayerMovement : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject targetToFollow;
#pragma warning restore 0649
    private void Update()
    {
        if (targetToFollow == null)
            return;
        transform.position = Vector2.Lerp(transform.position, targetToFollow.transform.position, Time.deltaTime * speed);
    }
    public float speed = 15;
}
