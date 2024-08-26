using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pulpit : MonoBehaviour
{
    public Transform[] spawnPoints;       // Array of spawn points for pulpits
    public GameObject pulpitPrefab;       // Pulpit prefab to spawn

    public float minPulpitDestroyTime = 4f;  // Minimum time before a pulpit is destroyed
    public float maxPulpitDestroyTime = 5f;  // Maximum time before a pulpit is destroyed
    public float pulpitSpawnInterval = 2.5f; // Time interval between spawning pulpits

    private int activePulpits = 0;        // Number of active pulpits
    private int maxPulpits = 2;           // Maximum number of pulpits allowed at once

    void Start()
    {
        // Start spawning pulpits at regular intervals
        StartCoroutine(SpawnPulpits());
    }

    IEnumerator SpawnPulpits()
    {
        while (true)
        {
            // Only spawn if we have fewer than the maximum number of pulpits
            if (activePulpits < maxPulpits)
            {
                SpawnPulpit();
            }

            // Wait for the next spawn interval before spawning again
            yield return new WaitForSeconds(pulpitSpawnInterval);
        }
    }

    void SpawnPulpit()
    {
        // Select a random spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate the pulpit at the selected spawn point
        GameObject pulpit = Instantiate(pulpitPrefab, spawnPoint.position, spawnPoint.rotation);
        activePulpits++;

        // Set a random time for the pulpit to be destroyed
        float destroyTime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);
        StartCoroutine(DestroyPulpitAfterTime(pulpit, destroyTime));
    }

    IEnumerator DestroyPulpitAfterTime(GameObject pulpit, float delay)
    {
        // Wait for the specified time before destroying the pulpit
        yield return new WaitForSeconds(delay);
        Destroy(pulpit);
        activePulpits--;
    }
}
