using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrowCharacterSelection : MonoBehaviour
{
    [SerializeField] bool shouldMoveToAkimoScene;
    [SerializeField] Player currentPlayer;
    [SerializeField] RawImage characterImage;
    [SerializeField] KeyCode moveArrowUP, moveArrowDown, selectCharacter;
    [SerializeField] float arrowOffset;
    [SerializeField] int numberOfCharacters;
    [SerializeField] Color charaColor1, charaColor2, charaColor3, charaColor4, characolor5;
    [SerializeField] Sprite characterKanji1, characterKanji2, characterKanji3, characterKanji4, characterKanji5, clearPixel;
    [SerializeField] GameObject[] characterNames;
    [SerializeField] Image kanjiImage;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject playersReady;

    static bool isPlayer1Ready = false;
    static bool isPlayer2Ready = false;

    float topLimit, bottomLimit;
    float arrowStartingPos;

    RectTransform arrowRect;
    GameObject hoveredOverCharacter, selectedCharatcer;
    string currentCharacterTag;
    GameObject currentCharacterGameObject;
    bool characterSelected = false;
    bool hasMoved = false;

    private void Start()
    {
        arrowRect = GetComponent<RectTransform>();
        arrowStartingPos = arrowRect.localPosition.y;
        topLimit = arrowStartingPos + arrowOffset;
        bottomLimit = arrowStartingPos - (arrowOffset * (numberOfCharacters + 2));
        characterImage.color = new Color(0, 0, 0, 0);
        kanjiImage.sprite = clearPixel;
        HideCharacterNames();
    }

    void Update()
    {
        //Debug
        TEMPPlayAnimations();


        if (isPlayer1Ready && isPlayer2Ready)
        {
            BothPlayersReady();
        }

        if (!characterSelected)
            PlayerControls();
    }

    private void BothPlayersReady()
    {
        timer.SetActive(false);
        //playersReady.SetActive(true);
        if (shouldMoveToAkimoScene)
        {
            shouldMoveToAkimoScene = false;
            //MoveToNextScene();
            TransitionScreen.instance.MoveScene(3.2f);
            return;
        }
    }

    private void PlayerControls()
    {
        if (Input.GetKeyDown(moveArrowUP))
        {
            HasMoved();

            MoveArrow(arrowOffset);
        }
        else if (Input.GetKeyDown(moveArrowDown))
        {
            HasMoved();

            MoveArrow(-arrowOffset);
        }
        if (Input.GetKeyDown(selectCharacter))
        {
            HasMoved();

            Debug.Log("SelectionKeyPressed");
            currentCharacterGameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
            characterSelected = true;
            switch (currentPlayer)
            {
                case Player.Player1:
                    CharacterSelectPlayAnimationsP1("choice");
                    isPlayer1Ready = true;
                    break;
                case Player.Player2:
                    CharacterSelectPlayAnimationsP2("choice");
                    isPlayer2Ready = true;
                    break;
                default:
                    Debug.LogError("WrongPlayer");
                    break;
            }
        }
    }

    private static void CharacterSelectPlayAnimationsP2(string animationName)
    {
        CharacterAnimationController.InstancePlayer2.PlayAnimationOnCharacter(animationName);
    }

    private static void CharacterSelectPlayAnimationsP1(string animationName)
    {
        CharacterAnimationController.InstancePlayer1.PlayAnimationOnCharacter(animationName);
    }

    private void MoveArrow(float offset)
    {
        arrowRect.localPosition += new Vector3(0, offset, 0);

        if (arrowRect.localPosition.y >= topLimit)
        {
            arrowRect.localPosition = new Vector3(arrowRect.localPosition.x, arrowStartingPos - (arrowOffset * (numberOfCharacters - 1)), arrowRect.localPosition.z);
        }
        else if (arrowRect.position.y <= bottomLimit)
        {
            arrowRect.localPosition = new Vector3(arrowRect.localPosition.x, arrowStartingPos, arrowRect.localPosition.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasMoved) return;
        //Debug.Log("Collided");
        currentCharacterGameObject = collision.gameObject;
        currentCharacterTag = collision.gameObject.tag;
        Debug.Log("Current tag = " + currentCharacterTag);
        switch (currentCharacterTag)
        {
            case "Chara1":
                characterImage.color = charaColor1;
                kanjiImage.sprite = characterKanji1;
                HideCharacterNames();
                characterNames[0].SetActive(true);
                break;
            case "Chara2":
                characterImage.color = charaColor2;
                kanjiImage.sprite = characterKanji2;
                HideCharacterNames();
                characterNames[1].SetActive(true);
                break;
            case "Chara3":
                characterImage.color = charaColor3;
                kanjiImage.sprite = characterKanji3;
                HideCharacterNames();
                characterNames[2].SetActive(true);
                break;
            case "Chara4":
                characterImage.color = charaColor4;
                kanjiImage.sprite = characterKanji4;
                HideCharacterNames();
                characterNames[3].SetActive(true);
                break;
            case "Chara5":
                characterImage.color = characolor5;
                kanjiImage.sprite = characterKanji5;
                HideCharacterNames();
                characterNames[4].SetActive(true);
                break;
            default:
                Debug.LogError("NonValidCharacter");
                break;
        }
    }

    void HideCharacterNames()
    {
        foreach (var characterName in characterNames)
        {
            characterName.SetActive(false);
        }
    }

    void HasMoved()
    {
        hasMoved = true;
    }


    ////////////////////////////////////////
    void TEMPPlayAnimations()
    {
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CharacterSelectPlayAnimationsP1("idle");
            CharacterSelectPlayAnimationsP1("idle");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterSelectPlayAnimationsP1("att");
            CharacterSelectPlayAnimationsP2("att");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CharacterSelectPlayAnimationsP1("hit");
            CharacterSelectPlayAnimationsP2("hit");
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            CharacterSelectPlayAnimationsP1("choice");
            CharacterSelectPlayAnimationsP2("choice");
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            CharacterSelectPlayAnimationsP1("win");
            CharacterSelectPlayAnimationsP2("win");
        }

    }
    ////////////////////////////////////////



}