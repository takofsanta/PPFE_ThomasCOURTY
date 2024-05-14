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

    public int stackLenght = 0;
    public string fruitName;
    public int numberToWin;

    private void OnMouseDown()
    {
        if (manager.alreadySelected == true)
        {
            fruitToStack = manager.fruitSelected;
            fruitName = fruitToStack.name;

            Invoke(fruitName, 0f);
        }

        else
        {
            Debug.Log("Rien de selectionné");
            fruitToStack = stack.Peek();
            stack.Pop().SetActive(true);
            cardBehavior = fruitToStack.GetComponent<CardBehavior>();
            cardBehavior.Start();
            stackLenght = stack.Count;
        }

    }

    private void PushingFruit()
    {
        stack.Push(fruitToStack);
        fruitToStack.SetActive(false);
        manager.alreadySelected = false;
        manager.fruitSelected = null;
        stackLenght = stack.Count;
        if (stackLenght > 4)
        {
            Invoke("Winning", 2f);
        }
        Debug.Log("youhou");
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
            Debug.Log("Fruit pas valide");
        }
    }
    private void Carotte()
    {
        if (stack.Peek().name == "Choux" || stack.Peek().name == "Courgette")
        {
            PushingFruit();
        }
        else
        {
            Debug.Log("Fruit pas valide");
        }
    }
    private void Citrouille()
    {
        if (stack.Peek().name == "Choux" || stack.Peek().name == "Courgette")
        {
            Debug.Log("Fruit pas valide");
        }
        else
        {
            PushingFruit();
        }
    }
    private void Courgette()
    {
        if (stack.Peek().name == "Patate" || stack.Peek().name == "Carotte")
        {
            PushingFruit();
        }
        else
        {
            Debug.Log("Fruit pas valide");
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
            Debug.Log("Fruit pas valide");
        }
    }
}
