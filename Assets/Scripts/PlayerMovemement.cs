using UnityEngine;

public class PlayerMovemement : MonoBehaviour
{
    private string horzAxis = "Horizontal";
    private string vertAxis = "Vertical";
    private float currentRotationZ;
    private Quaternion currentRotation;
    private Vector3 currentPosition;
    private Vector3 desiredVelocity;

    private void Start()
    {
        
    }

    private void Update()
    {
        RotatePlayer();
        MovePlayer();
    }

    private void MovePlayer()
    {
        currentPosition = transform.position;
        desiredVelocity = new Vector3(0, Input.GetAxis(vertAxis) * CONST_VALUES.MAX_VELOCITY_FORWARD * Time.deltaTime, 0);
        currentPosition += currentRotation * desiredVelocity;
        transform.position = currentPosition;
    }

    private void RotatePlayer()
    {
        currentRotation = transform.rotation;
        currentRotationZ = currentRotation.eulerAngles.z;
        currentRotationZ -= Input.GetAxis(horzAxis) * CONST_VALUES.MAX_VELOCITY_ROTATION * Time.deltaTime;
        currentRotation = Quaternion.Euler(0, 0, currentRotationZ);
        transform.rotation = currentRotation;
    }
}
