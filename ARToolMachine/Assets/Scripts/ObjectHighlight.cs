using UnityEngine;
using System.Collections;

public class ObjectHighlight : MonoBehaviour {

	public string objectIndex;
	public string objectNumber;
	public string objectName;
	public string objectQuantity;


	private Color startColor;
	private bool _displayObjectName = false;


	void Start()
	{
	}

	void Update(){
		//Debug.Log(Screen.width+" , "+Screen.height);
		//Debug.Log (Input.mousePosition.x+" , "+Input.mousePosition.y);
	}

	void OnGUI()
	{
		DisplayName ();
	}

	void OnMouseEnter()
	{
		startColor = GetComponent<Renderer>().material.color;
		GetComponent<Renderer> ().material.color = new Color(0.6f,0,0,1);
		_displayObjectName = true;
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = startColor;
		_displayObjectName = false;
	}

	void DisplayName()
	{
		if (_displayObjectName) {
			GUI.Box (new Rect (Event.current.mousePosition.x + 10, Event.current.mousePosition.y, 150, 70),
				"氣球號："+objectIndex+"\n"+
				"零件號碼："+objectNumber+"\n"+
				"零件名稱："+objectName+"\n"+
				"數量："+objectQuantity);
		}
	}
}
