using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuUIMover : MonoBehaviour
{
    public float timeMove;

    public GameObject upZone;
    public GameObject downZone;
    public GameObject leftZone;
    public GameObject rightZone;

    public float upMove = 1930;
    public float downMove = -10;
    public float leftMove = -10;
    public float rightMove = 1090;

    public void MoveCanvas(bool load)
    {
        if(upZone != null)
        {
            if (load) upZone.transform.DOMoveY(960, timeMove);
            else upZone.transform.DOMoveY(upMove, timeMove);
        }
        
        if(downZone != null)
        {
            if (load) downZone.transform.DOMoveY(960, timeMove);
            else downZone.transform.DOMoveY(downMove, timeMove);
        }

        if (leftZone != null)
        {
            if (load) leftZone.transform.DOMoveX(540, timeMove);
            else leftZone.transform.DOMoveX(leftMove, timeMove);
        }

        if (rightZone != null)
        {
            if (load) rightZone.transform.DOMoveX(540, timeMove);
            else rightZone.transform.DOMoveX(rightMove, timeMove);
        }
    }
}
