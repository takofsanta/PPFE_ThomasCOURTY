using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardBehavior : MonoBehaviour
{
    public SpriteRenderer CardBackground;
    public Color White;
    public Color Selected;

    public GameObject fruitNumber;

    public GameManager manager;

    public GameObject canvas;
    public TMP_Text titre;
    public TMP_Text texte;

    public string fruitName;

    public Vector3 actualPos;
    Vector3 mousePosition;
    public GameObject Soupe;
    public SoupBehavior SoupBehavior;


    private Vector3 GetMousePos() 
    { 
        return Camera.main.WorldToScreenPoint(transform.position);
    }


    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();

        manager.fruitSelected = fruitNumber;
        actualPos = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        Soupe.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnMouseUp()
    {
        Soupe.GetComponent<BoxCollider>().enabled = true;

    }

    private void OnMouseEnter()
    {
        fruitName = fruitNumber.name;
        canvas.SetActive(true);
        titre.text = fruitName;
        CardBackground.color = Selected;


        if (fruitName == "Choux" || fruitName == "Patate")
        {
            texte.text = "En premier ou en Dernier";
        }

        if (fruitName == "Carotte")
        {
            texte.text = "Précédé par un Légume Vert";
        }

        if (fruitName == "Courgette")
        {
            texte.text = "Précédé par un Tubercule";
        }

        if (fruitName == "Citrouille")
        {
            texte.text = "Précédé par n'importe quoi sauf un Légume Vert";
        }
    }
    private void OnMouseExit()
    {
        canvas.SetActive(false);
        CardBackground.color = White;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Marmite")
        {
            Soupe.GetComponent<SoupBehavior>();
            SoupBehavior.TestingFruit();
        }
    }

}
