/*
 * page = 0
 */

using UnityEngine;

public class Title_Btn_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void active_start(){
        //to select_mode_screen
        GameManager.Instance.set_screen(0, 1);
    }

    public void active_exit(){
        GameManager.Instance.Exit_game();
    }
}
