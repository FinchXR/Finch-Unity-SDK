Shader "AnimatedSprite"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_RecTex("Recolor Texture", 2D) = "white" {}

		_MaxAlpha("Max alpha",Range(0,1)) = 1
		_MaxColors("Animated colors",Int) = 0

		_DeltaH("Min delta H", Range(0,360)) = 0
		_DeltaS("Max delta S", Range(0,100)) = 0
		_DeltaV("Max delta V", Range(0,100)) = 0
	}

	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
		LOD 100
		Cull Off

		Pass
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _RecTex;

			float4 _MainTex_ST;
			
			float _MaxDelta;
			float _MaxAlpha;
			int _MaxColors;

			float3 GetHSV(float4 col);
			float3 GetRGB(float h, float s, float v);

			float _DeltaH;
			float _DeltaS;
			float _DeltaV;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target
			{
				float k = 1 / 3.0;
				float4 col = tex2D(_MainTex, i.uv);
				float alpha = min(_MaxAlpha, col[3]);
				col[3] = alpha;

				float3 hsvColor = GetHSV(col);

				#if defined(UNITY_COMPILER_HLSL)
				[unroll(3)]
				#endif

				float4 resultColor = float4(0, 0, 0, 0);
				float percent = 0;

				for (int i = 0; i < min(_MaxColors,3); i++)
				{
					float y = (0.5 + i) * k;

					float3 hsvAnimatedColor = GetHSV(tex2D(_RecTex, float2(0.5 * k, y)));
					float3 hsvChangedColor = GetHSV(tex2D(_RecTex, float2(1.5 * k, y)));

					float dH = min(abs(hsvColor[0] - hsvAnimatedColor[0]), 360 - abs(hsvColor[0] - hsvAnimatedColor[0]));
					float dS = abs(hsvColor[1] - hsvAnimatedColor[1]);
					float dV = abs(hsvColor[2] - hsvAnimatedColor[2]);

					float kV = 1 - min(1, dV / _DeltaV);
					float kS = 1 - min(1, dS / _DeltaS) * min(1, hsvAnimatedColor[2] / _DeltaV);
					float kH = 1 - (min(1,min(hsvAnimatedColor[1] / _DeltaS, hsvAnimatedColor[2] / _DeltaV))) * min(1, dH / _DeltaH);

					if (kS * kH * kV> percent)
					{
						percent = kS * kH * kV;
						
						float4 changedColor = tex2D(_RecTex, float2(1.5 * k, y));
						float3 hsvChangedColor = GetHSV(changedColor);
						float3 colorGenerate= GetRGB
						(
							hsvChangedColor[0],
							hsvChangedColor[1],
							hsvColor[2] * (1 - kV) + hsvChangedColor[2] * kV
						);;
						resultColor = float4(colorGenerate[0], colorGenerate[1], colorGenerate[2], min(changedColor[3], alpha));
					}
				}

				if (percent > 0)
				{
					return resultColor;
				}

				return col;
			}

			float3 GetRGB(float h, float s, float v)
			{
				float vmin = (100 - s) * v * 0.01;
				float a = (v - vmin) * (h % 60) / 60;

				float vinc = vmin + a;
				float vdec = v - a;

				float hi = abs(floor(h / 60)) % 6;

				if (hi == 0)
				{
					return float3(v, vinc, vmin) * 0.01;
				}

				if (hi == 1)
				{
					return float3(vdec, v, vmin) * 0.01;
				}

				if (hi == 2)
				{
					return float3(vmin, v, vinc) * 0.01;
				}

				if (hi == 3)
				{
					return float3(vmin, vdec, v) * 0.01;
				}

				if (hi == 4)
				{
					return float3(vinc, vmin, v) * 0.01;
				}

				return float3(v, vmin, vdec) * 0.01;
			}

			float3 GetHSV(float4 col) 
			{
				float h = 0;
				float s = 0;
				float v = 0;

				float r = col[0];
				float g = col[1];
				float b = col[2];

				float maxColor = max(max(r, g), b);
				float minColor = min(min(r, g), b);
				v = maxColor * 100;

				if (maxColor == minColor)
				{
					h = s = 0; // achromatic
				}
				else
				{
					float d = maxColor - minColor;
					s = (1 - minColor / maxColor) * 100;

					if (maxColor == r)
					{
						h = 60 * (g - b) / d + (g < b ? 360 : 0);
					}

					if (maxColor == g)
					{
						h = 60 * (b - r) / d + 120;
					}

					if (maxColor == b)
					{
						h = 60 * (r - g) / d + 240;
					}
				}

				return float3(h, s, v);
			}

			ENDCG
		}


	}
}
