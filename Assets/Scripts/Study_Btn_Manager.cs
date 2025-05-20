/*
 * page = 3
 */


using UnityEngine;

public class Study_Btn_Manager : MonoBehaviour
{
    public GameObject meaning_txt;
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
        GameManager.Instance.study_mode = false;
        GameManager.Instance.set_screen(3, 2);
    }

    public void active_meaning(){
        meaning_txt.SetActive(true);
    }

    public void active_retry(){
        meaning_txt.SetActive(false);
        GameManager.Instance.swlIdx++;
        if(GameManager.Instance.swlIdx>=GameManager.Instance.splittedWordList.words.Count){
            GameManager.Instance.splittedWordList.ShuffleWords();
            GameManager.Instance.swlIdx = 0;
        }
    }

    public void active_know(){
        meaning_txt.SetActive(false);
        GameManager.Instance.splittedWordList.words.RemoveAt(GameManager.Instance.swlIdx);
        if(GameManager.Instance.swlIdx>=GameManager.Instance.splittedWordList.words.Count){
            GameManager.Instance.swlIdx = 0;
        }
    }
}
