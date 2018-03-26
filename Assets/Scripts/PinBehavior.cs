using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinBehavior : MonoBehaviour
{
    //GameObject test;

    string[] type = { "you", "enemy", "neutral" };
    //string[] level = { "I", "II", "III" };
    //int nbrUnite;

    GameObject go;
    public GameObject pin;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.tag == type[0])
                {
                    if (!go)
                    {
                        go = Instantiate(pin, hit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;
                        go.transform.parent = GameObject.FindWithTag(type[0]).transform;

                        //test = go.gameObject.transform.GetChild(0).GetChild(0).gameObject;
                        //test.GetComponent<TextMeshProUGUI>().text = type[2];
                        //Debug.Log(test);
                    }
                }
                if (hit.collider.gameObject.tag == type[2])
                {
                    if (!go) {
                        go = Instantiate(pin, hit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;
                        go.transform.parent = GameObject.FindWithTag(type[2]).transform;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(go.gameObject, .5f);
        }
    }


}
