using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour {
 
	Camera mainCam;

	[SerializeField] int currentActiveIndex;
	public GameObject currentActiveMaster;
	[SerializeField] GameObject d1Master;
	[SerializeField] GameObject d2Master;
	[SerializeField] GameObject d3Master;
	[Space]
	[SerializeField] Color d1BGColor;
	[SerializeField] Color d2BGColor;
	[SerializeField] Color d3BGColor;


    void Start() {
		mainCam = Camera.main;
        currentActiveMaster = d1Master;
		mainCam.backgroundColor = d1BGColor;
    }

   

    void Update() {
        
    }


	public void SwitchDimension() {
		currentActiveMaster.SetActive(false);

		switch (currentActiveIndex) {
			case 0:
				currentActiveMaster = d2Master;
				currentActiveIndex = 1;
				mainCam.backgroundColor = d2BGColor;
				break;
			case 1:
				currentActiveMaster = d3Master;
				currentActiveIndex = 2;
				mainCam.backgroundColor = d3BGColor;
				break;
			case 2:
				currentActiveMaster = d1Master;
				currentActiveIndex = 0;
				mainCam.backgroundColor = d1BGColor;
				break;
			default:
				Debug.Log("You fucked up here");
				currentActiveMaster = d1Master;
				currentActiveIndex = 0;
				mainCam.backgroundColor = d1BGColor;
				break;
		}

		currentActiveMaster.SetActive(true);
	}


}
