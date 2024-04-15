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
using UnityEngine;

/**
 * Our car will track a reticle and collide with a <see cref="targetBehaviour"/>.
 */
/**
 * Our car will track a reticle and collide with a <see cref="FinishLineBehaviour"/>.
 */
public class sphereBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var Package = other.GetComponent<targetBehaviour>();
        if (Package != null)
        {
            Destroy(other.gameObject);
        }

    }
}