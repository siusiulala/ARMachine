using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Vuforia;

public class DebugSplitAndroid : MonoBehaviour {

	public string dataSetName;

	public GameObject[] ITGameObjects; 
	public GameObject GOaugmentation1;
	public GameObject GOtransformTemplate1;

	public GameObject GOaugmentation2;
	public GameObject GOtransformTemplate2;

	string windowText;

	string windowText1="windowText1(rien)";
	string windowText2="windowText2(rien)";
	string windowText3="windowText3(rien)";
	string windowText4="windowText4(rien)";
	string windowText5="windowText5(rien)";
	string windowText6="windowText6(rien)";
	string windowText7="windowText7(rien)";


	void OnGUI () {
	GUI.Box (new Rect (100,50,1,1), windowText1); 
	GUI.Box (new Rect (100,100,1,1), windowText2); 
	GUI.Box (new Rect (100,200,1,1), windowText3); 
	GUI.Box (new Rect (100,300,1,1), windowText4); 
	GUI.Box (new Rect (100,400,1,1), windowText5); 
	GUI.Box (new Rect (100,500,1,1), windowText6); 
	GUI.Box (new Rect (100,600,1,1), windowText7); 
	}


	private bool mLoaded = false;
	private DataSet mDataset = null;
	ObjectTracker tracker;

	// Use this for initialization
	void Start () {
		StartCoroutine(LancementSequenceComplete());

	}

	// ------------------------------------------------------------------------------------
	IEnumerator LancementSequenceComplete()
	{
		//   1/3 COPIE DU DATASET DU OBB VERS LA SD CARD
		//		StartCoroutine(copieDatasetEnLocal("BrochureArforia"));
		StartCoroutine(copieDatasetEnLocal());
		//	yield return new WaitForSeconds(2);
		//   2/3 CHARGEMENT DU DATASET A PARTIR DE LA SD CARD
		yield return new WaitForSeconds(3);
		SDCardDataSetLoader();
		//mLoaded= false;
		//mDataset = null;
		//SDCardDataSetLoader("showroom");

		//   3/3 CONFIGURATION DES IMAGE TARGET EN DYNAMIQUE
		//configurationImageTargetDynamique();
	}

	// ------------------------------------------------------------------------------------
	IEnumerator copieDatasetEnLocal() 
	{
		string[] filesInOBB = {
			dataSetName+".dat",
			dataSetName+".xml"
			//"showroom.dat",
			//"showroom.xml"
		};



		foreach (var filename in filesInOBB) {
			Debug.Log ("filename:"+filename);
			string uri = Application.streamingAssetsPath + "/QCAR/" +filename;
			var www = new WWW(uri);
			windowText1="copieDatasetEnLocal() : uri : "+ uri;
			yield return www;
			if (www.error != null)
			{
				windowText2="copieDatasetEnLocal() : wwww error " + www.error;
				yield break;
			}

			// modif CVI 13/06/2016
			if (!File.Exists(Application.persistentDataPath + "/" + filename))
			{
			File.WriteAllBytes(Application.persistentDataPath + "/" + filename, www.bytes);
			}
			windowText3="copieDatasetEnLocal() : copie OK, persitentDataPath : " +Application.persistentDataPath + "/" + filename;
		}
//		Application.LoadLevel("AR");
		Application.LoadLevel("Menu");

	}

	// ------------------------------------------------------------------------------------



	// Update is called once per frame
	void SDCardDataSetLoader () {
		if (VuforiaRuntimeUtilities.IsVuforiaEnabled() && !mLoaded) {
			//string externalPath = "/mnt/sdcard/demoartdeville/QCAR/"+fileName+".xml";
			string externalPath =Application.persistentDataPath + "/"+dataSetName+".xml";

			if (mDataset == null) {
				// First, create the dataset
				tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
				mDataset = tracker.CreateDataSet();
			}

			if (mDataset.Load(externalPath, VuforiaUnity.StorageType.STORAGE_ABSOLUTE)) {
				mLoaded = true; 
				windowText4="SDCardDataSetLoader()  : chargement dataset "+dataSetName+"ok ";
				tracker.ActivateDataSet(mDataset);
				AttachContentToTrackables(mDataset);

			}
			else {
				Debug.LogError ("Failed to load dataset!"); 
				windowText5="SDCardDataSetLoader()  : Failed to load dataset "+dataSetName+"";
			}
		}
	}

