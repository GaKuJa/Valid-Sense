using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveNotesInstanceScriput : MonoBehaviour
{
    Vector3 GetPoint(Vector3 start,Vector3 end,Vector3 control,float t)
    {
        Vector3 point_1 = Vector3.Lerp(start, control, t);
        Vector3 point_2 = Vector3.Lerp(control,end , t);
        Vector3 point_3 = Vector3.Lerp(point_1, point_2, t);
        return point_3;
    }
}
