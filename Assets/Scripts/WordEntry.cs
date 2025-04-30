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

    public WordList(List<WordEntry> words, int from_num, int to_num){
        this.words = new List<WordEntry>();
        for(int i=from_num;i<to_num;i++){
            this.words.Add(new WordEntry(words[i]));  // 깊은 복사
        }
    }
}