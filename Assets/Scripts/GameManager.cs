using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //screen
    public GameObject title_screen;
    public GameObject select_mode_screen;
    public GameObject select_seq_screen;
    public GameObject study_screen;

    GameObject[] screen_list;

    //stage
    public int cur_stage = 0;

    //word
    public TextAsset jsonFile; // Unity Editor에서 JSON 파일을 할당
    public WordList wordList;
    public WordList splittedWordList;
    public int swlIdx = 0;
    public int stage_amount = 1;

    //list in json
    //public TextAsset[] TA_list;

    //Stage button generator
    public GameObject StageBtnGenerator;
    private StageBtnGenerate stbgScript;

    //seq button generator
    public GameObject SeqBtnGenerator;
    private SeqBtnGenerate sbgScript;

    //flag
    public bool study_mode = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // 필요한 경우 DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screen_list = new GameObject[] { title_screen, select_mode_screen, select_seq_screen, study_screen };
        //TA_list = new TextAsset[] { jsonFile };
        stbgScript = StageBtnGenerator.GetComponent<StageBtnGenerate>();
        sbgScript = SeqBtnGenerator.GetComponent<SeqBtnGenerate>();
        LoadWords();
        stbgScript.StageBtnGen(wordList.words.Count);
        sbgScript.InitSeqBtn(wordList.words.Count);
        deactive_seq_btn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void set_screen(int cur, int go)
    {
        screen_list[cur].SetActive(false);
        screen_list[go].SetActive(true);
    }

    public void active_seq_btn(int stage)
    {
        for (int i = 0; i < sbgScript.instance_list[stage-1].Count; i++) {
            sbgScript.instance_list[stage - 1][i].SetActive(true);
        }
    }

    public void deactive_seq_btn()
    {
        for (int i = 0; i < sbgScript.instance_list.Count; i++)
        {
            for (int j = 0; j < sbgScript.instance_list[i].Count; j++)
            {
                sbgScript.instance_list[i][j].SetActive(false);
            }
        }
    }

    public void set_seq_screen(int stage)
    {
        active_seq_btn(stage);
        set_screen(1, 2);
    }

    public void set_study_screen(int from_num, int to_num, int stage)
    {
        splittedWordList = new WordList(wordList.words, from_num, to_num, stage);
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

    public void Exit_game()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void LoadWords(/*int mode*/)
    {
        // if (TA_list[mode] == null)
        // {
        //     Debug.LogError("JSON 파일이 할당되지 않았습니다.");
        //     return;
        // }

        if (jsonFile == null)
        {
            Debug.LogError("JSON 파일이 할당되지 않았습니다.");
            return;
        }

        wordList = JsonUtility.FromJson<WordList>(jsonFile.text);

        // foreach (var word in wordList.words)
        // {
        //     Debug.Log($"단어: {word.word}, 뜻: {word.meaning}");
        // }
        
    }

}
