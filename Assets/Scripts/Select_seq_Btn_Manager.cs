/*
 * page = 2
 */


using UnityEngine;

public class Select_seq_Btn_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void active_back(){
        //to title_screen;
        GameManager.Instance.deactive_seq_btn();
        GameManager.Instance.set_screen(2, 1);
    }
}
