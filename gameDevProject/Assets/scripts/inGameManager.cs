using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameManager : MonoBehaviour
{
    //enemy game object
    [SerializeField] GameObject enemy;
    int enemycount = 0;
    public int maxEnemyCount;

    // locations
    [SerializeField] int minX;
    [SerializeField] int maxX;
    [SerializeField] int minZ;
    [SerializeField] int maxZ;
    [SerializeField] float yPos;
    int xPos;
    int zPos;

    // Time constants
    [SerializeField] float waitTime;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(enemycount< maxEnemyCount)
        {
            xPos = Random.Range(minX, maxX);
            zPos = Random.Range(minZ, maxZ);
            Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            enemycount++;
        }
        

    }
}
