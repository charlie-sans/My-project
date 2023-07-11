using UnityEngine;
using UnityEngine.XR;

public class barplayer : MonoBehaviour
{
    public bool move;
    public int  MoveAmount;
    public void Move(bool move)
    {
        if (move)
        {
            RaycastHit hit;
            //a bar that finds anything with a audio player on it and plays said audio player on the object that the bars collision came in contact with while stil allowing the bar to pass thru objects
            if (Physics.Raycast(transform.position, transform.forward, out hit, MoveAmount))
            {
                if (hit.transform.tag == "AudioPlayer")
                {
                    hit.transform.GetComponent<AudioSource>().Play();
                }
                //move the bar forward when the move bool is true
                if (move)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * MoveAmount);
                }
               
            }
        }
    }
}