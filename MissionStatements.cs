using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionStatements : MonoBehaviour
{

	public AmbientColors ambientColors;

	[System.Serializable]
	public class AmbientColors
	{
		public ColorDay colorDay;
		public ColorNight colorNight;

		[System.Serializable]
		public class ColorDay
		{
			public float r1, b1, g1, a1;
		}

		[System.Serializable]
		public class ColorNight
		{
			public float r2, b2, g2, a2;
		}

	}
	public Transform gpc, gpuic, alienShip;
	public GameObject directionalLight;
	public Material daySky, nightSky;
	public Transform mainCamera;
	public Transform camRef1, camRef2, camRef3;
	public GameObject missionPanel, gamePanel, btnSkip, btnOK;
	public Text missionText;
	public string missionLine1, missionLine2;
	public AudioClip clip, btnPress;
	public bool isMissionTyping, isFade = false;
	int lvlNo;
	int l = 0;
	int missionLineNo = 0;


	void Awake ()
	{


		PlayerPrefs.SetInt ("Mode", 0);
		

		if (PlayerPrefs.GetInt ("Mode") == 1) {
			directionalLight.gameObject.SetActive (false);
			RenderSettings.skybox = nightSky;
//			RenderSettings.ambientLight = new Color (ambientColors.colorNight.r2, ambientColors.colorNight.g2, ambientColors.colorNight.b2, ambientColors.colorNight.a2);

		} else if (PlayerPrefs.GetInt ("Mode") == 0) {
			directionalLight.gameObject.SetActive (true);
			RenderSettings.skybox = daySky;
//			RenderSettings.ambientLight = new Color (ambientColors.colorDay.r1, ambientColors.colorDay.g1, ambientColors.colorDay.b1, ambientColors.colorDay.a1);
//			RenderSettings.ambientIntensity = 1.0f;

		}

		lvlNo = PlayerPrefs.GetInt ("LevelNo");
		mainCamera = GameObject.FindWithTag ("MainCamera").transform;
		alienShip.gameObject.SetActive (true);
//		if (lvlNo > 0 && lvlNo < 4) {
//			mainCamera.transform.GetComponent<SmoothFollow> ().SetTarget (camRef1);
//		} else if (lvlNo > 3 && lvlNo < 7) {
//			mainCamera.transform.GetComponent<SmoothFollow> ().SetTarget (camRef2);
//		} else if (lvlNo > 6 && lvlNo < 10) {
//			mainCamera.transform.GetComponent<SmoothFollow> ().SetTarget (camRef3);
//		}


		
	}


	// Use this for initialization
	void Start ()
	{
		lvlNo = PlayerPrefs.GetInt ("LevelNo");
		Time.timeScale = 1.0f;
		//MoPubAds.hideBanner ();
		StartCoroutine (CamSwitch ());
	}

	IEnumerator CamSwitch ()
	{


		yield return new WaitForSeconds (0.75f);


//		Invoke ("MissionObjective", 0.3f);
		MissionObjective();
		
	}


	public void MissionObjective ()
	{
		
		missionPanel.SetActive (true);
		missionPanel.transform.GetComponent<Animation> ().enabled = true;
		missionPanel.transform.GetComponent<Animation> ().Play ("PanelShowAnim");
		missionLineNo++;
		missionText.gameObject.SetActive (true);
		GetComponent<AudioSource> ().PlayOneShot (clip);
		missionLine1 = "Alien enemies are wandering in the city and deploying their mass destruction weapons...";
//		missionLine1 = "Alien enemies are ...";

		missionLine2 = "Trace them on the map shown and hunt them down.";
//		if (lvlNo == 1) {
//			missionLine1 = "Alien enemies are wandering in the city and deploying their mass destruction weapons...";
//			missionLine2 = "Trace them on the map shown and hunt them down.";
//		}
//		if (lvlNo == 2) {
//			missionLine1 = "Alien enemies are wandering in the city and deploying their mass destruction weapons...";
//			missionLine2 = "Trace them on the map shown and hunt them down.";
//		}
//		if (lvlNo == 3) {
//			missionLine1 = "Alien enemies are wandering in the city and deploying their mass destruction weapons...";
//			missionLine2 = "Trace them on the map shown and hunt them down.";
//		}
//		if (lvlNo == 4) {
//			missionLine1 = "Alien enemies are wandering in the city and deploying their mass destruction weapons...";
//			missionLine2 = "Trace them on the map shown and hunt them down.";
//		}
//		if (lvlNo == 5) {
//			missionLine1 = "Alien enemies are wandering in the city and deploying their mass destruction weapons...";
//			missionLine2 = "Trace them on the map shown and hunt them down.";
//		}
//		if (lvlNo == 6) {
//			missionLine1 = "Drive the loader truck to the stone factory by following the arrow and start stone reforming process.";
//		}
//		if (lvlNo == 7) {
//			missionLine1 = "Drive the excavator to the hills by following the arrow and crush big stones.";
//		}
//		if (lvlNo == 8) {
//			missionLine1 = "Drive the loader truck, join factory workers in hills by following the arrow and then load the stones on the truck.";
//		}
//		if (lvlNo == 9) {
//			missionLine1 = "Drive the loader truck to the stone factory by following the arrow and start stone reforming process.";
//		}
		if (missionLineNo == 1) {
			StartMissionMessage (0.1F, missionLine1);
//			Debug.Log ("starting mission line 1: " + missionLineNo);

		} else if (missionLineNo == 2) {
			StartMissionMessage (0.1F, missionLine2);
//			Debug.Log ("starting mission line 2: " + missionLineNo);

		} else {
			return;
		}
	
	
	}



	public void StartMissionMessage (float showtime, string str)
	{
		StopAllCoroutines ();
		isMissionTyping = false;
		StartCoroutine (MissionCorutine (showtime, str));
	}

	IEnumerator MissionCorutine (float t, string str)
	{
		if (!isMissionTyping) {
			yield return new WaitForSeconds (t);
			GetComponent<AudioSource> ().PlayOneShot (clip);
		
			missionOne (str);
			StartCoroutine (MissionCorutine (t, str));
		} else {
		
		}
	}

	public void missionOne (string st)
	{
		if (l < st.Length) {
			if (missionLineNo == 1) {
				missionText.text = string.Concat (missionText.text, missionLine1 [l]);
			} else {
				missionText.text = string.Concat (missionText.text, missionLine2 [l]);
			
			}
			l++;

		} else {

			isMissionTyping = true;
		}
	
	}

	public void OnBtnSkip(){
		btnSkip.SetActive (false);
		missionText.text = "";
		l = 0;
		MissionObjective ();

		GetComponent<AudioSource> ().PlayOneShot (btnPress);
		btnOK.SetActive (true);
	}



	public void OnButtonOK ()
	{
		
		GetComponent<AudioSource> ().PlayOneShot (btnPress);

		gpc.gameObject.SetActive (true);
		gpuic.gameObject.SetActive (true);
		alienShip.gameObject.SetActive (false);
		gpuic.GetComponent<GamePlayUIController> ().ShowControls ();
		Time.timeScale = 1.0f;
		StopAllCoroutines ();
		missionText.text = "";
		missionPanel.SetActive (false);
		missionText.gameObject.SetActive (false);
		gpc.GetComponent<SetAllForLevels> ().SetRoboOn (true);
		GamePlayUIController.isTime = true;
	}

	// Update is called once per frame
	void Update ()
	{
		
	}


}
