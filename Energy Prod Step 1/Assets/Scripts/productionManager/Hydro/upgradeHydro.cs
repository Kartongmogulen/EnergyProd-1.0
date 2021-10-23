using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeHydro : MonoBehaviour
{
	//Uppgradering 1
	public int[] upgradeProdCapacity = new int[4];
	public int upgradeProdCapacityLvl;
	public int[] costUpgradeProdCapacity = new int[3];

	//Uppgradering 2
	public int costUpgradeTwo;

	public GameObject upgradePanelGO;
	public GameObject scriptGO;
	public GameObject adjustProductionPanel;
	public hydroProduction HydroProduction;

	public Text productionNameText;
	public Text descriptionText;
	public Text costText;

	void Awake(){
		HydroProduction = scriptGO.GetComponent<hydroProduction> ();
	}

	public void chooseHydro(){

		upgradePanelGO.SetActive (true);

		productionNameText.text = "Hydro";

	}

	public void upgradeOneInfo()
	{
		if (upgradeProdCapacityLvl == upgradeProdCapacity.Length) {
			descriptionText.text = "Max level";
			costText.text = "Max level";
		} else {
			descriptionText.text = "Increase effect output with: " + upgradeProdCapacity [upgradeProdCapacityLvl];
			costText.text = "Cost: " + costUpgradeProdCapacity [upgradeProdCapacityLvl];
		}
	}

	public void upgradeHydroOne(){

		if (upgradeProdCapacityLvl < upgradeProdCapacity.Length) {

			HydroProduction.hydroProdCapacityMaxNow += upgradeProdCapacity [upgradeProdCapacityLvl];
			upgradeProdCapacityLvl++;
			HydroProduction.hydroProdTotNow = HydroProduction.hydroProdCapacityMaxNow;
			upgradeOneInfo ();
			HydroProduction.maxProduction ();

		} else {
			
			costText.text = "Max level";
		}
	}

	public void upgradeTwoInfo(){
		descriptionText.text = "Be able på controll the production";
		costText.text = "Cost: " + costUpgradeTwo;
	}

	public void upgradeHydroTwo(){

		adjustProductionPanel.SetActive (true);

	}



}
