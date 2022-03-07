/*
 * Created by: Haley Kelly
 * Date Created: 2/10/2022
 *
 * Last Edited by: N/A
 * Last Edited: 3/6/2022
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

  public GameObject directionalLightObject;
  private Light directionalLight;

    public AudioSource audioData;
    public GameObject title;
    public GameObject regionOne; // floating object [1] containing button
        public Button r1; // floating button child of regionOne
    public GameObject oneContinue;  // pop-up story object
        public Button r1_1; // progression button on story object
    public GameObject regionTwo;
        public Button r2;
    public GameObject twoContinue;
        public Button r2_1;
    public GameObject regionThree;
        public Button r3;
    public GameObject threeContinue;
        public Button r3_1;
    public GameObject regionFour;
        public Button r4;
    public GameObject fourContinue;
        public Button r4_1;
    public GameObject regionFive;
        public Button r5;
    public GameObject fiveContinue;
        public Button r5_1;
    public GameObject backdrop;

    public GameObject cryptids;
    public GameObject cryptid1;
    public GameObject cryptid2;
    public GameObject cryptid3;
    public GameObject cryptid4;
    public GameObject cryptid5;

    public GameObject eraseSaveDataEncapsulator;
    public Button eraseSaveData;

    public GameObject eraseSaveDataPrompt;
      public Button yeserase;
      public Button noerase;

    public GameObject instructionsEncapsulator;
      public Button instructions;

    public GameObject instructionsPrompt;
      public Button instructionsok;

    public GameObject creditsEncapsulator;
      public Button credits;

    public GameObject creditsPrompt;
      public Button creditsok;

    public GameObject exitGameEncapsulator;
    public Button exitGame;

    public GameObject exitGamePrompt;
      public Button yesexit;
      public Button noexit;

    public GameObject exitSelectionEncapsulator;
    public Button exitSelection;

    public int progress = 1;

    int yPosCurr = 0;
    public int yPosMax = 90;
    public float yeetAmount = 0.1f;
    bool reverse = false;

    void testForProgress(){
      PlayerPrefs.GetInt("progress", 1);

    if (PlayerPrefs.HasKey("progress")) {
            progress = PlayerPrefs.GetInt("progress");
      }else {
        progress = 1;
      }

    if (progress == 1){
      cryptid1.SetActive(false);
      cryptid2.SetActive(false);
      cryptid3.SetActive(false);
      cryptid4.SetActive(false);
      cryptid5.SetActive(false);
      r1.interactable = true;
      r2.interactable = false;
      r3.interactable = false;
      r4.interactable = false;
      r5.interactable = false;
    } else if (progress == 2){
      cryptid1.SetActive(true);
      cryptid2.SetActive(false);
      cryptid3.SetActive(false);
      cryptid4.SetActive(false);
      cryptid5.SetActive(false);
      r1.interactable = true;
      r2.interactable = true;
      r3.interactable = false;
      r4.interactable = false;
      r5.interactable = false;
    } else if (progress == 3){
      cryptid1.SetActive(true);
      cryptid2.SetActive(true);
      cryptid3.SetActive(false);
      cryptid4.SetActive(false);
      cryptid5.SetActive(false);
      r1.interactable = true;
      r2.interactable = true;
      r3.interactable = true;
      r4.interactable = false;
      r5.interactable = false;
    } else if (progress == 4){
      cryptid1.SetActive(true);
      cryptid2.SetActive(true);
      cryptid3.SetActive(true);
      cryptid4.SetActive(false);
      cryptid5.SetActive(false);
      r1.interactable = true;
      r2.interactable = true;
      r3.interactable = true;
      r4.interactable = true;
      r5.interactable = false;
    } else if (progress == 5){
      cryptid1.SetActive(true);
      cryptid2.SetActive(true);
      cryptid3.SetActive(true);
      cryptid4.SetActive(true);
      cryptid5.SetActive(false);
      r1.interactable = true;
      r2.interactable = true;
      r3.interactable = true;
      r4.interactable = true;
      r5.interactable = true;
    } else if (progress == 6){
      cryptid1.SetActive(true);
      cryptid2.SetActive(true);
      cryptid3.SetActive(true);
      cryptid4.SetActive(true);
      cryptid5.SetActive(true);
      r1.interactable = true;
      r2.interactable = true;
      r3.interactable = true;
      r4.interactable = true;
      r5.interactable = true;
    }

    }

    // Start is called before the first frame update
    void Start()
    {
      directionalLight = directionalLightObject.GetComponent<Light>();
      directionalLightObject.transform.position = new Vector3(0f , 9.58f, 0f);
      audioData = GetComponent<AudioSource>();
      audioData.loop = true;
      audioData.Play(0);

      testForProgress();

      r1.onClick.AddListener(regionOneStoryPrompt);
      r1_1.onClick.AddListener(loadRegionOne);
      r2.onClick.AddListener(regionTwoStoryPrompt);
      r2_1.onClick.AddListener(loadRegionTwo);
      r3.onClick.AddListener(regionThreeStoryPrompt);
      r3_1.onClick.AddListener(loadRegionThree);
      r4.onClick.AddListener(regionFourStoryPrompt);
      r4_1.onClick.AddListener(loadRegionFour);
      r5.onClick.AddListener(regionFiveStoryPrompt);
      r5_1.onClick.AddListener(loadRegionFive);
      exitGame.onClick.AddListener(exitGameePrompt);
      yesexit.onClick.AddListener(exitGamee);
      noexit.onClick.AddListener(SetMenuActive);
      exitSelection.onClick.AddListener(SetMenuActive);

      eraseSaveData.onClick.AddListener(eraseSaveDataa);
      yeserase.onClick.AddListener(reset);
      noerase.onClick.AddListener(SetMenuActive);
      credits.onClick.AddListener(creditss);
      creditsok.onClick.AddListener(SetMenuActive);
      instructions.onClick.AddListener(instructionss);
      instructionsok.onClick.AddListener(SetMenuActive);
    }

    void eraseSaveDataa(){
      SetMenuInactive();
      eraseSaveDataPrompt.SetActive(true);
    }

    void reset(){
      PlayerPrefs.SetInt("progress", 1);

      testForProgress();

      SetMenuActive();
    }

    void creditss(){
      SetMenuInactive();
      creditsPrompt.SetActive(true);
    }
    void instructionss(){
      SetMenuInactive();
      instructionsPrompt.SetActive(true);
    }


    void SetMenuActive(){ // enables menu selection screen
      cryptids.SetActive(true); title.SetActive(true); exitGameEncapsulator.SetActive(true); instructionsEncapsulator.SetActive(true); creditsEncapsulator.SetActive(true); eraseSaveDataEncapsulator.SetActive(true); instructionsPrompt.SetActive(false); creditsPrompt.SetActive(false); exitGamePrompt.SetActive(false); exitSelectionEncapsulator.SetActive(false);
      eraseSaveDataPrompt.SetActive(false); regionOne.SetActive(true); regionTwo.SetActive(true); regionThree.SetActive(true); regionFour.SetActive(true); regionFive.SetActive(true);
      oneContinue.SetActive(false); twoContinue.SetActive(false); threeContinue.SetActive(false); fourContinue.SetActive(false); fiveContinue.SetActive(false);
    } // fin

    void SetMenuInactive(){ // disables menu selection screen
      cryptids.SetActive(false);
      instructionsEncapsulator.SetActive(false); creditsEncapsulator.SetActive(false); eraseSaveDataEncapsulator.SetActive(false);
      title.SetActive(false);
      regionOne.SetActive(false);
      regionTwo.SetActive(false);
      regionThree.SetActive(false);
      regionFour.SetActive(false);
      regionFive.SetActive(false);
      exitGameEncapsulator.SetActive(false);
    } // fin

    void yeetUp(GameObject b){
      b.transform.position = new Vector3(b.transform.position.x, b.transform.position.y+yeetAmount, b.transform.position.z);
    } // fin

    void yeetDown(GameObject b){
      b.transform.position = new Vector3(b.transform.position.x, b.transform.position.y-yeetAmount, b.transform.position.z);
    } // fin


    void FixedUpdate(){

      if (yPosCurr == yPosMax){
        reverse = true;
      } // fin

      else if (yPosCurr == 0){
        reverse = false;
      } // fin

      if (reverse == false){
        yeetUp(regionOne); yeetUp(regionTwo); yeetUp(regionThree); yeetUp(regionFour); yeetUp(regionFive);
        yeetDown(title);
        yPosCurr ++;
      } // fin

      else if (reverse == true){
        yeetDown(regionOne); yeetDown(regionTwo); yeetDown(regionThree); yeetDown(regionFour); yeetDown(regionFive);
        yeetUp(title);
        yPosCurr --;
      } // fin


    } // fixed update

    void exitGameePrompt(){
      exitGamePrompt.SetActive(true);
      SetMenuInactive();
    } // fin

    void exitGamee(){
      Application.Quit();
    }

    void regionOneStoryPrompt(){ // enables story prompt
      Debug.Log("Region 1 clicked!" ) ;
      oneContinue.SetActive(true);
      SetMenuInactive();
      exitSelectionEncapsulator.SetActive(true);
    } // fin

    void loadRegionOne(){ // loads scene once story prompt is clicked
      SceneManager.LoadScene("RegionOne");
    } // fin

    void regionTwoStoryPrompt(){ // enables story prompt
      Debug.Log("Region 2 clicked!" ) ;
      twoContinue.SetActive(true);
      SetMenuInactive();
      exitSelectionEncapsulator.SetActive(true);
    } // fin

    void loadRegionTwo(){ // loads scene once story prompt is clicked
      SceneManager.LoadScene("RegionTwo");
    } // fin

    void regionThreeStoryPrompt(){ // enables story prompt
      Debug.Log("Region 3 clicked!" ) ;
      threeContinue.SetActive(true);
      SetMenuInactive();
      exitSelectionEncapsulator.SetActive(true);
    } // fin

    void loadRegionThree(){ // loads scene once story prompt is clicked
      SceneManager.LoadScene("RegionThree");
    } // fin

    void regionFourStoryPrompt(){ // enables story prompt
      Debug.Log("Region 4 clicked!" ) ;
      fourContinue.SetActive(true);
      SetMenuInactive();
      exitSelectionEncapsulator.SetActive(true);
    } // fin

    void loadRegionFour(){ // loads scene once story prompt is clicked
      SceneManager.LoadScene("RegionFour");
    } // fin

    void regionFiveStoryPrompt(){ // enables story prompt
      Debug.Log("Region 5 clicked!" ) ;
      fiveContinue.SetActive(true);
      SetMenuInactive();
      exitSelectionEncapsulator.SetActive(true);
    } // fin

    void loadRegionFive(){ // loads scene once story prompt is clicked
      SceneManager.LoadScene("RegionFive");
    } // fin



    // Update is called once per frame
    void Update()
    {


    }
}
