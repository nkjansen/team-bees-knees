Shader "Roystan/Toon/Water"
{
    Properties
    {	
    _DepthGradientShallow("Depth Gradient Shallow", Color) = (0.325, 0.807, 0.971, 0.725)
    _DepthGradientDeep("Depth Gradient Deep", Color) = (0.086, 0.407, 1, 0.749)
    _DepthMaxDistance("Depth Maximum Distance", Float) = 1
    _SurfaceNoise("SurfaceNoise", 2D) = "white" {}
    _SurfaceNoiseCutoff("Surface Noise Cutoff", Range (0, 1)) = 0.777
    _FoamDistance("Foam Distance", Float) = 0.4
    _SurfaceNoiseScroll ("Surface Noise Scroll Amount", Vector) = (0.03, 0.03, 0, 0)
    _SurfaceDistortion ("Surface Distortion", 2D) = "white" {}
    _SurfaceDistortionAmount("Surface Distortion Amount", Range(0,1)) = 0.27
    }
    SubShader
    {
      
        Pass
        {
			CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                //For Them Ripple Effects
                float4 uv : TEXCOORD0; 
            };

            //Variables
            //Animate
            sampler2D _SurfaceDistortion;
            float4 _SurfaceDistortion_ST;
            float _SurfaceDistortionAmount; 

            struct v2f
            {
                float4 vertex : SV_POSITION;
                //For Them Color Effects
                float4 screenPosition : TEXCOORD2;
                //For Them Ripple Effects
                float2 noiseUV : TEXCOORD0;
                //Animation
                float2 distortUV : TEXCOORD1;
            };

            //VARIABLES
            //For Them Ripple Effects
            sampler2D _SurfaceNoise;
            float4 _SurfaceNoise_ST;

            v2f vert (appdata v)
            {
                v2f o;

                o.vertex = UnityObjectToClipPos(v.vertex);
                //For Them Color Effects
                o.screenPosition = ComputeScreenPos (o.vertex);
                //For Them Ripple Effects
                o.noiseUV = TRANSFORM_TEX(v.uv, _SurfaceNoise);
                //Animation
                o.distortUV = TRANSFORM_TEX(v.uv, _SurfaceDistortion);

                return o;
            }

            //Variables
            //Controls the depth of material
            float4 _DepthGradientShallow;
            float4 _DepthGradientDeep;
            // Controls the distance of Depth Texture
            float _DepthMaxDistance;
            //Makes a greyscale image of objects from distance to camera
            sampler2D _CameraDepthTexture;
            //For Them Ripples
            float _SurfaceNoiseCutoff;
            //Sea Foam
            float _FoamDistance;
            //Animate
            float2 _SurfaceNoiseScroll;
          
            //Fragment Shader
            float4 frag (v2f i) : SV_Target
            {
            //Samples Texture and Screen position in black and white
               float existingDepth01 = tex2D(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPosition.xy / i.screenPosition.w)).r;
               //float existingDepth01 = tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPosition)).r; (**is the same thing**)
                float existingDepthLinear = LinearEyeDepth(existingDepth01);
                float depthDifference = existingDepthLinear - i.screenPosition.w; 
                //return depthDifference; (**black and white output**)

            //Colorized the Inverted Black and White Values
                float waterDepthDifference01 = saturate(depthDifference / _DepthMaxDistance);
                float4 waterColor = lerp(_DepthGradientShallow, _DepthGradientDeep, waterDepthDifference01);
            //(**Colorized Output**) return waterColor;
            
            //Sea Foam
            float foamDepthDifference01 = saturate(depthDifference / _FoamDistance);
            float surfaceNoiseCutoff = foamDepthDifference01 * _SurfaceNoiseCutoff;

            //Animate
            float2 distortSample = (tex2D (_SurfaceDistortion, i.distortUV).xy * 2 -1) * _SurfaceDistortionAmount;
            float2 noiseUV = float2((i.noiseUV.x + _Time.y * _SurfaceNoiseScroll.x) +distortSample.x, (i.noiseUV.y + _Time.y * _SurfaceNoiseScroll.y) + distortSample.y);

            // Ripple Effects
                float surfaceNoiseSample = tex2D(_SurfaceNoise, noiseUV).r;
                float surfaceNoise = surfaceNoiseSample > surfaceNoiseCutoff ? 1: 0;
                return waterColor + surfaceNoise; 

            }
            ENDCG
        }
    }
}