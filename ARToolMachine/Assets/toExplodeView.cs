using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class toExplodeView : MonoBehaviour {

	public void ToMain()
	{
		SceneManager.LoadScene ("explode");
	}

	public void ToTail()
	{
		SceneManager.LoadScene ("tail_all");
	}
}
