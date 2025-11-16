// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:Standard,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:0,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1874,x:32821,y:32635,varname:node_1874,prsc:2|emission-520-OUT,custl-7015-OUT;n:type:ShaderForge.SFN_NormalVector,id:6138,x:30481,y:32826,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:564,x:30481,y:32972,varname:node_564,prsc:2;n:type:ShaderForge.SFN_HalfVector,id:602,x:30481,y:33097,varname:node_602,prsc:2;n:type:ShaderForge.SFN_Dot,id:5646,x:30716,y:32876,varname:node_5646,prsc:2,dt:1|A-6138-OUT,B-564-OUT;n:type:ShaderForge.SFN_Dot,id:721,x:30716,y:33008,varname:node_721,prsc:2,dt:1|A-564-OUT,B-602-OUT;n:type:ShaderForge.SFN_Set,id:7223,x:30884,y:32876,varname:normal_light,prsc:2|IN-5646-OUT;n:type:ShaderForge.SFN_Set,id:7484,x:30884,y:33008,varname:light_half,prsc:2|IN-721-OUT;n:type:ShaderForge.SFN_Get,id:6818,x:31030,y:32620,varname:node_6818,prsc:2|IN-7223-OUT;n:type:ShaderForge.SFN_Color,id:9120,x:30905,y:32001,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9120,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2632,x:31127,y:32001,varname:node_2632,prsc:2|A-9120-RGB,B-6774-RGB;n:type:ShaderForge.SFN_Tex2d,id:6774,x:30905,y:32176,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_6774,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Set,id:1500,x:31308,y:32001,varname:combinedColor,prsc:2|IN-2632-OUT;n:type:ShaderForge.SFN_Get,id:2628,x:31030,y:32571,varname:node_2628,prsc:2|IN-1500-OUT;n:type:ShaderForge.SFN_Multiply,id:7851,x:31232,y:32571,varname:node_7851,prsc:2|A-2628-OUT,B-6818-OUT;n:type:ShaderForge.SFN_Add,id:619,x:31450,y:32571,varname:node_619,prsc:2|A-7851-OUT,B-313-OUT;n:type:ShaderForge.SFN_LightColor,id:8694,x:31450,y:32702,varname:node_8694,prsc:2;n:type:ShaderForge.SFN_Vector1,id:4639,x:31450,y:32842,varname:node_4639,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:9472,x:31663,y:32571,varname:node_9472,prsc:2|A-619-OUT,B-8694-RGB,C-4639-OUT;n:type:ShaderForge.SFN_Color,id:2352,x:31663,y:32400,ptovrint:False,ptlb:ShadowColor,ptin:_ShadowColor,varname:node_2352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7034,x:31855,y:32400,varname:node_7034,prsc:2|A-2352-RGB,B-9472-OUT;n:type:ShaderForge.SFN_Lerp,id:2977,x:32043,y:32552,varname:node_2977,prsc:2|A-7034-OUT,B-9472-OUT,T-6748-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:1829,x:31242,y:32933,varname:node_1829,prsc:2;n:type:ShaderForge.SFN_Vector1,id:8567,x:31242,y:33055,varname:node_8567,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:8520,x:31425,y:32933,varname:node_8520,prsc:2|A-1829-OUT,B-8567-OUT;n:type:ShaderForge.SFN_Subtract,id:6816,x:31611,y:32933,varname:node_6816,prsc:2|A-8520-OUT,B-990-OUT;n:type:ShaderForge.SFN_Vector1,id:990,x:31425,y:33055,varname:node_990,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:6748,x:31784,y:32933,varname:node_6748,prsc:2|IN-6816-OUT;n:type:ShaderForge.SFN_Set,id:4692,x:32139,y:33484,varname:Specular,prsc:2|IN-5853-OUT;n:type:ShaderForge.SFN_Get,id:313,x:31211,y:32702,varname:node_313,prsc:2|IN-4692-OUT;n:type:ShaderForge.SFN_Set,id:6478,x:32225,y:32552,varname:customLight,prsc:2|IN-2977-OUT;n:type:ShaderForge.SFN_Get,id:7015,x:32623,y:32874,varname:node_7015,prsc:2|IN-6478-OUT;n:type:ShaderForge.SFN_AmbientLight,id:6548,x:31783,y:32006,varname:node_6548,prsc:2;n:type:ShaderForge.SFN_Get,id:357,x:31783,y:32127,varname:node_357,prsc:2|IN-1500-OUT;n:type:ShaderForge.SFN_Multiply,id:1853,x:31982,y:32006,varname:node_1853,prsc:2|A-6548-RGB,B-357-OUT;n:type:ShaderForge.SFN_Set,id:6676,x:32175,y:32006,varname:emission,prsc:2|IN-1853-OUT;n:type:ShaderForge.SFN_Get,id:520,x:32623,y:32733,varname:node_520,prsc:2|IN-6676-OUT;n:type:ShaderForge.SFN_Slider,id:986,x:30998,y:33639,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_986,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRange,id:8930,x:31338,y:33640,varname:node_8930,prsc:2,frmn:0,frmx:1,tomn:1,tomx:11|IN-986-OUT;n:type:ShaderForge.SFN_Exp,id:661,x:31522,y:33640,varname:node_661,prsc:2,et:1|IN-8930-OUT;n:type:ShaderForge.SFN_Get,id:1124,x:31522,y:33484,varname:node_1124,prsc:2|IN-7484-OUT;n:type:ShaderForge.SFN_Power,id:9504,x:31728,y:33484,varname:node_9504,prsc:2|VAL-1124-OUT,EXP-661-OUT;n:type:ShaderForge.SFN_Color,id:2063,x:31728,y:33640,ptovrint:False,ptlb:SpecularColor,ptin:_SpecularColor,varname:node_2063,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5853,x:31951,y:33484,varname:node_5853,prsc:2|A-9504-OUT,B-2063-RGB,C-1922-OUT;n:type:ShaderForge.SFN_Slider,id:1922,x:31581,y:33831,ptovrint:False,ptlb:Specularity,ptin:_Specularity,varname:node_1922,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;proporder:9120-6774-2352-986-2063-1922;pass:END;sub:END;*/

