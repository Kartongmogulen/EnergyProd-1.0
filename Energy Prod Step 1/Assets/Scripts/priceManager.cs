using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceManager : MonoBehaviour
{
	public demandManager DemandManager; 
	public supplyManager SupplyManager; 

	public int priceInBalance; //Priset när utbud och efterfrågan möts

	public int demandNow;
	public int supplyNow;
	public int priceNow;

	public Text priceNowText;

    // Start is called before the first frame update
	void Awake(){
		SupplyManager = GetComponent<supplyManager> ();
		DemandManager = GetComponent<demandManager> ();
		updatePrice ();
	}

	void Update(){
		updatePrice ();
	}

	public void updatePrice(){

		demandNow = DemandManager.demandNow;
		supplyNow = SupplyManager.supplyNow;

		if (supplyNow - demandNow == 0) {
			priceNow = priceInBalance;
		}

		if (supplyNow - demandNow > 0) {
			priceNow = priceInBalance - (supplyNow - demandNow);
		}

		if (supplyNow - demandNow < 0) {
			priceNow = priceInBalance - (supplyNow - demandNow);
		}

		priceNowText.text = "Price: " + priceNow + " $/unit energy";

	}
}
