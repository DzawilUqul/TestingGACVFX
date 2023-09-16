using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
            //call the function from the VFXController script
            //vFXController.SpawnAndPlayVFX(vfxPrefab, spawnPoint, speedMultiplier, duration, scaleFactor, rotation);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            VFXController.Instance.PlayBuffLoopVFX(spawnPoint);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            VFXController.Instance.StopBuffLoopVFX();
        }
    }
}
