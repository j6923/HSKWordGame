using UnityEngine;
using TMPro;
using System.Collections.Generic;
using LanguageData; // 네임스페이스 추가
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;
using System.Collections;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.XR;
using XRController = UnityEngine.XR.Interaction.Toolkit.XRController;

//using UnityEditor.SceneManagement;
//using static UnityEngine.Rendering.DynamicArray<T>;

//grab 되었을 떄 물체 이름 
//grab 되었을 때

// interactorable 되었을 때의 object의 이름 

public class wordCreator : MonoBehaviour
{





    private bool isGrabbed;
    public GameObject obstacleEmpty;
    public List<int> availableIndexes;
    public int numberOfCubes;
    public int posIndex;
    public float[] xPositions;
    public UpdateWord update;
    public TMP_FontAsset chineseFont; // SINHEI 폰트 리소스
    public TMP_FontAsset KoreanFont; // 첫 번째 폰트 리소스
    UpdateWord updateWord;
    public lifeManager lifeScore;
    private List<GameObject> spareBlocks = new List<GameObject>();
    public List<GameObject> cubes = new List<GameObject>();
    private List<string> selectedWords = new List<string>();
    //private List<int> usedIndexes = new List<int>();
    public Material cubeMaterial; // qingciwenyang 머티리얼
                                  //public TextMeshProUGUI wordUI;

    public List<LanguageInfo> wordList = new List<LanguageInfo>(WordPair.wordPairs);
    public int randomIndex;

    LanguageInfo info;

    private List<int> posIndexes;
    //valueManager koreanAnswer;

    private wordCreator wordCreatorInstance;
    private List<GameObject> findCubes = new List<GameObject>();
    private List<TextMeshPro> findText = new List<TextMeshPro>();
    private XRBaseInteractable xrBase;

    GameObject spareCube;
    private GameObject cube;
    playerManager player;
    destroyMethod destory;



    public void SetWordCreator(wordCreator creator)
    {
        wordCreatorInstance = creator;
    }

    

    private void Start()
    {
        InvokeRepeating("OnStart", 4f, 0.07f * wordList.Count);// 반복 되는 횟수 

        posIndexes = new List<int> { posIndex };
    }





    private void OnStart()
    {

        //List<LanguageInfo> wordList = WordPair.wordPairs;

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
            
            


            GameObject textObject = Instantiate(textPrefab, cube.transform);


            TextMeshPro textMesh = textObject.AddComponent<TextMeshPro>();
            

            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            
            textObject.layer = 7;

            Vector2 newSize = new Vector2(1f, 1f); // 원하는 크기로 변경
            textRectTransform.sizeDelta = newSize;

            textObject.transform.localPosition = new Vector3(textPrefab.transform.position.x, textPrefab.transform.position.y, -0.6189f);

            textMesh.fontSize = 3f;
            textMesh.alignment = TextAlignmentOptions.Center;

            //Debug.Log("index: " + posIndex);
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
            //string randomKoreanWord = WordPair.wordPairs[randomIndex].KoreanWord;
            int randomKoreanIndex1 = wordList.FindIndex(wordList => wordList.KoreanWord == randomKoreanWord);// 인덱스 찾은 것이 한국어 인덱스와 맞으면 
             //인덱스 나옴 -1나옴 
            if (i != posIndex)
            {
                remainingIndices.Add(i);
            }

            if (i == 0) //첫번째 것이 맞으면
            {
                if (randomKoreanIndex1 != -1) // 디자인 패턴 오브젝트 설계 
                                              //컴포넌트 아키텍쳐 
                                              //프로젝트 구조 // 만들어서 어떤 구조 설계가 되어야 함. 
                {
                    // 한국어와 매칭되는 중국어 중에서 중복 피함 

                    string randomChineseWord = wordList[randomKoreanIndex1].ChineseWord;

                    // Debug.Log("선택한 한국어 : " + randomChineseWord);

                    textMesh.text = randomChineseWord;
                    //Debug.Log("선택:" + textMesh.text);
                    // 이미 선택한 단어 쌍을 제외합니다.

                    wordList.RemoveAt(randomKoreanIndex1);// 중복 제거 


                }

            }

            else // 나머지 큐브들에 대해서 랜덤하게 중국어 단어를 할당합니다. 
                 //cube에 대해서 한국어와 중국어 단어 쌍을 설정하고, 나머지 cubes에 대해서 랜덤하게 중국어 단어를 할당하는 부분
            {
                //randomIndex = Random.Range(0, wordPairs.Count);
                string randomChineseWord = wordList[randomIndex].ChineseWord;
                //Debug.Log("나머지 큐브 : " + randomChineseWord);
                //Debug.Log("인덱스:" + randomIndex);
                textMesh.text = randomChineseWord;
                // Debug.Log("textMesh.text:" + textMesh.text);


                // 이미 선택한 단어 쌍을 제외합니다.
                wordList.RemoveAt(randomIndex);

            }



            textObject.transform.parent = cube.transform;
            //XRGrabInteractable grabInteractable = cube.AddComponent<XRGrabInteractable>();
            XRSimpleInteractable simpleInteact = cube.AddComponent<XRSimpleInteractable>();
            simpleInteact.selectMode = InteractableSelectMode.Single;
            //IXRInteractable activeInteract = cube.AddComponent<IXRInteractable>();
            //XRBaseInteractable xrBaseCube = cube.AddComponent<XRBaseInteractable>();
            
            Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
            if (cubeRigidbody == null)
            {
                cubeRigidbody = cube.AddComponent<Rigidbody>();
                cubeRigidbody.useGravity = false;
            }

            cubes.Add(cube);
            //cubes.Add(spareCube);



            








            
        }





