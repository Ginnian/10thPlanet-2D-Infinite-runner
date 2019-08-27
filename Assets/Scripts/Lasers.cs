using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public HeroScript hero;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hero.HealthDown(1);
        Debug.Log("Collided with: " + collision);
    }
}
