// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:707,x:32361,y:32585,varname:node_707,prsc:2|emission-4449-OUT,custl-7011-OUT;n:type:ShaderForge.SFN_Color,id:2993,x:30722,y:33124,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2464,x:30722,y:33298,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_2464,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1689,x:30917,y:33124,varname:node_1689,prsc:2|A-2993-RGB,B-2464-RGB;n:type:ShaderForge.SFN_AmbientLight,id:831,x:31830,y:32003,varname:node_831,prsc:2;n:type:ShaderForge.SFN_Multiply,id:627,x:32044,y:32003,varname:node_627,prsc:2|A-831-RGB,B-2290-OUT;n:type:ShaderForge.SFN_Multiply,id:1423,x:29803,y:32406,varname:node_1423,prsc:2|A-3024-OUT,B-3611-OUT;n:type:ShaderForge.SFN_Add,id:2554,x:29998,y:32406,varname:node_2554,prsc:2|A-1423-OUT,B-4758-OUT;n:type:ShaderForge.SFN_Multiply,id:8728,x:30214,y:32406,varname:node_8728,prsc:2|A-2554-OUT,B-5958-RGB,C-3065-OUT;n:type:ShaderForge.SFN_LightColor,id:5958,x:29998,y:32536,varname:node_5958,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:4424,x:29872,y:32814,varname:node_4424,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:3217,x:29312,y:32581,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:3178,x:29312,y:32729,varname:node_3178,prsc:2;n:type:ShaderForge.SFN_Dot,id:901,x:29493,y:32641,varname:node_901,prsc:2,dt:1|A-3217-OUT,B-3178-OUT;n:type:ShaderForge.SFN_Dot,id:9611,x:29493,y:32788,varname:node_9611,prsc:2,dt:1|A-3178-OUT,B-8641-OUT;n:type:ShaderForge.SFN_Power,id:5970,x:31183,y:34177,varname:node_5970,prsc:2|VAL-6280-OUT,EXP-8278-OUT;n:type:ShaderForge.SFN_Exp,id:8278,x:30976,y:34394,varname:node_8278,prsc:2,et:1|IN-3153-OUT;n:type:ShaderForge.SFN_RemapRange,id:3153,x:30795,y:34394,varname:node_3153,prsc:2,frmn:0,frmx:1,tomn:1,tomx:11|IN-7156-OUT;n:type:ShaderForge.SFN_Slider,id:7156,x:30437,y:34394,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_7156,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4687,x:31400,y:34177,varname:node_4687,prsc:2|A-5970-OUT,B-9364-RGB,C-6212-OUT;n:type:ShaderForge.SFN_Color,id:9364,x:31183,y:34346,ptovrint:False,ptlb:SpecularColor,ptin:_SpecularColor,varname:node_9364,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Set,id:388,x:31573,y:34177,varname:specularColor,prsc:2|IN-4687-OUT;n:type:ShaderForge.SFN_Get,id:4758,x:29782,y:32536,varname:node_4758,prsc:2|IN-388-OUT;n:type:ShaderForge.SFN_Set,id:5304,x:29693,y:32641,varname:normalLightDir,prsc:2|IN-901-OUT;n:type:ShaderForge.SFN_Set,id:6154,x:29693,y:32788,varname:lightViewDir,prsc:2|IN-9611-OUT;n:type:ShaderForge.SFN_Get,id:6280,x:30974,y:34177,varname:node_6280,prsc:2|IN-6154-OUT;n:type:ShaderForge.SFN_Get,id:3611,x:29584,y:32452,varname:node_3611,prsc:2|IN-5304-OUT;n:type:ShaderForge.SFN_Set,id:5622,x:32224,y:32003,varname:emission,prsc:2|IN-627-OUT;n:type:ShaderForge.SFN_Get,id:4449,x:32141,y:32685,varname:node_4449,prsc:2|IN-5622-OUT;n:type:ShaderForge.SFN_Set,id:2072,x:30819,y:32387,varname:customLight,prsc:2|IN-1966-OUT;n:type:ShaderForge.SFN_Get,id:7011,x:32141,y:32826,varname:node_7011,prsc:2|IN-2072-OUT;n:type:ShaderForge.SFN_Set,id:4241,x:31090,y:33124,varname:combinedColor,prsc:2|IN-1689-OUT;n:type:ShaderForge.SFN_Get,id:2290,x:31830,y:32132,varname:node_2290,prsc:2|IN-4241-OUT;n:type:ShaderForge.SFN_Get,id:3024,x:29584,y:32406,varname:node_3024,prsc:2|IN-4241-OUT;n:type:ShaderForge.SFN_Vector1,id:3065,x:29998,y:32668,varname:node_3065,prsc:2,v1:1;n:type:ShaderForge.SFN_HalfVector,id:8641,x:29312,y:32850,varname:node_8641,prsc:2;n:type:ShaderForge.SFN_Slider,id:6212,x:31026,y:34579,ptovrint:False,ptlb:Sepcularity,ptin:_Sepcularity,varname:node_6212,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_Color,id:3350,x:30214,y:32248,ptovrint:False,ptlb:ShadowCololr,ptin:_ShadowCololr,varname:node_3350,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:4754,x:30411,y:32248,varname:node_4754,prsc:2|A-3350-RGB,B-8728-OUT;n:type:ShaderForge.SFN_Lerp,id:1966,x:30628,y:32387,varname:node_1966,prsc:2|A-4754-OUT,B-8728-OUT,T-1724-OUT;n:type:ShaderForge.SFN_Multiply,id:1432,x:30056,y:32814,varname:node_1432,prsc:2|A-4424-OUT,B-5834-OUT;n:type:ShaderForge.SFN_Subtract,id:6670,x:30235,y:32814,varname:node_6670,prsc:2|A-1432-OUT,B-157-OUT;n:type:ShaderForge.SFN_Clamp01,id:1724,x:30410,y:32814,varname:node_1724,prsc:2|IN-6670-OUT;n:type:ShaderForge.SFN_Vector1,id:5834,x:29872,y:32935,varname:node_5834,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:157,x:30056,y:32935,varname:node_157,prsc:2,v1:1;proporder:2993-2464-7156-9364-6212-3350;pass:END;sub:END;*/

