using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (target == null)
            return;
        
        Vector3 desiredPosition = target.position + offset;
        
        float cameraHeight = cam.orthographicSize;
        float cameraWight = cameraHeight * cam.aspect;
        
        
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + cameraWight, maxBounds.x - cameraWight);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + cameraHeight, maxBounds.y - cameraHeight);
        
        float fixedZ = offset.z;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, fixedZ), smoothSpeed);
        transform.position = smoothedPosition;
    }

    
}
