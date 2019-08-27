using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public GameObject currentPrefab, prefabToMove;
    public GameObject fuelCan, fuelCan1, crate, laser;
    public GameObject hero;
    public float incrementX;

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            Vector3 temp = currentPrefab.transform.position;
            temp.x = temp.x + incrementX;
            prefabToMove.transform.position = temp;

            Random random = new Random();
            int choice = Random.Range(0, 3);
            if (choice == 0)
            {
                fuelCan.SetActive(true);
                fuelCan1.SetActive(true);
                crate.SetActive(true);
                laser.SetActive(false);
            }
            else if (choice == 1)
            {
                fuelCan.SetActive(false);
                fuelCan1.SetActive(true);
                crate.SetActive(true);
                laser.SetActive(true);
            }
        }
    }
}

