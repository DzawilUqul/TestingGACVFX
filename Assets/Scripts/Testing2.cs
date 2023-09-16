using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing2 : MonoBehaviour
{
    // public ParticleSystem vfxPrefab; // Reference to the VFX prefab
     public Transform spawnPoint;   // Position to spawn the VFX
    // public float speedMultiplier;
    //public float duration;
    // public float scaleFactor;
    // public Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            VFXController.Instance.PlayBuffLoopVFX(spawnPoint);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            VFXController.Instance.StopBuffLoopVFX();
        }
    }
}
