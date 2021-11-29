using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectInfo : MonoBehaviour
{
    public Vector2Int numberPair = Vector2Int.zero;
    public void Setup(List<int> listOfPickableNumbers)
    {
        numberPair.y = listOfPickableNumbers.Last();
        TESTReorderList.pickableNumbers.Remove((int)numberPair.y);
        this.gameObject.name = "GameObject " + numberPair;
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }


}
