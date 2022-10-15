using UnityEngine;

public class CameraBuilder : ICameraBuilder
{
    public Camera Camera { get; set; }
    public Vector2 Position { get; set; }
    public float CameraAspect { get; set; }
    public float CameraPixelWidth { get; set; }
    public float CameraPixelHeight { get; set; }

    private float GetCameraOrthoSize(float cameraAspect, float pixelWidth, float pixelHeight)
    {
        //depending if landscape or portrait
        if (GameManager.GridWidth > GameManager.GridHeight * cameraAspect)
        {
            return (GameManager.GridWidth / (float)pixelWidth * pixelHeight) / 2;
        }

        return GameManager.GridHeight / 2;
    }

    public void Build()
    {
        Camera.orthographicSize = GetCameraOrthoSize(CameraAspect, CameraPixelWidth, CameraPixelHeight);
        Camera.transform.position = new Vector3(Position.x, Position.y, Camera.transform.position.z);
    }
}
