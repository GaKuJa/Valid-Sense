using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScreen : MonoBehaviour
{
    public static TransitionScreen instance;

    [SerializeField] float dropSpeedInSeconds = 0.01f;
    [SerializeField] AudioClip fallingUISound;

    RectTransform rectTransform;
    public float currentTime;
    Vector3 startingPos;
    Vector3 endingPos;
    float endingYPos = 0;

    private bool isShutterDown;
    AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);
    }

    void Start()
    {
        if (dropSpeedInSeconds <= 0) Debug.LogError("Value is less than or equal to zero!");
        currentTime = 0;
        rectTransform = GetComponent<RectTransform>();
        startingPos = rectTransform.position;
        endingPos = new Vector3(startingPos.x, endingYPos, startingPos.z);
        Debug.Log(endingPos);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fallingUISound;
    }

    void Update()
    {
        //Debug DropShutter Key
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) { DropShutter(1f,1f); }
    }

    public void DropShutter(float waitTime, float delayTime = 0f)
    {
        audioSource.Play();
        StartCoroutine(MoveShutter(waitTime));
        StartCoroutine(MoveShutter(waitTime,delayTime));
    }

    private IEnumerator MoveShutter(float waitTime, float delayTime = 0f)
    {
        if (delayTime != 0) yield return new WaitForSeconds(delayTime);

        if (!isShutterDown)
        {
            while (currentTime < 1)
            {
                currentTime += Time.deltaTime / dropSpeedInSeconds;
                rectTransform.position = Vector3.Lerp(startingPos, endingPos, currentTime);
                Debug.Log(rectTransform.position);
                yield return null;
            }

            isShutterDown = true;
            currentTime = 0;
            rectTransform.position = endingPos;
        }
        else if (isShutterDown)
        {
            while (currentTime < 1)
            {
                currentTime += Time.deltaTime / dropSpeedInSeconds;
                rectTransform.position = Vector3.Lerp(endingPos, startingPos, currentTime);
                Debug.Log(rectTransform.position);
                yield return null;
            }
            isShutterDown = false;
            currentTime = 0;
            rectTransform.position = startingPos;
        }
        yield return new WaitForSeconds(waitTime);
    }

    public void MoveScene(float delayTime = 0f)
    {
        Debug.Log("moveScene");
        StartCoroutine(LoadSceneInBackground(delayTime));
    }

    IEnumerator LoadSceneInBackground(float delayTime = 0f)
    {
        if (delayTime != 0) yield return new WaitForSeconds(delayTime);

        if (isShutterDown) Debug.LogError("ShutterIsDown");
        StartCoroutine(MoveShutter(5f));

        yield return new WaitUntil(() => isShutterDown);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        asyncOperation.allowSceneActivation = false;
        StartCoroutine(MoveShutter(0.0f));
        asyncOperation.allowSceneActivation = true;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameScene"));
        SceneManager.UnloadSceneAsync(0);
    }
}
