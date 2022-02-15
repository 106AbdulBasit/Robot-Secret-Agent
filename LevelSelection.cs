using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{



	public GameObject loadingPanel, mainMenuPanel, levelSelectPanel;
//	public GameObject[] missionPanels;
//	public GameObject[] missionBtnContent;
	public GameObject[] levelBtn;
//	bool isBlink, isBlinkLvl = false;
	public int levelOpen, missionOpen;
	public AudioClip bsound;
	static int btnMission;
	public AudioSource audioSource;
	void Awake ()
	{

		//MoPubAds.loadAd (MoPubAds._interstitialOnSelectionId);




//				PlayerPrefs.DeleteAll ();
		if (PlayerPrefs.GetInt ("LevelOpen") <= 0) {
			PlayerPrefs.SetInt ("LevelOpen", 1);
		}
		if (PlayerPrefs.GetInt ("LevelOpen") >= 11) {
			PlayerPrefs.SetInt ("LevelOpen", 10);
		}

//				PlayerPrefs.SetInt ("LevelOpen", 10);
		levelOpen = PlayerPrefs.GetInt ("LevelOpen");


//		if (PlayerPrefs.GetInt ("MissionOpen") <= 0) {
//			PlayerPrefs.SetInt ("MissionOpen", 1);
//		}
//		if (PlayerPrefs.GetInt ("MissionOpen") >= 4) {
//			PlayerPrefs.SetInt ("MissionOpen", 3);
//		}

		missionOpen = PlayerPrefs.GetInt ("MissionOpen");
		Debug.Log ("lvlopen:" + PlayerPrefs.GetInt ("LevelOpen"));

	}

	void Start ()
	{
		audioSource = this.transform.GetComponent<AudioSource> ();
		Debug.Log (PlayerPrefs.GetInt ("LevelOpen").ToString () + ":ok " + PlayerPrefs.GetInt ("LevelNo").ToString ());
		levelOpen = PlayerPrefs.GetInt ("LevelOpen");
		for (int i = 0; i < levelOpen; i++) {
//			levelBtn [i].SetActive (true);
			levelBtn [i].transform.GetComponent<Button> ().interactable = true;

		}
	}


	void Update ()
	{
//		missionOpen = PlayerPrefs.GetInt ("MissionOpen");


		if (Input.GetKeyUp (KeyCode.Escape)) {

			if (Application.platform == RuntimePlatform.Android) {

				levelSelectPanel.gameObject.SetActive (false);
				mainMenuPanel.gameObject.SetActive (true);
			}	
		}


//		if (levelOpen > 3 && levelOpen < 7) {
//			PlayerPrefs.SetInt ("MissionOpen", 2);
//		} else if (levelOpen > 6 && levelOpen < 10) {
//
//			PlayerPrefs.SetInt ("MissionOpen", 3);
//		} 



//		for (int i = 0; i < missionOpen; i++) {
//			missionBtnContent [i].transform.GetComponent<Button> ().interactable = true;
//		}


//		for (int i = 0; i < levelOpen; i++) {
//			levelBtn [i].SetActive (true);
//			levelBtn [i].transform.GetComponent<Button> ().interactable = true;
//
//		}

	}


	public void OnBtnBack ()
	{
		levelSelectPanel.gameObject.SetActive (false);
		mainMenuPanel.gameObject.SetActive (true);
		audioSource.PlayOneShot (bsound);
	}





	public void OnLevelBtn (int levelNo)
	{
		OnLoading ();
		PlayerPrefs.SetInt ("LevelNo", levelNo);
		SceneManager.LoadScene (1);
		audioSource.PlayOneShot (bsound);

	}


	public void OnLoading ()
	{
		loadingPanel.gameObject.SetActive (true);
		//MoPubAds.showAd (MoPubAds._interstitialOnSelectionId);
	}


}
