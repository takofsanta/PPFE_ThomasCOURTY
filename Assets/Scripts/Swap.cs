using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{

    public GameObject selfFruit;
    public GameObject swapFruit;
    public GameObject intermediateFruit;

    public CardBehavior cardBehavior;


    public SoupBehavior soupBehavior;
    private Vector3 swapPos;

    public SpriteRenderer self;

    public Sprite classic;
    public Sprite swapOver;
    public Sprite swapClick;
    
    private void OnMouseEnter()
    {
        self.sprite = swapOver;
    }

    private void OnMouseExit()
    {
        self.sprite = classic;
    }
    private void OnMouseDown()
    {
        self.sprite = swapClick;
        soupBehavior.audioSource.clip = soupBehavior.tic;
        soupBehavior.audioSource.Play();
        swapPos = selfFruit.transform.position;
        swapFruit.transform.position = swapPos;
        swapFruit.SetActive(true);
        selfFruit.SetActive(false);
        intermediateFruit = selfFruit;
        selfFruit = swapFruit;
        swapFruit = intermediateFruit;


    }
}
