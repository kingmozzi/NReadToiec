/*
 * page = 1
 */

using UnityEngine;

public class Select_Mode_Btn_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void active_word(int mode=0){
    //     //to select_seq_screen;
    //     GameManager.Instance.set_screen(1, 2);
    //     GameManager.Instance.LoadWords(mode);
    // }

    public void active_back(){
        //to title_screen;
        GameManager.Instance.set_screen(1, 0);
    }
}
