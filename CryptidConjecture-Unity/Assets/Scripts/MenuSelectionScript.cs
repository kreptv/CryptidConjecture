/*
 * Created by: Haley Kelly
 * Date Created: 2/10/2022
 *
 * Last Edited by: N/A
 * Last Edited: 2/10/2022
 *
 * Description: Menu selection for Cryptid Conjecture.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelectionScript : MonoBehaviour
{
    public Button regionOne;
    public Button regionTwo;
    public Button regionThree;
    public Button regionFour;
    public Button regionFive;
    public GameObject backdrop;

    private int progress = 1;

    // each region should load their respective scenes when clicked
    // backdrop should shift as regions are moused over
    // regions remain locked if save data is not found
    // regions show cryptid scene when region has been beat

    // Start is called before the first frame update
    void Start()
    {



    }

    void loadRegionOne(){
      Debug.Log("Region 1 clicked!" ) ;
      SceneManager.LoadScene("RegionOne");
    }
    void loadRegionTwo(){
      Debug.Log("Region 2 clicked!" ) ;
      //SceneManager.LoadScene("RegionTwo");
    }
    void loadRegionThree(){
      Debug.Log("Region 3 clicked!" ) ;
      //SceneManager.LoadScene("RegionThree");
    }
    void loadRegionFour(){
      Debug.Log("Region 4 clicked!" ) ;
      //SceneManager.LoadScene("RegionFour");
    }
    void loadRegionFive(){
      Debug.Log("Region 5 clicked!" ) ;
      //SceneManager.LoadScene("RegionFive");
    }



    // Update is called once per frame
    void Update()
    {

      // when clicked,
      regionOne.onClick.AddListener(loadRegionOne);

      if(progress > 1){
        regionTwo.onClick.AddListener(loadRegionTwo);
      }
      if(progress > 2){
        regionThree.onClick.AddListener(loadRegionThree);
      }
      if(progress > 3){
        regionFour.onClick.AddListener(loadRegionFour);
      }
      if(progress > 4){
        regionFive.onClick.AddListener(loadRegionFive);
      }



    }
}
