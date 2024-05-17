using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoupBehavior : MonoBehaviour
{
    public Stack<GameObject> stack = new Stack<GameObject>();

    public GameManager manager;
    public GameObject fruitToStack;
    public CardBehavior cardBehavior;

    public SpriteRenderer CardBackground;
    public Color White;
    public Color Wrong;
    public Color Right;
    public Color over;

    public int stackLenght = 0;
    public string fruitName;

    public int stackMax;
    Vector3 newPos;

    public GameObject victoire;

    public AudioSource audioSource;
    public AudioClip plouf;
    public AudioClip pop;
    public AudioClip tic;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            stackMax = 3;
        }
        else
        {
            stackMax = 5;
        }
    }

    public void TestingFruit()
    {
        fruitToStack = manager.fruitSelected;
        fruitName = fruitToStack.name;

        Invoke(fruitName, 0f);
    }

    private void OnMouseEnter()
    {
        CardBackground.color = over;
    }

    private void OnMouseExit()
    {
        CardBackground.color = White;

    }

    private void OnMouseDown()
    {
        if (stack.Count > 0) 
        {
            CardBackground.color = Right;
            fruitToStack = stack.Peek();
            stack.Pop().SetActive(true);
            cardBehavior = fruitToStack.GetComponent<CardBehavior>();
            stackLenght = stack.Count;
            audioSource.clip = pop;
            audioSource.Play();
            FruitPasValide();
        }
        else
        {
            CardBackground.color = Wrong;
            clicSound();
        }

    }

    private void OnMouseUp()
    {
        CardBackground.color = White;

    }

    public void PushingFruit()
    {
        stack.Push(fruitToStack);
        fruitToStack.SetActive(false);
        manager.fruitSelected = null;
        stackLenght = stack.Count;
        audioSource.clip = plouf;
        audioSource.Play();
        StartCoroutine(Plouf());
        if (stackLenght > stackMax + 1)
        {
            Invoke("Winning", 0.5f);
        }
    }

    private void Winning()
    {
        victoire.SetActive(true);
    }

    

    //Toutes les fonctions Léguminées
    private void Patate()
    {        
        if (stackLenght < 1 || stackLenght > stackMax)
        {
            PushingFruit();
        }
        else
        {
            FruitPasValide();
        }
    }
    private void Carotte()
    {
        if (stackLenght > 0)
        {
            if (stack.Peek().name == "Chou" || stack.Peek().name == "Courgette" || stack.Peek().name == "PoivronVert")
            {
                PushingFruit();
            }
            else
            {
                FruitPasValide();
            }
        }
        else
        {
            FruitPasValide();
        }
    }
    private void Citrouille()
    {
        if (stackLenght > 0)
        {
            if (stack.Peek().name == "Chou" || stack.Peek().name == "Courgette" || stack.Peek().name == "PoivronVert")
            {
                FruitPasValide();
            }
            else
            {
                PushingFruit();
            }
        }
        else
        {
            FruitPasValide();
        }
    }
    private void Chou()
    {
        if (stackLenght > 0)
        {
            if (stack.Peek().name == "Patate" || stack.Peek().name == "Carotte")
            {
                PushingFruit();
            }
            else
            {
                FruitPasValide();
            }
        }
        else
        {
            FruitPasValide();
        }

    }
    private void Courgette()
    {
        if (stackLenght < 1 || stackLenght > stackMax)
        {
            PushingFruit();
        }
        else
        {
            FruitPasValide();
        }
    }

    private void Ail()
    {
        if (stackLenght < 4)
        {
            PushingFruit();
        }
        else
        {
            FruitPasValide();
        }
    }
    private void Tomate()
    {
        if (stackLenght < 4)
        {
            PushingFruit();
        }
        else
        {
            FruitPasValide();
        }
    }
    private void PoivronRouge()
    {
        if (stackLenght > 0)
        {
            if (stack.Peek().name == "Tomate" || stack.Peek().name == "Piment")
            {
                PushingFruit();
            }
            else
            {
                FruitPasValide();
            }
        }
        else
        {
            FruitPasValide();
        }
    }
    private void PoivronVert()
    {
        if (stackLenght > 0)
        {
            if (stack.Peek().name == "Tomate" || stack.Peek().name == "Piment")
            {
                PushingFruit();
            }
            else
            {
                FruitPasValide();
            }
        }
        else
        {
            FruitPasValide();
        }
    }

    private void ChouFleur()
    {
        if (stackLenght > 0)
        {
            if (stack.Peek().name == "Patate" || stack.Peek().name == "Carotte")
            {
                PushingFruit();
            }
            else
            {
                FruitPasValide();
            }
        }
        else
        {
            FruitPasValide();
        }
    }
    private void Piment()
    {
        if (stackLenght > 0)
        {
            if (stack.Peek().name == "Ail" || stack.Peek().name == "ChouFleur")
            {
                PushingFruit();
            }
            else
            {
                FruitPasValide();
            }
        }
        else
        {
            FruitPasValide();
        }
    }


    private void FruitPasValide()
    {
        cardBehavior = fruitToStack.GetComponent<CardBehavior>();

        newPos = cardBehavior.actualPos;
        fruitToStack.transform.position = newPos;
        cardBehavior.ChangCoul();
    }

    IEnumerator Plouf()
    {
        CardBackground.color = Right;
        yield return new WaitForSeconds(0.3f);
        CardBackground.color = White;

    }

    public void clicSound()
    {
        audioSource.clip = tic;
        audioSource.Play();
    }
}
