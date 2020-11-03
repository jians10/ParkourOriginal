// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.10 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.10;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:0,nrsp:0,limd:3,spmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:1,fgcg:0.8038779,fgcb:0.6313726,fgca:1,fgde:2E-05,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3696,x:35476,y:33411,varname:node_3696,prsc:2|diff-7019-OUT,diffpow-7019-OUT,spec-5668-OUT,gloss-8908-OUT,normal-96-RGB,emission-762-OUT,amdfl-762-OUT,amspl-5079-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6697,x:33047,y:33993,ptovrint:False,ptlb:Normal map ,ptin:_Normalmap,varname:_Normalmap,tex:6ae2e98a1f700ac4caee012e4f272396,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2dAsset,id:6418,x:32427,y:33038,ptovrint:False,ptlb:Diffuse map,ptin:_Diffusemap,varname:_Diffusemap,tex:fd3d6d280525d2542a2ba61c2fdb724b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:5091,x:32406,y:33278,ptovrint:False,ptlb:Emission map,ptin:_Emissionmap,varname:_Emissionmap,tex:95b3f9eddc224a94fa7319f74a9c0787,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:96,x:34032,y:33294,varname:_node_96,prsc:2,tex:6ae2e98a1f700ac4caee012e4f272396,ntxv:0,isnm:False|UVIN-6343-OUT,TEX-6697-TEX;n:type:ShaderForge.SFN_Tex2d,id:6083,x:34943,y:33343,varname:_node_6083,prsc:2,tex:fd3d6d280525d2542a2ba61c2fdb724b,ntxv:0,isnm:False|UVIN-6343-OUT,TEX-6418-TEX;n:type:ShaderForge.SFN_Tex2d,id:7732,x:33040,y:33239,varname:_node_7732,prsc:2,tex:95b3f9eddc224a94fa7319f74a9c0787,ntxv:0,isnm:False|UVIN-6343-OUT,TEX-5091-TEX;n:type:ShaderForge.SFN_Slider,id:9346,x:32585,y:32642,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:_Specular,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:8908,x:32605,y:32519,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:3445,x:32974,y:32589,varname:node_3445,prsc:2|A-9346-OUT,B-7732-RGB;n:type:ShaderForge.SFN_Desaturate,id:5668,x:34922,y:33040,varname:node_5668,prsc:2|COL-3445-OUT,DES-2545-OUT;n:type:ShaderForge.SFN_Vector1,id:2545,x:33098,y:33602,varname:node_2545,prsc:2,v1:1;n:type:ShaderForge.SFN_FragmentPosition,id:3334,x:31982,y:33208,varname:node_3334,prsc:2;n:type:ShaderForge.SFN_Append,id:1691,x:33015,y:33825,varname:node_1691,prsc:2|A-3334-X,B-3334-Z;n:type:ShaderForge.SFN_ValueProperty,id:1855,x:32575,y:33215,ptovrint:False,ptlb:tiling,ptin:_tiling,varname:_tiling,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Vector1,id:5884,x:33297,y:33135,varname:node_5884,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:5079,x:34605,y:33205,varname:node_5079,prsc:2|A-5884-OUT,B-7732-RGB,T-5937-OUT;n:type:ShaderForge.SFN_Slider,id:5937,x:33095,y:32852,ptovrint:False,ptlb:emission power,ptin:_emissionpower,varname:_emissionpower,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:4434,x:32602,y:32947,varname:node_4434,prsc:2,v1:0.15;n:type:ShaderForge.SFN_Vector1,id:2368,x:32634,y:32900,varname:node_2368,prsc:2,v1:0;n:type:ShaderForge.SFN_Fresnel,id:6932,x:33537,y:33229,varname:node_6932,prsc:2|NRM-166-OUT,EXP-8795-OUT;n:type:ShaderForge.SFN_NormalVector,id:166,x:33260,y:33239,prsc:2,pt:True;n:type:ShaderForge.SFN_Slider,id:8795,x:33157,y:33442,ptovrint:False,ptlb:exponent,ptin:_exponent,varname:_exponent,prsc:2,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Add,id:762,x:35091,y:33547,varname:node_762,prsc:2|A-5079-OUT,B-8137-OUT,C-600-OUT;n:type:ShaderForge.SFN_Multiply,id:8137,x:34605,y:33445,varname:node_8137,prsc:2|A-6932-OUT,B-1200-RGB;n:type:ShaderForge.SFN_Color,id:1200,x:33948,y:32835,ptovrint:False,ptlb:heat color,ptin:_heatcolor,varname:_heatcolor,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:600,x:34828,y:33533,varname:node_600,prsc:2|A-6331-OUT,B-7588-OUT,T-6819-OUT;n:type:ShaderForge.SFN_Desaturate,id:6819,x:34072,y:33575,varname:node_6819,prsc:2|COL-7732-RGB,DES-2545-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:1639,x:35052,y:34061,ptovrint:False,ptlb:lava_ flowed,ptin:_lava_flowed,varname:_lava_flowed,tex:43b8c4171331be34db46a853d2a237fe,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Divide,id:3503,x:33223,y:33757,varname:node_3503,prsc:2|A-1691-OUT,B-1855-OUT;n:type:ShaderForge.SFN_Vector1,id:6331,x:34337,y:33730,varname:node_6331,prsc:2,v1:0;n:type:ShaderForge.SFN_Time,id:8324,x:33460,y:33917,varname:node_8324,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8863,x:33757,y:34019,varname:node_8863,prsc:2|A-8324-TSL,B-5991-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5991,x:33456,y:34095,ptovrint:False,ptlb:speed,ptin:_speed,varname:_speed,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:3203,x:35634,y:34003,varname:_node_3203,prsc:2,tex:43b8c4171331be34db46a853d2a237fe,ntxv:0,isnm:False|UVIN-3323-OUT,TEX-1639-TEX;n:type:ShaderForge.SFN_Add,id:4627,x:34276,y:33795,varname:node_4627,prsc:2|A-3503-OUT,B-8863-OUT;n:type:ShaderForge.SFN_Add,id:7019,x:35219,y:33294,varname:node_7019,prsc:2|A-6083-RGB,B-600-OUT;n:type:ShaderForge.SFN_Divide,id:9280,x:34523,y:33730,varname:node_9280,prsc:2|A-4627-OUT,B-8169-OUT;n:type:ShaderForge.SFN_E,id:8169,x:33813,y:34196,varname:node_8169,prsc:2;n:type:ShaderForge.SFN_Divide,id:7304,x:34066,y:34018,varname:node_7304,prsc:2|A-8863-OUT,B-8169-OUT;n:type:ShaderForge.SFN_Add,id:5881,x:34711,y:33963,varname:node_5881,prsc:2|A-9280-OUT,B-7304-OUT;n:type:ShaderForge.SFN_Add,id:6343,x:33898,y:33750,varname:node_6343,prsc:2|A-3503-OUT,B-7304-OUT;n:type:ShaderForge.SFN_Tex2d,id:4525,x:34145,y:34498,varname:_node_6911,prsc:2,tex:6ae2e98a1f700ac4caee012e4f272396,ntxv:0,isnm:False|UVIN-6343-OUT,TEX-7506-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7506,x:33066,y:34306,ptovrint:False,ptlb:Height ( alpha),ptin:_Heightalpha,varname:_Heightalpha,tex:6ae2e98a1f700ac4caee012e4f272396,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Time,id:7134,x:34971,y:34385,varname:node_7134,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9107,x:35294,y:34411,varname:node_9107,prsc:2|A-7134-T,B-6734-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6734,x:35184,y:34559,ptovrint:False,ptlb:flow speed,ptin:_flowspeed,varname:_flowspeed,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Vector1,id:8848,x:35470,y:34481,varname:node_8848,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:2856,x:35559,y:34803,varname:node_2856,prsc:2|A-9107-OUT,B-8848-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4363,x:34451,y:34525,varname:node_4363,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4525-RGB;n:type:ShaderForge.SFN_RemapRange,id:9827,x:34925,y:34838,varname:node_9827,prsc:2,frmn:0,frmx:1,tomn:-0.5,tomx:0.5|IN-4363-OUT;n:type:ShaderForge.SFN_Multiply,id:1840,x:35253,y:34917,varname:node_1840,prsc:2|A-9827-OUT,B-8043-OUT;n:type:ShaderForge.SFN_Vector1,id:1726,x:34716,y:34600,varname:node_1726,prsc:2,v1:-1;n:type:ShaderForge.SFN_Multiply,id:8043,x:34848,y:34556,varname:node_8043,prsc:2|A-9463-OUT,B-1726-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9463,x:34675,y:34525,ptovrint:False,ptlb:flow power,ptin:_flowpower,varname:_flowpower,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Frac,id:7431,x:35583,y:34545,varname:node_7431,prsc:2|IN-9107-OUT;n:type:ShaderForge.SFN_Frac,id:9936,x:35763,y:34728,varname:node_9936,prsc:2|IN-2856-OUT;n:type:ShaderForge.SFN_Multiply,id:3237,x:35932,y:34503,varname:node_3237,prsc:2|A-1840-OUT,B-9936-OUT;n:type:ShaderForge.SFN_Multiply,id:879,x:35922,y:34303,varname:node_879,prsc:2|A-1840-OUT,B-7431-OUT;n:type:ShaderForge.SFN_Subtract,id:8988,x:35902,y:34728,varname:node_8988,prsc:2|A-7431-OUT,B-5613-OUT;n:type:ShaderForge.SFN_Vector1,id:5613,x:35709,y:34909,varname:node_5613,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Divide,id:7899,x:35967,y:34974,varname:node_7899,prsc:2|A-8988-OUT,B-5613-OUT;n:type:ShaderForge.SFN_Abs,id:2033,x:36092,y:34743,varname:node_2033,prsc:2|IN-7899-OUT;n:type:ShaderForge.SFN_Add,id:3323,x:36200,y:34327,varname:node_3323,prsc:2|A-879-OUT,B-5881-OUT;n:type:ShaderForge.SFN_Add,id:4454,x:36212,y:34522,varname:node_4454,prsc:2|A-3237-OUT,B-5881-OUT;n:type:ShaderForge.SFN_Tex2d,id:8778,x:35634,y:34192,varname:_node_5816,prsc:2,tex:43b8c4171331be34db46a853d2a237fe,ntxv:0,isnm:False|UVIN-4454-OUT,TEX-1639-TEX;n:type:ShaderForge.SFN_Lerp,id:7588,x:35903,y:34057,varname:node_7588,prsc:2|A-3203-RGB,B-8778-RGB,T-2033-OUT;proporder:6697-6418-5091-9346-8908-1855-5937-8795-1200-1639-5991-7506-6734-9463;pass:END;sub:END;*/

