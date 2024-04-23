using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D col;
    public Animator _animator;
    public GameObject player;
    private Vector3 position;
    [SerializeField] private TrailRenderer trailRenderer;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image[] images;
    private int currentImageIndex = 0;
    private bool canTriggerWin = true;
    [SerializeField] private Game_Manager gameManager;
    public BoxCollider2D box;
   

    public Vector3 pos { get { return transform.position; } }

    private void Start()
    {
        position = transform.position;
        Debug.Log(position);
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        trailRenderer.enabled = true;
       
        images = new Image[] { image1, image2, image3 };
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DeactivateRb()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collision")
        {
            trailRenderer.enabled = false;
           _animator.SetTrigger("respawn");
          
            if (currentImageIndex < images.Length)
            {
                images[currentImageIndex].enabled = false;
                currentImageIndex++;
            }
            if(currentImageIndex==3)
            {
                
                SoundManager.inst.PlaySound(SoundName.gameOver);
                Debug.Log("Game Over");
                UiManager.instance.SwitchScreen(GameScreens.GameOver);
                ResetHealthImages();
                        
            }

        }
        if (collision.tag == "win" && canTriggerWin)
        {
            SoundManager.inst.PlaySound(SoundName.win);
            canTriggerWin = false;
            UiManager.instance.SwitchScreen(GameScreens.Win);
            StartCoroutine(EnableWinTrigger());
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "rotate")
    //    {
    //        rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
    //    }
    //}
    public void Respawn()
    {
         //   rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            box.enabled = true;
            gameManager.canTakeInput = true;
            rb.isKinematic = true;
            transform.position = position;  
            rb.velocity = Vector2.zero;
            StartCoroutine(Delay());
            rb.isKinematic = false;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(1f);
        trailRenderer.enabled = true;
    }

    IEnumerator EnableWinTrigger()
    {
        yield return new WaitForSeconds(1f);  
        canTriggerWin = true;  
    }

    public void ResetHealthImages()
    {
        foreach (var image in images)
        {
            image.enabled = true;  
        }
        currentImageIndex = 0;  
    }
}
