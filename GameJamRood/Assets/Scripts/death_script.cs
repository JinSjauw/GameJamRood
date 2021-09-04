using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_script : MonoBehaviour
{
    public GameObject redmenu;

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Y))
    //    {
    //        redmenu.SetActive(true);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enters Collider");

            redmenu.SetActive(true);
            //Destroy(this.gameObject);

        }
    }
}
