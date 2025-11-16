// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:7594,x:32719,y:32712,varname:node_7594,prsc:2|emission-9974-OUT,alpha-3137-OUT;n:type:ShaderForge.SFN_Tex2d,id:6567,x:30285,y:32801,ptovrint:False,ptlb:NoiseTexture,ptin:_NoiseTexture,varname:node_6567,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-859-UVOUT;n:type:ShaderForge.SFN_Color,id:6493,x:31350,y:32580,ptovrint:False,ptlb:WhiteColor,ptin:_WhiteColor,varname:node_6493,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:2270,x:30615,y:32414,ptovrint:False,ptlb:WhiteColorRange,ptin:_WhiteColorRange,varname:node_2270,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5162089,max:1;n:type:ShaderForge.SFN_Multiply,id:9974,x:31573,y:32781,varname:node_9974,prsc:2|A-6493-RGB,B-5482-OUT;n:type:ShaderForge.SFN_TexCoord,id:9723,x:29811,y:32675,varname:node_9723,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:4140,x:29244,y:32821,ptovrint:False,ptlb:uSpeed,ptin:_uSpeed,varname:node_4140,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:3094,x:29244,y:32906,ptovrint:False,ptlb:vSpeed,ptin:_vSpeed,varname:node_3094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Append,id:8432,x:29609,y:32820,varname:node_8432,prsc:2|A-4140-OUT,B-3094-OUT;n:type:ShaderForge.SFN_Multiply,id:6099,x:29811,y:32820,varname:node_6099,prsc:2|A-8432-OUT,B-6565-OUT;n:type:ShaderForge.SFN_Multiply,id:6565,x:29609,y:33010,varname:node_6565,prsc:2|A-9500-OUT,B-6918-T;n:type:ShaderForge.SFN_Slider,id:9500,x:29244,y:33012,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_9500,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Time,id:6918,x:29401,y:33094,varname:node_6918,prsc:2;n:type:ShaderForge.SFN_Panner,id:859,x:30086,y:32801,varname:node_859,prsc:2,spu:1,spv:1|UVIN-9723-UVOUT,DIST-6099-OUT;n:type:ShaderForge.SFN_Slider,id:6541,x:30285,y:31908,ptovrint:False,ptlb:whiteRangeVariation,ptin:_whiteRangeVariation,varname:node_6541,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.06,max:0.3;n:type:ShaderForge.SFN_Sin,id:2901,x:30216,y:32063,varname:node_2901,prsc:2|IN-5780-OUT;n:type:ShaderForge.SFN_Time,id:7514,x:29801,y:32045,varname:node_7514,prsc:2;n:type:ShaderForge.SFN_Multiply,id:388,x:30743,y:32041,varname:node_388,prsc:2|A-6541-OUT,B-4642-OUT;n:type:ShaderForge.SFN_Multiply,id:5780,x:29992,y:32063,varname:node_5780,prsc:2|A-7514-T,B-6574-OUT;n:type:ShaderForge.SFN_Vector1,id:6574,x:29801,y:32184,varname:node_6574,prsc:2,v1:7;n:type:ShaderForge.SFN_Add,id:6615,x:30968,y:32395,varname:node_6615,prsc:2|A-388-OUT,B-2270-OUT;n:type:ShaderForge.SFN_If,id:5482,x:31204,y:32798,varname:node_5482,prsc:2|A-6567-RGB,B-6615-OUT,GT-4877-OUT,EQ-4877-OUT,LT-8182-OUT;n:type:ShaderForge.SFN_Vector1,id:4877,x:30929,y:32906,varname:node_4877,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:8182,x:30929,y:32952,varname:node_8182,prsc:2,v1:1;n:type:ShaderForge.SFN_Sin,id:4944,x:30115,y:32200,varname:node_4944,prsc:2|IN-7514-TTR;n:type:ShaderForge.SFN_Add,id:4642,x:30462,y:32063,varname:node_4642,prsc:2|A-2901-OUT,B-4944-OUT;n:type:ShaderForge.SFN_Multiply,id:6790,x:31603,y:33295,varname:node_6790,prsc:2|A-9276-OUT,B-9849-OUT,C-4206-OUT;n:type:ShaderForge.SFN_Slider,id:9849,x:31230,y:33484,ptovrint:False,ptlb:blackVertexOffsetMultiplier,ptin:_blackVertexOffsetMultiplier,varname:node_9849,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_NormalVector,id:4206,x:31387,y:33559,prsc:2,pt:False;n:type:ShaderForge.SFN_Subtract,id:7406,x:30978,y:33295,varname:node_7406,prsc:2|A-6567-RGB,B-7372-OUT;n:type:ShaderForge.SFN_Slider,id:7372,x:30599,y:33424,ptovrint:False,ptlb:vertexOffsetLimiter,ptin:_vertexOffsetLimiter,varname:node_7372,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1378304,max:1;n:type:ShaderForge.SFN_OneMinus,id:1505,x:31159,y:33295,varname:node_1505,prsc:2|IN-7406-OUT;n:type:ShaderForge.SFN_OneMinus,id:9276,x:31367,y:33295,varname:node_9276,prsc:2|IN-1505-OUT;n:type:ShaderForge.SFN_Slider,id:3137,x:31964,y:33035,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:node_3137,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:6567-6493-2270-6541-4140-3094-9500-9849-7372-3137;pass:END;sub:END;*/

Shader "Psyren/Spells/FireballSphereShader" {
    Properties {
        _NoiseTexture ("NoiseTexture", 2D) = "white" {}
        _WhiteColor ("WhiteColor", Color) = (1,1,1,1)
        _WhiteColorRange ("WhiteColorRange", Range(0, 1)) = 0.5162089
        _whiteRangeVariation ("whiteRangeVariation", Range(0, 0.3)) = 0.06
        _uSpeed ("uSpeed", Range(0, 1)) = 0
        _vSpeed ("vSpeed", Range(0, 1)) = 0
        _speed ("speed", Range(0, 1)) = 1
        _blackVertexOffsetMultiplier ("blackVertexOffsetMultiplier", Range(0, 1)) = 1
        _vertexOffsetLimiter ("vertexOffsetLimiter", Range(0, 1)) = 0.1378304
        _Alpha ("Alpha", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
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
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _NoiseTexture; uniform float4 _NoiseTexture_ST;
            uniform float4 _WhiteColor;
            uniform float _WhiteColorRange;
            uniform float _uSpeed;
            uniform float _vSpeed;
            uniform float _speed;
            uniform float _whiteRangeVariation;
            uniform float _Alpha;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_6918 = _Time + _TimeEditor;
                float2 node_859 = (i.uv0+(float2(_uSpeed,_vSpeed)*(_speed*node_6918.g))*float2(1,1));
                float4 _NoiseTexture_var = tex2D(_NoiseTexture,TRANSFORM_TEX(node_859, _NoiseTexture));
                float4 node_7514 = _Time + _TimeEditor;
                float node_5482_if_leA = step(_NoiseTexture_var.rgb,((_whiteRangeVariation*(sin((node_7514.g*7.0))+sin(node_7514.a)))+_WhiteColorRange));
                float node_5482_if_leB = step(((_whiteRangeVariation*(sin((node_7514.g*7.0))+sin(node_7514.a)))+_WhiteColorRange),_NoiseTexture_var.rgb);
                float node_4877 = 0.0;
                float3 emissive = (_WhiteColor.rgb*lerp((node_5482_if_leA*1.0)+(node_5482_if_leB*node_4877),node_4877,node_5482_if_leA*node_5482_if_leB));
                float3 finalColor = emissive;
                return fixed4(finalColor,_Alpha);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
