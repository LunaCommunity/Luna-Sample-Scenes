Shader "Custom/TextureMask"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_BlendTex("Mask (RGB)", 2D) = "white" {}
		_MainTex("Albedo (Default)", 2D) = "white" {}
		[Normal] _BumpMap("Normal Map (Default)", 2D) = "bump" {}

        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        ZWrite Off
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade

        #pragma target 3.0

		sampler2D _BlendTex;
		sampler2D _MainTex;
		sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			float blend = tex2D(_BlendTex, IN.uv_MainTex).r;
			fixed4 c1 = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c1.rgb * (1 - blend);
            o.Alpha = c1.a * (1 - blend);

            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
			o.Occlusion = 1;
        }

        ENDCG
    }

    FallBack "Diffuse"
}