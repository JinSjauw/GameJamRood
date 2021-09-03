using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_script : MonoBehaviour
{
    public GameObject redmenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            redmenu.SetActive(true);
        }
    }
}
