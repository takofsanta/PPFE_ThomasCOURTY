using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupBehavior : MonoBehaviour
{
    public Stack<GameObject> stack = new Stack<GameObject>();

    public GameManager manager;
    public GameObject fruitToStack;
    private void OnMouseDown()
    {
        fruitToStack = manager.fruitSelected;
        stack.Push(fruitToStack);
        fruitToStack.SetActive(false);
        Debug.Log(stack.Peek());
    }
}
