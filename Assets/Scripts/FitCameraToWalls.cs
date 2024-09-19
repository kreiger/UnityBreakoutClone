using UnityEngine;

public class FitCameraToWalls : MonoBehaviour
{
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        AdjustCameraToFitWalls();
    }

    void AdjustCameraToFitWalls()
    {
        // Get the distance between the left and right walls (horizontal size)
        float horizontalSize = Mathf.Abs(rightWall.position.x - leftWall.position.x) / 2;
        
        // Calculate the vertical size using the top and bottom bounds of the left and right walls
        float leftWallHeight = leftWall.localScale.y;
        float rightWallHeight = rightWall.localScale.y;
        float verticalSize = Mathf.Max(leftWallHeight, rightWallHeight) / 2;

        // Adjust the camera's orthographic size based on the larger size (either fitting width or height)
        cam.orthographicSize = Mathf.Max(verticalSize, horizontalSize / cam.aspect);
    }
}
