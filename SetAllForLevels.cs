using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetAllForLevels : MonoBehaviour
{
	
	public Transform PlayerChrac;
	public GamePlayUIController gpuicScript;
	public GamePlayController gpcScript;
	public Transform mainCamera;
	int lvlNo, totalEnemyToKill;
	public static int enemyKilled = 0;
	public Text enemyCountText;
	bool winBool = false;
	// Use this for initialization
	void Awake ()
	{
		
		lvlNo = PlayerPrefs.GetInt ("LevelNo");

	}

	void Start ()
	{
		Starter ();
		mainCamera = GameObject.FindWithTag ("MainCamera").transform;
		gpcScript = GameObject.FindWithTag ("GameController").transform.GetComponent <GamePlayController> ();
		gpuicScript = GameObject.FindWithTag ("GameUIController").transform.GetComponent <GamePlayUIController> ();
		PlayerPrefs.SetInt ("LevelCash", 0);
		CheckWin ();
	}

	public void Starter ()
	{
		lvlNo = PlayerPrefs.GetInt ("LevelNo");

		SetterForAll ();
	}

	public void SetRoboOn(bool isRobo){
		if (isRobo) {
//			mainCamera.GetComponent<SmoothFollow> ().enabled = false;
//			mainCamera.GetComponent<ThirdPersonOrbitCam> ().enabled = true;
//			mainCamera.GetComponent<SmoothFollow> ().distance = 4f;
//			mainCamera.GetComponent<SmoothFollow> ().height = 1f;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		lvlNo = PlayerPrefs.GetInt ("LevelNo");

	}


	public void SetterForAll ()
	{
		Debug.Log ("Setting all from setter");

		if (lvlNo == 1 || lvlNo == 4 || lvlNo == 7) {

		} else if (lvlNo == 2 || lvlNo == 5 || lvlNo == 8) {



		} else if (lvlNo == 3 || lvlNo == 6 || lvlNo == 9) {

		}

		if (lvlNo == 1) {
			totalEnemyToKill = 2;
		}
		if (lvlNo == 2) {
			totalEnemyToKill = 4;
		}
		if (lvlNo == 3) {
			totalEnemyToKill = 6;
		}
		if (lvlNo == 4) {
			totalEnemyToKill = 8;
		}
		if (lvlNo == 5) {
			totalEnemyToKill = 8;
		}
		if (lvlNo == 6) {
			totalEnemyToKill = 10;
		}
		if (lvlNo == 7) {
			totalEnemyToKill = 10;
		}
		if (lvlNo == 8) {
			totalEnemyToKill = 12;
		}
		if (lvlNo == 9) {
			totalEnemyToKill = 12;
		}
		if (lvlNo == 10) {
			totalEnemyToKill = 14;

		}

	}

	public void CheckWin(){
		enemyCountText.text = "Enemies left: "+(totalEnemyToKill - enemyKilled).ToString ();
		if (enemyKilled >= totalEnemyToKill && !winBool) {
			winBool = true;
			gpcScript.Win ();
		}
	}



}
