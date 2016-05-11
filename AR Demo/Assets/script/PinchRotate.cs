using UnityEngine;
using System.Collections;

public class PinchRotate : MonoBehaviour {
	

	void Start () 
	{
		
	}
	public GameObject target;
	void Update () 
	{
		if (Input.touchCount == 1)
		{

			Touch touchZero = Input.GetTouch(0);
			Vector2 touchZeroDelta = touchZero.deltaPosition;

			target.transform.Rotate (touchZeroDelta.y, touchZeroDelta.x, 0);

		}

	}


}
