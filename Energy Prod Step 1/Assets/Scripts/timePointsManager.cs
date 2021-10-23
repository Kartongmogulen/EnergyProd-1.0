using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timePointsManager : MonoBehaviour
{
	public int timePointsStart;
	public int timePointsMaxNow;
	public int timePointsNow;

	public Text timePointsLeftText;

	public totalProductionPlayerManager TotalProductionPlayerManager; 
	public supplyManager SupplyManager; 

	void Start(){
		timePointsNow = timePointsStart;
		timePointsMaxNow = timePointsStart;
		timePointsLeftText.text = "TP: " + timePointsNow + "/" + timePointsMaxNow;

		SupplyManager = GetComponent<supplyManager> ();
		//TotalProductionPlayerManager = GetComponent<totalProductionPlayerManager> ();
	}

	public void spendTimePoints(int costTimePoints){
		

		if (timePointsNow > 0) {
			timePointsNow -= costTimePoints;
			timePointsLeftText.text = "TP: " + timePointsNow + "/" + timePointsMaxNow;

			//TotalProductionPlayerManager.updatePlayerProduction ();
			SupplyManager.supplyFromPlayer();
		}

	}

	public void addBackTimePoints(int costTimePoints){
		

		if (timePointsNow < timePointsStart) {
			timePointsNow += costTimePoints;
			timePointsLeftText.text = "TP: " + timePointsNow + "/" + timePointsMaxNow;

			//TotalProductionPlayerManager.updatePlayerProduction ();
			SupplyManager.supplyFromPlayer();
		}
	
	}

	public void resetAfterRound(){
		timePointsNow = timePointsMaxNow;
		timePointsLeftText.text = "TP: " + timePointsNow + "/" + timePointsMaxNow;
	}


}
