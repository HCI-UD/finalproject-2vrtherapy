using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMenuScript : MonoBehaviour
{
    public GameObject fishDots;
    public GameObject fishMenu;
    public GameObject fishButton;

    public GameObject chickenDots;
    public GameObject chickenMenu;
    public GameObject chickenButton;

    public GameObject threeDfishDots;
    public GameObject threeDfishMenu;
    public GameObject threeDfishButton;


    private void Start()
    {
        fishDots.SetActive(false);
        chickenDots.SetActive(false);
        threeDfishDots.SetActive(false);
    }

    void OnCollisionEnter(Collision collide)
    {
        Debug.Log("HELLO FISH collide (name) : " + collide.collider.gameObject.name + " Collide: " + collide + "  " + collide.collider.gameObject);
        FishIntialization();
    }

    public void FishIntialization()
    {
        fishDots.SetActive(true);
        Vector3 fishPosition = new Vector3(-0.038f, 1.38f, 1.33f);
        fishDots.transform.position = fishPosition;
        Vector3 buttonPosition = new Vector3(-10f, -10f, -10f);
        fishButton.transform.position = buttonPosition;
        chickenButton.transform.position = buttonPosition;
        threeDfishButton.transform.position = buttonPosition;

        threeDfishMenu.SetActive(false);
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
    }
}
