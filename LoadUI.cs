using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadUI : MonoBehaviour
{
    public GameObject loadPanel;
    public string Mode;
    public Button Iron;
    public Button Gold;
    public Button Copper;
    public Button Fish;
    public Button Meat;
    public Button GunPowder;
    public Button Wood;
    public Button Lumber;
    public Button Spice;
    public Button Fruit;
    public Button Cloth;
    public Button Cannon;
    public Button Sword;
    public Button Grain;
    public Order currentOrder;
    public TextMeshProUGUI Text;
    public Button exitBut;

    private Dictionary<string, Button> objectButtons = new Dictionary<string, Button>();

    private void OnExitButtonClick()
    {
         loadPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        objectButtons.Add("Iron", Iron);
        objectButtons.Add("Gold", Gold);
        objectButtons.Add("Copper", Copper);
        objectButtons.Add("Fish", Fish);
        objectButtons.Add("Meat", Meat);
        objectButtons.Add("GunPowder", GunPowder);
        objectButtons.Add("Wood", Wood);
        objectButtons.Add("Lumber", Lumber);
        objectButtons.Add("Spice", Spice);
        objectButtons.Add("Fruit", Fruit);
        objectButtons.Add("Cloth", Cloth);
        objectButtons.Add("Cannon", Cannon);
        objectButtons.Add("Sword", Sword);
        objectButtons.Add("Grain", Grain);
        exitBut.onClick.AddListener(OnExitButtonClick);

        loadPanel.SetActive(false);

        foreach (var kvp in objectButtons)
        {
            Button button = kvp.Value;
            string objectName = kvp.Key;

            button.onClick.AddListener(() => OnButtonClick(objectName));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mode == "Load")
        {
            Text.text = "Load";

            string but = currentOrder.loadtype;
            UpdateButtonInteractability(but);
        }
        if (Mode == "Unload")
        {
            Text.text = "Unload";
            string but = currentOrder.unloadtype;
            UpdateButtonInteractability(but);
        }

        
    }

    // Use this method to handle button clicks directly
    public void OnButtonClick(string objectType)
    {
        // Perform actions on the object
        HandleObject(objectType);

        // Update button interactability
        UpdateButtonInteractability(objectType);

        Debug.Log(objectType + "clicked");
    }

    void HandleObject(string objectType)
    {
        if (Mode == "Load")
        {
            currentOrder.load = true;
            currentOrder.loadtype = objectType;
        }

        if (Mode == "Unload")
        {
            currentOrder.unload = true;
            currentOrder.unloadtype = objectType;
        }
    }

    private void UpdateButtonInteractability(string chosenObject)
    {
        foreach (var kvp in objectButtons)
        {
            string objectName = kvp.Key;
            Button button = kvp.Value;

            if (objectName == chosenObject)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }
}
    