using UnityEngine;

public class SmoothCameraMovement : MonoBehaviour
{
    //getting player and camera speed set up
    public Transform player;
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        // speed and position of camera
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
