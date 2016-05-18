using UnityEngine;
using System.Collections;

public class NGUIRayCast : MonoBehaviour {

	public UICamera nguiCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
//	void Update () {
//		Ray ray1 = nguiCamera.camera.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit1;
//		LayerMask mask = 1 << LayerMask.NameToLayer("NGUI Layer");
//		if (Physics.Raycast(ray1, out hit1, 600, mask.value)) {
//			Debug.Log ("HIT!!!");
//			return;
//		}
//	}
}
