using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    private MenuScript menu;
    private bool hover;
    private Image buttonImage;
    private int hoverTime;
    
    // Start is called before the first frame update
    public void Start()
    {
        menu = GameObject.Find("Table").GetComponent<MenuScript>();
        buttonImage = this.GetComponent<Image>();
        hover = false;
        hoverTime = 0;
        buttonImage.color = Color.white;
        //Debug.Log("<MenuButton><START> " + this.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (hover) {
            hoverTime += 1;

            if (hoverTime > 200) {
                buttonImage.color = Color.green;

                if (hoverTime > 300) {
                    if (this.name == "ThreeDfishButton") {
                        Debug.Log("<MenuButton><Update> 3D fish button hit");
                        menu.ThreeDfishIntialization();
                    } else if (this.name == "TwoDfishButton") {
                        Debug.Log("<MenuButton><Update> 2D fish button hit ");
                        menu.FishIntialization();
                    } else if (this.name == "TwoDchickenButton") {
                        Debug.Log("<MenuButton><Update> 2D chicken button hit");
                        menu.ChickenIntialization();
                    } else if (this.name == "TwoDsquareButton") {
                        Debug.Log("<MenuButton><Update> 2D Square button hit");
                        menu.SquareIntialization();
                    } else if (this.name == "ReturnButton") {
                        Debug.Log("<MenuButton><Update> return button hit");
                        menu.restart();
                    } else if (this.name == "QuitButton") {
                        Debug.Log("Application Quit");
                        Application.Quit(); //only works when you build the project (doesn't work when you play in edit mode)
                    } else if (this.name == "TwoDsquareButton2") {
                        Debug.Log("<MenuButton><Update> Repeatable Square button hit");
                        menu.RepeatableSquareIntialization();
                    }

            }
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("<MenuButton><OnTriggerEnter> " + this.name);

        //ensure that the collider is not another part of the model
        if (other.gameObject.tag == "PTAsset")
        {
            buttonImage.color = Color.yellow;
            hover = true;
            hoverTime = 0;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("<MenuButton><OnTriggerExit> " + this.name);
        //ensure that the collider is not another part of the model
        if (other.gameObject.tag == "PTAsset")
        {
            buttonImage.color = Color.white;
            hover = false;
            hoverTime = 0;
        }
    }
    

}
