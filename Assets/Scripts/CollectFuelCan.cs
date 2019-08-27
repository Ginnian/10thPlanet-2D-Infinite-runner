using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectFuelCan : MonoBehaviour
{
    public GameObject fuelCan;
    public HeroScript hero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            fuelCan.SetActive(false);
            hero.HealthUp(1);
        }
    }
}
