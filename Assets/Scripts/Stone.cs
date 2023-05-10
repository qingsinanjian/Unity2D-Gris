using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Transform[] roadsTrans;
    private GameObject tearsGo;
    private int tearNum;
    public int stopTearNum;

    private void Start()
    {
        tearsGo = Resources.Load<GameObject>("Prefabs/Tear");
        Transform pointsTrans = transform.Find("Points");
        roadsTrans = new Transform[pointsTrans.childCount];
        for (int i = 0; i < roadsTrans.Length; i++)
        {
            roadsTrans[i] = pointsTrans.GetChild(i);
        }

        Invoke("StartCreatingTears", 6);
    }

    private void Update()
    {
        if (tearNum >= 5)
        {
            CancelInvoke("CreateTear");
            tearNum = 0;
        }
    }

    private void StartCreatingTears()
    {
        InvokeRepeating("CreateTear", 0, 2);
    }

    private void CreateTear()
    {
        GameObject go = Instantiate(tearsGo, roadsTrans[0].position, Quaternion.Euler(Vector3.zero));
        Tear tear = go.GetComponent<Tear>();
        tear.roadsTrans = roadsTrans;
        tear.finalIndex = roadsTrans.Length - 1 - tearNum;
        tearNum++;
        tear.stone = this;
    }
}
