// https://gamedev.stackexchange.com/a/119057

Shader "Unlit/YarnLineShader"
{
	Properties
	{
		_RepeatCount("Repeat Count", float) = 5
		_Spacing("Spacing", float) = 0.5
		_Offset("Offset", float) = 0
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 100

		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float _RepeatCount;
			float _Spacing;
			float _Offset;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				fixed4 color : COLOR0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv.x = (o.uv.x + _Offset) * _RepeatCount * (1.0f + _Spacing);
				o.color = v.color;

				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{


				i.uv.x = fmod(i.uv.x, 1.0f + _Spacing);
			//float r = length(i.uv - float2(1.0f + _Spacing, 1.0f) * 0.5f) * 2.0f;
			fixed4 color = tex2D(_MainTex, i.uv);
			color.a *= saturate((0.99f) * 100.0f);



			return color;
		}
		ENDCG
	}
	}
}