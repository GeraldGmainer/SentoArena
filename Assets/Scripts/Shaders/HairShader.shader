// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:7576,x:32719,y:32712,varname:node_7576,prsc:2|emission-2269-OUT,custl-8776-OUT,clip-6540-OUT,olwid-3446-OUT,olcol-9329-OUT;n:type:ShaderForge.SFN_Color,id:6214,x:26648,y:32191,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_6214,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:53,x:27088,y:32194,varname:node_53,prsc:2|A-6214-RGB,B-7765-OUT;n:type:ShaderForge.SFN_Tex2d,id:1242,x:26648,y:32362,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_1242,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:58bf9258a43ea1c4a96fbe557556d710,ntxv:3,isnm:False;n:type:ShaderForge.SFN_LightVector,id:3470,x:26651,y:32728,varname:node_3470,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:896,x:26651,y:32860,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:7015,x:26866,y:32728,varname:node_7015,prsc:2,dt:0|A-3470-OUT,B-896-OUT;n:type:ShaderForge.SFN_Cross,id:318,x:26866,y:32985,varname:node_318,prsc:2|A-896-OUT,B-8586-OUT;n:type:ShaderForge.SFN_Normalize,id:5433,x:27054,y:32985,varname:node_5433,prsc:2|IN-318-OUT;n:type:ShaderForge.SFN_Add,id:8586,x:26651,y:33096,varname:node_8586,prsc:2|A-2846-OUT,B-2346-OUT;n:type:ShaderForge.SFN_Tangent,id:2846,x:26456,y:33096,varname:node_2846,prsc:2;n:type:ShaderForge.SFN_Sin,id:2346,x:26456,y:33228,varname:node_2346,prsc:2|IN-9977-OUT;n:type:ShaderForge.SFN_Slider,id:9977,x:26104,y:33228,ptovrint:False,ptlb:HighlightSharpness,ptin:_HighlightSharpness,varname:node_9977,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:6186,x:27245,y:32985,varname:node_6186,prsc:2|A-5433-OUT,B-5547-OUT;n:type:ShaderForge.SFN_Vector1,id:5547,x:27054,y:33125,varname:node_5547,prsc:2,v1:-1;n:type:ShaderForge.SFN_Dot,id:5690,x:27451,y:33063,varname:node_5690,prsc:2,dt:3|A-6186-OUT,B-6631-OUT;n:type:ShaderForge.SFN_Normalize,id:6631,x:27245,y:33226,varname:node_6631,prsc:2|IN-8576-OUT;n:type:ShaderForge.SFN_Add,id:8576,x:27071,y:33226,varname:node_8576,prsc:2|A-9702-OUT,B-608-OUT;n:type:ShaderForge.SFN_ViewVector,id:9702,x:26876,y:33226,varname:node_9702,prsc:2;n:type:ShaderForge.SFN_LightVector,id:608,x:26876,y:33349,varname:node_608,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6105,x:27639,y:33063,varname:node_6105,prsc:2|A-5690-OUT,B-5690-OUT;n:type:ShaderForge.SFN_OneMinus,id:6118,x:27823,y:32985,varname:node_6118,prsc:2|IN-6105-OUT;n:type:ShaderForge.SFN_Sqrt,id:8458,x:28014,y:32985,varname:node_8458,prsc:2|IN-6118-OUT;n:type:ShaderForge.SFN_Power,id:5232,x:28203,y:32985,varname:node_5232,prsc:2|VAL-8458-OUT,EXP-4556-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4556,x:28014,y:33150,ptovrint:False,ptlb:HightlightSize,ptin:_HightlightSize,varname:node_4556,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:100;n:type:ShaderForge.SFN_Multiply,id:141,x:28410,y:32964,varname:node_141,prsc:2|A-7015-OUT,B-5232-OUT,C-2286-OUT;n:type:ShaderForge.SFN_Slider,id:2286,x:28046,y:33242,ptovrint:False,ptlb:HighlightIntensity,ptin:_HighlightIntensity,varname:node_2286,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5384616,max:1;n:type:ShaderForge.SFN_Add,id:8693,x:28632,y:32832,varname:node_8693,prsc:2|A-53-OUT,B-141-OUT;n:type:ShaderForge.SFN_Multiply,id:8006,x:30994,y:32654,varname:node_8006,prsc:2|A-6646-OUT,B-376-RGB;n:type:ShaderForge.SFN_LightAttenuation,id:95,x:30019,y:32884,varname:node_95,prsc:2;n:type:ShaderForge.SFN_LightColor,id:376,x:30796,y:32793,varname:node_376,prsc:2;n:type:ShaderForge.SFN_Slider,id:3446,x:32344,y:33306,ptovrint:False,ptlb:OutlineWidth,ptin:_OutlineWidth,varname:node_3446,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.004017089,max:0.01;n:type:ShaderForge.SFN_Multiply,id:6793,x:27436,y:32195,varname:node_6793,prsc:2|A-53-OUT,B-5710-RGB;n:type:ShaderForge.SFN_AmbientLight,id:5710,x:27210,y:32300,varname:node_5710,prsc:2;n:type:ShaderForge.SFN_Set,id:1664,x:27637,y:32195,varname:emissionColor,prsc:2|IN-6793-OUT;n:type:ShaderForge.SFN_Get,id:2269,x:32528,y:32811,varname:node_2269,prsc:2|IN-1664-OUT;n:type:ShaderForge.SFN_Get,id:9329,x:32528,y:33050,varname:node_9329,prsc:2|IN-1664-OUT;n:type:ShaderForge.SFN_Set,id:9356,x:31177,y:32654,varname:customLight,prsc:2|IN-8006-OUT;n:type:ShaderForge.SFN_Get,id:8776,x:32528,y:32951,varname:node_8776,prsc:2|IN-9356-OUT;n:type:ShaderForge.SFN_Set,id:569,x:28805,y:32832,varname:combinedColor,prsc:2|IN-8693-OUT;n:type:ShaderForge.SFN_Get,id:3977,x:30402,y:32800,varname:node_3977,prsc:2|IN-569-OUT;n:type:ShaderForge.SFN_Color,id:2848,x:30402,y:32654,ptovrint:False,ptlb:ShadowColor,ptin:_ShadowColor,varname:node_2848,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.801217,c2:0.7941176,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4441,x:30593,y:32654,varname:node_4441,prsc:2|A-2848-RGB,B-3977-OUT;n:type:ShaderForge.SFN_Lerp,id:6646,x:30796,y:32654,varname:node_6646,prsc:2|A-4441-OUT,B-3977-OUT,T-485-OUT;n:type:ShaderForge.SFN_Multiply,id:9600,x:30226,y:32884,varname:node_9600,prsc:2|A-95-OUT,B-4375-OUT;n:type:ShaderForge.SFN_Subtract,id:8456,x:30405,y:32884,varname:node_8456,prsc:2|A-9600-OUT,B-7915-OUT;n:type:ShaderForge.SFN_Clamp01,id:485,x:30593,y:32884,varname:node_485,prsc:2|IN-8456-OUT;n:type:ShaderForge.SFN_Vector1,id:4375,x:30019,y:33019,varname:node_4375,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:7915,x:30226,y:33019,varname:node_7915,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:7765,x:26913,y:32362,varname:node_7765,prsc:2|A-1242-RGB,B-1525-OUT;n:type:ShaderForge.SFN_Slider,id:1525,x:26523,y:32569,ptovrint:False,ptlb:ColorMultiplierer,ptin:_ColorMultiplierer,varname:node_1525,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Slider,id:6540,x:32215,y:32993,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:node_6540,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;proporder:1242-6214-1525-2848-9977-2286-4556-3446-6540;pass:END;sub:END;*/

