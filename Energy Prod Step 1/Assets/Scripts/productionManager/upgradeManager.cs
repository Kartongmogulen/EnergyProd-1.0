using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeManager : MonoBehaviour
{
	public Text productionNameActiveText;
	public upgradeHydro HydroUpgrade;
	public upgradeBiomass BiomassUpgrade;
	public moneyPlayerManager MoneyPlayerManager;

	public int activeUpgrade;
	public int moneyPlayer;
	public int costUpgrade;

	public GameObject ScriptsGO;

	void Awake(){
		HydroUpgrade = GetComponent<upgradeHydro> ();
		BiomassUpgrade = GetComponent<upgradeBiomass> ();
		MoneyPlayerManager = ScriptsGO.GetComponent<moneyPlayerManager> ();
	}

	public void upgradeOneInfo(){

		if (productionNameActiveText.text == "Hydro") {
			HydroUpgrade.upgradeOneInfo ();
			activeUpgrade = 1;
		}

		if (productionNameActiveText.text == "Biomass") {
			BiomassUpgrade.upgradeOneInfo ();
			activeUpgrade = 1;
		}

	}

	public void buyUpgradeOne(){

		moneyPlayer = MoneyPlayerManager.moneyNow;

		if (productionNameActiveText.text == "Hydro" && activeUpgrade == 1) {
			
			costUpgrade = HydroUpgrade.costUpgradeProdCapacityNow; 
			if (HydroUpgrade.upgradeProdCapacityLvl < HydroUpgrade.upgradeProdCapacity.Length) { //Kontrollera att inte max-nivån är uppnådd
				if (moneyPlayer >= costUpgrade) { //Kontrollera att spelaren har tillräckligt med pengar
					MoneyPlayerManager.moneyNow -= costUpgrade;
					HydroUpgrade.upgradeHydroOne ();
					MoneyPlayerManager.updatePlayerMoney ();
				}
			}
		}
		if (productionNameActiveText.text == "Biomass" && activeUpgrade == 1) {
			costUpgrade = BiomassUpgrade.costUpgradeProdCapacityNow; 

			if (BiomassUpgrade.upgradeProdCapacityLvl < BiomassUpgrade.upgradeProdCapacity.Length) { //Kontrollera att inte max-nivån är uppnådd
				if (moneyPlayer >= costUpgrade) { //Kontrollera att spelaren har tillräckligt med pengar
					MoneyPlayerManager.moneyNow -= costUpgrade;
					BiomassUpgrade.upgradeBiomassOne ();
					MoneyPlayerManager.updatePlayerMoney ();
				}
			}
		}
	}

	public void upgradeTwoInfo(){

		if (productionNameActiveText.text == "Hydro") {
			HydroUpgrade.upgradeTwoInfo ();
			activeUpgrade = 2;
		}

		if (productionNameActiveText.text == "Biomass") {
			BiomassUpgrade.upgradeTwoInfo ();
			activeUpgrade = 2;
		}


	}

	public void buyUpgradeTwo(){

		moneyPlayer = MoneyPlayerManager.moneyNow;

		if (HydroUpgrade.doesThePlayerOwnUpgradeTwo == 0) { //Kontrollera att inte max-nivån är uppnådd
			costUpgrade = HydroUpgrade.costUpgradeTwo; 
			if (productionNameActiveText.text == "Hydro" && activeUpgrade == 2) {
				if (moneyPlayer >= costUpgrade) {
					MoneyPlayerManager.moneyNow -= costUpgrade;
					HydroUpgrade.upgradeHydroTwo ();
					MoneyPlayerManager.updatePlayerMoney ();
				}
			}
		}

		if (BiomassUpgrade.doesThePlayerOwnUpgradeTwo == 0) { //Kontrollera att inte max-nivån är uppnådd
			costUpgrade = BiomassUpgrade.costUpgradeTwo; 
			if (productionNameActiveText.text == "Biomass" && activeUpgrade == 2) {
				MoneyPlayerManager.moneyNow -= costUpgrade;
				BiomassUpgrade.upgradeBiomassTwo ();
				MoneyPlayerManager.updatePlayerMoney ();
			}
		}
	}
}
