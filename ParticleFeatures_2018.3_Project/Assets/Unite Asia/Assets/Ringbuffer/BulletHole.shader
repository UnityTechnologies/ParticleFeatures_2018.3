Shader "Particles/BulletHole"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_EmissionTex("Emission", 2D) = "white" {}
		_GlowStrength("Glow Strength", float) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off
		ZWrite Off
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
				float2 uv : TEXCOORD0;
				float4 color : COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.color = v.color;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _EmissionTex;
			float _GlowStrength;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 emis = tex2D(_EmissionTex, i.uv);
				col.rgb += emis.rgb * i.color.rgb * _GlowStrength; //apply emission
				col.a *= i.color.a; //fade alpha out
				return col;
			}
			ENDCG
		}
	}
}
