// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:5004,x:32719,y:32712,varname:node_5004,prsc:2|normal-5103-RGB,emission-6005-OUT,custl-2338-OUT,clip-1715-OUT,olwid-4394-OUT,olcol-4044-RGB;n:type:ShaderForge.SFN_Color,id:2141,x:30950,y:32451,ptovrint:False,ptlb:shadowColor,ptin:_shadowColor,varname:node_2141,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9333333,c2:0.9254902,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:1667,x:31121,y:33023,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_1667,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6429,x:31145,y:32451,varname:node_6429,prsc:2|A-2141-RGB,B-2138-OUT;n:type:ShaderForge.SFN_Lerp,id:917,x:31351,y:32545,varname:node_917,prsc:2|A-6429-OUT,B-2138-OUT,T-4137-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:3929,x:30603,y:32658,varname:node_3929,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6947,x:30783,y:32658,varname:node_6947,prsc:2|A-3929-OUT,B-3845-OUT;n:type:ShaderForge.SFN_Subtract,id:2311,x:30968,y:32658,varname:node_2311,prsc:2|A-6947-OUT,B-8385-OUT;n:type:ShaderForge.SFN_Clamp01,id:4137,x:31145,y:32658,varname:node_4137,prsc:2|IN-2311-OUT;n:type:ShaderForge.SFN_Vector1,id:3845,x:30603,y:32788,varname:node_3845,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:8385,x:30783,y:32788,varname:node_8385,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:5817,x:28911,y:33100,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_5817,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:1739,x:28911,y:33276,ptovrint:False,ptlb:RedColor,ptin:_RedColor,varname:node_1739,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:6186,x:28911,y:33445,ptovrint:False,ptlb:GreenColor,ptin:_GreenColor,varname:node_6186,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:8956,x:28911,y:33616,ptovrint:False,ptlb:BlueColor,ptin:_BlueColor,varname:node_8956,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9596,x:29193,y:33119,varname:node_9596,prsc:2|A-5817-R,B-1739-RGB;n:type:ShaderForge.SFN_Multiply,id:8158,x:29193,y:33242,varname:node_8158,prsc:2|A-5817-G,B-6186-RGB;n:type:ShaderForge.SFN_Multiply,id:4844,x:29193,y:33369,varname:node_4844,prsc:2|A-5817-B,B-8956-RGB;n:type:ShaderForge.SFN_Add,id:4293,x:29408,y:33221,varname:node_4293,prsc:2|A-9596-OUT,B-8158-OUT,C-4844-OUT;n:type:ShaderForge.SFN_Set,id:51,x:29663,y:33220,varname:maskColor,prsc:2|IN-4293-OUT;n:type:ShaderForge.SFN_Set,id:3171,x:31656,y:32547,varname:customLight,prsc:2|IN-917-OUT;n:type:ShaderForge.SFN_Get,id:2338,x:32519,y:32919,varname:node_2338,prsc:2|IN-3171-OUT;n:type:ShaderForge.SFN_NormalVector,id:7236,x:28920,y:32625,prsc:2,pt:False;n:type:ShaderForge.SFN_ViewVector,id:1670,x:28920,y:32769,varname:node_1670,prsc:2;n:type:ShaderForge.SFN_Dot,id:3800,x:29104,y:32625,varname:node_3800,prsc:2,dt:0|A-7236-OUT,B-1670-OUT;n:type:ShaderForge.SFN_OneMinus,id:8048,x:29284,y:32625,varname:node_8048,prsc:2|IN-3800-OUT;n:type:ShaderForge.SFN_Clamp,id:9786,x:29468,y:32625,varname:node_9786,prsc:2|IN-8048-OUT,MIN-5796-OUT,MAX-9903-OUT;n:type:ShaderForge.SFN_Vector1,id:5796,x:29284,y:32760,varname:node_5796,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Vector1,id:9903,x:29284,y:32821,varname:node_9903,prsc:2,v1:0.98;n:type:ShaderForge.SFN_Set,id:784,x:29646,y:32625,varname:falloffU,prsc:2|IN-9786-OUT;n:type:ShaderForge.SFN_Tex2d,id:8741,x:30914,y:33213,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_8741,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Set,id:5448,x:31951,y:33174,varname:combinedColor,prsc:2|IN-372-OUT;n:type:ShaderForge.SFN_Get,id:2138,x:30950,y:32601,varname:node_2138,prsc:2|IN-5448-OUT;n:type:ShaderForge.SFN_Get,id:3146,x:30893,y:33149,varname:node_3146,prsc:2|IN-51-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:6324,x:32476,y:33710,varname:node_6324,prsc:2;n:type:ShaderForge.SFN_Code,id:5158,x:32328,y:33856,varname:node_5158,prsc:2,code:cgBlAHQAdQByAG4AIABfAFcAbwByAGwAZABTAHAAYQBjAGUAQwBhAG0AZQByAGEAUABvAHMAOwA=,output:2,fname:getWorldSpaceCameraPos,width:247,height:132;n:type:ShaderForge.SFN_Distance,id:8688,x:32666,y:33710,varname:node_8688,prsc:2|A-6324-XYZ,B-5158-OUT;n:type:ShaderForge.SFN_Power,id:8466,x:32844,y:33710,varname:node_8466,prsc:2|VAL-8688-OUT,EXP-3177-OUT;n:type:ShaderForge.SFN_Slider,id:3177,x:32497,y:34027,ptovrint:False,ptlb:OutlineDistancePower,ptin:_OutlineDistancePower,varname:node_3177,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.84,max:1;n:type:ShaderForge.SFN_Slider,id:2977,x:32687,y:33635,ptovrint:False,ptlb:OutlineWidth,ptin:_OutlineWidth,varname:node_2977,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.001,max:0.01;n:type:ShaderForge.SFN_Multiply,id:4041,x:33021,y:33635,varname:node_4041,prsc:2|A-2977-OUT,B-8466-OUT;n:type:ShaderForge.SFN_Set,id:3725,x:33190,y:33635,varname:outlineWidth,prsc:2|IN-4041-OUT;n:type:ShaderForge.SFN_Get,id:4394,x:32519,y:33031,varname:node_4394,prsc:2|IN-3725-OUT;n:type:ShaderForge.SFN_Color,id:4044,x:32530,y:33110,ptovrint:False,ptlb:OutlineColor,ptin:_OutlineColor,varname:node_4044,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8032,x:31121,y:33403,ptovrint:False,ptlb:falloffSampler,ptin:_falloffSampler,varname:node_8032,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5584-OUT;n:type:ShaderForge.SFN_Get,id:1399,x:30744,y:33404,varname:node_1399,prsc:2|IN-784-OUT;n:type:ShaderForge.SFN_Vector1,id:6479,x:30765,y:33451,varname:node_6479,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Append,id:5584,x:30940,y:33403,varname:node_5584,prsc:2|A-1399-OUT,B-6479-OUT;n:type:ShaderForge.SFN_HalfVector,id:6962,x:30252,y:33845,varname:node_6962,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:1164,x:30252,y:33969,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:9514,x:30437,y:33845,varname:node_9514,prsc:2,dt:0|A-6962-OUT,B-1164-OUT;n:type:ShaderForge.SFN_Power,id:7208,x:30801,y:33845,varname:node_7208,prsc:2|VAL-9514-OUT,EXP-2661-OUT;n:type:ShaderForge.SFN_Multiply,id:4412,x:30981,y:33845,varname:node_4412,prsc:2|A-7208-OUT,B-9232-RGB,C-9294-OUT;n:type:ShaderForge.SFN_Slider,id:2235,x:30252,y:34239,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_2235,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:11,max:11;n:type:ShaderForge.SFN_Color,id:9232,x:30803,y:34035,ptovrint:False,ptlb:SpecularColor,ptin:_SpecularColor,varname:node_9232,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:9294,x:30646,y:34232,ptovrint:False,ptlb:Specularity,ptin:_Specularity,varname:node_9294,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_RemapRange,id:2661,x:30622,y:34007,varname:node_2661,prsc:2,frmn:0,frmx:1,tomn:1,tomx:11|IN-2235-OUT;n:type:ShaderForge.SFN_Set,id:5979,x:31517,y:33843,varname:specularColor,prsc:2|IN-8273-OUT;n:type:ShaderForge.SFN_Get,id:4987,x:31552,y:33314,varname:node_4987,prsc:2|IN-5979-OUT;n:type:ShaderForge.SFN_Add,id:372,x:31761,y:33174,varname:node_372,prsc:2|A-9815-OUT,B-4987-OUT;n:type:ShaderForge.SFN_NormalVector,id:1867,x:30464,y:31915,prsc:2,pt:False;n:type:ShaderForge.SFN_ViewVector,id:2610,x:30464,y:32061,varname:node_2610,prsc:2;n:type:ShaderForge.SFN_Dot,id:8514,x:30648,y:31915,varname:node_8514,prsc:2,dt:0|A-1867-OUT,B-2610-OUT;n:type:ShaderForge.SFN_Multiply,id:4354,x:30830,y:31915,varname:node_4354,prsc:2|A-8514-OUT,B-9653-OUT;n:type:ShaderForge.SFN_Add,id:2929,x:31025,y:31915,varname:node_2929,prsc:2|A-4354-OUT,B-6888-OUT;n:type:ShaderForge.SFN_Append,id:9151,x:31410,y:31915,varname:node_9151,prsc:2|A-4657-OUT,B-4121-OUT;n:type:ShaderForge.SFN_Tex2d,id:9226,x:31603,y:31915,ptovrint:False,ptlb:RimSampler,ptin:_RimSampler,varname:node_9226,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-9151-OUT;n:type:ShaderForge.SFN_Vector1,id:6888,x:30830,y:32072,varname:node_6888,prsc:2,v1:1;n:type:ShaderForge.SFN_Get,id:4950,x:31025,y:32072,varname:node_4950,prsc:2|IN-784-OUT;n:type:ShaderForge.SFN_Vector1,id:9653,x:30648,y:32072,varname:node_9653,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:4657,x:31220,y:31915,varname:node_4657,prsc:2|A-2929-OUT,B-4950-OUT;n:type:ShaderForge.SFN_Vector1,id:4121,x:31220,y:32072,varname:node_4121,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Color,id:9546,x:31603,y:32100,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:node_9546,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:6099,x:31813,y:31915,varname:node_6099,prsc:2|A-9226-RGB,B-9546-RGB;n:type:ShaderForge.SFN_Set,id:6980,x:31996,y:31915,varname:rimColor,prsc:2|IN-6099-OUT;n:type:ShaderForge.SFN_Get,id:6005,x:32519,y:32811,varname:node_6005,prsc:2|IN-6980-OUT;n:type:ShaderForge.SFN_Multiply,id:8273,x:31355,y:33843,varname:node_8273,prsc:2|A-8426-OUT,B-6772-RGB;n:type:ShaderForge.SFN_Tex2d,id:6772,x:31095,y:34048,ptovrint:False,ptlb:specularMask,ptin:_specularMask,varname:node_6772,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9815,x:31364,y:33171,varname:node_9815,prsc:2|A-1667-RGB,B-8547-OUT,C-8032-RGB;n:type:ShaderForge.SFN_Tex2d,id:7235,x:32210,y:32956,ptovrint:False,ptlb:CutoutTexture,ptin:_CutoutTexture,varname:node_7235,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:1715,x:32382,y:32973,varname:node_1715,prsc:2|IN-7235-R;n:type:ShaderForge.SFN_Tex2d,id:5103,x:32519,y:32623,ptovrint:False,ptlb:NormalMap,ptin:_NormalMap,varname:node_5103,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Lerp,id:8547,x:31121,y:33192,varname:node_8547,prsc:2|A-3146-OUT,B-8741-RGB,T-8741-A;n:type:ShaderForge.SFN_Clamp01,id:8426,x:31157,y:33843,varname:node_8426,prsc:2|IN-4412-OUT;proporder:1667-8741-5817-1739-6186-8956-8032-2141-2977-3177-4044-9226-9546-6772-2235-9232-9294-7235-5103;pass:END;sub:END;*/

