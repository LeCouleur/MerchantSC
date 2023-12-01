using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelUI : MonoBehaviour
{
    public Button closeButton;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnExitButtonClick()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
