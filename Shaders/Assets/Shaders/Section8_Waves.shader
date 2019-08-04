Shader "Custom Shaders/Section8_Waves"
{
    Properties
    {
        // Main texture
        _MainTex ("Texture", 2D) = "white" {}
        // Tint of color
        _Tint ("Tint Color", Color) = (1,1,1,1)
        // How close neighboring peaks are
        _Freq("Frequency", Range(0,5)) = 2
        // Speed across the surface
        _Speed ("Speed", Range(1,100)) = 30
        // Height of waves
        _Amp ("Amplitude", Range(0,1)) = 0.5
    }
    SubShader
    {
            CGPROGRAM
            // Regular surface shader together with a vertex shader
            #pragma surface surf Lambert vertex:vert

            // Input structure for main uv textures
            // Vertex color adds the tint
            struct Input 
            {
                float2 uv_MainTex;
                float3 vertColor;
            };

            // We will be using these inside of the functions
            float4 _Tint;
            float _Freq;
            float _Speed;
            float _Amp;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0; 
                float4 texcoord1: TEXCOORD1;
                float4 texcoord2: TEXCOORD2;
            };

            // Appdata coming in Input data going out
            void vert (inout appdata v, out Input o) {
                UNITY_INITIALIZE_OUTPUT(Input,o);
                float t = _Time * _Speed;
                // multiple sin functions to add variations
                // to the "rolling" of the waves
                float waveHeight = sin(t + v.vertex.x * _Freq) * _Amp +
                                   sin(t*0.2 + v.vertex.y * _Freq*0.2) * _Amp;
                v.vertex.y = v.vertex.y + waveHeight;
                v.normal = normalize(float3(v.normal.x + waveHeight, 
                                            v.normal.y, v.normal.z));
                // sets the min wave height to 2
                o.vertColor = waveHeight + 2;
            
            }
            
            sampler2D _MainTex;
            void surf (Input IN, inout SurfaceOutput o) {
                float4 c = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = c * IN.vertColor.rgb;
            } 
        ENDCG
        }
Fallback "Diffuse"
}

