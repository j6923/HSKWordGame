# HSK 단어 맞추기 게임입니다. 
## 동영상 : http://bit.ly/hskprojectvideo<br>

##중국어와 한국어 단어 매핑(LanguageData.cs) 
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
        new LanguageInfo{KoreanWord="반",ChineseWord ="半" },
        new LanguageInfo {KoreanWord="도와주다",ChineseWord ="帮忙"  },
            ...
        }
    }
```
##큐브 및 중국어 단어 생성 
1) 큐브 생성 
```C#
for (int i = 0; i < numberOfCubes; i++)
{

    randomIndex = Random.Range(0, availableIndexes.Count); //큐브의 위치 인덱스 갯수 중 램덤하게 그 위치갸 numberOfCubes의 갯수만큼 나옴 
    cubeCount = randomIndex;
    int posIndex = availableIndexes[randomIndex];// 큐브 위치의 갯수 중 램덤하게 위치 
                                                
    generatedRandomIndexes.Add(randomIndex);

    availableIndexes.RemoveAt(randomIndex); // 해당 인덱스 제거

     
    float spawnX = xPositions[posIndex];// 큐브의 위치 지정  //큐브 위치 갯수 중 램덤하게 위치한 것 배치 
    // randomIndex = Random.Range(0, wordList.Count);
    //List<int> posIndexes = new List<int> { posIndex };

    Vector3 spawnPosition = new Vector3(spawnX, 608.7f + 2.3f, -1107.5f);
```
랜덤하게 뽑은 수만큼 반복하여 큐브를 만들어 위치시키는 부분입니다. 

```C#
GameObject cube = Instantiate(cubePrefab, spawnPosition, rotation);
destroyMethod destroyMethodScript = cube.AddComponent<destroyMethod>();
cube.SetActive(true);
randomIndex = Random.Range(0, availableIndexes.Count);
```
큐브에 큐브가 파괴될 때 작동하도록 destroyMethod라는 스크립트를 붙여주고 큐브 위치의 갯수만큼 램덤하게 만들어지도록 합니다. 

###2) 중국어 단어 부착  - 큐브 생성 후 중국어 텍스트 생성 및 머티리얼 조정 
```C#
randomIndex = Random.Range(0, wordList.Count);
LanguageInfo languageInfo = wordList[randomIndex];
string randomKoreanWord = wordList[randomIndex].KoreanWord;
GameObject wordObject = new GameObject();
TextMeshProUGUI koreanUI = GameObject.Find("wordAnswer").GetComponent<TextMeshProUGUI>();
koreanUI.font = KoreanFont;
koreanUI.text = randomKoreanWord;
```
후에 한국어 단어와 대응되는 중국어 단어 정답 및 램더하게 중국어 단러를 큐브에 붙이기 위한 작업입니다.  
```C#
GameObject textPrefab = new GameObject();

GameObject textObject = Instantiate(textPrefab, cube.transform);
TextMeshPro textMesh = textObject.AddComponent<TextMeshPro>();
RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
textObject.layer = 7;

Vector2 newSize = new Vector2(1f, 1f); 
textRectTransform.sizeDelta = newSize;

textObject.transform.localPosition = new Vector3(textPrefab.transform.position.x, textPrefab.transform.position.y, -0.6189f);

textMesh.fontSize = 3f;
textMesh.alignment = TextAlignmentOptions.Center;

```
// 중국어 단어가 렌더링될 영역의 크기 조정

           

textMesh.color = Color.white;
textMesh.font = chineseFont;
textMesh.fontStyle = FontStyles.Bold;
textMesh.isOverlay = false;
textObject.SetActive(true);
textMesh.isOverlay = false;

//XRController leftcontroller; 
BoxCollider boxCollider = textPrefab.AddComponent<BoxCollider>();
//XRBaseInteractable textInteractor = textPrefab.AddComponent
//XRGrabInteractable grabInteractableText = textPrefab.AddComponent<XRGrabInteractable>();
boxCollider.size = new Vector3(1f, 0.5f, 0.1f);
```

```C#
    GameObject cube = Instantiate(cubePrefab, spawnPosition, rotation);
    destroyMethod destroyMethodScript = cube.AddComponent<destroyMethod>();
    cube.SetActive(true);
    randomIndex = Random.Range(0, availableIndexes.Count); //큐브의 위치 인덱스 갯수 중 램덤하게 그 위치 numberOfCubes의 갯수만큼 나옴     
```
```C#
 textMesh.alignment = TextAlignmentOptions.Center;
 textMesh.color = Color.white;
 textMesh.font = chineseFont;
 textMesh.fontStyle = FontStyles.Bold;
 textMesh.isOverlay = false;
 textObject.SetActive(true);
 textMesh.isOverlay = false;
```




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



