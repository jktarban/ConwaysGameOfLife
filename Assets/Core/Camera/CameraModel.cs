public class CameraModel
{
    public float GetCameraOrthoSize(float cameraAspect, float pixelWidth, float pixelHeight)
    {
        if (GameManager.GridWidth > GameManager.GridHeight * cameraAspect)
        {
            return (GameManager.GridWidth / (float)pixelWidth * pixelHeight) / 2;
        }

        return GameManager.GridHeight / 2;
    }
}
