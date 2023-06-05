using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour {

	public float myTimer=0;

	Text text;

	void Start () {
		text = GetComponent<Text>();
	}

	void Update () {
		myTimer += Time.deltaTime;
		text.text = (myTimer).ToString("'Survive(60s):'00");
	}
}


