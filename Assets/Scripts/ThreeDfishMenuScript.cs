using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDfishMenuScript : MonoBehaviour
{
    public GameObject fishDots;
    public GameObject fishMenu;
    public GameObject fishButton;

    public GameObject chickenDots;
    public GameObject chickenMenu;
    public GameObject chickenButton;

    public GameObject ThreeDfishTask;
    public GameObject threeDfishDots;
    public GameObject threeDfishMenu;
    public GameObject threeDfishButton;


    private void Start()
    {
        fishDots.SetActive(false);
        chickenDots.SetActive(false);
        ThreeDfishTask.SetActive(false);
    }
    
    void OnCollisionEnter(Collision collide)
    {
        Debug.Log("HELLO 3D FISH collide (name) : " + collide.collider.gameObject.name + " Collide: " + collide + "  " + collide.collider.gameObject);
        ThreeDFishIntialization();
    }

    public void ThreeDFishIntialization()
    {
        // Move the menu out of the way and replace with fish

        // Move and activate the 3D fish
        ThreeDfishTask.SetActive(true);
        Vector3 threeDfishPosition = new Vector3(-0.038f, 1.38f, 1.33f);
        ThreeDfishTask.transform.position = threeDfishPosition;

        // Move and deactivate the menu
        Vector3 buttonPosition = new Vector3(-10f, -10f, -10f);
        threeDfishButton.transform.position = buttonPosition;
        fishButton.transform.position = buttonPosition;
        chickenButton.transform.position = buttonPosition;
        threeDfishMenu.SetActive(false);
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
    }
}
