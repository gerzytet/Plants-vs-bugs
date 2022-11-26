
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverLight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public new GameObject light;

    public void Start()
    {
        light.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        light.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        light.SetActive(false);
    }
}