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
}
