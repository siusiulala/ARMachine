using UnityEngine;
using System.Collections;

public class ChangeVisible : MonoBehaviour {

	public GameObject target;
	public bool isVisable = false;
	public void Show()
	{
		NGUITools.SetActive(target, true);
	}

	public void Hide()
	{
		NGUITools.SetActive(target, false);
	}

	public void Switch()
	{
		if (isVisable) {
			NGUITools.SetActive(target, false);
			isVisable = false;
		} else {
			NGUITools.SetActive(target, true);
			isVisable = true;
		}
	}
}
