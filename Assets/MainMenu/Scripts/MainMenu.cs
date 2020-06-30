 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum MenuOrientation
    {
        Horizontal = 0,
        Vertical = 1,
        OnlyText = 2
    }

    public static MainMenu instance;

    public GameObject verticalMenuLayout;
    public GameObject verticalMenuLayout2;
    public GameObject horizontalMenuLayout;
    public string[] menuLayouts = new string[] { "Horizontal", "Vertical", "Text" };
    public MenuOrientation orientation;

    private void Awake()
    {
        instance = this;
    }
   
    private void Start()
    {

        orientation = new MenuOrientation();
        orientation = MenuOrientation.Horizontal;
    }
    public void ChangeMenuOrientation()
    {
        verticalMenuLayout.SetActive(false);
        verticalMenuLayout2.SetActive(false);
        horizontalMenuLayout.SetActive(false);
        switch (orientation)
        {
            case MenuOrientation.Horizontal:
                horizontalMenuLayout.SetActive(true);
                orientation = MenuOrientation.Vertical;
                break;
            case MenuOrientation.Vertical:
                verticalMenuLayout.SetActive(true);
                orientation = MenuOrientation.OnlyText;
                break;
            case MenuOrientation.OnlyText:
                verticalMenuLayout2.SetActive(true);
                orientation = MenuOrientation.Horizontal;
                break;
            default:
                break;
        }

    }

    
    //---button clicks---
    public void btn_Profile_click()
    {
        print("QuickMatch btn");
        SceneManager.LoadScene("Boxing");
    }
    public void btn_FightMatch_click()
    {
        print("Mode btn");
    }
    public void btn_CharacterCreation_click()
    {
        print("Training btn");
        SceneManager.LoadScene("Gym");  
    }
    public void btn_FightingSystem_click()
    {
        print("Shop btn");
    }
    public void btn_AmatureStart_click()
    {
        print("Settings btn");
    }
    public void btn_VirtualBetting_click()
    {
        print("virtual betting btn");
        SceneManager.LoadScene("Betting");
    }
    public void btn_TrainingMode_click()
    {
        print("leader board btn");
    }
    public void btn_LeaderBoard_click()
    {
        print("Exit btn ");
    }

}
