using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
 
    public GameObject interaction_Info_UI;
    Text interaction_text;

    private GameObject atom;
 
    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<Text>();
    }
 
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
 
            if (selectionTransform.GetComponent<InteractableObject>() && selectionTransform.GetComponent<InteractableObject>().playerInRange)
            {
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else 
            { 
                interaction_Info_UI.SetActive(false);
            }

            if (selectionTransform.tag == "Chemical" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                atom = selectionTransform.GameObject();
                ChemicalAtom atomInfo = atom.GetComponent<ChemicalAtom>();
                atomInfo.AssignInfo();
            }
 
        }
        else
        {
            interaction_Info_UI.SetActive(false);
        }
    }
}

