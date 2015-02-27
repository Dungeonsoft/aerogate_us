Shader "Toony Gooch/Toony Gooch Glow"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
	
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		
        _SColor ("Shadow Color", Color) = (0.0,0.0,0.0,1)
		_LColor ("Highlight Color", Color) = (0.5,0.5,0.5,1)
		_GlowScale("GlowScale", Range(0,1) ) = 0.5
	}

	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
CGPROGRAM
		#pragma surface surf ToonRamp
		
		sampler2D _MainTex;
		sampler2D _Ramp;
		float4 _LColor;
		float4 _SColor;
		float4 _Color;
		
		// custom lighting function that uses a texture ramp based
		// on angle between light direction and normal
		#pragma lighting ToonRamp exclude_path:prepass
		inline half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
		{
			#ifndef USING_DIRECTIONAL_LIGHT
			lightDir = normalize(lightDir);
			#endif
			
			//Calculate N . L
			half d = dot (s.Normal, lightDir)*0.5 + 0.5;
			//Basic toon shading
			half3 ramp = tex2D(_Ramp, float2(d,d)).rgb;
			//Gooch shading
			ramp = lerp(_SColor,_LColor,ramp);
			
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
			c.a = 0;
			
			return c;
		}
		
		struct Input
		{
			float2 uv_MainTex : TEXCOORD0;
		};
		
		void surf (Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			
			o.Albedo = c.rgb * _Color.rgb;
			o.Alpha = c.a;
		}
//ENDCG
//	
//	}
//	
//	Fallback "Toon/Lighted"
//
	
/////////////////////////////////////

			
//		CGPROGRAM
//#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 2.0


			sampler2D _sampler;
			float _GlowScale;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
				half3 spec = light.a * s.Gloss;
				half4 c;
				c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
				c.a = s.Alpha;
				return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input2 
			{
				float2 uv_sampler;

			};

			void vert (inout appdata_full v, out Input2 o) 
			{
				float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input2 IN, inout EditorSurfaceOutput o) 
			{
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
				float4 Sampled2D0=tex2D(_sampler,IN.uv_sampler.xy);
				float4 Multiply0=Sampled2D0 * _GlowScale.xxxx;
				float4 Master0_1_NoInput = float4(0,0,1,1);
				float4 Master0_2_NoInput = float4(0,0,0,0);
				float4 Master0_3_NoInput = float4(0,0,0,0);
				float4 Master0_4_NoInput = float4(0,0,0,0);
				float4 Master0_7_NoInput = float4(0,0,0,0);
				float4 Master0_6_NoInput = float4(1,1,1,1);
				o.Albedo = Sampled2D0;
				o.Alpha = Multiply0;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}									
