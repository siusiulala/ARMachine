using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour {

//	public GameObject loadText;
//	public GameObject loadImage;
//	IEnumerator DisplayLoadingScreen (string sceneName){////(1)
//		AsyncOperation async = Application.LoadLevelAsync (sceneName);////(2)
//		while (!async.isDone) {////(3)
//			loadText.text = (async.progress * 100).ToString() + "%";////(4)
//			loadImage.transform.localScale = new Vector2(async.progress,loadImage.transform.localScale.y);
//			yield return null;
//		}
//	}

	public void ToAR()
	{
		SceneManager.LoadScene ("AR");
	}

	public void ToAll()
	{
		SceneManager.LoadScene ("All");
	}

	public void ToMain()
	{
		SceneManager.LoadScene ("main_all");
	}

	public void ToMainA1()
	{
		SceneManager.LoadScene ("main_A1");
	}

	public void ToMainA2()
	{
		SceneManager.LoadScene ("main_A2");
	}

	public void ToMainB()
	{
		SceneManager.LoadScene ("main_B");
	}

	public void ToMainF()
	{
		SceneManager.LoadScene ("main_F");
	}

	public void ToMainL1()
	{
		SceneManager.LoadScene ("main_L1");
	}

	public void ToMainL2()
	{
		SceneManager.LoadScene ("main_L2");
	}

	public void ToTail()
	{
		SceneManager.LoadScene ("tail_all");
	}

	public void ToTailLock()
	{
		SceneManager.LoadScene ("tail_Lock");
	}

	public void ToTailmandrel()
	{
		SceneManager.LoadScene ("tail_mandrel");
	}

	public void ToBed()
	{
		SceneManager.LoadScene ("bed_all");
	}

	public void ToBedMotor()
	{
		SceneManager.LoadScene ("bed_Motor");
	}

	public void ToBedFoot()
	{
		SceneManager.LoadScene ("bed_Foot");
	}

	public void ToBedZ()
	{
		SceneManager.LoadScene ("bed_Z");
	}

	public void ToBedC()
	{
		SceneManager.LoadScene ("bed_C");
	}

	public void ToBedMotorCase()
	{
		SceneManager.LoadScene ("bed_MotorCase");
	}

	public void ToYall()
	{
		SceneManager.LoadScene ("y_all");
	}

	public void ToYStand()
	{
		SceneManager.LoadScene ("y_Stand");
	}

	public void ToYATC()
	{
		SceneManager.LoadScene ("y_ATC");
	}

	public void ToYBAxis()
	{
		SceneManager.LoadScene ("y_Baxis");
	}

	public void ToYSub()
	{
		SceneManager.LoadScene ("y_Sub");
	}

	public void ToYYAxis()
	{
		SceneManager.LoadScene ("y_Yaxis");
	}

	public void ToXall()
	{
		SceneManager.LoadScene ("x_all");
	}

	public void ToXXAxis()
	{
		SceneManager.LoadScene ("x_Xaxis");
	}

}
