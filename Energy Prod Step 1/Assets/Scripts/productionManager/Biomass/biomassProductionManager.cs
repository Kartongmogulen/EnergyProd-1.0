using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class biomassProductionManager : MonoBehaviour
{
	public int biomassProdCapacityStart;
	public int costTimePointsProdStart;

	public int biomassProdTotNow;
	public int biomassProdCapacityNow;
	public int costTimePointsProdNow;

	public timePointsManager TimePointsManager;
	public totalProductionPlayerManager TotalProductionPlayerManager; 

	public Text biomassProdText;

	void Awake(){
		TimePointsManager = GetComponent<timePointsManager> ();
		costTimePointsProdNow = costTimePointsProdStart;
		biomassProdCapacityNow = biomassProdCapacityStart;
		TotalProductionPlayerManager = GetComponent<totalProductionPlayerManager> ();
	}

	// Update is called once per frame
	void Update()
	{
		biomassProdText.text = "B1: " + biomassProdTotNow + "/" + biomassProdCapacityStart;
	}

	public void addProduction(){
		TimePointsManager.spendTimePoints (costTimePointsProdNow);

		if (biomassProdTotNow < biomassProdCapacityNow) {
			biomassProdTotNow++;
		}

		biomassProdText.text = "B1: " + biomassProdTotNow + "/" + biomassProdCapacityStart;
		TotalProductionPlayerManager.updatePlayerProduction ();
	}

	public void reduceProduction(){
		TimePointsManager.addBackTimePoints (costTimePointsProdNow);

		if (biomassProdTotNow > 0) {
			biomassProdTotNow--;
		}

		biomassProdText.text = "B1: " + biomassProdTotNow + "/" + biomassProdCapacityStart;
		TotalProductionPlayerManager.updatePlayerProduction ();
	}
}
