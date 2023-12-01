using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipUI : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Set the initial value (optional)
        OnDropdownValueChanged(dropdown.value);
    }


    private void OnDropdownValueChanged(int index)
    {
        // Respond to the dropdown value change
        string selectedValue = dropdown.options[index].text;

        // Use 'selectedValue' as needed
        Debug.Log("Selected Value: " + selectedValue);
    }



    void Update()
    {
        
    }
}
