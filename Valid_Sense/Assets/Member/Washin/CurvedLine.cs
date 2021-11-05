using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedLine : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float timeForLerp;
    [SerializeField] int numberOfSpheres;
    public List<GameObject> sphereHolder;
    [SerializeField] GameObject spherePrefab;
    bool startDrawing = false;
    int currentSphere = 0;
    float currentTime;
    [SerializeField] bool shouldLoop;

    [SerializeField] GameObject testObject;
    private void Start()
    {
        SpawnSpheres();
    }

    void Update()
    {
        timer();
        testObject.transform.position = Vector3.Lerp(LerpTwice(points[0].position, points[1].position, points[2].position,currentTime),
                                                     LerpTwice(points[1].position, points[2].position, points[3].position,currentTime),currentTime);

        if (Input.GetKey(KeyCode.KeypadMinus)) currentTime = 0;

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            foreach (GameObject sphere in sphereHolder)
            {
                transform.position = Vector3.up * 100;
            }
            startDrawing = true;
        }

        if (startDrawing)
        {
            FirstCurve();
            if (currentSphere == numberOfSpheres)
            {
                startDrawing = false;
                currentSphere = 0;
                currentTime = 0;
            }
        }
    }

    private void FirstCurve()
    {
        Vector3 combinedLerp = LerpTwice(points[0].position, points[1].position, points[2].position,currentTime);

        if (currentSphere / numberOfSpheres <= currentTime)
        {
            sphereHolder[currentSphere].transform.position = combinedLerp;
            currentSphere++;
        }
    }

    private Vector3 LerpTwice(Vector3 point1, Vector3 point2, Vector3 point3, float time)
    {
        Vector3 firstLerp = Vector3.Lerp(point1, point2, time);
        Vector3 secondLerp = Vector3.Lerp(point2, point3, time);
        Vector3 combinedLerp = Vector3.Lerp(firstLerp, secondLerp, time);
        return combinedLerp;
    }

    private float timer()
    {
        if (shouldLoop && currentTime >= 1) currentTime = 0; 
        return currentTime += Time.deltaTime / timeForLerp;
    }

    void SpawnSpheres()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
            sphereHolder.Add(Instantiate(spherePrefab, this.transform));
        }
    }
}
