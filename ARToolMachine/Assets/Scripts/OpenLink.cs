using UnityEngine;
using System.Collections;

public class OpenLink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Link()
	{
		Application.OpenURL("https://drive.google.com/open?id=0B69ToyZnDg2tbW5KTHVIbS11ejQ");
	}
}
