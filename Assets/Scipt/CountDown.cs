using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	public float myTimer=5;

	Text text;

	void Start () {
		text = GetComponent<Text>();
	}

	void Update () {
		if (myTimer > 0) 
			myTimer -= Time.deltaTime;
		text.text = Mathf.Ceil(myTimer).ToString();
	}
}