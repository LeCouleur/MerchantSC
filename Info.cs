using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Info : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Player player;
    public TextMeshProUGUI Text;
    public GameObject panelToActivate;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
            Text.text = player.GoldInCities.ToString();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (panelToActivate != null)
        {
            panelToActivate.SetActive(false);
        }
    }
}
