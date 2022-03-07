/*
 * Created by: Haley Kelly
 * Date Created: 3/6/2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 3/7/2022
 *
 * Description: Script that controls fog that traverses the screen.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogScript : MonoBehaviour
{
  private float xCurr = 0f;

  private float xMax = 10f;
  private float yMax = 4.5f;
  private float zMax = 6.0f;

  private float xMin = -10f;
  private float yMin = -3.5f;
  private float zMin = 3.0f;

  public float yeetAmountx = 0.01f;
  private bool returne = false;
  private bool pause = false; // runs a coroutine that pauses the object before it begins to fall again

  private float rotateAmount;

    // Start is called before the first frame update
    void Start()
    {
      xCurr = this.transform.position.x;
    } // end start

    IEnumerator Pause()
    {
      pause = true; // pauses fixedupdate falling motion
      float waittime = Random.Range( 0.5f, 1.0f );
      yield return new WaitForSeconds(waittime);
      pause = false;
    } // fin

    void Spawn(){
      Vector3 loc = Vector3.zero;
        loc.x = xMax;
        loc.y = Random.Range( yMin, yMax );
        loc.z = Random.Range( zMin, zMax );

        this.transform.position = loc;
        xCurr = loc.x;
    } // spawn the leaf at the top of the screen

        void FixedUpdate()
        {
          if (pause == false){

          if ((xCurr <= xMin) ){
            returne = true;
          } // fin

          if (returne == false){
              this.transform.position = new Vector3(this.transform.position.x-yeetAmountx, this.transform.position.y, this.transform.position.z);
              xCurr -= yeetAmountx;
          } // fin

          else if (returne == true){
            StartCoroutine(Pause());
            Spawn();
            returne = false;
          } // fin
        } // if pause is not false

        } // fixed update
}
