using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;

public class Button : MonoBehaviour
{
    private Notes _notes = new Notes();
    private int _saveIndex = 1;
    // クリックしたオブジェクトを入れる
    private GameObject clickedGameObject;
    // クリックしたオブジェクトの Transform を取得する
    private Transform clickedGameObject_transform;
    void Update()
    {
        GetMousePosition();
    }
    private void GetMousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedGameObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if(Physics.Raycast(ray,out hit))
            {
                clickedGameObject = hit.collider.gameObject;
                clickedGameObject_transform = clickedGameObject.GetComponent<Transform>();
                _notes.NotesList.Add(new Vector3(clickedGameObject_transform.position.x,
                                                 hit.point.y,
                                                 clickedGameObject_transform.position.z - 0.55f));
            }
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    public void OnClickButton()
    {
        //_notes.NotesList.Remove(_notes.NotesList.Last());
        string flieName = "Assets/Member/Akimoto/Resources/Datas/SaveData/" + "notesData" + _saveIndex.ToString() + ".json";
        Debug.Log(_notes.NotesList.Count);
        using (var streamWriter = new StreamWriter(flieName, false, Encoding.Default))
        {
            var jsonText = JsonUtility.ToJson(_notes);
            streamWriter.Write(jsonText);
        }
        _saveIndex++;
    }
}
