using UnityEngine;
using System.Collections;

public class ClickObject : MonoBehaviour {

	// Use this for initialization
	private void OnMouseDown() {
		Destroy (gameObject);
	}
}
