using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
public class CharacterController : MonoBehaviour
{
    public Transform[] waypoints; // Assign waypoints in the Inspector.
    public float speed = 5f;
    private int currentWaypoint = 0;
    public string From;
    public string To;
    public string combinedName;
    public bool hasBeenSet;
    private Animator animator;
    public string Type;
    public float maxCarriage;
    public float neededSupplies;
    public float Food;
    public bool onLoop;
    public float Carriage;
    public City currentLocation;
    public Order Order1;
    public Order Order2;
    public Order Order3;
    public CitySelectionUI shipUI;
    public Order currentOrder;
    public int orderID;
    public string currentlyIn;
    Vector3 moveDirection;
    public Player Player;
    public string carriageType;
    public CityUI cityUI;
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject citySelectionCanvas = GameObject.Find("CitySelectionCanvas");
        currentOrder = Order1;
        orderID = 1;

        GameObject player = GameObject.Find("Player");

        Player = player.GetComponent<Player>();
        // Check if the GameObject is found and has the CitySelectionUI component
        if (citySelectionCanvas != null)
        {
            shipUI = citySelectionCanvas.GetComponent<CitySelectionUI>();
        }
        else
        {
            Debug.LogWarning("CitySelectionCanvas not found!");
        }

    }

    void Update()
    {

        
        if (hasBeenSet == false)
        {
            if (currentOrder == Order1 && Order1.hasSet == true)
            {
                
                orderID = 1;
                if (Order1.To != null && Order2.To != null && Order1.hasSet == true && Order2.hasSet == true)
                {

                    setWaypoint(currentlyIn, Order1.To);
                }
            }

            if (currentOrder == Order2)
            {
                orderID = 2;
                if (Order2.To != null && Order3.To != null && Order2.hasSet == true && Order3.hasSet == true)
                {
                    setWaypoint(currentlyIn, Order2.To);
                }
                else if (Order2.To != null && Order2.hasSet == true && Order1.hasSet == true)
                {
                    setWaypoint(currentlyIn, Order2.To);
                    Debug.LogWarning("Has Set");
                    
                }
            }

            if(Order3.hasSet)
            if (currentOrder == Order3)
            {
                
                orderID = 3;
                if (Order3.To != null && Order1.To != null && Order3.hasSet == true)
                {
                    setWaypoint(currentlyIn, Order3.To);
                }


            }
        }

        animator.SetFloat("moveX", moveDirection.normalized.x);
        animator.SetFloat("moveY", moveDirection.normalized.y);

        if (currentWaypoint < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypoint].position;
            moveDirection = targetPosition - transform.position;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypoint++;
            }
        }
        else if (waypoints.Length > 0)
        {
         //ADD A METHOD TO CURRENT LOCATION WITH A SWITCH TO ADD A TYPE OF LOAD AND UNLOAD STUFF. YOU GET IT
        

         if(currentOrder.unload  == true)
            {
                Unload(currentLocation, currentOrder);
                Debug.LogError("Called");
            }

            if (currentOrder.load == true)
            {
                Load(currentLocation, currentOrder);
            }

            Debug.Log("Reached end of waypoints. orderID: " + orderID);

            switch (orderID)
            {
                case 1:
                    currentOrder = Order2;
                    break;
                case 2:
                    if (Order3.hasSet == true)
                    {
                        currentOrder = Order3;
                    }
                    else { currentOrder = Order1; }
                    break;
                case 3:
                    currentOrder = Order1;
                    break;
                default:
                    Debug.LogWarning("Invalid orderID");
                    break;
            }
            currentWaypoint = 0;
            hasBeenSet = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Perform a hit check
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);

            // Iterate through all hits
            foreach (RaycastHit2D hit in hits)
            {
                Debug.LogWarning("Hit object: " + hit.collider.gameObject.name);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    if (hit.collider.gameObject.tag == "Ship")
                    {
                        Debug.LogWarning("It hit");
                        // Check if the object has shipUI
                        CharacterController CS = hit.collider.gameObject.GetComponent<CharacterController>();

                        CitySelectionUI shipUIComponent = CS.shipUI;
                        if (shipUIComponent != null)
                        {
                            // Handle the click on the object
                            shipUIComponent.OnCharacterClicked(this);
                            return; // Exit the loop if a valid hit is found
                        }
                        else
                        {
                            Debug.LogWarning("ShipUI is not assigned!");
                        }
                    }
                    else if(hit.collider.gameObject.tag == "City")
                    {
                        City city = hit.collider.gameObject.GetComponent<City>();

                        cityUI.Panel.SetActive(true);
                        cityUI.city = city;
                    }
                }
            }
        }





    }

    public void addOrder(string from, string to, string value)
    {

    }
    

    private bool IsMouseOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                // The object has the "UI" layer
                return true;
            }
        }

        return false;
    }

    private void Load(City city, Order order)
    {

        Debug.Log("Called");
        if(city == order.cityTo)
        {
            Debug.LogError("Called the fucker");
            city.Load(order.loadtype, maxCarriage, this);
        }
    }

    private void Unload(City city, Order order) {
        if (city == order.cityTo)
        {
            Debug.LogError("Called the fucker2");
            city.Unload(order.unloadtype, Carriage, this);
        }
    }

    private void setWaypoint(string from, string to)
    {
        if (from != null && to != null)
        {

            if (hasBeenSet == false)
            {

                if(from == to)
                {

                    if (currentOrder.unload == true)
                    {
                        Unload(currentLocation, currentOrder);
                    }

                    if (currentOrder.load == true)
                    {
                        Load(currentLocation, currentOrder);
                        
                    }


                    switch (orderID)
                    {
                        case 1:
                            currentOrder = Order2;
                            break;
                        case 2:
                            if (Order3.hasSet == true)
                            {
                                currentOrder = Order3;
                            }
                            else { currentOrder = Order1; }
                            break;
                        case 3:
                            currentOrder = Order1;
                            break;
                        default:
                            Debug.LogWarning("Invalid orderID");
                            break;
                    }

                    return;
                }
                if(carriageType == "Ship") { 
                combinedName = from + "to" + to;
                Debug.Log(combinedName);
                Debug.Log(from + ",first " + to);
                GameObject parentObject = GameObject.Find(combinedName);
                if (parentObject != null)
                {
                    hasBeenSet = true;
                    // Get an array of all child transforms, including nested children.
                    waypoints = new Transform[0];
                    waypoints = parentObject.GetComponentsInChildren<Transform>(true);

                    // Exclude the parent's transform from the array (optional).
                    waypoints = waypoints.Where(t => t != parentObject.transform).ToArray();



                }
                else
                {
                    // Handle the case where the parent GameObject was not found.

                    combinedName = to + "to" + from;
                    parentObject = GameObject.Find(combinedName);
                    Debug.Log(combinedName);
                    Debug.Log(from + ",second " + to);
                    if (parentObject != null)
                    {
                        hasBeenSet = true;
                        waypoints = new Transform[0];
                        // Get an array of all child transforms, including nested children.
                        waypoints = parentObject.GetComponentsInChildren<Transform>(true);

                        // Exclude the parent's transform from the array (optional).
                        waypoints = waypoints.Where(t => t != parentObject.transform).ToArray();

                        // Reverse the array in-place.
                        Array.Reverse(waypoints);
                    }

                    else
                    {
                        Debug.Log("Parent GameObject with the name 'ParentObjectName' not found.");
                    }
                }
            }
                else if(carriageType == "Wagon")
                {
                    combinedName = from + "to" + to + "wagon";
                    Debug.Log(combinedName);
                    Debug.Log(from + ",first " + to);
                    GameObject parentObject = GameObject.Find(combinedName);
                    if (parentObject != null)
                    {
                        hasBeenSet = true;
                        // Get an array of all child transforms, including nested children.
                        waypoints = new Transform[0];
                        waypoints = parentObject.GetComponentsInChildren<Transform>(true);

                        // Exclude the parent's transform from the array (optional).
                        waypoints = waypoints.Where(t => t != parentObject.transform).ToArray();



                    }
                    else
                    {
                        // Handle the case where the parent GameObject was not found.

                        combinedName = to + "to" + from + "wagon";
                        parentObject = GameObject.Find(combinedName);
                        Debug.Log(combinedName);
                        Debug.Log(from + ",second " + to);
                        if (parentObject != null)
                        {
                            hasBeenSet = true;
                            waypoints = new Transform[0];
                            // Get an array of all child transforms, including nested children.
                            waypoints = parentObject.GetComponentsInChildren<Transform>(true);

                            // Exclude the parent's transform from the array (optional).
                            waypoints = waypoints.Where(t => t != parentObject.transform).ToArray();

                            // Reverse the array in-place.
                            Array.Reverse(waypoints);
                        }

                        else
                        {
                            Debug.Log("Parent GameObject with the name 'ParentObjectName' not found.");
                        }
                    }
                }
            }
        }
    }
}
