using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private Animator _loadingScreenAnimator;
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
        _loadingScreenAnimator.SetBool("Active", true);
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
        yield return new WaitForSecondsRealtime(1.0f);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneId);
        loadOperation.allowSceneActivation = false;

        while(loadOperation.progress < 0.9f)
        {
            _loadingBar.value = loadOperation.progress;
            yield return null;
        }
        Time.timeScale = 1.0f;
        loadOperation.allowSceneActivation = true;
        _loadingScreenAnimator.SetBool("Active", false);
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
