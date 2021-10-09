using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] gameObject;
    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        int gameObjectAmount = Random.Range(0, 5);
        for (int i = 0; i < gameObjectAmount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            int randomObject = Random.Range(0, gameObject.Length);

            Instantiate(gameObject[randomObject], new Vector2(randomX, randomY), Quaternion.identity);
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(Spawn());
    }
}
