using UnityEngine;
using UnityEngine.UI;

public class Study_Mode_Manager : MonoBehaviour
{
    public Text progress_txt;
    public Text word_txt;
    public Text meaning_txt;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.study_mode){
            if(GameManager.Instance.splittedWordList.words.Count <= 0){
                GameManager.Instance.study_mode = false;
                GameManager.Instance.set_screen(3, 2);
            }
            present_info();
        }
    }

    void present_info(){
        progress_txt.text = GameManager.Instance.swlIdx + "/" + GameManager.Instance.splittedWordList.words.Count;
        word_txt.text = GameManager.Instance.splittedWordList.words[GameManager.Instance.swlIdx].word;
        meaning_txt.text = GameManager.Instance.splittedWordList.words[GameManager.Instance.swlIdx].meaning;
    }
}
