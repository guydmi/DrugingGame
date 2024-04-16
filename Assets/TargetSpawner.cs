/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetSpawner : MonoBehaviour
{
    public targetBehaviour Package;
    public GameObject PackagePrefab;
    public GameObject finishLine;
    private int counter = 4;


    public static Vector3 FindRandomLocation()
    {

        var randomPoint = new Vector3();
        randomPoint.x = Random.Range(0.0f, 2.0f);
        randomPoint.y = 1;
        randomPoint.z = Random.Range(0.0f, 2.0f);
        Quaternion CubeRotation = Quaternion.Euler(0, 0, 0);
        Vector3 CubeSize = new Vector3(0.05f, 0.05f, 0.05f);
        while (Physics.CheckBox(randomPoint, CubeSize, CubeRotation))
        {
            randomPoint.x = Random.Range(0.0f, 2.0f);
            randomPoint.y = 1;
            randomPoint.z = Random.Range(0.0f, 2.0f);
        }

        return randomPoint;
    }

    public void SpawnPackage()
    {
        var packageClone = GameObject.Instantiate(PackagePrefab);
        packageClone.transform.position = FindRandomLocation();

        Package = packageClone.GetComponent<targetBehaviour>();
    }
    /*
        public void SpawnFinishLine()
        {
            var finishClone = GameObject.Instantiate(finishLine);
            finishClone.transform.position = FindRandomLocation();

            FinishLine = finishClone.GetComponent<FinishLineBehaviour>();
        }
    */
    private void Update()
    {
        if (counter != 0)
        {
            if (Package == null)
            {
                SpawnPackage();
                counter--;
            }
            var packagePosition = Package.gameObject.transform.position;
            packagePosition.Set(packagePosition.x, packagePosition.y, packagePosition.z);
        }
/*        else
        {
            if (FinishLine == null)
            {
                SpawnFinishLine();
            }
            var finishPosition = finishLine.gameObject.transform.position;
            finishPosition.Set(finishPosition.x, finishPosition.y, finishPosition.z);
        }
*/

    }
}
