public class CameraModel: ICameraModel
{
    public float GetCameraOrthoSize(float cameraAspect, float pixelWidth, float pixelHeight)
    {
        //depending if landscape or portrait
        if (GameManager.GridWidth > GameManager.GridHeight * cameraAspect)
        {
            return (GameManager.GridWidth / (float)pixelWidth * pixelHeight) / 2;
        }

        return GameManager.GridHeight / 2;
    }
}
