using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour {

	public void ToAR()
	{
		SceneManager.LoadScene ("ARview");
	}

	public void ToMain()
	{
		SceneManager.LoadScene ("explode");
	}

	public void ToTail()
	{
		SceneManager.LoadScene ("tail_all");
	}
}
