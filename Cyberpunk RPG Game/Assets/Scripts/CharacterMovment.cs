using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{


    public bool isSelected;
    private bool overCollider = false;

    private bool debugTest = true;
    Target target;


    private void Awake()
    {
        target = this.GetComponent<Target>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (!overCollider)
            {
                isSelected = false;
                Debug.Log(target.name + "is selected? " + isSelected);
            }
        }


        if (Input.GetMouseButtonDown(0)){

            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Debug.Log("Test");
            if ((!(hitInfo.collider.gameObject.tag == "Character"))) //  && (isSelected)
            {
                Debug.Log("InMove with " + target.name + "selected");
                Vector2 lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.transform.position = lastClickedPos;
            }
        }

        
    }

    private void OnMouseOver()
    {
        if (debugTest) {
            //Debug.Log("Is hovering over " + target.name);
            debugTest = false;
        }
        if (Input.GetMouseButtonDown(0)) {
            //Debug.Log("Clicked on " + target.name);
        }
        overCollider = true;
        
    }

    private void OnMouseExit()
    {
        overCollider = false;
        debugTest = true;
    }

    private void OnMouseDown()
    {
        
    }
}
