using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCalculator : MonoBehaviour
{
    static Vector3 maxScale = new Vector3(2.5f, 2.5f, 2.5f);
    static Vector3 minScale = new Vector3(0.8f, 0.8f, 0.8f);
    
    public static Vector3 CalculateSize(GateType gateType, int gateValue, Transform transform)
    {
        float changeSize = gateValue / 1000f;
        Vector3 newScale = transform.localScale;

        if(gateType == GateType.increase)
        {
            newScale += new Vector3(changeSize, changeSize, changeSize);
            newScale = newScale.magnitude > maxScale.magnitude ? maxScale : newScale;
        }
        else
        {
            newScale -= new Vector3(changeSize, changeSize, changeSize);
            newScale = newScale.magnitude < minScale.magnitude ? minScale : newScale;
        }

        return newScale;
    }
}
