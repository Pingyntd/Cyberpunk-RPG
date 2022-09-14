using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class CharacterMovment : MonoBehaviour
{

    GameObject selected = null;
    List<Characteristics> characteristics = new List<Characteristics>();

    public GameObject screenText;
    private TMP_Text textComponent;

    public Tilemap tilemap;

    bool characterSelected = false;
    bool canMove = true;


    private void Awake()
    {
        textComponent = screenText.GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {

        Debug.Log("mouse pos: " + Input.mousePosition);

        if (Input.GetMouseButtonDown(0)){
            canMove = true;
            Collider2D[] hit = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            for (int i = 0; i < hit.Length; i++){

                if (hit[i].gameObject.tag == "Character"){
                    characteristics = new List<Characteristics>();
                    characterSelected = true;
                    selected = hit[i].gameObject;
                    characteristics.Add(selected.GetComponent<Characteristics>());

                    /*for (int j = 0; j < characteristics.Count; j++) {
                        Debug.Log(characteristics[j].name);
                    }*/

                    Debug.Log("Adding character to selected. Character name: " + characteristics[0].name);
                }
                else{
                    characterSelected = false;
                }
                for (int j = 0; j < hit.Length; j++) {
                    if (hit[j].gameObject.tag == "Character") {
                        canMove = false;
                    }
                }


            }

            if (canMove) {
                /*Vector2 mousePos = Input.mousePosition;
                Debug.Log("mouse pos: " + mousePos);
                Vector3Int cellPos = tilemap.WorldToCell(mousePos);
                selected.transform.position = tilemap.GetCellCenterWorld(cellPos);*/
                Vector2 screenPos;
                Vector2 worldPos;

                screenPos = Input.mousePosition;
                worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                Vector3Int cellPos = tilemap.WorldToCell(worldPos);
                selected.transform.position = tilemap.GetCellCenterWorld(cellPos);

            }

            
        }

        if (characterSelected){
            textComponent.text = "Selected Character: " + characteristics[0].name;
            characterSelected = false;
        }
    }

}
