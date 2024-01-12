using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class playerManager : MonoBehaviour
{
    public wordCreator wordcreator;// = new wordCreator(); 
    
    public lifeManager lifeScore;
    public TextMeshProUGUI scoreText;
    
    public scoreManager scoremanager;
    public TMP_Text koreanAnswer;
   
    
    public List<GameObject> findCubes = new List<GameObject>();
    private List<TextMeshPro> findText = new List<TextMeshPro>();
    private List<GameObject> spareCubeList = new List<GameObject>();
    
    private TextMeshPro cubeText;
    private GameObject destroyedCube;
    public TextMeshProUGUI lifeUI;
    
    public GameObject player;


    UnityEngine.InputSystem.XR.XRController controllers;
    public XRRayInteractor interactor;
    private UnityEngine.XR.Interaction.Toolkit.XRController xrController;
    private XRRayInteractor rayInteractor;
    public XRInteractorLineVisual lineVisual;
    destroyMethod destory;
    


    public XRBaseInteractable xrInteractable;
    public XRRayInteractor Ray;

    public XRGrabInteractable grabInteractable;



    public XRBaseInteractor xrInteractor;  // xrInteractor를 public 변수로 선언
    
    private Ray ray;

    private void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();

    }
    private void Update()
    {

        Vector3 raycastOrigin = transform.position + Vector3.up;
        Vector3 raycastDirection = transform.forward;


        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, 1.1f))
        {
            TextMeshPro cubeText = hit.collider.GetComponentInChildren<TextMeshPro>();
            TextMeshPro cubeTextChild = hit.collider.GetComponent<TextMeshPro>();

            if (cubeText != null || cubeTextChild != null)
            {
                findCubes.Add(hit.collider.gameObject);
                findText.Add(cubeText);
                findText.Add(cubeTextChild);
                string chineseCube = cubeText.text;
                Debug.Log("중국어 단어: " + chineseCube);


                Destroy(hit.collider.gameObject);


            }
            else if (!hit.collider.CompareTag("spareCubes") && (cubeText == null || cubeTextChild == null))
            {
                findCubes.Add(hit.collider.gameObject);


                lifeScore.life -= 1;

                Destroy(hit.collider.gameObject);

            }


            else if (hit.collider.CompareTag("spareCubes") && (cubeText == null || cubeTextChild == null) )

            {
                findCubes.Add(hit.collider.gameObject);


                lifeScore.life -= 1;

                Destroy(hit.collider.gameObject);




            }
        }

        

    }


    /*
    private void OnDestroy()
    {
        Destroy(gameObject);
    }


    private void OnRaycastHit(XRSimpleInteractable interactable)
    {
        // Ray가 충돌한 object를 destroy
        Destroy(interactable.gameObject);
    }

    */











}

