using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class HighlightCamArrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // required interface when using the OnPointerEnter method.
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlightObject();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        unHighlightObject();
    }

    void highlightObject()
    {
        GetComponent<Image>().color = Color.gray;
    }
    void unHighlightObject()
    {
        GetComponent<Image>().color = Color.white;
    }
}
