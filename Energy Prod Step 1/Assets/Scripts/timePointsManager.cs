using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timePointsManager : MonoBehaviour
{
	public int timePointsStart;
	public int timePontsNow;

	public Text timePointsLeftText;

	public totalProductionPlayerManager TotalProductionPlayerManager; 
	public supplyManager SupplyManager; 

	void Start(){
		timePontsNow = timePointsStart;
		timePointsLeftText.text = "TP: " + timePontsNow + "/" + timePointsStart;

		SupplyManager = GetComponent<supplyManager> ();
		//TotalProductionPlayerManager = GetComponent<totalProductionPlayerManager> ();
	}

	public void spendTimePoints(int costTimePoints){
		

		if (timePontsNow > 0) {
			timePontsNow -= costTimePoints;
			timePointsLeftText.text = "TP: " + timePontsNow + "/" + timePointsStart;

			//TotalProductionPlayerManager.updatePlayerProduction ();
			SupplyManager.supplyFromPlayer();
		}

	}

	public void addBackTimePoints(int costTimePoints){
		

		if (timePontsNow < timePointsStart) {
			timePontsNow += costTimePoints;
			timePointsLeftText.text = "TP: " + timePontsNow + "/" + timePointsStart;

			//TotalProductionPlayerManager.updatePlayerProduction ();
			SupplyManager.supplyFromPlayer();
		}
	
	}


}
