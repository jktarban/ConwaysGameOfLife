using UnityEngine;

public class CameraManager : ICameraManager
{
    private readonly ICameraView _cameraView;
    private readonly ICameraModel _cameraModel;

    public CameraManager(ICameraView cameraView, ICameraModel cameraModel)
    {
        _cameraView = cameraView;
        _cameraModel = cameraModel;
    }

    public void SetPosition(Vector2 position)
    {
        _cameraView.SetPosition(position);
    }
}