        // 기존 코드...

        if (cubes.Count != 5)
        {
            List<int> validIndexes = availableIndexes
            .Where(index => index != posIndex || posIndex == 0)
            .ToList();

            int spareCubeCount = 0;
            int maxSpareCubeCount = Mathf.Min(validIndexes.Count, 2);

            for (int j = 0; j < maxSpareCubeCount; j++)
            {
                if (validIndexes.Count == 0)
                    break;

                int randomIndex = Random.Range(0, validIndexes.Count);
                int randomNonSelectedIndex = validIndexes[randomIndex];
                validIndexes.RemoveAt(randomIndex);

                float nonSelectedSpawnX = xPositions[randomNonSelectedIndex];
                Vector3 nonSelectedSpawnPosition = new Vector3(nonSelectedSpawnX, 608.7f + 2.3f, -1107.5f);

                // 새로운 큐브를 생성
                spareCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                spareCube.transform.localScale = new Vector3(3.813359f, 6f, 1f);
                spareCube.transform.position = nonSelectedSpawnPosition;
                spareCube.transform.rotation = Quaternion.identity;

                // 파란색으로 설정
                MeshRenderer spareCubeRenderer = spareCube.GetComponent<MeshRenderer>();
                Color blueColor = Color.blue;
                spareCubeRenderer.material.color = blueColor;
               
                spareCube.tag = "spareCubes";
                destroyMethod destroyMethodScript = spareCube.AddComponent<destroyMethod>();
                //XRGrabInteractable grabInteractableSpareCube = spareCube.AddComponent<XRGrabInteractable>();
                //XRBaseInteractable xrBaseSpareCube = spareCube.AddComponent<XRBaseInteractable>();
                XRSimpleInteractable InteractableSpareCube = spareCube.AddComponent<XRSimpleInteractable>();
                
                InteractableSpareCube.selectMode = InteractableSelectMode.Single;
                //XRBaseInteractable xrBaseSpareCube = spareCube.AddComponent<XRBaseInteractable>();
                Rigidbody spareCubeRigidbody = spareCube.GetComponent<Rigidbody>();
                BoxCollider spareCubeBoxCollider = spareCube.GetComponent<BoxCollider>();



                if (spareCubeRigidbody == null)
                {
                    spareCubeRigidbody = spareCube.AddComponent<Rigidbody>();
                   
                    spareCubeRigidbody.useGravity = false;


                }
                if(spareCubeBoxCollider == null)
                {
                    spareCubeBoxCollider = spareCube.AddComponent<BoxCollider>();
                }

                spareCube.layer = 7;
                cubes.Add(spareCube);

                spareCubeCount++;

                //Debug.Log($"Spare Cube Count: {spareCubeCount}, Random Index: {randomNonSelectedIndex}");
                //Debug.Log("Valid Indexes: " + string.Join(", ", validIndexes));
                //Debug.Log("randomIndex: " + randomIndex);
            }
        }

      





        // 수정된 부분: 큐브 하나가 destroy되면 나머지 큐브들도 destroy



        // BoxCollider 활성화





    }











    public void SpereColliderEnabled()
    {
        GameObject leftSphere = GameObject.Find("LeftSphere");
        SphereCollider leftSphereCollider = leftSphere.GetComponent<SphereCollider>();
        if (leftSphereCollider != null)
        {
            // SphereCollider를 활성화
            leftSphereCollider.enabled = true;
        }

        GameObject rightSphere = GameObject.Find("RightSphere");
        SphereCollider rightSphereCollider = rightSphere.GetComponent<SphereCollider>();
        if (rightSphereCollider != null)
        {
            // SphereCollider를 활성화
            rightSphereCollider.enabled = true;
        }
    }
    

    


    void Update()
    {
        update.MoveForward();
        if (lifeScore.life < 1)
        {
            SceneManager.LoadScene("GameOver5");
        }

    }



    public List<GameObject> GetCubesList()
    {
        return cubes;
    }

    public List<GameObject> GetSpareBlocksList()
    {
        return spareBlocks;
    }
   


    

}





