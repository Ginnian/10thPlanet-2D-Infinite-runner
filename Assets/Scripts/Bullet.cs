using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            GameObject hero = GameObject.Find("Hero");
            hero.GetComponent<HeroScript>().HealthDown(1);
            Destroy(gameObject);
            Debug.Log("bullet hit hero");
        } else if (collision.gameObject.name != "Trigger" || collision.gameObject.name == "FuelCan" ) {
            Destroy(gameObject);
        }
    }
}
