using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectControl : MonoBehaviour
{
    [SerializeField] public RectTransform Rect;
    [SerializeField] public GameObject Menu,StartMenu;
    [SerializeField] public Text player1SpeedText,player2SpeedText,player1OffsetText,player2OffsetText,startText;

    private bool isMenu = false; 
    private bool isStart = false;
    private int player1speed = 2;
    private int player2speed = 2;
    private int player1offset = 0;
    private int player2offset = 0;
    private int nowSongNum = 1;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(isMenu)
            {
                OpenMenu();
            }
            OpenStartMenu(nowSongNum);
        }
        if(isStart)
        {
            StartMenuControl();
            return;
        }


        if(Input.GetKeyDown(KeyCode.V))
        {
            OpenMenu();
        }
        if(isMenu)
        {
            MenuAnimation();
            MenuControl();
            return;
        }


        if(Input.GetKeyDown(KeyCode.UpArrow))
        {        
            StartCoroutine("ScrollUp");
            nowSongNum--;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine("ScrollDown");
            nowSongNum++;
        }

    }

    void OpenStartMenu(int num)
    {
        isStart = true;
        StartMenu.SetActive(true);
    }

    void StartMenuControl()
    {
        startText.text = nowSongNum.ToString("00");
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isStart = false;
            StartMenu.SetActive(false);
        }
    }

    void MenuControl()
    {
        if(Input.GetKeyDown(KeyCode.A))//player1 speed
        {
            if(player1speed > 1) player1speed--;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if(player1speed < 11) player1speed++;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))//player2 speed
        {
            if(player2speed > 1) player2speed--;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(player2speed < 11) player2speed++;
        }

        if(Input.GetKeyDown(KeyCode.S))//player1 offset
        {
            if(player1offset < 20) player1offset ++;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            if(player1offset > -20) player1offset --;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))//player2 offset
        {
            if(player2offset < 20) player2offset ++;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(player2offset > -20) player2offset --;
        }
    }
    void MenuAnimation()
    {
        player1SpeedText.text = (player1speed.ToString("Player1Speed : 0"));
        player2SpeedText.text = (player2speed.ToString("Player2Speed : 0"));
        player1OffsetText.text = ("Offset : " + player1offset.ToString("-# ms;+# ms;+0 ms"));
        player2OffsetText.text = ("Offset : " + player2offset.ToString("-# ms;+# ms;+0 ms"));
    }
    void OpenMenu()
    {
        if(!isMenu)
        {
            isMenu = true;
            Menu.SetActive(true);
        }
        else
        {   
            isMenu = false;
            Menu.SetActive(false);
        }
    }


    IEnumerator ScrollUp()
    {
        for(int i = 0;i<10;i++)
        {
            Rect.position += new Vector3(0,-100,0);
            yield return null;
        }
    }
    IEnumerator ScrollDown()
    {
        for(int i = 0;i<10;i++)
        {
            Rect.position += new Vector3(0,100,0);
            yield return null;
        }
    }


}
