using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab = null;
    public Transform spawn = null;
    public float minTime = 3.0f;
    public float maxTime = 4.0f;



    private void Start()
    {
        InvokeRepeating("SpawnObstacle", Random.Range(minTime, maxTime),200);
       
    }
    private void SpawnObstacle()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = new Vector3(spawn.position.x, spawn.position.y, spawn.position.z);
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }
}
