using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject gameObject;
    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        int gameObjectAmount = Random.Range(0, 10);
        for (int i = 0; i < gameObjectAmount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Instantiate(gameObject, new Vector2(randomX, randomY), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
