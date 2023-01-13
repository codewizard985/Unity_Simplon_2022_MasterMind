using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    public Color[] CodePegs;    // answers pegs
    public Color[] KeyPegs;     // results pegs

    Color[] colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow, Color.magenta, Color.cyan };
    private int currentColor, length;
    // Use this for initialization

    //void Start()
    //{
    //    currentColor = 0; // Red
    //    length = colors.Length;
    //    GetComponent<MeshRenderer>().material.color = colors[currentColor];
    //}

    void Update()
    {
        // This property is null if the ray hit nothing and not-null if it hit a Collider.

        /**
         * "Input.GetMouseButtonDown" Returns true (when user release the mouse button) during the frame the user pressed the given mouse button.
         *  This function is called from the Update function
         *  Button values are 0 for the primary button (often the left button), 1 for secondary button, and 2 for the middle button.
         *  **/
        if (Input.GetMouseButtonDown(0))    // Left button = primary button
        {
            Debug.Log("clic !!!");
            /**
             * Raycast in Unity is a Physics function that projects a Ray into the scene, returning a boolean value if a target was successfully hit. 
             * When this happens, information about the hit, such as the distance, position or a reference to the object’s Transform, can be stored in a Raycast Hit variable for further use.
             * **/
            RaycastHit hit;
            /**
             * "ScreenPointToRay" Returns a ray going from camera through a screen point.
             * Resulting ray is in world space, starting on the near plane of the camera and going through position's (x,y) pixel coordinates on the screen (position.z is ignored).
             * **/
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //  Input.mousePosition reports the position of the mouse even when it is not inside the Game View

            /**
             * "Physics.Raycast" Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene.
             * bool Returns true if the ray intersects with a Collider, otherwise false. 
             * **/
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Peg>() != null)   // Collider components define the shape of an object for the purposes of physical collisions.
                {
                    Debug.Log("clic on Peg!!!");  

                    //currentColor = (currentColor + 1) % length;
                    //GetComponent<MeshRenderer>().material.color = colors[currentColor];
                    hit.collider.GetComponent<Peg>().ChangeColor();
                }
            }

        }
    }
}
