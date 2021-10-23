using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hydroProduction : MonoBehaviour
{
	public int hydroProdCapacityStart;
	public int hydroProdCapacityMaxNow;

	public int hydroProdTotNow;

	public Text hydroProdText;

	public totalProductionPlayerManager TotalProductionPlayerManager; 
	public timePointsManager TimePointsManager;

    // Start is called before the first frame update
    void Awake()
    {
		TotalProductionPlayerManager = GetComponent<totalProductionPlayerManager> ();
		TimePointsManager = GetComponent<timePointsManager> ();

		hydroProdTotNow = hydroProdCapacityStart;
		hydroProdCapacityMaxNow = hydroProdCapacityStart;
    }

    // Update is called once per frame
    void Update()
    {
		hydroProdText.text = "H1: " + hydroProdTotNow + "/" + hydroProdCapacityMaxNow;
    }

	public void maxProduction(){
		hydroProdTotNow = hydroProdCapacityMaxNow;
	}

	public void addProduction(){
		TimePointsManager.spendTimePoints (0);

		if (hydroProdTotNow  < hydroProdCapacityMaxNow) {
			hydroProdTotNow++;
		}

		TotalProductionPlayerManager.updatePlayerProduction ();
	}

	public void reduceProduction(){
		TimePointsManager.addBackTimePoints (0);

		if (hydroProdTotNow > 0) {
			hydroProdTotNow--;
		}
			
		TotalProductionPlayerManager.updatePlayerProduction ();
	}
}
