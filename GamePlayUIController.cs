using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{

	int lvlNo, unLockedLvl, carNo, controlNo;
	int l = 0;


	//	public GameObject truckControls, arrowLeft, arrowRight, steer;
	public GameObject gameControls, roboControls;
	public GameObject allPanels, miniMapObjs;
	//	public GameObject lvlsImages;
	public GamePlayController gpc;
	public AudioSource audioSource;
	public TimeController tc;
	public SetAllForLevels scriptSetAll;
	public Text insText;
	public Text cashText, lvlText;
	public bool isMissionTyping, isPaused, isPressed = false;
	public static bool isTime = false;
	public static bool isStart;
	public AudioClip btnPress;
	// Use this for initialization
	void Awake ()
	{

		//MoPubAds.loadAd (MoPubAds._interstitialOnGpEndId);
		//MoPubAds.hideBanner ();
		lvlNo = PlayerPrefs.GetInt ("LevelNo");

	}

	void Start ()
	{
		AllStaticZero ();
		//MoPubAds.hideBanner ();
		lvlText.text = "Level No : " + lvlNo;
		Starter ();
	}

	public void Starter ()
	{

		lvlNo = PlayerPrefs.GetInt ("LevelNo");
		unLockedLvl = PlayerPrefs.GetInt ("LevelOpen");
		controlNo = PlayerPrefs.GetInt ("Controls");

		HideControls ();
		isStart = true;



	}

	
	// Update is called once per frame
	void Update ()
	{

		lvlNo = PlayerPrefs.GetInt ("LevelNo");
		unLockedLvl = PlayerPrefs.GetInt ("LevelOpen");

//		lvlsImages.transform.GetChild (lvlNo - 1).gameObject.SetActive (true);

			

		if (!isPaused && isTime) {
			if (Input.GetKeyUp (KeyCode.Escape)) {
				OnButtonPause ();		
			}
		}
		cashText.text = PlayerPrefs.GetInt ("TotalCash").ToString ();

	}


	public void OnButtonMainMenu ()
	{
		GetComponent<AudioSource> ().PlayOneShot (btnPress);
		Time.timeScale = 1.0f;
		Application.LoadLevel ("Main_Menu");
	}



	public void ShowInsText (string ins)
	{
		insText.gameObject.SetActive (true);
		insText.text = ins.ToString ();
		StartCoroutine (InsWait ());
	}

	IEnumerator InsWait ()
	{
		yield return new WaitForSeconds (4.0f);
		insText.text = "";
		insText.gameObject.SetActive (false);
	}

	public void OnButtonNextLevel ()
	{

		if (lvlNo != 10) {
			if (lvlNo == unLockedLvl) {
				PlayerPrefs.SetInt ("LevelOpen", (PlayerPrefs.GetInt ("LevelOpen") + 1));
			}
			PlayerPrefs.SetInt ("LevelNo", (PlayerPrefs.GetInt ("LevelNo") + 1));
			GetComponent<AudioSource> ().PlayOneShot (btnPress);
			Application.LoadLevel ("GamePlay");
			for (int i = 0; i < allPanels.transform.childCount; i++) {
				allPanels.transform.GetChild (i).gameObject.SetActive (false);
			}
			Time.timeScale = 1.0f;
			AllStaticZero ();
		} else
			Application.LoadLevel ("Main_Menu");
	}

	public void OnButtonPause ()
	{
		GetComponent<AudioSource> ().PlayOneShot (btnPress);
		Time.timeScale = 0.0f;
		isPaused = true;
		isTime = false;
		allPanels.transform.GetChild (2).gameObject.SetActive (true);
		//MoPubAds.showBanner ();
		HideControls ();
		Time.timeScale = 0.0f;
	}

	public void OnButtonResumeLevel ()
	{
		GetComponent<AudioSource> ().PlayOneShot (btnPress);
		Time.timeScale = 1.0f;
		isPaused = false;
		isTime = true;
		allPanels.transform.GetChild (2).gameObject.SetActive (false);
		//MoPubAds.hideBanner ();
		ShowControls ();

	}

	public void OnButtonRestartLevel ()
	{
		Application.LoadLevel ("GamePlay");
		AllStaticZero ();
		//MoPubAds.showAd (MoPubAds._interstitialOnGpEndId);
		GetComponent<AudioSource> ().PlayOneShot (btnPress);
	}

	public void AllStaticZero ()
	{
		l = 0;
		PlayerRoboController.isBareHand = true;
		PlayerRoboController.isRifleStand = false;
		PlayerRoboController.isRifleSit = false;
		SetAllForLevels.enemyKilled = 0;
		GamePlayController.playerDied = false;
	}

	public void ShowControls ()
	{
		
//		if (isTruckSelected) {
		StartCoroutine (ShowControl ());
//		} 
	}

	IEnumerator ShowControl ()
	{
//		MoPubAds.hideBanner ();
		yield return new WaitForSeconds (0.4f);
		
//		if (controlNo == 0) {
////			arrowLeft.gameObject.SetActive(true);
////			arrowRight.gameObject.SetActive(true);
////			steer.gameObject.SetActive(false);
//			GetComponent<accelerometerController>().enabled = false;
//			GetComponent<SteeringWheelCanvas>().enabled = false;
//			
//		} else if (controlNo == 1) {
//			arrowLeft.gameObject.SetActive(false);
//			arrowRight.gameObject.SetActive(false);
//			steer.gameObject.SetActive(true);
//			GetComponent<accelerometerController>().enabled = false;
//			GetComponent<SteeringWheelCanvas>().enabled = true;
//			
//		} else if (controlNo == 2) {
//			arrowLeft.gameObject.SetActive(false);
//			arrowRight.gameObject.SetActive(false);
//			steer.gameObject.SetActive(false);
//			GetComponent<accelerometerController>().enabled = true;
//			GetComponent<SteeringWheelCanvas>().enabled = false;
//		}
		gameControls.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.4f);

		roboControls.gameObject.SetActive (true);
//		GameObject.FindWithTag ("Player").transform.GetComponent<AudioSource> ().mute = false;
//		miniMapObjs.gameObject.SetActive (true);
	}

	public void HideControls ()
	{
		
//		GameObject.FindWithTag ("Player").transform.GetComponent<AudioSource> ().mute = true;
		gameControls.gameObject.SetActive (false);
		roboControls.gameObject.SetActive (false);
//		miniMapObjs.gameObject.SetActive (false);
	}



}