Shader "Psyren/WorldShaderSave" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Texture ("Texture", 2D) = "white" {}
        _ShadowColor ("ShadowColor", Color) = (0.5,0.5,0.5,1)
        _Gloss ("Gloss", Range(0, 1)) = 0
        _SpecularColor ("SpecularColor", Color) = (1,1,1,1)
        _Specularity ("Specularity", Range(0, 4)) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Background"
            "RenderType"="Opaque"
        }
        LOD 200
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _ShadowColor;
            uniform float _Gloss;
            uniform float4 _SpecularColor;
            uniform float _Specularity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
////// Emissive:
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 combinedColor = (_Color.rgb*_Texture_var.rgb);
                float3 emission = (UNITY_LIGHTMODEL_AMBIENT.rgb*combinedColor);
                float3 emissive = emission;
                float normal_light = max(0,dot(i.normalDir,lightDirection));
                float light_half = max(0,dot(lightDirection,halfDirection));
                float3 Specular = (pow(light_half,exp2((_Gloss*10.0+1.0)))*_SpecularColor.rgb*_Specularity);
                float3 node_9472 = (((combinedColor*normal_light)+Specular)*_LightColor0.rgb*1.0);
                float3 customLight = lerp((_ShadowColor.rgb*node_9472),node_9472,saturate(((attenuation*2.0)-1.0)));
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
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _ShadowColor;
            uniform float _Gloss;
            uniform float4 _SpecularColor;
            uniform float _Specularity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 combinedColor = (_Color.rgb*_Texture_var.rgb);
                float normal_light = max(0,dot(i.normalDir,lightDirection));
                float light_half = max(0,dot(lightDirection,halfDirection));
                float3 Specular = (pow(light_half,exp2((_Gloss*10.0+1.0)))*_SpecularColor.rgb*_Specularity);
                float3 node_9472 = (((combinedColor*normal_light)+Specular)*_LightColor0.rgb*1.0);
                float3 customLight = lerp((_ShadowColor.rgb*node_9472),node_9472,saturate(((attenuation*2.0)-1.0)));
                float3 finalColor = customLight;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "ShaderForgeMaterialInspector"
}
