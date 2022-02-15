using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimeController : MonoBehaviour
{

	public Text timeTM;
	int[] timeToCompleteLevels = new int[] {
		150,
		150,
		150,
		200,
		200,
		200,
		250,
		275,
		300,
		300
		};
	int lvlNo;
	public static float timeToCompleteLevel;
	public static bool isTimeOver;
	public static bool isGamePaused;
	bool checkIt;

	void Awake(){
		
	}

	void Start ()
	{
		Starter ();
	}
	public void Starter(){

		lvlNo = PlayerPrefs.GetInt ("LevelNo");
		Debug.Log ("lvl is "+lvlNo);
		timeToCompleteLevel = timeToCompleteLevels [lvlNo-1];
//		GamePlayUIController.isTime = false;
		isTimeOver = false;
		isGamePaused = false;
	}

	void Update ()
	{
		//print (timeTM);
		if (GamePlayUIController.isTime) {
			if (timeToCompleteLevel >= 0 && !isGamePaused) {
				timeToCompleteLevel -= Time.deltaTime;

			}

			if (timeToCompleteLevel < 0.0F && !isTimeOver) {

				isTimeOver = true;

				GetComponent<GamePlayController> ().TimesUp ();
			}

			timeTM.text = ((int)timeToCompleteLevel).ToString () + "/" + timeToCompleteLevels [lvlNo - 1].ToString ();

		}
	}

}
