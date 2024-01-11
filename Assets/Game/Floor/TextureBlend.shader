Shader "Unlit/TextureBlend"
{
	Properties
	{
		_MainTex("MainTexture", 2D) = "white" {}
		_SubTex("SubTexture", 2D) = "white" {}
		_MaskTex("MaskTexture", 2D) = "black" {}
	}
		SubShader
	{
		Tags { "Queue" = "Transparent"}

		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 worldPosition : TEXCOORD1;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			sampler2D _SubTex;
			sampler2D _MaskTex;

			float4 _MainTex_ST;
			float4 _SubTex_ST;
			float4 _MaskTex_ST;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = UnityObjectToWorldNormal(v.normal);
				o.worldPosition = mul(unity_ObjectToWorld, v.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float2 MainTil = _MainTex_ST.xy;
				float2 MainOff = _MainTex_ST.zw;
				float2 SubTil = _SubTex_ST.xy;
				float2 SubOff = _SubTex_ST.zw;
				float2 MaskTil = _MaskTex_ST.xy;
				float2 MaskOff = _MaskTex_ST.zw;

				fixed4 main = tex2D(_MainTex, i.uv * MainTil + MainOff);
				fixed4 sub = tex2D(_SubTex, i.uv * SubTil + SubOff);
				fixed4 mask = tex2D(_MaskTex, i.uv * MaskTil + MaskOff);
				fixed4 col = mask.r * sub + (1 - mask.r) * main;

				return col;
			}
			ENDCG
		}
	}
}
