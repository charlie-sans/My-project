using UnityEngine;
using UnityEngine.XR;

public class hiding : MonoBehaviour
{
    public bool hidekey = false;
    public GameObject[] list;
    

    public void hide(){
        //turn off mesh renderer for all game objects in a list for unity when hde bool is true
        if(hidekey == true){
            foreach(GameObject obj in list){
                obj.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}

