using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public float delayTime = 2;

	float fadeTime=0;
	public GameObject tex0;
	public GameObject tex1;
	IEnumerator Start(){
		print (tex1.GetComponent<RawImage> ().color.a);
		yield return new WaitForSeconds( delayTime );

		Application.LoadLevel( "All" );
	}

	void Update () {
		fadeTime += Time.deltaTime;
		if (fadeTime > 1.2f) {
			tex0.GetComponent<RawImage> ().CrossFadeAlpha (0f, 0.3f, false);
			tex1.GetComponent<RawImage> ().CrossFadeAlpha (0f, 0.3f, false);

		}

	}
}
