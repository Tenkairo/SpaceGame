using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenyu : MonoBehaviour {

    public GameObject loadScreen;
    public Slider slide;
    public TextMeshProUGUI loadText;

    public void loadThyLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation thyOp = SceneManager.LoadSceneAsync(sceneIndex);

        loadScreen.SetActive(true);

        while (!thyOp.isDone)
        {
            float progress = Mathf.Clamp01(thyOp.progress / .9f);

            slide.value = progress;
            loadText.text = (progress * 100f) + "%";
            yield return null;
        }
    }
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
