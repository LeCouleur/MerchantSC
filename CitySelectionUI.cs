using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CitySelectionUI : MonoBehaviour
{
    public CharacterController characterController;
    public TextMeshProUGUI loc1Label;
    public TextMeshProUGUI loc2Label;
    public TextMeshProUGUI loc3Label;
    public Button locButton1;
    public Button locButton2;
    public Button locButton3;

    public Button loadButton1;
    public Button loadButton2;
    public Button loadButton3;

    public Button unloadButton1;
    public Button unloadButton2;
    public Button unloadButton3;

    public Button closeButton;
    public CityUI CityUI;
    public GameObject cityUI;
    private City selectedFromCity;
    private City selectedToCity;
    string selectedValue;
    public GameObject Panel;
    public LoadUI loadUI;

    public TextMeshProUGUI carryTxt;
    public TextMeshProUGUI weightTxt;
    public TextMeshProUGUI typeTxt;

    public City LoadCit1;
    public City LoadCit2;
    public City LoadCit3;


    private void Start()
    {
        // Set up button click listeners
        locButton1.onClick.AddListener(() => OnButtonClick(locButton1));
        locButton2.onClick.AddListener(() => OnButtonClick(locButton2));
        locButton3.onClick.AddListener(() => OnButtonClick(locButton3));
        loadButton1.onClick.AddListener(() => OnLoadButtonClick(loadButton1));
        loadButton2.onClick.AddListener(() => OnLoadButtonClick(loadButton2));
        loadButton3.onClick.AddListener(() => OnLoadButtonClick(loadButton3));
        unloadButton1.onClick.AddListener(() => OnUnloadButtonClick(unloadButton1));
        unloadButton2.onClick.AddListener(() => OnUnloadButtonClick(unloadButton2));
        unloadButton3.onClick.AddListener(() => OnUnloadButtonClick(unloadButton3));
        closeButton.onClick.AddListener(OnExitButtonClick);
        Panel.SetActive(false);


    }

    private void OnExitButtonClick()
    {
        Panel.SetActive(false);
    }
    // Start is called before the first frame update


    private void OnButtonClick(Button clickedButton)
    {
        // Make the clicked button interactable
        clickedButton.interactable = true;

        Debug.Log("Button Clicked: " + clickedButton.name);
        // Make the other buttons non-interactable
        if (clickedButton == locButton1)
        {
            locButton2.interactable = false;
            locButton3.interactable = false;
        }
        else if (clickedButton == locButton2)
        {
            locButton1.interactable = false;
            locButton3.interactable = false;
        }
        else if (clickedButton == locButton3)
        {
            locButton1.interactable = false;
            locButton2.interactable = false;
        }
    }


    private void OnLoadButtonClick(Button clickedButton)
    {
        if (clickedButton == loadButton1)
        {
            if (!loadUI.loadPanel.activeSelf)
            {
                loadUI.loadPanel.SetActive(true);
                CityUI.Panel.SetActive(true);
                if (characterController.Order1.cityTo != null)
                {
                    CityUI.city = characterController.Order1.cityTo;
                }
            }


            loadUI.currentOrder = characterController.Order1;
            loadUI.Mode = "Load";
        }

        if (clickedButton == loadButton2)
        {
            if (!loadUI.loadPanel.activeSelf)
            {
                loadUI.loadPanel.SetActive(true);
                CityUI.Panel.SetActive(true);
                if (characterController.Order2.cityTo != null)
                {
                    CityUI.city = characterController.Order2.cityTo;
                }
            }


            loadUI.currentOrder = characterController.Order2;
            loadUI.Mode = "Load";
        }

        if (clickedButton == loadButton3)
        {
            if (!loadUI.loadPanel.activeSelf)
            {
                loadUI.loadPanel.SetActive(true);
                CityUI.Panel.SetActive(true);
                if (characterController.Order3.cityTo != null)
                {
                    CityUI.city = characterController.Order3.cityTo;
                }
            }



            loadUI.currentOrder = characterController.Order3;
            loadUI.Mode = "Load";
        }
    }


    private void OnUnloadButtonClick(Button clickedButton)
    {
        if (clickedButton == unloadButton1)
        {

                loadUI.loadPanel.SetActive(true);
                CityUI.Panel.SetActive(true);
                if (characterController.Order1.cityTo != null)
                {
                    CityUI.city = characterController.Order1.cityTo;
                }
            loadUI.currentOrder = characterController.Order1;
            loadUI.Mode = "Unload";
        }


 

        if (clickedButton == unloadButton2)
        {
           
                loadUI.loadPanel.SetActive(true);
                CityUI.Panel.SetActive(true);
                if (characterController.Order2.cityTo != null)
                {
                    CityUI.city = characterController.Order2.cityTo;
                }
          

            loadUI.currentOrder = characterController.Order2;
            loadUI.Mode = "Unload";
        }

        if (clickedButton == unloadButton3)
        {
         
                loadUI.loadPanel.SetActive(true);
                CityUI.Panel.SetActive(true);
                if (characterController.Order3.cityTo != null)
                {
                    CityUI.city = characterController.Order3.cityTo;
                }
           

            loadUI.currentOrder = characterController.Order3;
            loadUI.Mode = "Unload";
        }

    }

    public void OnCharacterClicked(CharacterController clickedCharacter)
    {
        // Implement your logic here
        Debug.Log("Character Clicked: " + clickedCharacter.gameObject.name);
        // You can access the properties of the clickedCharacter and perform actions accordingly
        // Example: clickedCharacter.addOrder("FromCity", "ToCity", "SomeValue");
        Panel.SetActive(true);
        characterController = clickedCharacter;
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

    private void Update()
    {
        if (characterController != null)
        {
            if (characterController.Order1.hasSet == true)
            {
                loc1Label.text = characterController.Order1.To;
                LoadCit1 = characterController.Order1.cityTo;
                loadButton1.interactable = true;
            }
            else
            {
                loc1Label.text = "";
                loadButton1.interactable = false;
            }
            if (characterController.Order2.hasSet == true)
            {
                loc2Label.text = characterController.Order2.To;
                LoadCit1 = characterController.Order2.cityTo;
                loadButton2.interactable = true;
            }
            else
            {
                loc2Label.text = "";
                loadButton2.interactable = false;
            }
            if (characterController.Order3.hasSet == true)
            {
                loc3Label.text = characterController.Order3.To;
                LoadCit1 = characterController.Order3.cityTo;
                loadButton3.interactable = true;
            }
            else
            {
                loc3Label.text = "";
                loadButton3.interactable = false;
            }
        }
        if (Panel.activeSelf)
        {

            carryTxt.text = characterController.Type;
            weightTxt.text = characterController.Carriage + "/" + characterController.maxCarriage;
            typeTxt.text = characterController.carriageType;
        }



        // Check for mouse click
        if (Panel.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
                if (!IsMouseOverUI())
                {
                    if (hit.collider != null && hit.collider.CompareTag("City"))
                    {
                        cityUI.SetActive(false);
                        City selectedCity = hit.collider.GetComponent<City>();
                        if (!locButton1.interactable || !locButton2.interactable || !locButton3.interactable)
                        {
                            if (selectedCity != null)
                            {
                                if (locButton1.interactable && selectedCity != selectedToCity)
                                {
                                    selectedFromCity = selectedCity;
                                    loc1Label.text = selectedCity.cityName;

                                    if (characterController.carriageType == "Ship")
                                    {
                                        locButton1.GetComponentInChildren<TextMeshProUGUI>().text = selectedCity.cityName;
                                        locButton1.interactable = true;
                                        locButton2.interactable = true;
                                        locButton3.interactable = true;
                                        characterController.Order1.To = selectedCity.cityName;
                                        characterController.Order1.cityTo = selectedCity;
                                        characterController.Order1.hasSet = true;
                                    }
                                    else if (characterController.carriageType == "Wagon")
                                    {
                                        if (selectedCity.wagonAccessible)
                                        {
                                            locButton1.GetComponentInChildren<TextMeshProUGUI>().text = selectedCity.cityName;
                                            locButton1.interactable = true;
                                            locButton2.interactable = true;
                                            locButton3.interactable = true;
                                            characterController.Order1.To = selectedCity.cityName;
                                            characterController.Order1.cityTo = selectedCity;
                                            characterController.Order1.hasSet = true;
                                        }
                                    }
                                }
                                else if (locButton2.interactable && selectedCity != selectedFromCity)
                                {
                                    if (characterController.carriageType == "Ship")
                                    {
                                        selectedToCity = selectedCity;
                                        loc2Label.text = selectedCity.cityName;
                                        locButton2.GetComponentInChildren<TextMeshProUGUI>().text = selectedCity.cityName;
                                        locButton1.interactable = true;
                                        locButton2.interactable = true;
                                        locButton3.interactable = true;
                                        characterController.Order2.To = selectedCity.cityName;
                                        characterController.Order2.cityTo = selectedCity;
                                        characterController.Order2.hasSet = true;
                                    }
                                    else if (characterController.carriageType == "Wagon")
                                    {
                                        if (selectedCity.wagonAccessible)
                                        {
                                            selectedToCity = selectedCity;
                                            loc2Label.text = selectedCity.cityName;
                                            locButton2.GetComponentInChildren<TextMeshProUGUI>().text = selectedCity.cityName;
                                            locButton1.interactable = true;
                                            locButton2.interactable = true;
                                            locButton3.interactable = true;
                                            characterController.Order2.To = selectedCity.cityName;
                                            characterController.Order2.cityTo = selectedCity;
                                            characterController.Order2.hasSet = true;
                                        }

                                    }
                                }
                                else if (locButton3.interactable && selectedCity != selectedFromCity)
                                {
                                    if (characterController.carriageType == "Ship")
                                    {
                                        selectedToCity = selectedCity;
                                        loc3Label.text = selectedCity.cityName;
                                        locButton3.GetComponentInChildren<TextMeshProUGUI>().text = selectedCity.cityName;
                                        locButton1.interactable = true;
                                        locButton2.interactable = true;
                                        locButton3.interactable = true;
                                        characterController.Order3.To = selectedCity.cityName;
                                        characterController.Order3.cityTo = selectedCity;
                                        characterController.Order3.hasSet = true;
                                    }
                                    else if (characterController.carriageType == "Wagon")
                                    {
                                        if (selectedCity.wagonAccessible)
                                        {
                                            selectedToCity = selectedCity;
                                            loc3Label.text = selectedCity.cityName;
                                            locButton3.GetComponentInChildren<TextMeshProUGUI>().text = selectedCity.cityName;
                                            locButton1.interactable = true;
                                            locButton2.interactable = true;
                                            locButton3.interactable = true;
                                            characterController.Order3.To = selectedCity.cityName;
                                            characterController.Order3.cityTo = selectedCity;
                                            characterController.Order3.hasSet = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}