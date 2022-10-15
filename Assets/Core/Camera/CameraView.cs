using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    public void SetCamera(float orthoSize, Vector2 cameraPosition)
    {
        _camera.orthographicSize = orthoSize;
        _camera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, _camera.transform.position.z);
    }

    public float GetCameraAspect
    {
        get
        {
            return _camera.aspect;
        }
    }

    public float GetCameraPixelWidth
    {
        get
        {
            return _camera.pixelWidth;
        }
    }

    public float GetCameraPixelHeight
    {
        get
        {
            return _camera.pixelHeight;
        }
    }
}
