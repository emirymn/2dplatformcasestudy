using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaccleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaccle, spawner;
    IEnumerator Start()
    {
        while (true)
        {
            Vector3 randomSpawnTransform = new Vector3(spawner.transform.position.x, spawner.transform.position.y + Random.Range(-2f, 2f), spawner.transform.position.z);
            Instantiate(obstaccle, randomSpawnTransform, spawner.transform.rotation);
            yield return new WaitForSeconds(3f);
        }
    }


}
