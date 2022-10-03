using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Pickup : Interactable {

	[SerializeField] DimensionManager DManager;
	GameObject player;
	Transform pickupPos;
	Animator anim;
	PlayerInteract playerInteract;

	public string itemName;
	SphereCollider areaCol;
	[SerializeField] float areaSize;
	
	[Header("Deposit", order = 0)]
	[SerializeField] GameObject myDeposit;
	[SerializeField] Transform depositPos;
	[SerializeField] bool canDeposit;
	[SerializeField] bool deposited;

	[Header("Combination", order = 0)]
	[SerializeField] GameObject myCombiner;
	[SerializeField] bool canCombine;
	[SerializeField] GameObject combinedObject;
 





	private void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		pickupPos = player.transform.GetChild(0);
		anim = player.GetComponent<PlayerMove>().anim;
		playerInteract = player.GetComponent<PlayerInteract>();

		if (gameObject.GetComponent<SphereCollider>() == null) {
			areaCol = gameObject.AddComponent<SphereCollider>();
		}

		SphereCollider area = GetComponent<SphereCollider>();
		area.radius = areaSize;
		area.isTrigger = true;

	}


	void OnTriggerEnter (Collider other) {
		if (myDeposit != null && other.gameObject == myDeposit) {
			canDeposit = true;
		}
		else if (myCombiner != null && other.gameObject == myCombiner) {
			canCombine = true;
		}
	}


	void OnTriggerExit (Collider other) {
		if (canDeposit && myDeposit != null && other.gameObject == myDeposit) {
			canDeposit = false;
		}
		else if (canCombine && myCombiner != null && other.gameObject == myCombiner) {
			canCombine = false;
		}
	}


	public override void Interact () {
		if (!deposited && playerInteract.carriedObject == null) {
			transform.parent = pickupPos;
			transform.position = pickupPos.position;
			transform.rotation = pickupPos.rotation;
			playerInteract.carriedObject = gameObject;
			playerInteract.interactableObject = null;

			DManager.itemNameText.text = itemName;

			anim.SetBool("Carrying", true);
		}
	}


	public override void Disengage () {
		///Put object down
		///Set the object's parent to the current active dimension master
		if (canDeposit) {
			DepositItem();
		}
		else if (canCombine) {
			CombineItems();
		}
		else {
			DropItem();
		}

	}

	void DropItem () {
		transform.parent = DManager.currentActiveMaster.transform;
		transform.position = player.transform.position;

		playerInteract.isInteracting = false;
		playerInteract.interactableObject = null;
		playerInteract.carriedObject = null;

		DManager.itemNameText.text = "";

		anim.SetBool("Carrying", false);
	}

	void DepositItem() {
		transform.parent = depositPos.transform;
		transform.position = depositPos.position;
		transform.rotation = depositPos.rotation;
		canDeposit = false;
		deposited = true;

		GetComponent<SphereCollider>().enabled = false;
		//this.enabled = false;

		playerInteract.isInteracting = false;
		playerInteract.interactableObject = null;
		playerInteract.carriedObject = null;

		myDeposit.GetComponent<Interact_Deposit>().CheckIfComplete();

		DManager.itemNameText.text = "";

		anim.SetBool("Carrying", false);
	}


	void CombineItems() {
		combinedObject.SetActive(true);
		combinedObject.transform.parent = pickupPos;
		combinedObject.transform.position = pickupPos.position;

		myCombiner.transform.parent = DManager.combineStandby;
		gameObject.transform.parent = DManager.combineStandby;

		myCombiner.SetActive(false);
		gameObject.SetActive(false);

		//playerInteract.interactableObject = combinedObject;
		playerInteract.carriedObject = combinedObject;

		DManager.itemNameText.text = combinedObject.GetComponent<Interact_Pickup>().itemName;
	}


}
