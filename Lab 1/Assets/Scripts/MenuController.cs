using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    void Awake(){
        Time.timeScale = 0.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked(){
        foreach(Transform eachChild in transform){ //the transform component of the UI gameobject. is a hierarchical data structure
            if (eachChild.name != "Score"){
                Debug.Log("Child found. Name: " + eachChild.name);
                //disable them
                eachChild.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }
}
