using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeManager : MonoBehaviour
{
	public Text productionNameActiveText;
	public upgradeHydro HydroUpgrade;
	public moneyPlayerManager MoneyPlayerManager;

	public int activeUpgrade;

	void Awake(){
		HydroUpgrade = GetComponent<upgradeHydro> ();
		MoneyPlayerManager = GetComponent<moneyPlayerManager> ();
	}

	public void upgradeOneInfo(){

		if (productionNameActiveText.text == "Hydro") {
			HydroUpgrade.upgradeOneInfo ();
			activeUpgrade = 1;
		}

	}

	public void buyUpgradeOne(){

		if (productionNameActiveText.text == "Hydro" && activeUpgrade == 1) {

			HydroUpgrade.upgradeHydroOne();
		}
	}

	public void upgradeTwoInfo(){

		if (productionNameActiveText.text == "Hydro") {
			HydroUpgrade.upgradeTwoInfo ();
			activeUpgrade = 2;
		}
	}

	public void buyUpgradeTwo(){

		if (productionNameActiveText.text == "Hydro" && activeUpgrade == 2) {
			HydroUpgrade.upgradeHydroTwo();
		}
	}
}
