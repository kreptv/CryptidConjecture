/*
 * Created by: Haley Kelly
 * Date Created: 2/23/2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 3/7/2022
 *
 * Description: Script that controls falling leaves that rotate.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{

  private float yCurr = 0f;
  private float xCurr = 0f;

  private float xMax = 7f;
  private float yMax = 4.5f;
  private float zMax = 6.0f;

  private float xMin = -8f;
  private float yMin = -3.5f;
  private float zMin = 3.0f;

  private Quaternion rotStart = Quaternion.Euler(0, 0, 0);
  private Quaternion rotCurr = Quaternion.Euler(0, 0, 0);

  public float yeetAmounty = 0.01f;
  public float yeetAmountx = 0.01f;
  private bool returne = false;
  private bool pause = false; // runs a coroutine that pauses the object before it begins to fall again

  private float rotateAmount;

    void Start()
    {
      rotateAmount = Random.Range( 0.05f, 1f ); // randomize how much the leaf rotates
      yCurr = this.transform.position.y;
      xCurr = this.transform.position.x;

    } // end start

    IEnumerator Pause()
    {
      pause = true; // pauses fixedupdate falling motion
      float waittime = Random.Range( 0.5f, 5.0f );
      yield return new WaitForSeconds(waittime);
      pause = false;
    } // fin

    void Spawn(){
      this.transform.rotation = rotStart;
      rotCurr = rotStart;
      Vector3 loc = Vector3.zero;
        loc.x = Random.Range( xMin, xMax );
        loc.y = yMax;
        loc.z = Random.Range( zMin, zMax );

        this.transform.position = loc;
        yCurr = loc.y;
        xCurr = loc.x;
    } // spawn the leaf at the top of the screen

        void FixedUpdate()
        {
          if (pause == false){

          if ((yCurr <= yMin) || (xCurr <= xMin) ){
            returne = true;
          } // fin

          if (returne == false){
              this.transform.position = new Vector3(this.transform.position.x-yeetAmountx, this.transform.position.y-yeetAmounty, this.transform.position.z);
              rotCurr = rotCurr * Quaternion.Euler(0, 0, rotateAmount);
              this.transform.rotation = rotCurr;
              xCurr -= yeetAmountx;
            yCurr -= yeetAmounty;
          } // fin

          else if (returne == true){
            StartCoroutine(Pause());
            Spawn();
            returne = false;
          } // fin
        } // if pause is not false

        } // fixed update
}
