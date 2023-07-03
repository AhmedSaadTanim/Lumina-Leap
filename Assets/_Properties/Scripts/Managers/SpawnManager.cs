using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] prefabList;
    
    [Header ("Coins")]
    [SerializeField] Vector3 coinPos, coinRotation;
    [SerializeField] float[] spawnXLanes;

    Player player;
    bool activateCoins;
    bool shouldSpawn;
    float elapsedTime, duration = 20f;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        shouldSpawn = true;
    }

    private void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;

        float percentage = elapsedTime / duration;
        transform.position = Vector3.Lerp(transform.position, player.playerMovement.endOfPath, percentage);

        if(activateCoins)
        {
            coinPos.z = transform.position.z;
            coinPos.x = spawnXLanes[Random.Range(0, spawnXLanes.Length)];

            coinRotation.z = 90f;
            coinRotation.y = transform.rotation.y + 90f;

            if (shouldSpawn)
            {
                shouldSpawn = false;
                StartCoroutine("SpawnCoins");
            }
        }
    }

    IEnumerator SpawnCoins()
    {
        yield return new WaitForFixedUpdate();
        Instantiate(prefabList[prefabList.Length - 1], coinPos, Quaternion.Euler(coinRotation));
        shouldSpawn = true;
    }

    private void SpawnObjects(Vector3 triggerPos)
    {
       Instantiate(prefabList[GenerateRandomIndex()], triggerPos, Quaternion.identity);
    }

    private int GenerateRandomIndex()
    {
        return Random.Range(0, prefabList.Length-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            SpawnObjects(other.transform.position);
            Destroy(other.gameObject);
        }
        else if (other.name == "CoinTriggerStart")
        {
            activateCoins = true;
            Destroy(other.gameObject);
        }
        else if(other.name == "CoinTriggerEnd")
        {
            activateCoins = false;
            Destroy(other.gameObject);
        }
    }
}
