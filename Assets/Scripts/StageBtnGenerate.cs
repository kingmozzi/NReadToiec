using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StageBtnGenerate : MonoBehaviour
{
    //stage button generator
    public GameObject StageBtn_prefab;
    List<GameObject> instance_list = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void StageBtnSet(int stage)
    {
        GameObject tempObj = Instantiate(StageBtn_prefab, this.transform);
        instance_list.Add(tempObj);
        Text tempText = tempObj.GetComponentInChildren<Text>();
        tempText.text = "STAGE " + stage;
        Button tempBtn = tempObj.GetComponent<Button>();
        tempBtn.onClick.AddListener(() => GameManager.Instance.set_seq_screen(stage));
    }

    public void StageBtnGen(int array_len)
    {
        int stage_len = (int)(array_len / 1000) + 1;

        for (int i = 1; i <= stage_len; i++)
        {
            StageBtnSet(i);
        }
        
    }
}
