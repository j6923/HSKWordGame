# HSK 단어 맞추기 게임입니다. 
# 동영상 : http://bit.ly/hskprojectvideo<br>
<br>
##중국어와 한국어 단어 매핑 
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

### 큐브가 만들어지는 횟수 및 시간 조정 
```C#
private void Start()
{
    InvokeRepeating("OnStart", 4f, 0.07f * wordList.Count);

    posIndexes = new List<int> { posIndex };
}
```
## 큐브 및 중국어 단어 스크립트 생성 (wordCreator.cs)
###1) 큐브 생성 
```C#
GameObject cubePrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);


cubePrefab.transform.localScale = new Vector3(3.813359f, 6f, 1f);
cubePrefab.GetComponent<Renderer>().material = cubeMaterial;
//XRGrabInteractable grabInteractable = cubePrefab.AddComponent<XRGrabInteractable>();
       
//grabInteractable.interactionLayerMask = LayerMask.GetMask("interactable"); // Set the appropriate layer
cubePrefab.layer = 7;
```
비동기로 큐브를 생성해야 했기에 인스펙터창에서 작업하지 못하고 코드로 작업하였습니다. <br>
큐브를 생성하여 머티리얼을 입히고 layer을 변경해주었습니다. 
```C#
float[] xPositions = new float[] { 1475.7f, 1479.93f, 1484.03f, 1488.09f, 1492.16f }; //큐브의 위치 지정 
int numberOfCubes = Random.Range(3, 6);
List<int> availableIndexes = new List<int>(xPositions.Length);// 큐브 위치의 갯수 
```
큐브의 위치를 지정합니다. 
```C#
int numberOfCubes = Random.Range(3, 6);
List<int> availableIndexes = new List<int>(xPositions.Length);// 큐브 위치의 갯수 
```
랜덤으로 3~5개 큐브를 만들도록 하고 인덱스를 이용하여 큐브의 위치에 나올 수 있도록 availableIndexes지정합니다. 

```C#
 for (int i = 0; i < xPositions.Length; i++)
 {
     availableIndexes.Add(i);
 }

```
나온 쿠브의 인덱스를 저장합니다. 
```C#
for (int i = 0; i < numberOfCubes; i++)
{

    randomIndex = Random.Range(0, availableIndexes.Count); //큐브의 위치 인덱스 갯수 중 램덤하게 그 위치갸 numberOfCubes의 갯수만큼 나옴 
    cubeCount = randomIndex;
    int posIndex = availableIndexes[randomIndex];// 큐브 위치의 갯수 중 램덤하게 위치 
                                                 //List<int> availableIndexes = new List<int>(xPositions.Length);
    generatedRandomIndexes.Add(randomIndex);

    availableIndexes.RemoveAt(randomIndex); // 해당 인덱스 제거

     
    float spawnX = xPositions[posIndex];// 큐브의 위치 지정  //큐브 위치 갯수 중 램덤하게 위치한 것 배치 
    // randomIndex = Random.Range(0, wordList.Count);
    //List<int> posIndexes = new List<int> { posIndex };

    Vector3 spawnPosition = new Vector3(spawnX, 608.7f + 2.3f, -1107.5f);
    

    // 큐브 생성 후 중국어 텍스트 생성
    GameObject cube = Instantiate(cubePrefab, spawnPosition, rotation);
    //cube.transform.parent = obstacleEmpty.transform;
    //destroyMethod destory = new destroyMethod();
    destroyMethod destroyMethodScript = cube.AddComponent<destroyMethod>();
    cube.SetActive(true);
    randomIndex = Random.Range(0, availableIndexes.Count); //큐브의 위치 인덱스 갯수 중 램덤하게 그 위치갸 numberOfCubes의 갯수만큼 나옴 
    //int posIndex = availableIndexes[randomIndex];
    //List<int> availableIndexes = new List<int>(xPositions.Length);
    
    

```
###2) 중국어 단어 부착 


```C#
   

    randomIndex = Random.Range(0, wordList.Count);
    LanguageInfo languageInfo = wordList[randomIndex];

    string randomKoreanWord = wordList[randomIndex].KoreanWord;




    // 랜덤하게 선택한 한국어 단어 표시

    GameObject wordObject = new GameObject();

    TextMeshProUGUI koreanUI = GameObject.Find("wordAnswer").GetComponent<TextMeshProUGUI>();
    koreanUI.font = KoreanFont;
    koreanUI.text = randomKoreanWord;

    //cubePrefab = new GameObject();

    //cube prefab 할 것 먼저 만들어 놓음 
    GameObject cubePrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
    

    cubePrefab.transform.localScale = new Vector3(3.813359f, 6f, 1f);
    cubePrefab.GetComponent<Renderer>().material = cubeMaterial;
    //XRGrabInteractable grabInteractable = cubePrefab.AddComponent<XRGrabInteractable>();
   
    //grabInteractable.interactionLayerMask = LayerMask.GetMask("interactable"); // Set the appropriate layer
    cubePrefab.layer = 7;
    //cubePrefab.AddComponent<BoxCollider>();

    //cubePrefab.SetActive(false);

    //text prefab할 것 먼저 만들어 놓음 
    GameObject textPrefab = new GameObject();

    // -- for문 시작

    Quaternion rotation = Quaternion.identity;

    List<int> usedIndexes = new List<int>();
    List<int> remainingIndices = new List<int>();
    List<int> generatedRandomIndexes = new List<int>();
    int cubeCount;
    float[] xPositions = new float[] { 1475.7f, 1479.93f, 1484.03f, 1488.09f, 1492.16f };
    int numberOfCubes = Random.Range(3, 6);
    List<int> availableIndexes = new List<int>(xPositions.Length);// 큐브 위치의 갯수 

    for (int i = 0; i < xPositions.Length; i++)
    {
        availableIndexes.Add(i);
    }
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



