using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldNotesInstanceScriput : MonoBehaviour
{
    public static HoldNotesInstanceScriput Instance { get => _instance; }
    static HoldNotesInstanceScriput _instance;

    // クリックしたオブジェクトを入れる
    private GameObject clickedGameObject;
    // クリックしたオブジェクトの Transform を取得する
    private Transform clickedGameObject_transform;
    // ホールドノーツのプレハブ
    [SerializeField]
    private GameObject HoldNotes;
    // ホールドノーツの実体用変数
    private GameObject hold;
    void Awake()
    {
        _instance = this;
    }
    public void HoldNotesSet()
    {
        clickedGameObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            clickedGameObject = hit.collider.gameObject;
            clickedGameObject_transform = clickedGameObject.GetComponent<Transform>();
            hold = Instantiate(HoldNotes, new Vector3(clickedGameObject_transform.position.x,
                                                     hit.point.y,
                                                     clickedGameObject_transform.position.z - 0.55f), Quaternion.identity);
        }
    }
    public void NotesExtend()
    {
        clickedGameObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            clickedGameObject = hit.collider.gameObject;
        }
        if (hold.transform.position.y < hit.point.y)
        {
            hold.transform.localScale = new Vector3(hold.transform.localScale.x,
                                                    hold.transform.localScale.y + 1.0f,
                                                    hold.transform.localScale.z);
            hold.transform.position = new Vector3(hold.transform.position.x,
                                                  hold.transform.position.y + 0.5f,
                                                  hold.transform.position.z);
        }
        if(hold.transform.position.y > hit.point.y)
        {
            if (hold.transform.localScale.y <= 2.0f)
                return;
            hold.transform.localScale = new Vector3(hold.transform.localScale.x,
                                                    hold.transform.localScale.y - 1.0f,
                                                    hold.transform.localScale.z);
            hold.transform.position = new Vector3(hold.transform.position.x,
                                                  hold.transform.position.y - 0.5f,
                                                  hold.transform.position.z);
        }
    }
}
