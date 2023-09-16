using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public static VFXController Instance { get; set; }

    [SerializeField] private ParticleSystem buffLoopedPrefab;
    private List<ParticleSystem> buffLoopList;

    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        buffLoopList = new List<ParticleSystem>();
    }

    public void SpawnAndPlayVFX(ParticleSystem buffLoopedPrefab, Transform spawnPoint, float speedMultiplier, float duration, float scaleFactor, Vector3 rotation)
    {
        ParticleSystem vfxInstance = Instantiate(buffLoopedPrefab, spawnPoint.position, Quaternion.identity);
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

    public void PlayBuffLoopVFX(Transform spawnPoint)
    {
        ParticleSystem vfxInstance = Instantiate(buffLoopedPrefab, spawnPoint.position, Quaternion.identity);
        buffLoopList.Add(vfxInstance);

        vfxInstance.gameObject.SetActive(true);
    }

    public void StopBuffLoopVFX()
    {
        foreach (ParticleSystem particleSystem in buffLoopList.ToList())
        {
            Destroy(particleSystem.gameObject);
            buffLoopList.Remove(particleSystem);
        }
    }
}
