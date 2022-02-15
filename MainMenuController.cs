using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

	public Transform mainPanel, exitPanel, levelSelectPanel;


	public AudioSource audioSource;
	public AudioClip btnSound;

	public static bool isBackToMainMenu = false;

	//public GooglePlugin gp;
	// Use this for initialization
	void Awake ()
	{

		//MoPubAds.initBanner (MoPubAds._bannerAdUnitId, MoPubAdPosition.TopCenter);
		//MoPubAds.loadAd (MoPubAds._interstitialOnDefault);
		//MoPubAds.loadAd (MoPubAds._interstitialOnExit);

	}

	void Start ()
	{
		//MoPubAds.showBanner ();
		//gp.SignIn ();
		//gp.SubmitScore (PlayerPrefs.GetInt("EnemyRobotsKilled"));
		//if (isBackToMainMenu) {
		//	MoPubAds.showAd (MoPubAds._interstitialOnDefault);
		//}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor) {
			
			if (Input.GetKeyUp (KeyCode.Escape)) {
			
				Debug.Log ("ecs");

			//	MoPubAds.showAd (MoPubAds._interstitialOnExit);
				exitPanel.gameObject.SetActive (true);
			}
		}

	}

	public void OnBtnPlay ()
	{
		audioSource.PlayOneShot (btnSound);
		isBackToMainMenu = true;
		mainPanel.gameObject.SetActive (false);
		levelSelectPanel.gameObject.SetActive (true);

	}

	public void OnBtnMoreApps ()
	{
		audioSource.PlayOneShot (btnSound);
		//AGameUtils.moreAppsLink ();
	}

	public void OnBtnFeedBack ()
	{
		audioSource.PlayOneShot (btnSound);
		///AGameUtils.SendFeedbackMail ();
	}

	public void OnBtnExitApp ()
	{
		audioSource.PlayOneShot (btnSound);
		exitPanel.gameObject.SetActive (true);
	}

	public void OnBtnYes ()
	{
		audioSource.PlayOneShot (btnSound);
		Application.Quit ();

	}

	public void OnBtnNo ()
	{
		audioSource.PlayOneShot (btnSound);
		exitPanel.gameObject.SetActive (false);

	}

}
