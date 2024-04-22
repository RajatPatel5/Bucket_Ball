using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;
    [SerializeField] [Range(0.01f,0.1f)]float dotMinScale;
    [SerializeField][Range(0.1f, 2f)] float dotMaxScale;

    Transform[] dotsList; //Array
    Vector2 Pos; //A vector to store the position of each dot.
    float timeStamp;

    void Start()
    {
        Hide();

        prepareDots();
    }

    void prepareDots()
    { 
        dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsNumber;

        for(int i=0;i<dotsNumber;i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
            {
                scale -= scaleFactor;
            }

        }
    }
    public void UpdateDots(Vector3 PlayerPos, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;

        for (int i = 0; i < dotsNumber; i++)
        {
            Pos.x = (PlayerPos.x + forceApplied.x * timeStamp);
            Pos.y = (PlayerPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;//Projectile motion Formula

            dotsList[i].position = Pos;
            timeStamp += dotSpacing;
        }
    }

    public void Show()
    { 
     dotsParent.SetActive(true);
    }

    public void Hide() 
    {
        dotsParent.SetActive(false);
    }

}
