using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardBehavior : MonoBehaviour
{
    public SpriteRenderer legume;
    public SpriteRenderer CardBackground;
    public Color White;
    public Color Selected;
    public Color Over;

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

    public Color notValid;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }


    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        actualPos = transform.position;

        manager.fruitSelected = fruitNumber;
        CardBackground.color = Selected;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        Soupe.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnMouseUp()
    {
        Soupe.GetComponent<BoxCollider>().enabled = true;
        CardBackground.color = Over;
        SoupBehavior.audioSource.clip = SoupBehavior.pop;
        SoupBehavior.audioSource.Play();
    }

    private void OnMouseEnter()
    {
        fruitName = fruitNumber.name;
        canvas.SetActive(true);
        titre.text = fruitName;
        CardBackground.color = Over;


        if (fruitName == "Courgette" || fruitName == "Patate")
        {
            texte.text = "En premier ou en Dernier";
        }

        if (fruitName == "Carotte")
        {
            texte.text = "Précédé par un Légume Vert";
        }

        if (fruitName == "Chou")
        {
            texte.text = "Précédé par un Tubercule";
        }

        if (fruitName == "Citrouille")
        {
            texte.text = "Précédé par n'importe quoi sauf un Légume Vert";
        }

        if (fruitName == "Ail")
        {
            texte.text = "Dans les trois premiers";
        }

        if (fruitName == "Piment")
        {
            texte.text = "Précédé par un Légume Blanc";
        }

        if (fruitName == "Tomate")
        {
            texte.text = "Dans les trois premiers";
        }
        
        if (fruitName == "ChouFleur")
        {
            texte.text = "Précédé par un Tubercule";
        }

        if (fruitName == "PoivronRouge")
        {
            titre.text = "Poivron";
            texte.text = "Précédé par un Légume Rouge";
        }

        if (fruitName == "PoivronVert")
        {
            titre.text = "Poivron";
            texte.text = "Précédé par un Légume Rouge";
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

    public void ChangCoul()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        legume.color = notValid;
        yield return new WaitForSeconds(0.2f);
        legume.color = White;
        yield return new WaitForSeconds(0.2f);
        legume.color = notValid;
        yield return new WaitForSeconds(0.2f);
        legume.color = White;
    }
}
