using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool hasBeenPlayed;

    public Material CardBackground;
    public Color White;
    public Color Selected;

    public GameObject fruitNumber;

    public GameManager manager;

    private void OnMouseDown()
    {
        if (hasBeenPlayed == false)
        {
            if (manager.alreadySelected == false)
            {
                hasBeenPlayed = true;
                CardBackground.color = Selected;
                manager.alreadySelected = true;
                manager.fruitSelected = fruitNumber;
            }
        }
        else
        {
            hasBeenPlayed = false;
            CardBackground.color = White;
            manager.alreadySelected = false;
            manager.fruitSelected = null;
        }
    }
}
