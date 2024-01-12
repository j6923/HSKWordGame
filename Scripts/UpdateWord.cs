using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateWord : MonoBehaviour
{


    wordCreator wordCreatorInstance;



    public void MoveForward()
    {
        wordCreatorInstance = FindObjectOfType<wordCreator>();

        List<GameObject> cubes = wordCreatorInstance.GetCubesList();
        List<GameObject> spareBlocks = wordCreatorInstance.GetSpareBlocksList();
        float moveSpeed = 5f;  // 이동 속도를 조절하는 값

        foreach (GameObject cube in cubes)
        {
            if (cube == null) continue;

            float newZ = cube.transform.position.z - moveSpeed * Time.deltaTime;
            cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, newZ);
        }

        foreach (GameObject spareCube in spareBlocks)
        {
            if (spareCube == null) continue;

            float newZ = spareCube.transform.position.z - moveSpeed * Time.deltaTime;
            spareCube.transform.position = new Vector3(spareCube.transform.position.x, spareCube.transform.position.y, newZ);
        }
    }
}
