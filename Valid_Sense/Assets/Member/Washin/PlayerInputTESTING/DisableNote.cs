using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableNote : MonoBehaviour
{
    MeshRenderer myRenderer;

    Color normalColor;
    Color switchedColor;

    public void SwitchColors()
    {
        myRenderer.material.color =(myRenderer.material.color == switchedColor) ? normalColor : switchedColor;
    }

    public void SetNoteColors(Color characterColor, Color opponentColor)
    {
        myRenderer = GetComponent<MeshRenderer>();

        normalColor = characterColor;
        myRenderer.material.color = normalColor;

        switchedColor = opponentColor;
    }

    public void HideNote()
    {
        myRenderer.enabled = false;
    }
}
