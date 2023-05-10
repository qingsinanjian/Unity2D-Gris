using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour
{
    public Transform[] roadsTrans;
    private int index;
    public int finalIndex;
    public Stone stone;
    private bool notTargetMove;
    private float moveSpeed;
    private float rotateAngle;
    
    private void Start()
    {
        moveSpeed = 5;
        rotateAngle = 30;
    }

    private void Update()
    {
        if (notTargetMove)
        {
            if (stone.stopTearNum >= 5)
            {
                //沿着某个方向移动
                transform.Translate(transform.right * Time.deltaTime * moveSpeed);
            }
        }
        else
        {
            //朝着某个固定目标点移动
            if (index == finalIndex)
            {
                if (Vector2.Distance(transform.position, roadsTrans[finalIndex].position) <= 0.1f)
                {
                    stone.stopTearNum++;
                    notTargetMove = true;
                    transform.Rotate(new Vector3(0, 0, rotateAngle * finalIndex));
                    return;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, roadsTrans[index + 1].position, 0.02f);
                if (Vector2.Distance(transform.position, roadsTrans[index + 1].position) <= 0.1f)
                {
                    index++;
                }
            }
        }
    }
}
