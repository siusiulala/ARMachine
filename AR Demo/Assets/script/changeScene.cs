using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Dropdown menu;
	public void changeSceneTo() {
		switch (menu.value) {
		case 0:
			SceneManager.LoadScene ("explode");
			break;
		case 1:
			SceneManager.LoadScene ("explodeA1");
			break;
		case 2:
			SceneManager.LoadScene ("explodeA2");
			break;
		case 3:
			SceneManager.LoadScene ("explodeB");
			break;
		case 4:
			SceneManager.LoadScene ("explodeF");
			break;
		case 5:
			SceneManager.LoadScene ("explodeL1");
			break;
		case 6:
			SceneManager.LoadScene ("explodeL2");
			break;
		default:
			break;
		}

	}
}
