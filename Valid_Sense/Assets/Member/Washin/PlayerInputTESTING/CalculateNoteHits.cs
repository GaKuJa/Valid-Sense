using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CalculateNoteHits : MonoBehaviour
{
    public static CalculateNoteHits instance;

    [SerializeField] int numberOfObjectsToGenerate;

    [SerializeField] GameObject objectPrefab;
    [SerializeField] List<GameObject> listOfNoteGOs;
    public static List<int> pickableNumbers = new List<int>();

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }    
    }

    private void Start()
    {
        SetupPickableNumbers();
        GenerateRandomObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReorderObjects();
        }
    }

    void SetupPickableNumbers()
    {
        for (int i = 0; i < numberOfObjectsToGenerate; i++)
        {
            pickableNumbers.Add(i);
        }

        Shuffle(pickableNumbers);
    }

    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            int tempInt = list[i];
            list[i] = list[random];
            list[random] = tempInt;
        }
    }

    void GenerateRandomObject()
    {
        for (int i = 0; i < numberOfObjectsToGenerate; i++)
        {
            GameObject testObject = Instantiate(objectPrefab, this.gameObject.transform);
            testObject.transform.position = new Vector3(1, i + 3);

            ObjectInfo objectInfo = testObject.GetComponent<ObjectInfo>();
            objectInfo.numberPair.x = i;
            objectInfo.Setup(pickableNumbers);
            testObject.name = "GameObject " + objectInfo.numberPair;
            listOfNoteGOs.Add(testObject);
        }
    }


    void ReorderObjects()
    {
        listOfNoteGOs = listOfNoteGOs.OrderBy(note => note.GetComponent<ObjectInfo>().numberPair.y).ToList();
        foreach (GameObject cube in listOfNoteGOs)
        {
            cube.transform.position = new Vector3(1, cube.GetComponent<ObjectInfo>().numberPair.y + 3);
        }
    }
}
