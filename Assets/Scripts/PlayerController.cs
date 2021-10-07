using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vertic = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horiz, vertic);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
