using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game_Manager : MonoBehaviour
{
    Camera cam;
    [SerializeField] float pushForce = 5f;
    bool isDragging = false;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    public Movement move;
    public Trajectory trajectory;
    public bool canTakeInput = true;
    public BoxCollider2D box;
    public void Start()
    {
        cam = Camera.main;
        move.DeactivateRb();
    }


    private void Update()
    {
        if (canTakeInput)
         {
           if (!EventSystem.current.IsPointerOverGameObject())
           { 
              if (Input.GetMouseButtonDown(0))
              {
               isDragging= true;
               OnDragStart();
              }
              if (Input.GetMouseButtonUp(0))
              {
                box.enabled= false;
                isDragging = false;
                OnDragEnd();
                canTakeInput = false;
              }
              if (isDragging)
              {
                OnDrag();
              }
            
           }
        }
    }
    void OnDragStart()
    {
        move.DeactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag() 
    {

        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

       // Debug.DrawLine(startPoint, endPoint);
        trajectory.UpdateDots(move.pos, force);
    }
    void OnDragEnd()
    {
        move.ActivateRb();
        move.Push(force);
        
        trajectory.Hide();
    }

    
}