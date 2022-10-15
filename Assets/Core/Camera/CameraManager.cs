using UnityEngine;

public class CameraManager : ICameraManager
{
    private readonly CameraView _cameraView;
    private readonly CameraModel _cameraModel;

    public CameraManager(CameraView cameraView, CameraModel cameraModel)
    {
        _cameraView = cameraView;
        _cameraModel = cameraModel;
    }

    public void SetPosition(Vector2 position)
    {
        _cameraView.SetCamera(_cameraModel.GetCameraOrthoSize(_cameraView.GetCameraAspect, _cameraView.GetCameraPixelWidth, _cameraView.GetCameraPixelHeight), position);
    }
}
