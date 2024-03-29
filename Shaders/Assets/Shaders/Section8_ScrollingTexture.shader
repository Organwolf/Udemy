﻿Shader "Custom Shaders/Section8_ScrollingTexture"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _FoamTex ("Foam (RGB)", 2D) = "white" {}
        _ScrollX ("Scroll X", Range(-5,5)) = 1
        _ScrollY ("Scroll Y", Range(-5,5)) = 1
    }

    SubShader
    {

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _FoamTex;
        
        float _ScrollX;
        float _ScrollY;

        struct Input
        {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            // By multiplying the scroll values the shader scrolls!
            _ScrollX *= _Time;
            _ScrollY *= _Time;

            // water and foam are color values
            float3 water = (tex2D (_MainTex, IN.uv_MainTex + float2(_ScrollX, _ScrollY))).rgb;
            float3 foam = (tex2D (_FoamTex, IN.uv_MainTex + float2(_ScrollX/2.0, _ScrollY/2.0))).rgb;
            
            // they are added to the Albedo. Dividing by 2 decrease the intensity 
            o.Albedo = (water + foam) / 2.0;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
