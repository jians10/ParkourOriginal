// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.10 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.10;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:3,bsrc:0,bdst:6,culm:2,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:1,fgcg:0.8038779,fgcb:0.6313726,fgca:1,fgde:2E-05,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:7004,x:34076,y:32650,varname:node_7004,prsc:2|emission-6394-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:1042,x:32293,y:32903,ptovrint:False,ptlb:smoke texture,ptin:_smoketexture,varname:_smoketexture,tex:1d1afc68a1939374ab308cdd52ba04c1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9176,x:33485,y:32825,varname:_node_9176,prsc:2,tex:1d1afc68a1939374ab308cdd52ba04c1,ntxv:0,isnm:False|UVIN-4399-OUT,TEX-1042-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:4852,x:32397,y:32641,ptovrint:False,ptlb:height ( alpha),ptin:_heightalpha,varname:_heightalpha,tex:6ae2e98a1f700ac4caee012e4f272396,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4682,x:32570,y:32566,varname:_node_4682,prsc:2,tex:6ae2e98a1f700ac4caee012e4f272396,ntxv:0,isnm:False|TEX-4852-TEX;n:type:ShaderForge.SFN_Add,id:7464,x:33008,y:32624,varname:node_7464,prsc:2|A-6750-R,B-5170-OUT,C-4770-OUT;n:type:ShaderForge.SFN_Append,id:4113,x:33144,y:32534,varname:node_4113,prsc:2|A-6750-G,B-7464-OUT;n:type:ShaderForge.SFN_Time,id:8560,x:33038,y:32864,varname:node_8560,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4770,x:33241,y:32854,varname:node_4770,prsc:2|A-8560-TSL,B-1249-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1249,x:33152,y:33068,ptovrint:False,ptlb:speed,ptin:_speed,varname:_speed,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Add,id:4399,x:33320,y:32594,varname:node_4399,prsc:2|A-4113-OUT,B-4770-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:1994,x:31887,y:32999,varname:node_1994,prsc:2;n:type:ShaderForge.SFN_Append,id:5413,x:32200,y:32518,varname:node_5413,prsc:2|A-1994-X,B-1994-Z;n:type:ShaderForge.SFN_Divide,id:34,x:32719,y:32365,varname:node_34,prsc:2|A-5413-OUT,B-5737-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5737,x:32357,y:32352,ptovrint:False,ptlb:tile,ptin:_tile,varname:_tile,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:6750,x:32931,y:32397,varname:node_6750,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-34-OUT;n:type:ShaderForge.SFN_Blend,id:5170,x:32766,y:32590,varname:node_5170,prsc:2,blmd:6,clmp:True|SRC-4682-A,DST-1038-R;n:type:ShaderForge.SFN_Tex2d,id:1038,x:32606,y:33008,varname:_node_8411,prsc:2,tex:1d1afc68a1939374ab308cdd52ba04c1,ntxv:0,isnm:False|UVIN-34-OUT,TEX-1042-TEX;n:type:ShaderForge.SFN_Multiply,id:6394,x:33707,y:32825,varname:node_6394,prsc:2|A-5592-RGB,B-9176-RGB;n:type:ShaderForge.SFN_Color,id:5592,x:33531,y:32625,ptovrint:False,ptlb:smoke color,ptin:_smokecolor,varname:_smokecolor,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:1042-4852-1249-5737-5592;pass:END;sub:END;*/

Shader "Almgp/Almgp_Lava_smoke" {
    Properties {
        _smoketexture ("smoke texture", 2D) = "white" {}
        _heightalpha ("height ( alpha)", 2D) = "bump" {}
        _speed ("speed", Float ) = 1
        _tile ("tile", Float ) = 1
        _smokecolor ("smoke color", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcColor
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _smoketexture; uniform float4 _smoketexture_ST;
            uniform sampler2D _heightalpha; uniform float4 _heightalpha_ST;
            uniform float _speed;
            uniform float _tile;
            uniform float4 _smokecolor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float2 node_34 = (float2(i.posWorld.r,i.posWorld.b)/_tile);
                float2 node_6750 = node_34.rg;
                float4 _node_4682 = tex2D(_heightalpha,TRANSFORM_TEX(i.uv0, _heightalpha));
                float4 _node_8411 = tex2D(_smoketexture,TRANSFORM_TEX(node_34, _smoketexture));
                float4 node_8560 = _Time + _TimeEditor;
                float node_4770 = (node_8560.r*_speed);
                float2 node_4399 = (float2(node_6750.g,(node_6750.r+saturate((1.0-(1.0-_node_4682.a)*(1.0-_node_8411.r)))+node_4770))+node_4770);
                float4 _node_9176 = tex2D(_smoketexture,TRANSFORM_TEX(node_4399, _smoketexture));
                float3 emissive = (_smokecolor.rgb*_node_9176.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
