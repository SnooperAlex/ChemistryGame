using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChemicalCardDisplay : MonoBehaviour
{
    public TMP_Text nametext;
    public Image image;

    public void AssignCardInfo(ElementCard card)
    {
        Debug.Log("hehehrerererr");
        nametext.text = card.name;
        image.sprite = card.elementIcon;
    }
    
}