Shader "Psyren/CharacterShader" {
    Properties {
        _Tint ("Tint", Color) = (1,1,1,1)
        _Texture ("Texture", 2D) = "black" {}
        _Mask ("Mask", 2D) = "white" {}
        _RedColor ("RedColor", Color) = (1,0,0,1)
        _GreenColor ("GreenColor", Color) = (0,1,0,1)
        _BlueColor ("BlueColor", Color) = (0,0,1,1)
        _falloffSampler ("falloffSampler", 2D) = "white" {}
        _shadowColor ("shadowColor", Color) = (0.9333333,0.9254902,1,1)
        _OutlineWidth ("OutlineWidth", Range(0, 0.01)) = 0.001
        _OutlineDistancePower ("OutlineDistancePower", Range(0, 1)) = 0.84
        _OutlineColor ("OutlineColor", Color) = (0,0,0,1)
        _RimSampler ("RimSampler", 2D) = "black" {}
        _RimColor ("RimColor", Color) = (0,0,0,1)
        _specularMask ("specularMask", 2D) = "white" {}
        _Gloss ("Gloss", Range(0, 11)) = 11
        _SpecularColor ("SpecularColor", Color) = (0,0,0,1)
        _Specularity ("Specularity", Range(0, 4)) = 0
        _CutoutTexture ("CutoutTexture", 2D) = "black" {}
        _NormalMap ("NormalMap", 2D) = "bump" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            float3 getWorldSpaceCameraPos(){
            return _WorldSpaceCameraPos;
            }
            
            uniform float _OutlineDistancePower;
            uniform float _OutlineWidth;
            uniform float4 _OutlineColor;
            uniform sampler2D _CutoutTexture; uniform float4 _CutoutTexture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float outlineWidth = (_OutlineWidth*pow(distance(mul(unity_ObjectToWorld, v.vertex).rgb,getWorldSpaceCameraPos()),_OutlineDistancePower));
                o.pos = UnityObjectToClipPos(float4(v.vertex.xyz + v.normal*outlineWidth,1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _CutoutTexture_var = tex2D(_CutoutTexture,TRANSFORM_TEX(i.uv0, _CutoutTexture));
                clip((1.0 - _CutoutTexture_var.r) - 0.5);
                return fixed4(_OutlineColor.rgb,0);
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _shadowColor;
            uniform float4 _Tint;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float4 _RedColor;
            uniform float4 _GreenColor;
            uniform float4 _BlueColor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _falloffSampler; uniform float4 _falloffSampler_ST;
            uniform float _Gloss;
            uniform float4 _SpecularColor;
            uniform float _Specularity;
            uniform sampler2D _RimSampler; uniform float4 _RimSampler_ST;
            uniform float4 _RimColor;
            uniform sampler2D _specularMask; uniform float4 _specularMask_ST;
            uniform sampler2D _CutoutTexture; uniform float4 _CutoutTexture_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
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
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _NormalMap_var = tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _CutoutTexture_var = tex2D(_CutoutTexture,TRANSFORM_TEX(i.uv0, _CutoutTexture));
                clip((1.0 - _CutoutTexture_var.r) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float falloffU = clamp((1.0 - dot(i.normalDir,viewDirection)),0.02,0.98);
                float2 node_9151 = float2((((dot(i.normalDir,viewDirection)*0.5)+1.0)*falloffU),0.25);
                float4 _RimSampler_var = tex2D(_RimSampler,TRANSFORM_TEX(node_9151, _RimSampler));
                float3 rimColor = (_RimSampler_var.rgb*_RimColor.rgb);
                float3 emissive = rimColor;
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 maskColor = ((_Mask_var.r*_RedColor.rgb)+(_Mask_var.g*_GreenColor.rgb)+(_Mask_var.b*_BlueColor.rgb));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float2 node_5584 = float2(falloffU,0.25);
                float4 _falloffSampler_var = tex2D(_falloffSampler,TRANSFORM_TEX(node_5584, _falloffSampler));
                float4 _specularMask_var = tex2D(_specularMask,TRANSFORM_TEX(i.uv0, _specularMask));
                float3 specularColor = (saturate((pow(dot(halfDirection,i.normalDir),(_Gloss*10.0+1.0))*_SpecularColor.rgb*_Specularity))*_specularMask_var.rgb);
                float3 combinedColor = ((_Tint.rgb*lerp(maskColor,_Texture_var.rgb,_Texture_var.a)*_falloffSampler_var.rgb)+specularColor);
                float3 node_2138 = combinedColor;
                float3 customLight = lerp((_shadowColor.rgb*node_2138),node_2138,saturate(((attenuation*2.0)-1.0)));
                float3 finalColor = emissive + customLight;
                return fixed4(finalColor,1);
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _shadowColor;
            uniform float4 _Tint;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float4 _RedColor;
            uniform float4 _GreenColor;
            uniform float4 _BlueColor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _falloffSampler; uniform float4 _falloffSampler_ST;
            uniform float _Gloss;
            uniform float4 _SpecularColor;
            uniform float _Specularity;
            uniform sampler2D _RimSampler; uniform float4 _RimSampler_ST;
            uniform float4 _RimColor;
            uniform sampler2D _specularMask; uniform float4 _specularMask_ST;
            uniform sampler2D _CutoutTexture; uniform float4 _CutoutTexture_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
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
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _NormalMap_var = tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _CutoutTexture_var = tex2D(_CutoutTexture,TRANSFORM_TEX(i.uv0, _CutoutTexture));
                clip((1.0 - _CutoutTexture_var.r) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 maskColor = ((_Mask_var.r*_RedColor.rgb)+(_Mask_var.g*_GreenColor.rgb)+(_Mask_var.b*_BlueColor.rgb));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float falloffU = clamp((1.0 - dot(i.normalDir,viewDirection)),0.02,0.98);
                float2 node_5584 = float2(falloffU,0.25);
                float4 _falloffSampler_var = tex2D(_falloffSampler,TRANSFORM_TEX(node_5584, _falloffSampler));
                float4 _specularMask_var = tex2D(_specularMask,TRANSFORM_TEX(i.uv0, _specularMask));
                float3 specularColor = (saturate((pow(dot(halfDirection,i.normalDir),(_Gloss*10.0+1.0))*_SpecularColor.rgb*_Specularity))*_specularMask_var.rgb);
                float3 combinedColor = ((_Tint.rgb*lerp(maskColor,_Texture_var.rgb,_Texture_var.a)*_falloffSampler_var.rgb)+specularColor);
                float3 node_2138 = combinedColor;
                float3 customLight = lerp((_shadowColor.rgb*node_2138),node_2138,saturate(((attenuation*2.0)-1.0)));
                float3 finalColor = customLight;
                return fixed4(finalColor * 1,0);
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _CutoutTexture; uniform float4 _CutoutTexture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _CutoutTexture_var = tex2D(_CutoutTexture,TRANSFORM_TEX(i.uv0, _CutoutTexture));
                clip((1.0 - _CutoutTexture_var.r) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
