using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int stackLenght = 0;
    public string fruitName;
    public int numberToWin;

    Vector3 newPos;

    public GameObject victoire;

    public void TestingFruit()
    {
        fruitToStack = manager.fruitSelected;
        fruitName = fruitToStack.name;

        Invoke(fruitName, 0f);
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
            FruitPasValide();
        }
        else
        {
            CardBackground.color = Wrong;
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
        StartCoroutine(Plouf());
        if (stackLenght > 4)
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
        if (stackLenght < 1 || stackLenght > 3)
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
            if (stack.Peek().name == "Choux" || stack.Peek().name == "Courgette")
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
            if (stack.Peek().name == "Choux" || stack.Peek().name == "Courgette")
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
    private void Choux()
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
        if (stackLenght < 1 || stackLenght > 3)
        {
            PushingFruit();
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
        //yield return new WaitForSeconds(0.2f);
        //CardBackground.color = Right;
        //yield return new WaitForSeconds(0.2f);
        //CardBackground.color = White;

    }
}
