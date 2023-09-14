using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public static void SpawnAndPlayVFX(ParticleSystem vfxPrefab, Transform spawnPoint, float speedMultiplier, float duration, float scaleFactor, Vector3 rotation)
    {
        ParticleSystem vfxInstance = Instantiate(vfxPrefab, spawnPoint.position, Quaternion.identity);
        vfxInstance.gameObject.SetActive(false);

        var mainModule = vfxInstance.main;
        mainModule.simulationSpeed *= speedMultiplier;
        mainModule.duration = duration;
        vfxInstance.transform.rotation = Quaternion.Euler(rotation);

        vfxInstance.gameObject.SetActive(true);

        // Mengubah skala efek visual berdasarkan scaleFactor
        vfxInstance.transform.localScale = Vector3.one * scaleFactor;

        Destroy(vfxInstance.gameObject, duration + 2f);
    }
}
