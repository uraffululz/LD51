using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImerScript : MonoBehaviour {

	[SerializeField] DimensionManager DManager;
 
	float timerMax = 10f;
	[SerializeField] float timerCurrent;
	[SerializeField] bool timerActive;



	void Start() {
        timerCurrent = timerMax;
    }

   
    void Update() {
		if (timerActive) {
			timerCurrent -= Time.deltaTime;

			if (timerCurrent <= 0) {
				///Switch dimensions
				DManager.SwitchDimension();

				timerCurrent = timerMax;
			}

		}
    }


}
