using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Pickup : Interactable {

	[SerializeField] DimensionManager DManager;
 
	SphereCollider areaCol;
	[SerializeField] float areaSize;


	Transform pickupPos;



	private void Awake () {
		pickupPos = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);

		if (gameObject.GetComponent<SphereCollider>() == null) {
			areaCol = gameObject.AddComponent<SphereCollider>();
		}

		SphereCollider area = GetComponent<SphereCollider>();
		area.radius = areaSize;
		area.isTrigger = true;

	}


	public override void Interact () {
		transform.parent = pickupPos;
		transform.position = pickupPos.position;
	}


	public override void Disengage () {
		///Put object down
		///Set the object's parent to the current active dimension master
		transform.parent = DManager.currentActiveMaster.transform;
	}


}
