using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	[SerializeField] DimensionManager DManager;
	[SerializeField] Text timerText;

	[SerializeField] GameObject player;
 
	float timerMax = 11f;
	[SerializeField] float timerCurrent;
	[SerializeField] bool timerActive;

	[SerializeField] GameObject introBG;
	[SerializeField] GameObject outroBG;


	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");

        timerCurrent = timerMax;
		timerActive = false;
    }

   
    void Update() {
		//DManager.EndGame();

		if (timerActive) {
			timerCurrent -= Time.deltaTime;

			if (timerCurrent <= 1) {
				///Switch dimensions
				DManager.SwitchDimension();

				timerCurrent = timerMax;
			}

			timerText.text = Mathf.FloorToInt(timerCurrent).ToString();
		}
    }


	public void StartGame() {
		timerActive = true;
		player.GetComponent<PlayerMove>().canMove = true;

		introBG.SetActive(false);
	}


	public void StopTimeForEndGame() {
		timerActive = false;

		timerText.text = "";
		outroBG.SetActive(true);
	}


	public void QuitGame() {
		print("Quitting");
		Application.Quit();
	}

}