Shader "Almgp/Almgp_Lava" {
    Properties {
        _Normalmap ("Normal map ", 2D) = "bump" {}
        _Diffusemap ("Diffuse map", 2D) = "white" {}
        _Emissionmap ("Emission map", 2D) = "white" {}
        _Specular ("Specular", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0
        _tiling ("tiling", Float ) = 1
        _emissionpower ("emission power", Range(0, 1)) = 0
        _exponent ("exponent", Range(0, 5)) = 0
        _heatcolor ("heat color", Color) = (0.5,0.5,0.5,1)
        _lava_flowed ("lava_ flowed", 2D) = "white" {}
        _speed ("speed", Float ) = 0
        _Heightalpha ("Height ( alpha)", 2D) = "gray" {}
        _flowspeed ("flow speed", Float ) = 1
        _flowpower ("flow power", Float ) = 0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform sampler2D _Diffusemap; uniform float4 _Diffusemap_ST;
            uniform sampler2D _Emissionmap; uniform float4 _Emissionmap_ST;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float _tiling;
            uniform float _emissionpower;
            uniform float _exponent;
            uniform float4 _heatcolor;
            uniform sampler2D _lava_flowed; uniform float4 _lava_flowed_ST;
            uniform float _speed;
            uniform sampler2D _Heightalpha; uniform float4 _Heightalpha_ST;
            uniform float _flowspeed;
            uniform float _flowpower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float2 node_3503 = (float2(i.posWorld.r,i.posWorld.b)/_tiling);
                float4 node_8324 = _Time + _TimeEditor;
                float node_8863 = (node_8324.r*_speed);
                float node_8169 = 2.718281828459;
                float node_7304 = (node_8863/node_8169);
                float2 node_6343 = (node_3503+node_7304);
                float3 _node_96 = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(node_6343, _Normalmap)));
                float3 normalLocal = _node_96.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_5884 = 0.0;
                float4 _node_7732 = tex2D(_Emissionmap,TRANSFORM_TEX(node_6343, _Emissionmap));
                float3 node_5079 = lerp(float3(node_5884,node_5884,node_5884),_node_7732.rgb,_emissionpower);
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float node_2545 = 1.0;
                float3 specularColor = lerp((_Specular*_node_7732.rgb),dot((_Specular*_node_7732.rgb),float3(0.3,0.59,0.11)),node_2545);
                float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (0 + node_5079);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_6331 = 0.0;
                float4 _node_6911 = tex2D(_Heightalpha,TRANSFORM_TEX(node_6343, _Heightalpha));
                float2 node_1840 = ((_node_6911.rgb.rg*1.0+-0.5)*(_flowpower*(-1.0)));
                float4 node_7134 = _Time + _TimeEditor;
                float node_9107 = (node_7134.g*_flowspeed);
                float node_7431 = frac(node_9107);
                float2 node_4627 = (node_3503+node_8863);
                float2 node_9280 = (node_4627/node_8169);
                float2 node_5881 = (node_9280+node_7304);
                float2 node_3323 = ((node_1840*node_7431)+node_5881);
                float4 _node_3203 = tex2D(_lava_flowed,TRANSFORM_TEX(node_3323, _lava_flowed));
                float2 node_4454 = ((node_1840*frac((node_9107+0.5)))+node_5881);
                float4 _node_5816 = tex2D(_lava_flowed,TRANSFORM_TEX(node_4454, _lava_flowed));
                float node_5613 = 0.5;
                float3 node_600 = lerp(float3(node_6331,node_6331,node_6331),lerp(_node_3203.rgb,_node_5816.rgb,abs(((node_7431-node_5613)/node_5613))),lerp(_node_7732.rgb,dot(_node_7732.rgb,float3(0.3,0.59,0.11)),node_2545));
                float3 node_762 = (node_5079+(pow(1.0-max(0,dot(normalDirection, viewDirection)),_exponent)*_heatcolor.rgb)+node_600);
                indirectDiffuse += node_762; // Diffuse Ambient Light
                float4 _node_6083 = tex2D(_Diffusemap,TRANSFORM_TEX(node_6343, _Diffusemap));
                float3 node_7019 = (_node_6083.rgb+node_600);
                float3 diffuseColor = node_7019;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_762;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform sampler2D _Diffusemap; uniform float4 _Diffusemap_ST;
            uniform sampler2D _Emissionmap; uniform float4 _Emissionmap_ST;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float _tiling;
            uniform float _emissionpower;
            uniform float _exponent;
            uniform float4 _heatcolor;
            uniform sampler2D _lava_flowed; uniform float4 _lava_flowed_ST;
            uniform float _speed;
            uniform sampler2D _Heightalpha; uniform float4 _Heightalpha_ST;
            uniform float _flowspeed;
            uniform float _flowpower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float2 node_3503 = (float2(i.posWorld.r,i.posWorld.b)/_tiling);
                float4 node_8324 = _Time + _TimeEditor;
                float node_8863 = (node_8324.r*_speed);
                float node_8169 = 2.718281828459;
                float node_7304 = (node_8863/node_8169);
                float2 node_6343 = (node_3503+node_7304);
                float3 _node_96 = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(node_6343, _Normalmap)));
                float3 normalLocal = _node_96.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _node_7732 = tex2D(_Emissionmap,TRANSFORM_TEX(node_6343, _Emissionmap));
                float node_2545 = 1.0;
                float3 specularColor = lerp((_Specular*_node_7732.rgb),dot((_Specular*_node_7732.rgb),float3(0.3,0.59,0.11)),node_2545);
                float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float4 _node_6083 = tex2D(_Diffusemap,TRANSFORM_TEX(node_6343, _Diffusemap));
                float node_6331 = 0.0;
                float4 _node_6911 = tex2D(_Heightalpha,TRANSFORM_TEX(node_6343, _Heightalpha));
                float2 node_1840 = ((_node_6911.rgb.rg*1.0+-0.5)*(_flowpower*(-1.0)));
                float4 node_7134 = _Time + _TimeEditor;
                float node_9107 = (node_7134.g*_flowspeed);
                float node_7431 = frac(node_9107);
                float2 node_4627 = (node_3503+node_8863);
                float2 node_9280 = (node_4627/node_8169);
                float2 node_5881 = (node_9280+node_7304);
                float2 node_3323 = ((node_1840*node_7431)+node_5881);
                float4 _node_3203 = tex2D(_lava_flowed,TRANSFORM_TEX(node_3323, _lava_flowed));
                float2 node_4454 = ((node_1840*frac((node_9107+0.5)))+node_5881);
                float4 _node_5816 = tex2D(_lava_flowed,TRANSFORM_TEX(node_4454, _lava_flowed));
                float node_5613 = 0.5;
                float3 node_600 = lerp(float3(node_6331,node_6331,node_6331),lerp(_node_3203.rgb,_node_5816.rgb,abs(((node_7431-node_5613)/node_5613))),lerp(_node_7732.rgb,dot(_node_7732.rgb,float3(0.3,0.59,0.11)),node_2545));
                float3 node_7019 = (_node_6083.rgb+node_600);
                float3 diffuseColor = node_7019;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
