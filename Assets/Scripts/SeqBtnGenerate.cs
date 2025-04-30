using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SeqBtnGenerate : MonoBehaviour
{
    public GameObject btn_prefab;
    List<GameObject> instance_list = new List<GameObject>();

    void Start()
    {
  
    }

    void SetBtn(int from_num, int to_num){
        GameObject tempObj = Instantiate(btn_prefab, this.transform);
        instance_list.Add(tempObj);
        Text tempText = tempObj.GetComponentInChildren<Text>();
        tempText.text = from_num + "~" + to_num;
        Button tempBtn = tempObj.GetComponent<Button>();
        tempBtn.onClick.AddListener(() => GameManager.Instance.set_study_screen(from_num, to_num));
    }

    public void GenBtn(int array_len)
    {
        int from_num = 0;
        int to_num = 0;

        for (; to_num < array_len;)
        {
            to_num += 50;

            if(to_num > array_len)
            {
                to_num = array_len;
            }

            // 버튼 생성 및 텍스트 변경
            SetBtn(from_num, to_num);

            // 특정 조건에서 새로운 범위 버튼 생성
            if (to_num % 300 == 0 || to_num == 1000)
            {
                from_num = to_num;
                if (from_num != 300)
                {
                    SetBtn(0, to_num);
                }
            }
        }
    }
}