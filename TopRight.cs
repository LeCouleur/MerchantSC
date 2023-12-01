using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopRight : MonoBehaviour
{
    public GameManager GM;
    public TextMeshProUGUI Date;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Date.text = GM.GetCurrentSeason() + " " + GM.currentYear;
    }
}
