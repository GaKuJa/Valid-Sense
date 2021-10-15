using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstanceScriput : MonoBehaviour
{
    public static NotesInstanceScriput Instance { get => _instance; }
    static NotesInstanceScriput _instance;
    // クリックしたオブジェクトを入れる
    private GameObject clickedGameObject;
    // クリックしたオブジェクトの Transform を取得する
    private Transform clickedGameObject_transform;
    // Instantiate するノーツオブジェクト
    [SerializeField]
    private GameObject notesObject;
    void Awake()
    {
        _instance = this;
    }
    public void NotesPut()
    {
        clickedGameObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            clickedGameObject = hit.collider.gameObject;
            clickedGameObject_transform = clickedGameObject.GetComponent<Transform>();
            Instantiate(notesObject, new Vector3(clickedGameObject_transform.position.x,
                                                 hit.point.y,
                                                 clickedGameObject_transform.position.z - 0.55f), Quaternion.identity, clickedGameObject_transform);
            Debug.Log(hit.point.y);
        }
    }
}