using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demandManager : MonoBehaviour
{
	public int demandNow;
	public int demandWinter;
	public int demandSummer;
	public Text demandText;

	public timeManager TimeManager; 

	public int month;

    // Start is called before the first frame update
	void Awake(){
		TimeManager = GetComponent<timeManager> ();
		updateDemand ();
	}

	public void updateDemand(){
		month = TimeManager.month;

		//Vinter
		if (month <=3 || month >= 10){ 
			demandNow = demandWinter;
		}

		//Sommar
		if (month >3 && month < 10){ 
			demandNow = demandSummer;
		}

		demandText.text = "Demand: " + demandNow;
	}
}
