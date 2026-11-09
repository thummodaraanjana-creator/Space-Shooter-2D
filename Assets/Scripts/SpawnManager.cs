using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject[] _powerupPrefabs;
    void Start()
    {
        StartCoroutine(SpawnEnemies());//start spawning enemies
        StartCoroutine(SpawnPowerups());//start spawning powerups

    }//start

    
    void Update()
    {
        
    }//update

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(5.0f);
        float randomX = Random.Range(-8f, 8f);
        Instantiate(_enemyPrefab, new Vector3(randomX, 8f, 0), Quaternion.identity);

        StartCoroutine(SpawnEnemies());
    }//spawn enemies at random x position every 5 seconds

    private IEnumerator SpawnPowerups()
    {
        yield return new WaitForSeconds(5.0f);
        float randomX = Random.Range(-8f, 8f);
        int randomPowerup = Random.Range(0, _powerupPrefabs.Length);
        Instantiate(_powerupPrefabs[randomPowerup], new Vector3(randomX, 8f, 0), Quaternion.identity);
        StartCoroutine(SpawnPowerups());
    }//spawn powerups at random x position every 5 seconds
}//class
