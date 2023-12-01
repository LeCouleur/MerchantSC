using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class topleft : MonoBehaviour
{
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Wagon;
    public TextMeshProUGUI Ship;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(player.Gold % 1 == 0)
        {
            Gold.text = player.Gold.ToString();
        }
        else { 
        Gold.text = player.Gold.ToString("F2");
        }
        Wagon.text = player.WagonNum.ToString();
        Ship.text = player.ShipNum.ToString(); 
    }
}
