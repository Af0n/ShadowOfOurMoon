Shader "Custom/JustLight"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("Normal", 2D) = "bump" {}
        _BumpScale("Normal Strength", float) = 1
        _Threshold("Shadow Threshold", Range(0,2)) = 1
        _ShadowSoftness("Shadow Smoothness", Range(0.5, 1)) = 0.5
        _ShadowColor("Shadow Color", Color) = (0,0,0,1)
        _PointThreshold("Point Threshold", Range(0, 1)) = 0.001
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Toon fullforwardshadows

        half _Threshold;
        half _ShadowSoftness;
        half3 _ShadowColor;

        sampler2D _MainTex;
        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
        };

        half4 _Color;
        float _BumpScale;
        half _PointThreshold;

        inline half4 LightingToon(SurfaceOutput s, half3 lightDir, half atten)
        {
        #ifndef USING_DIRECTIONAL_LIGHT
            lightDir = normalize(lightDir);
        #endif
        #ifdef POINT
            atten = step(_PointThreshold, atten);
        #endif
        #ifdef SPOT
            atten = step(_PointThreshold, atten);
        #endif
            half shadowDot = pow(dot(s.Normal, lightDir) * 0.5 + 0.5, _Threshold);
            float threshold = smoothstep(0.5, _ShadowSoftness, shadowDot);
            half3 diffuseTerm = threshold * atten;
            half3 diffuse = lerp(_ShadowColor, _LightColor0.rgb, diffuseTerm);
            return half4(s.Albedo * diffuse, 1);
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color;
            o.Normal = UnpackScaleNormal(tex2D(_BumpMap, IN.uv_MainTex), _BumpScale);
        }
        ENDCG

        // Refined Shadow Caster Pass
        Pass
        {
            Name "ShadowCaster"
            Tags { "LightMode" = "ShadowCaster" }
            ZWrite On
            ZTest LEqual
            ColorMask 0
            Cull Back

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 shadowCoord : TEXCOORD1;
            };

            v2f vert(appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                // Calculate shadow coordinates for precision
                // UNITY_TRANSFER_SHADOW(o, v);
                return o;
            }

            float frag(v2f i) : SV_Target
            {
                // Apply shadow attenuation
                // UNITY_APPLY_SHADOW(i);
                return 0.0;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
