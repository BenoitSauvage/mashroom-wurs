using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBehavior : MonoBehaviour {

    GameObject go;
    public GameObject thing;
    
    void OnMouseOver()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject)
            {
                if (!go)
                {
 
                    go = Instantiate(thing, hit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;
                    go.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
                    go.transform.Rotate(90f,0,0);
                    go.transform.parent = gameObject.transform;
                }
            }
        }
    }

    void OnMouseExit()
    {
        Destroy(go.gameObject);
    }
}
