using UnityEngine;
using UnityEngine.XR;
public class buttonchanger : MonoBehaviour{
public GameObject button;
public bool changecolornow;
    public void changebuttoncolor()
    {
        // get the button component of the inputted gameobject and set the normal color to grey when changecolor now is set to true

        if (changecolornow == true)
        {
            button.GetComponent<Renderer>().material.color = Color.grey;
        }
        else
        {
            button.GetComponent<Renderer>().material.color = Color.white;
        }
        
        
    }
}