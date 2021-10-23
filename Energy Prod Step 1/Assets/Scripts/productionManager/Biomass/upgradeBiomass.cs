using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeBiomass : MonoBehaviour
{
	//Uppgradering 1
	public int[] upgradeProdCapacity = new int[3];
	public int upgradeProdCapacityLvl;
	public int costUpgradeProdCapacityNow;
	public int[] costUpgradeProdCapacity = new int[3];

	//Uppgradering 2
	public int costUpgradeTwo;
	public int doesThePlayerOwnUpgradeTwo; //Värde 0 om spelaren inte har uppgraderat, 1 om spelaren redan har uppgraderat

	public GameObject upgradePanelGO;
	public GameObject scriptGO;

	public biomassProductionManager BiomassProductionManager;

	public Text productionNameText;
	public Text descriptionText;
	public Text costText;

	void Awake(){
		BiomassProductionManager = scriptGO.GetComponent<biomassProductionManager> ();
	}

	public void chooseBiomass(){

		upgradePanelGO.SetActive (true);

		productionNameText.text = "Biomass";

	}

	public void upgradeOneInfo()
	{

		if (upgradeProdCapacityLvl == upgradeProdCapacity.Length) {
			descriptionText.text = "Max level";
			costText.text = "Max level";
		} else {
			descriptionText.text = "Increase max output effect with: " + upgradeProdCapacity [upgradeProdCapacityLvl];
			costText.text = "Cost: " + costUpgradeProdCapacity [upgradeProdCapacityLvl];
			costUpgradeProdCapacityNow = costUpgradeProdCapacity [upgradeProdCapacityLvl];
		}
	}

	public void upgradeBiomassOne(){

		if (upgradeProdCapacityLvl < upgradeProdCapacity.Length) {

			BiomassProductionManager.biomassProdCapacityNow += upgradeProdCapacity [upgradeProdCapacityLvl];
			upgradeProdCapacityLvl++;
			upgradeOneInfo ();

	} else {

		costText.text = "Max level";

		}
	}

	public void upgradeTwoInfo(){

		if (doesThePlayerOwnUpgradeTwo == 0) {
			descriptionText.text = "Decrease time to produce one unit och Biomass with 1";
			costText.text = "Cost: " + costUpgradeTwo;

		} else {
			descriptionText.text = "Max level";
			costText.text = "Max level";
		}
	}

	public void upgradeBiomassTwo(){

		if (doesThePlayerOwnUpgradeTwo == 0) {

			BiomassProductionManager.costTimePointsProdNow = 1;

			doesThePlayerOwnUpgradeTwo = 1;

		}

		upgradeTwoInfo ();
	}
}

