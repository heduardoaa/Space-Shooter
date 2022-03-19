using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerups;
    //    private GameObject _tripleShotPowerupPrefab;

    private bool _stopSpawning = false;
    // Start is called before the first frame update

    public void StartSpawning() 
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // spawn game Object every 6 seconds
    // create a coroutine of type IEnumerator -- Yield Events
    // while loop

    IEnumerator SpawnEnemyRoutine()
    {

        // while loop (infinite loop)
        // Instantiate enemy prefab
        // yield wait for 5 seconds
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);


        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
                yield return new WaitForSeconds(6.0f);
        // every 3- 7 seconds, spawn in a powerup
        while (_stopSpawning == false)
        {
            Vector3 postToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randowPowerUp = Random.Range(0, 3);
            Instantiate(_powerups[randowPowerUp], postToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }

    public void OnPlayerDeath()
    {
        Debug.Log("Has muerto papú");
        _stopSpawning = true;
    }


}
