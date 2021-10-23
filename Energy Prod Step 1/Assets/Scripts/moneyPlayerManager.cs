using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyPlayerManager : MonoBehaviour
{
	public int moneyStart;
	public int moneyNow;
	public int moneyFromProduction;

	public Text moneyPlayerText;

	public priceManager PriceManager;
	public totalProductionPlayerManager TotalProductionPlayerManager;

    // Start is called before the first frame update
    void Start()
    {
		PriceManager = GetComponent<priceManager> ();
		TotalProductionPlayerManager = GetComponent<totalProductionPlayerManager> ();

		moneyNow = moneyStart;
		moneyPlayerText.text = "Money: " + moneyNow + "$";
    }

    // Update is called once per frame
    public void updatePlayerMoney()
    {
		moneyFromProduction = PriceManager.priceNow * TotalProductionPlayerManager.totalProdPlayer;

		moneyNow += moneyFromProduction;
		moneyPlayerText.text = "Money: " + moneyNow + "$";
    }
		
}
