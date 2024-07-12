// 文件名称：WoMenContorl.cs
// 功能描述：
// 编写作者：曾理
// 编写日期：
// 修改记录：

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using MotionverseSDK;

public class WoMenContorl : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    //public Avatar avatar;


    // Start is called before the first frame update
    void Start()
    {
        //skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        for (int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
        {
            foreach (BlendShape value in Enum.GetValues(typeof(BlendShape)))
            {
                if (skinnedMeshRenderer.sharedMesh.GetBlendShapeName(i).Contains(value.ToString()))
                {
                    Debug.LogError(skinnedMeshRenderer.sharedMesh.GetBlendShapeName(i));
                
                }
            }
        }


        //GetBlendShapeIndex
        for (int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount;i++)
        {
            var name = skinnedMeshRenderer.sharedMesh.GetBlendShapeName(i);
            Debug.LogError($"{i}_{name}的权重：{skinnedMeshRenderer.GetBlendShapeWeight(i)}");
        }

        //avatar.humanDescription.human.
    }

    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (timer>0.1f)
        {
            for (int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
            {
                if (i>6)
                {
                    continue;
                }
                var name = skinnedMeshRenderer.sharedMesh.GetBlendShapeName(i);

                float value = Random.Range(0, 10);
                skinnedMeshRenderer.SetBlendShapeWeight(i, value);
                //Debug.LogError($"{i}_{name}的权重：{skinnedMeshRenderer.GetBlendShapeWeight(i)}");
            }

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }


    }
}
