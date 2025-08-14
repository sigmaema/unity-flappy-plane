using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject prefab;           // přetáhni sem svůj prefab v Inspectoru
    public float spawnInterval = 1.5f;  // čas mezi spawny v sekundách

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void Spawn()
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab není nastavený!");
            return;
        }
        Vector3 spawnPos = transform.position;
        spawnPos.y += Random.Range(minHeight, maxHeight);  // posun v ose Y
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

}

