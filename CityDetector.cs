using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityDetector : MonoBehaviour
{
    public City City;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ship")
        {
            GameObject ship = collision.gameObject;
            CharacterController CS = ship.GetComponent<CharacterController>();
            CS.currentlyIn = City.cityName;
            CS.currentLocation = City;
        }
    }
}
