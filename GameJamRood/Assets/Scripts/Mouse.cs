using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    AudioSource Click;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
        
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Debug.Log(mousePos.x);
            //Debug.Log(mousePos.y);

            if(Physics.Raycast(Ray, out hit)) 
            {
                Debug.DrawRay(mousePos, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                Debug.Log("Shot ray");
                Debug.Log("Tag:" + hit.collider.tag);


                if (hit.collider.tag == "Enemy") 
                {

                    //hit.collider.gameObject.SetActive(false);
                    Destroy(hit.collider.gameObject);

                    
                }



            }
            //Debug.DrawRay(mousePos, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);

        }

        if (Input.GetButtonUp("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;

            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);

        }
    }
}
