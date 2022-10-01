using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour {
 
	[SerializeField] bool isInteracting;
	//[SerializeField] bool inInteractArea;
	[SerializeField] GameObject interactableObject;


    void Start() {
        
    }


    void Update() {
        
    }


	void OnTriggerEnter (Collider other) {
		//inInteractArea = true;
		if (other.CompareTag("Pickup")) {
			interactableObject = other.gameObject;
		}
	}


	void OnTriggerExit (Collider other) {
		//inInteractArea = false;
		if (other.CompareTag("Pickup")) {
			interactableObject = null;
		}
	}


	void OnInteract(InputValue pkp) {
		if (isInteracting) {
			isInteracting = false;
			interactableObject.GetComponent<Interactable>().Disengage();
		}
		else if (!isInteracting && interactableObject != null) {
			isInteracting = true;
			interactableObject.GetComponent<Interactable>().Interact();
		}
	}


}
