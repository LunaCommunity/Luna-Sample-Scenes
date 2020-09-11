using UnityEngine;

public class Platform : MonoBehaviour
{

    /// <summary>
    /// Modify this value if the platform moves whilst still in the camera view frustum 
    /// </summary>
    [SerializeField] private float positionOffset = 10;
    
    private PlatformManager platformManager;
    private CameraMove playerCamera = null;

    public PlatformManager PlatformManager
    {
        set => platformManager = value;
    }
    public CameraMove PlayerCamera
    {
        set => playerCamera = value;
    }

    /// <summary>
    /// Called from the platformManager
    /// </summary>
    public bool CheckPosition()
    {
        if (transform.position.z <= playerCamera.transform.position.z-positionOffset)
        {
            platformManager.PlatformReset(gameObject);
            return true;
        }

        return false;
    }
}
