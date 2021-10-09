using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float minX, maxX, minY, maxY;
    //Vector2 pos;
    public Text scoreText;
    int score;
    public bool canShoot = true;
    WaitForSeconds shootDelay = new WaitForSeconds(0.2f);

    // Start is called before the first frame update
    void Start()
    {
        //pos = transform.position;
        score = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vertic = Input.GetAxis("Vertical");

        if (horiz != 0 || vertic != 0)
        {
            Vector2 direction = new Vector2(horiz, vertic);
            transform.position += transform.up * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.forward , direction);
        }
        else if (horiz == 0 || vertic == 0)
        {
            InputMouse();
        }

        scoreText.text = score.ToString();

        if(speed > 7)
        {
            speed = 7;
        }
    }

    void InputMouse()
    {
        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        if (pos.x > minX && pos.x < maxX && pos.y > minY && pos.y < maxY)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward , pos - transform.position);
            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            pos.z = 1.0f;
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Object" || collision.gameObject.tag == "Speed")
        {
            score += 1;
        }

        if(collision.gameObject.tag == "Speed")
        {
            speed += 2;
            Invoke("normalSpeed", 5.0f);
        }
    }

    void normalSpeed()
    {
        speed = 5.0f;
    }
}
