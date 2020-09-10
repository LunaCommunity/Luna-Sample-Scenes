Shader "Custom/TextureSwap"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_BlendTex("Mask (RGB)", 2D) = "white" {}
		_MainTex("Albedo (Default)", 2D) = "white" {}
		_SecondTex ("Albedo (Swapped)", 2D) = "white" {}
		[Normal] _BumpMap("Normal Map (Default)", 2D) = "bump" {}
		[Normal] _SecondBumpMap("Normal Map (Swapped)", 2D) = "bump" {}

        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

		sampler2D _BlendTex;
		sampler2D _MainTex;
		sampler2D _SecondTex;
		sampler2D _BumpMap;
		sampler2D _SecondBumpMap;

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
			fixed4 c2 = tex2D(_SecondTex, IN.uv_MainTex) * _Color;
            o.Albedo = lerp(c1.rgb, c2.rgb, blend);
			o.Normal = lerp(UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex)), UnpackNormal(tex2D(_SecondBumpMap, IN.uv_MainTex)), blend);

            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
			o.Alpha = 1;
			o.Occlusion = 1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
