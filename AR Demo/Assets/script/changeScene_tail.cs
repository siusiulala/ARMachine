using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScene_tail : MonoBehaviour {

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
			SceneManager.LoadScene ("tail_all");
			break;
		case 1:
			SceneManager.LoadScene ("tail_mandrel");
			break;
		case 2:
			SceneManager.LoadScene ("tail_lock");
			break;
		default:
			break;
		}

	}
}
