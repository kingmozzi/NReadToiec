using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class WordEntry
{
    public string word;
    public string meaning;

    // 복사 생성자 (깊은 복사)
    public WordEntry(WordEntry other) {
        this.word = other.word;
        this.meaning = other.meaning;
    }
}

[Serializable]
public class WordList
{
    public List<WordEntry> words;

    public WordList(List<WordEntry> words, int from_num, int to_num, int stage)
    {
        this.words = new List<WordEntry>();
        int coef = (stage - 1) * 1000;
        for (int i = from_num + coef; i < to_num + coef; i++)
        {
            this.words.Add(new WordEntry(words[i]));  // 깊은 복사
        }
    }

    //Fisher-Yates shuffle
    public void ShuffleWords()
    {
        System.Random rng = new System.Random();
        int n = words.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            WordEntry temp = words[k];
            words[k] = words[n];
            words[n] = temp;
        }
    }
}