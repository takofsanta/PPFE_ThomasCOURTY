using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.SplashScreen;

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
        if (stackLenght > 4)
        {
            Invoke("Winning", 2f);
        }
    }

    private void Winning()
    {
        Debug.Log("c'est gagné");
    }

    

    //Toutes les fonctions fruitées
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
    private void Courgette()
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
    private void Choux()
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
    }
}
