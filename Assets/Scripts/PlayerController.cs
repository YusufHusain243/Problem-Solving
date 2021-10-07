using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float minX, maxX, minY, maxY;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vertic = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horiz, vertic);
        transform.Translate(direction * speed * Time.deltaTime);

        pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);

        if (pos.x > minX && pos.x < maxX && pos.y > minY && pos.y < maxY)
        {
            transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        }
        else
        {
            return;
        }

    }
}
