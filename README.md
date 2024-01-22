# HSK 단어 맞추기 게임입니다. 
동영상 : http://bit.ly/hskprojectvideo<br>
##중국어와 한국어 구조체 매핑 
```C#
namespace LanguageData
{
    [System.Serializable]
    public class LanguageInfo
    {
        public int index; 
        public string KoreanWord;
        public string ChineseWord;
    }

    public static class WordPair
    {
        public static List<LanguageInfo> wordPairs = new List<LanguageInfo>
        {
        new LanguageInfo {KoreanWord = "아줌마",ChineseWord = "阿姨" },
        new LanguageInfo {KoreanWord = "문장의 끝에 쓰여 감탄·찬탄 따위 등의 어기를 나타냄", ChineseWord = "啊" },
        new LanguageInfo{KoreanWord= "(키가)작다",ChineseWord ="矮"  },
        new LanguageInfo{KoreanWord="취미",ChineseWord = "爱好"  },
        new LanguageInfo{KoreanWord="조용하다",ChineseWord="安静"},
        new LanguageInfo{KoreanWord="을,를(목적어를 동사 앞에 놓을 때 쓰는 것)",ChineseWord = "把"},
        new LanguageInfo{KoreanWord="(학급의)반",ChineseWord = "班"},
        new LanguageInfo{KoreanWord="옮기다",ChineseWord = "搬"},
        new LanguageInfo{KoreanWord="방법",ChineseWord ="办法" },
        new LanguageInfo{KoreanWord="사무실",ChineseWord ="办公室"},
        new LanguageInfo{KoreanWord="반",ChineseWord ="半" }
        ...
}
```
구조체를 이용하여 한국어와 중국어를 매핑했습니다. 

## 큐브 및 중국어 단어 스크립트
```C#
```
## 큐브 및 중국어 단어 스크립트 
## 목숨(life)
```C#
public TextMeshProUGUI lifeUI;
public int life;
private void Update()
{
    lifeUI.text = "×"+ life;
}

```
## 음악 정지 및 재생 



