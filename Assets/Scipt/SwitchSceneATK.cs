using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchSceneATK : MonoBehaviour {
	public Weapon weapon;

	public void NextScene (string sceneName) {
		Time.timeScale = 1;
		weapon.damage += 5;
		SceneManager.LoadScene(sceneName);
	}
}


