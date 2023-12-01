using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Gold;
    public float GoldInCities;
    public int ShipNum;
    public int WagonNum;
    public List<City> Cities;
    public List<CharacterController> Ships;
    public List<CharacterController> Wagons;
    public City BaseCity;
    // Start is called before the first frame update
    void Start()
    {
        Gold = 1000f;   
    }

    // Update is called once per frame
    void Update()
    {
        foreach(City city in Cities) {
            float num =+ city.PGoldStock;
            GoldInCities = num;
        }

        ShipNum = Ships.Count;
        WagonNum = Wagons.Count;
        if(BaseCity.PGoldStock > 0)
        {
            Gold =+ BaseCity.PGoldStock;
            BaseCity.PGoldStock = 0;    
        }
    }
}
