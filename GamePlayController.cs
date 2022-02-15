using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	int lvlNo, unLockedLvl;
	public GameObject allPanels;
	public GameObject levelObjects;

	GamePlayUIController gpuiScript;

	public AudioClip gpEndSound;
	AudioSource mainAudio;
	public Text pointsTextWinPanel, timeTextWinPanel, failTextFailPanel ;
//	public Image starsEarned;
	public static float distance;
	int ntime;
	float myTime;
	int coin;
    public static bool playerDied = false;


	// Use this for initialization
	void Awake(){
         //MoPubAds.loadAd (MoPubAds._interstitialOnGpEndId);
	}
	void Start () {
		Starter ();

		mainAudio = this.transform.GetComponent<AudioSource> ();
		//gpuiScript = GameObject.FindWithTag ("GameUIController").transform.GetComponent<GamePlayUIController> ();
	}
	public void Starter(){

		lvlNo = PlayerPrefs.GetInt("LevelNo");
		unLockedLvl = PlayerPrefs.GetInt ("LevelOpen");

		if (lvlNo == 0) {
			PlayerPrefs.SetInt("LevelNo", 1);
			Application.LoadLevel(Application.loadedLevel);
		}


		for (int l=0; l<levelObjects.transform.childCount; l++) {
			levelObjects.transform.GetChild (l).gameObject.SetActive (false);
		}
		levelObjects.transform.GetChild (lvlNo -1).gameObject.SetActive (true);
		Time.timeScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		if (GamePlayUIController.isStart) {
			myTime = myTime + Time.deltaTime;
			ntime = (int)myTime;
		}

	}
//	public static float  percentHealth, percentStars = 0.0f;

	public void Win(){
		Debug.Log ("in win");
		mainAudio.Stop();
		mainAudio.PlayOneShot(gpEndSound);
		gpuiScript.HideControls ();
		PlayerPrefs.SetInt ("TotalCash", (PlayerPrefs.GetInt ("TotalCash") + 200));
		PlayerPrefs.SetInt ("LevelCash", (PlayerPrefs.GetInt ("LevelCash") + 200));
		GamePlayUIController.isTime = false;
		allPanels.transform.GetChild(0).gameObject.SetActive (true);
		allPanels.transform.GetChild(0).transform.GetComponent<Animation>().Play("PanelShowAnim");
		pointsTextWinPanel.text = "Points Earned: 200";
		timeTextWinPanel.text = "Time Elapsed: "+ntime.ToString()+" sec";
		ShowAd ();

//		starsEarned.fillAmount = percentHealth / 100;
//		Debug.Log (HurdleDetection.health+" after :"+percentHealth.ToString());
//		Time.timeScale = 0.0f;
		if (lvlNo == unLockedLvl) {
			PlayerPrefs.SetInt ("LevelOpen", (PlayerPrefs.GetInt ("LevelOpen") + 1));
		}


//		if (lvlNo == 3 || lvlNo == 6 || lvlNo == 9) {
//			noOfTiles = noOfTiles + 16;
//		}
		//gp.SubmitScore (PlayerPrefs.GetInt("EnemyRobotsKilled"));
//		if (PlayerPrefs.GetInt ("LevelOpen") == 9) {
//			gp.unlockAchievement1 ();
//
//		}else if (PlayerPrefs.GetInt ("TotalCash") >= 10000) {
//			gp.unlockAchievement2 ();
//
//		}else if (StoneCutting.totalStonesCrushed >= 100) {
//			gp.unlockAchievement3 ();
//
//		}else if (noOfTiles >= 1600) {
//			gp.unlockAchievement4 ();
//		}
//		if (HurdleDetection.excavatorOnFire >= 50) {
//			gp.unlockAchievement5 ();
//		}
	}

	public void CallFail(){
		StartCoroutine (WaitFail ());
	}
	IEnumerator WaitFail(){
		yield return new WaitForSeconds (1.0f);
		Failed ("Mission Failed");
	}

	public void Failed( string msg){

		PlayerPrefs.SetInt ("TotalCash", (PlayerPrefs.GetInt ("TotalCash") - (PlayerPrefs.GetInt ("LevelCash"))));
		Debug.Log ("in Fail");
		mainAudio.Stop();
		mainAudio.PlayOneShot(gpEndSound);
		GamePlayUIController.isTime = false;
		failTextFailPanel.text = msg;
		allPanels.transform.GetChild(1).gameObject.SetActive (true);
		gpuiScript.HideControls ();
		ShowAd ();
//		Time.timeScale = 0.0f;

	}

	public void TimesUp(){

		PlayerPrefs.SetInt ("TotalCash", (PlayerPrefs.GetInt ("TotalCash") - (PlayerPrefs.GetInt ("LevelCash"))));
		Debug.Log ("in timesup");
		mainAudio.Stop();
		mainAudio.PlayOneShot(gpEndSound);
		allPanels.transform.GetChild(3).gameObject.SetActive (true);
		GamePlayUIController.isTime = false;
		gpuiScript.HideControls ();
		ShowAd ();
//		Time.timeScale = 0.0f;

	}
	public void Crashed(){
		Debug.Log ("in Crash");
		PlayerPrefs.SetInt ("TotalCash", (PlayerPrefs.GetInt ("TotalCash") - (PlayerPrefs.GetInt ("LevelCash"))));
		mainAudio.Stop();
		mainAudio.PlayOneShot(gpEndSound);
		allPanels.transform.GetChild(5).gameObject.SetActive (true);
		gpuiScript.HideControls ();
		GamePlayUIController.isTime = false;
//		Time.timeScale = 0.0f;
		
	}

	public void ShowAd(){
		try{

			//MoPubAds.showBanner ();
			//MoPubAds.showAd (MoPubAds._interstitialOnGpEndId);

		}catch{

		}
	}


}
