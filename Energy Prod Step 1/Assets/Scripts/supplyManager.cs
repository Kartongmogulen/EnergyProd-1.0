using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class supplyManager : MonoBehaviour
{
	public int supplyNow;
	public int supplyWithoutPlayer;
	public int supplyWinter;
	public int supplySummer;
	public Text supplyText;

	public int supplyFromPlayerTot;
	public int supplyFromPlayerHydro;

	public timeManager TimeManager; 
	public demandManager DemandManager; 
	public hydroProduction HydroProduction; 
	public totalProductionPlayerManager TotalProductionPlayerManager; 

	public int month;

    // Start is called before the first frame update
	void Awake(){
		TimeManager = GetComponent<timeManager> ();
		DemandManager = GetComponent<demandManager> ();
		HydroProduction = GetComponent<hydroProduction> ();
		TotalProductionPlayerManager = GetComponent<totalProductionPlayerManager> ();
		updateSupply ();
	}

	public void updateSupply(){
		month = TimeManager.month;

		//Vinter
		if (month <=3 || month >= 10){ 
			supplyNow = DemandManager.demandNow + Random.Range (-2,3)*10;
		}

		//Sommar
		if (month >3 && month < 10){ 
			supplyNow = DemandManager.demandNow + Random.Range (-1,2)*10;
		}

		//supplyFromPlayerHydro = HydroProduction.hydroProdTotNow;
		supplyWithoutPlayer = supplyNow;
		supplyFromPlayerTot  = TotalProductionPlayerManager.totalProdPlayer;

		supplyNow += supplyFromPlayerTot;

		supplyText.text = "Supply: " + supplyNow;


	}

	public void supplyFromPlayer(){
		
		supplyFromPlayerTot  = TotalProductionPlayerManager.totalProdPlayer;

		supplyNow = supplyWithoutPlayer + supplyFromPlayerTot;		

		supplyText.text = "Supply: " + supplyNow;
	}
}
