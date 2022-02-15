using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRoboController : MonoBehaviour
{
	Animator anim;
	public EasyJoystick playerRoboJoyStick;
	public Transform btnRifleIn, btnRifleOut, attckBtn;
	public Sprite fireSprite, punchSprite;
	public GameObject rifleObjIn, rifleObjOut;

	int health = 100;
	int maxHealth = 100;
	public Image healthBar;

	public static bool isBareHand, isRifleStand, isRifleSit = false;
	bool punch = false;

	public Transform bulletSpawnPoint;
	public Rigidbody roboBullet;
	public int bulletSpeed;

	// Use this for initialization
	void Start ()
	{
		anim = this.transform.GetComponent<Animator> ();
		btnRifleIn.gameObject.SetActive (false);

		isBareHand = true;
		isRifleStand = false;
		isRifleSit = false;

		rifleObjIn.SetActive (true);
		rifleObjOut.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			OnBtnAttack ();
		}


	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "EnemyBullet") {
			Hit (10);
		}
	}

	public void Hit (int damage){
		health = health - damage;
		Debug.Log ("eroboHealth : " + health.ToString ());
		healthBar.fillAmount = (float)health / (float)maxHealth;
		if (health <= 0) {
			GameObject.FindWithTag ("GameUIController").transform.GetComponent<GamePlayUIController> ().HideControls ();
			anim.Play ("death");
			GamePlayController.playerDied = true;
			StartCoroutine (CallFail ());
		}
	}

	IEnumerator CallFail(){
		yield return new WaitForSeconds (2.0f);
		GameObject.FindWithTag ("GameController").transform.GetComponent<GamePlayController> ().Failed ("Player died!!");	

	}

	public void OnBtnAttack ()
	{


		if (!GamePlayController.playerDied) {	
			if (isBareHand) {
			
				if (!punch) {
					anim.Play ("smash");
					punch = true;
				} else {
					anim.Play ("punch");
					punch = false;
				}

			} else if (isRifleStand) {
				anim.Play ("rifleShootStand");
				OnFire ();
			} else if (isRifleSit) {
			
			}
		}


	}

	public void OnBtnRifleSit ()
	{

	}

	public void OnBtnRifleStand ()
	{
		
	}

	public void OnBtnRifleOut ()
	{
		isRifleStand = true;
		isBareHand = false;
		isRifleSit = false;

		anim.Play ("rifleOut");

		btnRifleOut.gameObject.SetActive (false);
		btnRifleIn.gameObject.SetActive (true);
		attckBtn.transform.GetComponent<Image> ().sprite = fireSprite;

		StartCoroutine (RifleOUT ());
		playerRoboJoyStick.speed.y = 12f;

	}

	IEnumerator RifleOUT ()
	{
		yield return new WaitForSeconds (.3f);
		rifleObjIn.SetActive (false);
		rifleObjOut.SetActive (true);
	}

	public void OnBtnRifleIn ()
	{
		

		anim.Play ("rifleIn");

		isRifleStand = false;
		isBareHand = true;
		isRifleSit = false;

		btnRifleOut.gameObject.SetActive (true);
		btnRifleIn.gameObject.SetActive (false);
		attckBtn.transform.GetComponent<Image> ().sprite = punchSprite;


		StartCoroutine (RifleIN ());
		playerRoboJoyStick.speed.y = 22f;

	}

	IEnumerator RifleIN ()
	{
		yield return new WaitForSeconds (.8f);
		rifleObjIn.SetActive (true);
		rifleObjOut.SetActive (false);
	}

	public void OnFire(){
		Rigidbody bullet;
		bullet = Instantiate (roboBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody;
		bullet.velocity = bulletSpawnPoint.TransformDirection(Vector3.forward * bulletSpeed);
	}


}
