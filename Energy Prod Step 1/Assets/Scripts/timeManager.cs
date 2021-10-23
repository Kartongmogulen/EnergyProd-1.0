using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
	public demandManager DemandManager;
	public supplyManager SupplyManager;
	public priceManager PriceManager;
	public moneyPlayerManager MoneyPlayerManager;
	public totalProductionPlayerManager TotalProductionPlayerManager;
	public timePointsManager TimePointsManager;

	public Text DateNowText;
	public int year;
	public int month;

	void Awake(){
		DemandManager = GetComponent<demandManager> ();
		SupplyManager = GetComponent<supplyManager> ();
		PriceManager = GetComponent<priceManager> ();
		MoneyPlayerManager = GetComponent<moneyPlayerManager> ();
		TotalProductionPlayerManager = GetComponent<totalProductionPlayerManager> ();
		TimePointsManager = GetComponent<timePointsManager> ();

		month = 1;
		DateNowText.text = "Y: " + year + " M: " + month;
	}

	public void endRound() {

		month++;//Add 1 to the month;
		DateNowText.text = "Y: " + year + " M: " + month;

		if (month == 13) {
			year++;
			month = 0;

			DateNowText.text = "Y: " + year + " M: " + month;
		}
		TotalProductionPlayerManager.updatePlayerProduction ();
		MoneyPlayerManager.updatePlayerMoneyFromProd ();

		DemandManager.updateDemand ();
		SupplyManager.updateSupply ();
		PriceManager.updatePrice ();

		resetAfterRound ();

	}

	public void resetAfterRound(){

		TimePointsManager.resetAfterRound ();

	}


}
