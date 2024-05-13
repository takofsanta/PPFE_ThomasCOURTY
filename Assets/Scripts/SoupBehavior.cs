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

    public string fruitName;

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
        }

    }

    private void PushingFruit()
    {
        stack.Push(fruitToStack);
        fruitToStack.SetActive(false);
        manager.alreadySelected = false;
        manager.fruitSelected = null;
        Debug.Log("youhou");
    }

    
    //Toutes les fonctions fruitées
    private void Fraise()
    {
        Debug.Log("Fraise");
        
        if (stack.Peek().CompareTag("Vert"))
        {
            PushingFruit();
        }
        else
        {
            Debug.Log("Fruit pas valide");
        }
    }

    private void Pomme()
    {
        Debug.Log("Pomme");
        PushingFruit();
    }
}
