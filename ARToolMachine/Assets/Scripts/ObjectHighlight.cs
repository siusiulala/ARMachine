using UnityEngine;
using System.Collections;

public class ObjectHighlight : MonoBehaviour {

	public string objectIndex;
	public string objectNumber;
	public string objectName;
	public string objectQuantity;
	public string[] objectFeature;

	private int boxWidth2 = 0;
	private int boxHeight2 = 0;
	private string tmpStr = "";

	private Color startColor;
	private bool _displayObjectName = false;


	void Start()
	{
		
		foreach (string fetureStr in objectFeature) {
			tmpStr += "\n" + fetureStr;
			boxWidth2 = (fetureStr.Length > boxWidth2) ? fetureStr.Length : boxWidth2;
		}
		boxWidth2 = boxWidth2 * 16;
		boxHeight2 = 90 + objectFeature.Length * 25;
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
		GetComponent<Renderer> ().material.color = new Color(0.2f,0.6f,1.0f,1);
		_displayObjectName = true;
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = startColor;
		_displayObjectName = false;
	}

	void DisplayName()
	{
		GUIStyle myStyle = new GUIStyle(GUI.skin.button);
		myStyle.fontSize = 30;



		if (_displayObjectName) {
			int boxWidth = (objectNumber.Length > objectName.Length) ? 180 + objectNumber.Length * 25 : 180 + objectName.Length * 25;
//			int boxHeight = 120 + objectFeature * 25;
			GUI.Box (new Rect (Event.current.mousePosition.x-75, Event.current.mousePosition.y-140, boxWidth, 120),
				//"氣球號："+objectIndex+"\n"+
				"零件號碼：" + objectNumber + "\n" +
				"零件名稱：" + objectName + "\n" +
				"數量：" + objectQuantity
				,myStyle);
			if (objectFeature.Length > 0) {
				GUI.Box (new Rect (Event.current.mousePosition.x - 75, Event.current.mousePosition.y + 100, boxWidth2, boxHeight2),
				//"氣球號："+objectIndex+"\n"+
					tmpStr, myStyle);
			}
		}
	}
}
