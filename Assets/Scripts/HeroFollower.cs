using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollower : MonoBehaviour
{
    public GameObject hero;

    // Update is called once per frame
    void Update()
    {
        if (hero.transform.position.x > transform.position.x)
        {
            transform.position = new Vector2(hero.transform.position.x, -1.95f);
        }
    }
}
