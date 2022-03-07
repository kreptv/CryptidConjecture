/*
 * Created by: Haley Kelly
 * Date Created: 2/23/2022
 *
 * Last Edited by: N/A
 * Last Edited: 2/23/2022
 *
 * Description: Script that controls balls for Cryptid Conjecture.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Material ballMaterial;
    Color color = new Color(1f, 0.0290f, 0f, 1f);
    Color color1 = new Color(0.770f, 1f, 0f, 1f);
    Color color2 = new Color(1f, 0.310f, 0f, 1f);

    private int bounces = 0;
    void Start()
    {
       ballMaterial.SetColor("_Color", color1);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("DestroyBall")){
          if (bounces == 0){
            bounces ++;
            ballMaterial.SetColor("_Color", color2);
          }
          else if (bounces == 1){
            bounces = 0;
            Destroy(gameObject);
            ballMaterial.SetColor("_Color", color);
          }



        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
