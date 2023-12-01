using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CityUI : MonoBehaviour
{
    public Transform spawnLoc;
    public GameObject shipPrefab;
    public GameObject wagonPreFab;
    public GameObject Panel;
    public Button createBut;
    public City city;
    public Player player;
    public TextMeshProUGUI Population;
    public TextMeshProUGUI SpicePrice;
    public TextMeshProUGUI SpiceSupply;
    public TextMeshProUGUI CopperPrice;
    public TextMeshProUGUI CopperSupply;
    public TextMeshProUGUI MeatPrice;
    public TextMeshProUGUI MeatSupply;
    public TextMeshProUGUI GunpowderPrice;
    public TextMeshProUGUI GunpowderSupply;
    public TextMeshProUGUI FishPrice;
    public TextMeshProUGUI FishSupply;
    public TextMeshProUGUI LumberPrice;
    public TextMeshProUGUI LumberSupply;
    public TextMeshProUGUI SwordPrice;
    public TextMeshProUGUI SwordSupply;
    public TextMeshProUGUI FruitPrice;
    public TextMeshProUGUI FruitSupply;
    public TextMeshProUGUI WoodPrice;
    public TextMeshProUGUI WoodSupply;
    public TextMeshProUGUI GrainPrice;
    public TextMeshProUGUI GrainSupply;
    public TextMeshProUGUI CannonPrice;
    public TextMeshProUGUI CannonSupply;
    public TextMeshProUGUI ClothPrice;
    public TextMeshProUGUI ClothSupply;
    public TextMeshProUGUI IronPrice;
    public TextMeshProUGUI IronSupply;
    public TextMeshProUGUI CityName;
    public Button BuyBut;
    public GameObject BuyPanel;
    public Button BuyExitButton;
    public Button BuyShipBut;
    public Button BuyWagonBut;
    public Transform WagonSpawnloc;

    public Button exitBut;
    public void SpawnShip()
    {
        GameObject ship = Instantiate(shipPrefab, spawnLoc.position, Quaternion.identity);
        
        // Access the CharacterController component from the ship GameObject
        CharacterController shipController = ship.GetComponent<CharacterController>();

        // Check if the CharacterController component exists before accessing its properties
        if (shipController != null)
        {
            // Set the maxCarriage property
            shipController.maxCarriage = 40;
            player.Ships.Add(shipController);
            shipController.carriageType = "Ship";
        }
        else
        {
            // Handle the case where CharacterController is not found on the ship
            Debug.LogError("CharacterController component not found on the ship.");
        }


    }

    public void SpawnWagon()
    {
        GameObject wagon = Instantiate(wagonPreFab, WagonSpawnloc.position, Quaternion.identity);

        // Access the CharacterController component from the ship GameObject
        CharacterController wagonController = wagon.GetComponent<CharacterController>();

        // Check if the CharacterController component exists before accessing its properties
        if (wagonController != null)
        {
            // Set the maxCarriage property
            wagonController.maxCarriage = 40;
            player.Wagons.Add(wagonController);
            wagonController.carriageType = "Wagon";
        }
        else
        {
            // Handle the case where CharacterController is not found on the ship
            Debug.LogError("CharacterController component not found on the ship.");
        }


    }
    private void OnBuyShipButtonClick()
    {
        SpawnShip();
        player.Gold -= 100;
    }

    private void OnBuyWagonButtonClick()
    {
        SpawnWagon();
        player.Gold -= 50;
    }
    private void OnBuyButtonClick()
    { 
    BuyPanel.SetActive(true);
    }

    private void OnBuyExitButtonClick()
    {
        BuyPanel.SetActive(false);
    }
    private void OnExitButtonClick()
    {
        Panel.SetActive(false);
    }
        // Start is called before the first frame update
        void Start()
    {
        Panel.SetActive(false);
        BuyPanel.SetActive(false);
        exitBut.onClick.AddListener(OnExitButtonClick);
        BuyBut.onClick.AddListener(OnBuyButtonClick);
        BuyShipBut.onClick.AddListener(OnBuyShipButtonClick);
        BuyWagonBut.onClick.AddListener(OnBuyWagonButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("City"))
            {
                City selectedCity = hit.collider.GetComponent<City>();
                city = selectedCity;
                Panel.SetActive(true);
                spawnLoc = selectedCity.spawnLoc;
                WagonSpawnloc = selectedCity.wagonSpawnLoc;
            }
        }    

        if(Panel.activeSelf)
        {
            SpicePrice.text = city.SpicePrice.ToString();
            GrainPrice.text = city.GrainPrice.ToString();
            CannonPrice.text = city.CannonPrice.ToString();
            ClothPrice.text = city.ClothPrice.ToString();  
            CopperPrice.text = city.CopperPrice.ToString();
            FishPrice.text = city.FishPrice.ToString();
            FruitPrice.text = city.FruitPrice.ToString();  
            IronPrice.text = city.IronPrice.ToString();
            GunpowderPrice.text = city.GunPowderPrice.ToString();
            LumberPrice.text = city.LumberPrice.ToString();    
            MeatPrice.text = city.MeatPrice.ToString();
            SwordPrice.text = city.SwordPrice.ToString();   
            WoodPrice.text = city.WoodPrice.ToString();

            CannonSupply.text = city.CannonStock.ToString();
            ClothSupply.text = city.ClothStock.ToString();
            CopperSupply.text = city.CopperStock.ToString();
            FishSupply.text = city.FishStock.ToString();
            FruitSupply.text = city.FruitStock.ToString();
            GrainSupply.text = city.GrainStock.ToString();
            GunpowderSupply.text = city.GunPowderStock.ToString();
            IronSupply.text = city.IronStock.ToString();
            LumberSupply.text = city.LumberStock.ToString();
            MeatSupply.text = city.MeatStock.ToString();
            SpiceSupply.text = city.SpiceStock.ToString();
            SwordSupply.text = city.SwordStock.ToString();
            WoodSupply.text = city.WoodStock.ToString();


            Population.text = city.Population.ToString();


            CityName.text = city.cityName;

            if (BuyPanel.activeSelf)
            {
                if (city.wagonBuyable && player.Gold >= 50)
                {
                    BuyWagonBut.interactable = true;
                }
                else
                {
                    BuyWagonBut.interactable = false;
                }

                if (city.shipBuyable && player.Gold >= 100)
                {
                    BuyShipBut.interactable = true;
                }
                else
                {
                    BuyShipBut.interactable = false;
                }
            }
        }
    }
}
