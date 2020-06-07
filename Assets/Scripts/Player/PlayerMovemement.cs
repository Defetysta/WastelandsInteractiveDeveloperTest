using UnityEngine;

public class PlayerMovemement : MonoBehaviour
{
    private const int VOLUME_DIVIDER = 15;
    private string horzAxis = "Horizontal";
    private string vertAxis = "Vertical";
    [SerializeField]
    private AudioSource engineLoudness = null;
    private float currentRotationZ;
    private Quaternion currentRotation;
    private Vector3 desiredPosition;
    private Vector3 desiredVelocity;

    private void Start()
    {
        
    }

    private void Update()
    {
        RotatePlayer();
        MovePlayer();
        ChangeEngineLoudness();
    }

    private void ChangeEngineLoudness()
    {
        engineLoudness.volume = GetRelativeSpeed();
    }

    internal float GetRelativeSpeed()
    {
        return Mathf.Abs(Input.GetAxis(vertAxis) * CONST_VALUES.MAX_VELOCITY_FORWARD) / VOLUME_DIVIDER;
    }

    private void MovePlayer()
    {
        desiredPosition = transform.position;
        desiredVelocity = new Vector3(0, Input.GetAxis(vertAxis) * CONST_VALUES.MAX_VELOCITY_FORWARD * Time.deltaTime, 0);
        desiredPosition += currentRotation * desiredVelocity;
        transform.position = desiredPosition;
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
