﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class WaterFlow : PostEffectBase
{
    //扭曲的时间系数
    [Range(0.0f, 1.0f)]
    public float DistortTimeFactor;
    //扭曲的强度
    [Range(0.0f, 0.2f)]
    public float DistortStrength;
    //噪声图
    public Texture NoiseTexture = null;
 
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_Material)
        {
            _Material.SetTexture("_NoiseTex", NoiseTexture);
            _Material.SetFloat("_DistortTimeFactor", DistortTimeFactor);
            _Material.SetFloat("_DistortStrength", DistortStrength);
            Graphics.Blit(source, destination, _Material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
