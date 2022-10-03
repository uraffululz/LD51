using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Deposit : MonoBehaviour {

	[SerializeField] DimensionManager DManager;
 
	public Transform[] deposits;

	//[SerializeField] System.Type componentType;
	public GameObject completeObject;
	public bool projectFinished = false;


    void Start() {
        
    }

   

    void Update() {
        
    }


	public void CheckIfComplete() {
		bool isComplete = true;

		foreach (Transform dep in deposits) {
			if (dep.childCount == 0) {
				isComplete = false;
			}
		}

		if (isComplete) {
			ActivateCompleteMode();
			projectFinished = true;
			print("Objective completed");
		}

		CheckAllCenterPieces();
	}


	void ActivateCompleteMode() {
		completeObject.SetActive(true);

		if (completeObject.GetComponent<Animator>() != null) {
			Animator anim = completeObject.GetComponent<Animator>();

			anim.enabled = true;
		}
		//else if (completeObject.GetComponent<LineRenderer>() != null) {
		//	LineRenderer LR = completeObject.GetComponent<LineRenderer>();
		//}
		//else {
		//	print("I fucked up");
		//}
	}


	void CheckAllCenterPieces() {
		bool allComplete = true;

		foreach (GameObject centerP in DManager.centerPieces) {
			if (!centerP.GetComponent<Interact_Deposit>().projectFinished) {
				allComplete = false;
			}
		}

		if (allComplete) {
			foreach (GameObject centerP in DManager.centerPieces) {
				centerP.GetComponent<Interact_Deposit>().completeObject.SetActive(true);
			}

			ActivateEndgame();
		}
	}


	void ActivateEndgame() {
		print("All projects complete!");

		DManager.EndGame();
	}

}
