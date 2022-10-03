using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimensionManager : MonoBehaviour {
 
	Camera mainCam;

	[SerializeField] int currentActiveIndex = 0;
	public GameObject currentActiveMaster;
	[SerializeField] GameObject d1Master;
	[SerializeField] GameObject d2Master;
	[SerializeField] GameObject d3Master;
	[Space]
	[SerializeField] Color d1BGColor;
	[SerializeField] Color d2BGColor;
	[SerializeField] Color d3BGColor;
	[Space]
	public Transform combineStandby;

	//[SerializeField] Light mainLight;

	public Text itemNameText;

	public GameObject[] centerPieces;

	[SerializeField] GameObject finalD;

	[SerializeField] TimerScript timeScript;


    void Start() {
		mainCam = Camera.main;
        currentActiveMaster = d1Master;
		mainCam.backgroundColor = d1BGColor;
    }

   

    void Update() {
        
    }


	public void SwitchDimension() {
		currentActiveMaster.SetActive(false);
		//currentActiveIndex++;

		switch (currentActiveIndex) {
			case 0:
				currentActiveMaster = d2Master;
				currentActiveIndex = 1;
				mainCam.backgroundColor = d2BGColor;
				//mainLight.intensity = .7f;
				break;
			case 1:
				currentActiveMaster = d3Master;
				currentActiveIndex = 2;
				mainCam.backgroundColor = d3BGColor;
				//mainLight.intensity = .5f;
				break;
			case 2:
				currentActiveMaster = d1Master;
				currentActiveIndex = 0;
				mainCam.backgroundColor = d1BGColor;
				//mainLight.intensity = .1f;
				break;
			default:
				Debug.Log("You fucked up here");
				break;
		}

		currentActiveMaster.SetActive(true);
	}


	public void EndGame() {
		d1Master.SetActive(false);
		d2Master.SetActive(false);
		d3Master.SetActive(false);
		currentActiveMaster = finalD;

		Vector3 startingSpawn = new Vector3(-5, 0, 0);

		foreach (GameObject piece in centerPieces) {
			piece.transform.parent = finalD.transform;
			piece.transform.position = startingSpawn;
			piece.SetActive(true);
			piece.GetComponent<Interact_Deposit>().completeObject.SetActive(true);

			startingSpawn += Vector3.right * 5;

			finalD.SetActive(true);

			timeScript.StopTimeForEndGame();
		}
	}


}
