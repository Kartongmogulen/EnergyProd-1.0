using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalProductionPlayerManager : MonoBehaviour
{
	public int totalProdPlayer;
	public int hydroProdPlayer;
	public int biomassProdPlayer;

	public hydroProduction HydroProduction;
	public biomassProductionManager BiomassProduction;
	public supplyManager SupplyManager;

    // Start is called before the first frame update
    void Awake()
    {
		HydroProduction = GetComponent<hydroProduction> ();
		BiomassProduction = GetComponent<biomassProductionManager> ();
		SupplyManager = GetComponent<supplyManager> ();
    }

    // Update is called once per frame
    public void updatePlayerProduction()
    {
		hydroProdPlayer = HydroProduction.hydroProdTotNow;
		biomassProdPlayer = BiomassProduction.biomassProdTotNow;

		totalProdPlayer = hydroProdPlayer + biomassProdPlayer;
		SupplyManager.supplyFromPlayer ();
    }
}
