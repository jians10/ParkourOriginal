using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Menu[] menus=null;
    public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string openMenu) {

        for (int i = 0; i < menus.Length; i++) {

            if (menus[i].MenuName == openMenu)
            {
                menus[i].Open();
            }
            else if (menus[i].open) {

                CloseMenu(menus[i]);
            }
        
        }
    
    }
    public void OpenMenu(Menu menu) {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
                //Debug.Log("Close" + menus[i].MenuName);
            }

        }
        menu.Open();
    }
    public void CloseMenu(Menu menu) {
        menu.Close();
    }
}
