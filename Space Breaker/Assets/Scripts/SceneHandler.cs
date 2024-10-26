using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _loadingBar;

    public static SceneHandler Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void LoadScene(int sceneId)
    {
        int sceneAmount = SceneManager.sceneCountInBuildSettings;
        if (sceneId > sceneAmount - 1)
            sceneId = 0;
        _loadingBar.value = 0.0f;
        StartCoroutine(ChangeScene(sceneId));
    }

    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentIndex + 1);
    }

    public void ReloadScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentIndex);
    }

    private IEnumerator ChangeScene(int sceneId)
    {
        _loadingScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneId);

        while(!loadOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _loadingBar.value = progress;
            yield return null;
        }
        Time.timeScale = 1.0f;
        _loadingScreen.SetActive(false);
    }

    //Save unlocked level
    public void UnlockLevelScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int savedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (savedLevel < currentIndex + 1)
            PlayerPrefs.SetInt("UnlockedLevel", currentIndex + 1); 
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
