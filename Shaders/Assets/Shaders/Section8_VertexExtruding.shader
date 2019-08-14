Shader "Custom Shaders/Section8_VertexExtruding"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Amount ("Extrude", Range(-1, 1)) = 0.1
    }
    SubShader
    {
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert vertex:vert

        float _Amount;
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        struct appdata {
            float4 vertex: POSITION;
            float3 normal: NORMAL;
            float4 texcoord: TEXCOORD0;
        };

        // manipulates the vertices of the model through rendering
        void vert (inout appdata v) {
            v.vertex.xyz += v.normal * _Amount;
        }

        
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