	//This will also call on the function that will activate the imagetarget and add content to it.


	private void AttachContentToTrackables(DataSet dataSet)
	{
		windowText1="init";
		// get all current TrackableBehaviours
		IEnumerable<TrackableBehaviour> trackableBehaviours = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
		bool check = false;
		int compteur=0;
		// Loop over all TrackableBehaviours.
		foreach (TrackableBehaviour trackableBehaviour in trackableBehaviours)
		{

			windowText6+="tb: " + trackableBehaviour.Trackable.Name +"; ";
			// check if the Trackable of the current Behaviour is part of this dataset
			if (dataSet.Contains(trackableBehaviour.Trackable))// && !check)
			{
				compteur+=1;
				//check = true;
				GameObject go = trackableBehaviour.gameObject;

				go.name="ImageTarget"+compteur;

				if (compteur>1) {	windowText2="GO trackableBehaviour.gameObject.name N"+compteur+ " :"+ go.gameObject.name+" trackable:"+trackableBehaviour.Trackable.Name;}
				else {windowText1="GO trackableBehaviour.gameObject.name N"+compteur+ " :"+ go.gameObject.name +" trackable:"+trackableBehaviour.Trackable.Name;}


				//go.transform.position = GOtransformTemplate1.transform.position;
				//go.transform.rotation = GOtransformTemplate1.transform.rotation;
				//go.transform.localScale = GOtransformTemplate1.transform.localScale;

				// Add a Trackable event handler to the Trackable.
				// This Behaviour handles Trackable lost/found callbacks.
				go.AddComponent<TrackableBehaviour>();
				go.AddComponent<DefaultTrackableEventHandler>();//PouletTrackableEventHandler

				/*	
			    go.GetComponent<PouletTrackableEventHandler>().GOaugmentation1=GOaugmentation1;
				go.GetComponent<PouletTrackableEventHandler>().GOaugmentation2=GOaugmentation2;
				go.GetComponent<PouletTrackableEventHandler>().GOtransformTemplate1=GOtransformTemplate1;
				go.GetComponent<PouletTrackableEventHandler>().GOtransformTemplate2=GOtransformTemplate2;
				*/

				// Attach the cube to the Trackable and make sure it has a proper size.
				if (compteur==1){		
					go.transform.localPosition = GOtransformTemplate1.transform.position;
					go.transform.localRotation = GOtransformTemplate1.transform.rotation;
					go.transform.localScale = GOtransformTemplate1.transform.localScale;
					GOaugmentation1.transform.parent = trackableBehaviour.transform;
				}

				if (compteur==2){
					go.transform.localPosition = GOtransformTemplate2.transform.position;
					go.transform.localRotation = GOtransformTemplate2.transform.rotation;
					go.transform.localScale = GOtransformTemplate2.transform.localScale;
					GOaugmentation2.transform.parent = trackableBehaviour.transform;
				}

				for (int x = 0; x < ITGameObjects.Length; x++)
				{
					go.transform.localPosition = ITGameObjects[x].transform.position;
					go.transform.localRotation = ITGameObjects[x].transform.rotation;
					go.transform.localScale = ITGameObjects[x].transform.localScale;
					ITGameObjects[x].transform.parent = trackableBehaviour.transform;
				}

				trackableBehaviour.gameObject.SetActive(true);

			}
		}
	}
}


