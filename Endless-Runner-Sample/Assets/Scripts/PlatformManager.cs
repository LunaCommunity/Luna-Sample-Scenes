using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    /// <summary>
    /// Add the prefab for your road into the platform field
    /// z_offset will determine the first platform position distance from the end of the initially instantiated prefabs from platforms
    /// platformSizeZ - this need to be set to the z scale size of the platform you want repeated.
    /// platforms - Queue that contains all instantiated platforms except for the currentPlatform
    /// currentPlatform - this is the platform that is closest to the camera
    /// </summary>
    [SerializeField] private Platform platform = null;
    [SerializeField] private CameraMove playerCamera = null;

    [SerializeField] private int platformCount = 10;
    [SerializeField] private int z_Offset = 0;
    [SerializeField] private int platformSizeZ = 20;

    private Queue<Platform> platforms = new Queue<Platform>();
    private Platform currentPlatform = null;

    /// <summary>
    /// Instantiates the platforms and assigns required references
    /// Adds each platform to the platforms queue
    /// </summary>
    void Start()
    {
        for (int i = 0; i < platformCount; i++)
        {
            Platform _platform = Instantiate(this.platform, new Vector3(0, 0, i * platformSizeZ), Quaternion.identity);
            _platform.PlayerCamera = playerCamera;
            _platform.PlatformManager = this;
            platforms.Enqueue(_platform);
            z_Offset += platformSizeZ;
        }
        // Assign the currentPlatform to the first in the queue 
        currentPlatform = platforms.Dequeue();
    }

    void Update()
    {
        if (currentPlatform.CheckPosition())
        {
            //If CheckPosition succeeds, Enqueue the currentPlatform to add it to the back of the queue
            //Then Dequeue the next platform and assign it to currentPlatform to allow for .CheckPosition to be called on the new currentPlatform
            platforms.Enqueue(currentPlatform);
            currentPlatform = platforms.Dequeue();
        }
    }
    
    /// <summary>
    /// Called when the currentPlatform is behind the camera to move it to the end of the platforms
    /// </summary>
    public void PlatformReset(GameObject _platform)
    {
        _platform.transform.position = new Vector3(0, 0, z_Offset);
        z_Offset += platformSizeZ;
    }
   
}
