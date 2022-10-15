using UnityEngine;

public interface ICameraBuilder: IBuilder
{
    Camera Camera { get; set; }
    Vector2 Position { get; set; }
    float CameraAspect { get; set; }
    float CameraPixelWidth { get; set; }
    float CameraPixelHeight { get; set; }
}
