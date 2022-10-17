using UnityEngine;

public class CameraView : MonoBehaviour, ICameraView
{
    [SerializeField]
    private Camera _camera;

    public void SetPosition(Vector2 position)
    {
        ICameraBuilder cameraBuilder = new CameraBuilder()
        {
            Camera = _camera,
            Position = position,
            CameraAspect = _camera.aspect,
            CameraPixelWidth = _camera.pixelWidth,
            CameraPixelHeight = _camera.pixelHeight
        };

        cameraBuilder.Build();
    }
}
