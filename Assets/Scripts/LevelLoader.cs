using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;
	public Text progressText;

	void Start() {
		StartCoroutine (LoadAsynchronously());
	}


	IEnumerator LoadAsynchronously () {
		AsyncOperation operation = SceneManager.LoadSceneAsync (1);
		loadingScreen.SetActive (true);
		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);

			slider.value = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);

			Debug.Log(progress);

			yield return null;
		}
	}
}
