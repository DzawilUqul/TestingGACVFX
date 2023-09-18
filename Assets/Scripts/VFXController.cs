using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public static VFXController Instance { get; set; }

    [SerializeField] private ParticleSystem buffLoopedPrefab;
    [SerializeField] private ParticleSystem deBuffLoopedPrefab;
    [SerializeField] private float scaleFactor;
    private List<ParticleSystem> loopParticleList;

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

        loopParticleList = new List<ParticleSystem>();
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
        AddVFXList(buffLoopedPrefab, spawnPoint);
    }

    public void PlayDebuffLoopVFX(Transform spawnPoint)
    {
        AddVFXList(deBuffLoopedPrefab, spawnPoint);
    }

    public void StopBuffLoopVFX()
    {
        foreach (ParticleSystem particleSystem in loopParticleList.ToList())
        {
            Destroy(particleSystem.gameObject);
            loopParticleList.Remove(particleSystem);
        }
    }

    private void AddVFXList(ParticleSystem vFXPrefab, Transform spawnPoint)
    {
        ParticleSystem vfxInstance = Instantiate(vFXPrefab, spawnPoint.position, Quaternion.identity);
        loopParticleList.Add(vfxInstance);

        ResizeVFX();
    }

    private void ResizeVFX()
    {
        foreach (ParticleSystem item in loopParticleList)
        {
            foreach (Transform particleGameObject in item.transform)
            {
                particleGameObject.transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);
            }
        }
    }
}
