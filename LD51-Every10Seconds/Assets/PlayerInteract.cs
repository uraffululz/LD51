using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour {
 
	public bool isInteracting;
	//[SerializeField] bool inInteractArea;
	public GameObject interactableObject;
	public GameObject carriedObject;


    void Start() {
        
    }


    void Update() {
        
    }


	void OnTriggerStay (Collider other) {
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
			//isInteracting = false;
			carriedObject.GetComponent<Interactable>().Disengage();
		}
		else if (!isInteracting && interactableObject != null && carriedObject == null) {
			isInteracting = true;
			interactableObject.GetComponent<Interactable>().Interact();
		}
	}


}
