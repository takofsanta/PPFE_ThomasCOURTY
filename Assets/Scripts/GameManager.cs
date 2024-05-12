using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool alreadySelected;
    public GameObject fruitSelected;

    private void Start()
    {
        alreadySelected = false;
        fruitSelected = null;
    }
}
