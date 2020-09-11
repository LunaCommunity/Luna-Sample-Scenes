using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    /// <summary>
    /// Add the prefab for your road into the platform field
    /// z_offset will determine the first platform position distance from the end of the initially instantiated prefabs from platforms
    /// platformSizeZ - this need to be set to the z scale size of the platform you want repeated.
    /// </summary>
    [SerializeField] private Platform platform = null;
    [SerializeField] private CameraMove playerCamera = null;

    [SerializeField] private int platformCount = 10;
    [SerializeField] private int z_Offset = 0;
    [SerializeField] private int platformSizeZ = 20;

    private Queue<Platform> platforms = new Queue<Platform>();
    private Platform popped = null;

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
        popped = platforms.Dequeue();
    }

    void Update()
    {
        if (popped.CheckPosition())
        {
            platforms.Enqueue(popped);
            popped = platforms.Dequeue();
        }
    }
    
    public void PlatformReset(GameObject _platform)
    {
        _platform.transform.position = new Vector3(0, 0, z_Offset);
        z_Offset += platformSizeZ;
    }
   
}
