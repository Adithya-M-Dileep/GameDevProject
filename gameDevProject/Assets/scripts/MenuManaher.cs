using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManaher : MonoBehaviour
{
    public static MenuManaher Instance;

    [SerializeField] Menu[] menus;
    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string MenuName)
    {

        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == MenuName)
            {
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            //if (menus[i].open)
            //{
                CloseMenu(menus[i]);
            //}
        }
        menu.Open();
    }
    public void CloseMenu(Menu menu)

    {
        menu.Close();

    }

}