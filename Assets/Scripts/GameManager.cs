using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //screen
    public GameObject title_screen;
    public  GameObject select_mode_screen;
    public GameObject select_seq_screen;
    public GameObject study_screen;

    GameObject[] screen_list;

    //word
    public TextAsset jsonFile; // Unity Editor에서 JSON 파일을 할당
    public WordList wordList;
    public WordList splittedWordList;
    public int swlIdx = 0;
    public int stage_amount = 1;

    //size 최대 1000 예정
    public TextAsset[] TA_list;

    //seq button generator
    public GameObject SeqBtnGenerator;
    private SeqBtnGenerate sbgScript;

    //flag
    public bool study_mode = false;

     private void Awake() {
        if (Instance == null) {
            Instance = this;
            // 필요한 경우 DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screen_list = new GameObject[]{title_screen, select_mode_screen, select_seq_screen, study_screen};
        TA_list = new TextAsset[]{jsonFile};
        sbgScript = SeqBtnGenerator.GetComponent<SeqBtnGenerate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_screen(int cur, int go){
        screen_list[cur].SetActive(false);
        screen_list[go].SetActive(true);
    }

    public void set_study_screen(int from_num, int to_num){
        splittedWordList = new WordList(wordList.words, from_num, to_num);
        study_mode = true;
        swlIdx = 0;
        set_screen(2, 3);
        // Debug.Log(splittedWordList.words.Count);
        // foreach(var word in splittedWordList.words)
        // {
        //     if(word == null){
        //         Debug.Log("null-------------------");
        //         continue;
        //     }
        //     Debug.Log($"단어: {word.word}, 뜻: {word.meaning}");
        // }
    }

    public void Exit_game(){
        Debug.Log("exit");
        Application.Quit();
    }

    public void LoadWords(int mode)
    {
        if (TA_list[mode] == null)
        {
            Debug.LogError("JSON 파일이 할당되지 않았습니다.");
            return;
        }

        wordList = JsonUtility.FromJson<WordList>(TA_list[mode].text);

        // foreach (var word in wordList.words)
        // {
        //     Debug.Log($"단어: {word.word}, 뜻: {word.meaning}");
        // }

        sbgScript.GenBtn(wordList.words.Count);
    }
}
