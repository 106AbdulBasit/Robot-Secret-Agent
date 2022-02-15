using UnityEngine;
using System.Collections;

public class TrafficCollision : MonoBehaviour
{

	public Transform[] tyres;
	public float tyrerotationspeed;
	bool once;
	hoMove homove;
	TrafficController tc;

	// Use this for initialization
	void Start ()
	{
		once = true;
		homove = this.transform.GetComponent<hoMove> ();
		tc = this.transform.GetComponentInChildren<TrafficController> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
      



       
		if (this.tc.isFrontBlocked) {
			this.homove.Pause ();
			foreach (Transform t in tyres) {
				t.Rotate (0, 0, 0);
			}
		} else {
			once = true;
			this.homove.Resume ();
			foreach (Transform t in tyres) {
				t.Rotate (12, 0, 0);
			}
		}

//        else
//        {
//            if (once)
//            {
//                transform.GetComponent<hoMove>().Resume();
//
//                foreach (Transform t in tyres)
//                {
//                    t.Rotate(12, 0, 0);
//                }
//            }
//        }
	}

	void OnCollisionEnter (Collision col)
	{

		if (col.collider.tag == "Player" || col.collider.tag == "Traffic") {
			Debug.Log (col.gameObject.name);
			
			homove.Pause ();
			foreach (Transform t in tyres) {
				t.Rotate (0, 0, 0);
			}
			once = false;
			StartCoroutine (WWait ());

		}
		
	}

	IEnumerator WWait ()
	{
		
		yield return new WaitForSeconds (6.0f);
		homove.Resume ();
		foreach (Transform t in tyres) {
			t.Rotate (12, 0, 0);
		}
		once = true;
	}
}