/*
	void copieDatasetEnLocal(string fileName)
	{
		if (!File.Exists("/sdcard/demoartville/"+fileName+".xml") && !File.Exists("/sdcard/demoartdeville/"+fileName+".dat"))
		{
			var filePath1 = System.IO.Path.Combine(Application.streamingAssetsPath, "QCAR/"+fileName+".xml");
			var filePath2 = System.IO.Path.Combine(Application.streamingAssetsPath, "QCAR/"+fileName+".dat");
			
			Debug.Log("File path1 :"+filePath1);
			Debug.Log("File path2 :"+filePath2);
			windowText="copieDatasetEnLocal() : File path1 :"+filePath1;
			windowText="copieDatasetEnLocal() : File path2 :"+filePath2;

			var www1 = new WWW(filePath1);
			
			while(!www1.isDone)
			{
				Debug.Log(www1.progress);
			};
			
			var www2 = new WWW(filePath2);
			
			/*while(!www2.isDone)
			{
				Debug.Log("This is the progress: "+www2.progress);
				windowText="copieDatasetEnLocal() : This is the progress: "+www2.progress;
			};

			if (!System.IO.Directory.Exists("/mnt/sdcard/demoartdeville/"))
			{
				System.IO.Directory.CreateDirectory("/mnt/sdcard/demoartdeville/");
			}
			File.WriteAllBytes("/mnt/sdcard/demoartdeville/"+fileName+".xml", www1.bytes);
			File.WriteAllBytes("/mnt/sdcard/demoartdeville/"+fileName+".dat", www2.bytes);
			
			Debug.Log(fileName+" is done!!!!!*!*!*!*!*!*!");
			windowText="copieDatasetEnLocal() : DONE ";
		}
	}
	*/
// ------------------------------------------------------------------------------------

/*void configurationImageTargetDynamique()
	{
	StateManager sm = TrackerManager.Instance.GetStateManager();
	IEnumerable<TrackableBehaviour> tbs = sm.GetTrackableBehaviours();
	
	// Add an augmentation to each trackable
	foreach ( TrackableBehaviour tb in tbs ) {
		Debug.Log ("configurationImageTargetDynamique() : Adding augmentation to " + tb.TrackableName);
		windowText6="configurationImageTargetDynamique() : Adding augmentation to " + tb.TrackableName;
		
		// Create a simple cube
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		
		// attach the cube to the TB
		cube.transform.parent = tb.transform;
		
		// adjust the local position and scale
		cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
		cube.transform.localPosition = new Vector3(0,0.15f,0);
		cube.transform.localRotation = Quaternion.identity;
		cube.SetActive(true);
		
		// Add a DefaultTrackableEventHandler to the Trackable object
		tb.gameObject.AddComponent<DefaultTrackableEventHandler>();
			windowText7="configurationImageTargetDynamique() : fin";
	}


	}
	/*

	public bool LoadDataSet(string dataSetPath, DataSet.StorageType storageType)
	{
		// Check if the data set exists at the given path.
		if (!DataSet.Exists(dataSetPath, storageType))
		{
			Debug.LogError("Data set " + dataSetPath + " does not exist.");
			return false;
		}
		// Request an ImageTracker instance from the TrackerManager.
		ImageTracker imageTracker =
			(ImageTracker)TrackerManager.Instance.GetTracker(Tracker.Type.IMAGE_TRACKER);
		// Create a new empty data set.
		DataSet dataSet = imageTracker.CreateDataSet();
		
		// Load the data set from the given path.
		if (!dataSet.Load(dataSetPath, storageType))
		{
			Debug.LogError("Failed to load data set " + dataSetPath + ".");
			return false;
		}
		// (Optional) Activate the data set.
		imageTracker.ActivateDataSet(dataSet);
		
		return true;
	}
	*/
//This function is straight from Vuforia sample code. It simply loades the dataset on the given path. Here is how to call it.
/*
	void ChargerDataset(){

		if(LoadDataSet("/mnt/sdcard/YourAppName/"+name+".xml", DataSet.StorageType.STORAGE_ABSOLUTE))
	{
		ImageTracker imageTracker =
			(ImageTracker)TrackerManager.Instance.GetTracker(Tracker.Type.IMAGE_TRACKER);
		
		IEnumerable<DataSet> datasets = imageTracker.GetActiveDataSets();
		//DataSet dataSet;
		
		//foreach (DataSet dataSet in datasets)
		//{
		AttachContentToTrackables(dataSet);
		//}
		}}
*/
