using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteractions : MonoBehaviour {

    NavMeshAgent playersAgent;

    void Start()
    {
        playersAgent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObj = interactionInfo.collider.gameObject;
            if (interactedObj.tag == "InteractableObj")
            {
                interactedObj.GetComponent<Interactable>().MoveToInteraction(playersAgent);
            }
            else
            {
                playersAgent.destination = interactionInfo.point;
            }
        }
    }
}