Shader "Psyren/Shizuka/HairShader" {
    Properties {
        _Texture ("Texture", 2D) = "bump" {}
        _Color ("Color", Color) = (1,0,0,1)
        _ColorMultiplierer ("ColorMultiplierer", Range(0, 5)) = 1
        _ShadowColor ("ShadowColor", Color) = (0.801217,0.7941176,1,1)
        _HighlightSharpness ("HighlightSharpness", Range(0, 1)) = 1
        _HighlightIntensity ("HighlightIntensity", Range(0, 1)) = 0.5384616
        _HightlightSize ("HightlightSize", Float ) = 100
        _OutlineWidth ("OutlineWidth", Range(0, 0.01)) = 0.004017089
        _Alpha ("Alpha", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _OutlineWidth;
            uniform float _ColorMultiplierer;
            uniform float _Alpha;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(float4(v.vertex.xyz + normalize(v.vertex)*_OutlineWidth,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                clip(_Alpha - 0.5);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_53 = (_Color.rgb*(_Texture_var.rgb*_ColorMultiplierer));
                float3 emissionColor = (node_53*UNITY_LIGHTMODEL_AMBIENT.rgb);
                return fixed4(emissionColor,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _HighlightSharpness;
            uniform float _HightlightSize;
            uniform float _HighlightIntensity;
            uniform float4 _ShadowColor;
            uniform float _ColorMultiplierer;
            uniform float _Alpha;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                clip(_Alpha - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_53 = (_Color.rgb*(_Texture_var.rgb*_ColorMultiplierer));
                float3 emissionColor = (node_53*UNITY_LIGHTMODEL_AMBIENT.rgb);
                float3 emissive = emissionColor;
                float node_5690 = abs(dot((normalize(cross(i.normalDir,(i.tangentDir+sin(_HighlightSharpness))))*(-1.0)),normalize((viewDirection+lightDirection))));
                float3 combinedColor = (node_53+(dot(lightDirection,i.normalDir)*pow(sqrt((1.0 - (node_5690*node_5690))),_HightlightSize)*_HighlightIntensity));
                float3 node_3977 = combinedColor;
                float3 customLight = (lerp((_ShadowColor.rgb*node_3977),node_3977,saturate(((attenuation*2.0)-1.0)))*_LightColor0.rgb);
                float3 finalColor = emissive + customLight;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _HighlightSharpness;
            uniform float _HightlightSize;
            uniform float _HighlightIntensity;
            uniform float4 _ShadowColor;
            uniform float _ColorMultiplierer;
            uniform float _Alpha;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                clip(_Alpha - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_53 = (_Color.rgb*(_Texture_var.rgb*_ColorMultiplierer));
                float node_5690 = abs(dot((normalize(cross(i.normalDir,(i.tangentDir+sin(_HighlightSharpness))))*(-1.0)),normalize((viewDirection+lightDirection))));
                float3 combinedColor = (node_53+(dot(lightDirection,i.normalDir)*pow(sqrt((1.0 - (node_5690*node_5690))),_HightlightSize)*_HighlightIntensity));
                float3 node_3977 = combinedColor;
                float3 customLight = (lerp((_ShadowColor.rgb*node_3977),node_3977,saturate(((attenuation*2.0)-1.0)))*_LightColor0.rgb);
                float3 finalColor = customLight;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Alpha;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                clip(_Alpha - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