Shader "Psyren/WorldShader" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Texture ("Texture", 2D) = "white" {}
        _Gloss ("Gloss", Range(0, 1)) = 0
        _SpecularColor ("SpecularColor", Color) = (1,1,1,1)
        _Sepcularity ("Sepcularity", Range(0, 4)) = 0
        _ShadowCololr ("ShadowCololr", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
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
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _Gloss;
            uniform float4 _SpecularColor;
            uniform float _Sepcularity;
            uniform float4 _ShadowCololr;
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
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
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
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 combinedColor = (_Color.rgb*_Texture_var.rgb);
                float3 emission = (UNITY_LIGHTMODEL_AMBIENT.rgb*combinedColor);
                float3 emissive = emission;
                float normalLightDir = max(0,dot(i.normalDir,lightDirection));
                float lightViewDir = max(0,dot(lightDirection,halfDirection));
                float3 specularColor = (pow(lightViewDir,exp2((_Gloss*10.0+1.0)))*_SpecularColor.rgb*_Sepcularity);
                float3 node_8728 = (((combinedColor*normalLightDir)+specularColor)*_LightColor0.rgb*1.0);
                float3 customLight = lerp((_ShadowCololr.rgb*node_8728),node_8728,saturate(((attenuation*2.0)-1.0)));
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
            uniform float _Gloss;
            uniform float4 _SpecularColor;
            uniform float _Sepcularity;
            uniform float4 _ShadowCololr;
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
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
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
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 combinedColor = (_Color.rgb*_Texture_var.rgb);
                float normalLightDir = max(0,dot(i.normalDir,lightDirection));
                float lightViewDir = max(0,dot(lightDirection,halfDirection));
                float3 specularColor = (pow(lightViewDir,exp2((_Gloss*10.0+1.0)))*_SpecularColor.rgb*_Sepcularity);
                float3 node_8728 = (((combinedColor*normalLightDir)+specularColor)*_LightColor0.rgb*1.0);
                float3 customLight = lerp((_ShadowCololr.rgb*node_8728),node_8728,saturate(((attenuation*2.0)-1.0)));
                float3 finalColor = customLight;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
