using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Tooltips : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text toolTip;
    public TMP_Text button;
    public Upgrade upgrade;
    void Update()
    {
        toolTip.text = upgrade.description;
        button.text = upgrade.upgrade;
    }
    void Start()
    {

        // I added t$$anonymous$$s in case I forgot to set the tooltip object
        if (toolTip != null)
        {
            toolTip.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Same here
        if (toolTip != null)
        {
            toolTip.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // and same here
        if (toolTip != null)
        {
            toolTip.gameObject.SetActive(false);
        }
    }
}