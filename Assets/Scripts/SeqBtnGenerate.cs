using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SeqBtnGenerate : MonoBehaviour
{
    public GameObject btn_prefab;
    public List<List<GameObject>> instance_list = new List<List<GameObject>>();

    void Start()
    {

    }

    void SetBtn(int from_num, int to_num, List<GameObject> temp_instance_list, int stage)
    {
        GameObject tempObj = Instantiate(btn_prefab, this.transform);
        temp_instance_list.Add(tempObj);
        Text tempText = tempObj.GetComponentInChildren<Text>();
        tempText.text = from_num + "~" + to_num;
        Button tempBtn = tempObj.GetComponent<Button>();
        tempBtn.onClick.AddListener(() => GameManager.Instance.set_study_screen(from_num, to_num, stage));
    }

    public void GenBtn(int array_len, int stage)
    {
        //each stage size
        const int size = 1000;
        //ex stage1 -> stage=0 * size; each stage start point
        int stage_size_mult = (stage - 1) * size;
        int from_num = 0;
        int to_num = 0;
        int end_point = size;

        List<GameObject> temp_instance_list = new List<GameObject>();

        if (stage_size_mult + size > array_len)
        {
            end_point = array_len - stage_size_mult;
        }

        for (; to_num < end_point;)
        {
            to_num += 50;

            if (to_num > end_point)
            {
                to_num = end_point;
            }

            // 버튼 생성 및 텍스트 변경
            SetBtn(from_num, to_num, temp_instance_list, stage);

            // 특정 조건에서 새로운 범위 버튼 생성
            if (to_num % 300 == 0 || to_num == end_point)
            {
                from_num = to_num;
                if (from_num != 300)
                {
                    SetBtn(0, to_num, temp_instance_list, stage);
                }
            }
        }

        instance_list.Add(temp_instance_list);
    }

    public void InitSeqBtn(int array_len)
    {
        int stage_len = (int)(array_len / 1000) + 1;

        for (int i = 1; i <= stage_len; i++)
        {
            GenBtn(array_len, i);
        }
    }
}