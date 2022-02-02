Shader "Custom/GrassForCompute"
{
    Properties
    {
        [Toggle(FADE)] _TransparentBottom("Alpha at Bottom", Float) = 0
        _Fade("Fade Multiplier", Range(1,10)) = 6
    }

    CGINCLUDE
    #include "UnityCG.cginc" 
    #include "Lighting.cginc"
    #include "AutoLight.cginc"
    #pragma multi_compile _SHADOWS_SCREEN
    #pragma multi_compile_fwdbase_fullforwardshadows
    #pragma multi_compile_fog
    #pragma shader_feature FADE

    struct DrawVertex
    {
        float3 positionWS; 
        float2 uv;
        float3 diffuseColor;
    };

    struct DrawTriangle
    {
        float3 normalOS;
        DrawVertex vertices[3];
    };

    StructuredBuffer<DrawTriangle> _DrawTriangles;

    struct v2f
    {
        float4 pos : SV_POSITION; 
        float2 uv : TEXCOORD0;          
        float3 positionWS : TEXCOORD1;
        float3 normalWS : TEXCOORD2;   
        float3 diffuseColor : COLOR;
        LIGHTING_COORDS(3, 4)
        UNITY_FOG_COORDS(5)
    };

 
    float4 _TopTint;
    float4 _BottomTint;
    float _AmbientStrength;
    float _Fade;

    struct unityTransferVertexToFragmentSucksHack
    {
        float3 vertex : POSITION;
    };

    v2f vert(uint vertexID : SV_VertexID)
    {
        v2f output = (v2f)0;

        DrawTriangle tri = _DrawTriangles[vertexID / 3];
        DrawVertex input = tri.vertices[vertexID % 3];

        output.pos = UnityObjectToClipPos(input.positionWS);
        output.positionWS = input.positionWS;
        
        float3 faceNormal = tri.normalOS;
        output.normalWS = faceNormal;
        
        output.uv = input.uv;

        output.diffuseColor = input.diffuseColor;

        unityTransferVertexToFragmentSucksHack v;
        v.vertex = output.pos;

        TRANSFER_VERTEX_TO_FRAGMENT(output);
        UNITY_TRANSFER_FOG(output,  output.pos);

        return output;
    }


    
    
    ENDCG
    SubShader
    {
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha 
        Pass 
        {
            Tags
            {              
                "LightMode" = "ForwardBase"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag            
            
            float4 frag(v2f i) : SV_Target
            {
                float shadow = 1;
                //close shadow
                /*#if defined(SHADOWS_SCREEN)
                    shadow = (SAMPLE_DEPTH_TEXTURE_PROJ(_ShadowMapTexture, UNITY_PROJ_COORD(i._ShadowCoord)).r);
                #endif		*/	
       
                float4 baseColor = lerp(_BottomTint , _TopTint , saturate(i.uv.y)) * float4(i.diffuseColor, 1);
                float4 litColor = (baseColor * _LightColor0);
                float4 final = litColor;
                final.rgb = litColor * shadow;
                final += saturate((1 - shadow) * baseColor * 0.2);
                final += (unity_AmbientSky * baseColor * _AmbientStrength);
                UNITY_APPLY_FOG(i.fogCoord, final);
                #if FADE
                    float alpha = lerp(0, 1, saturate(i.uv.y * _Fade));
                    final.a = alpha;
                #endif
                return final;               
            }
            ENDCG
        }

        Pass
        {
            Tags
            {              
                "LightMode" = "ForwardAdd"
            }
            Blend OneMinusDstColor One
            ZWrite Off
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag									
            #pragma multi_compile_fwdadd_fullforwardshadows

            float4 frag(v2f i) : SV_Target
            {
                UNITY_LIGHT_ATTENUATION(atten, i, i.positionWS);
                float3 baseColor = lerp(_BottomTint , _TopTint , saturate(i.uv.y)) * i.diffuseColor;
                
                float3 pointlights = atten * _LightColor0.rgb * baseColor;
                #if FADE
                    float alpha = lerp(0, 1, saturate(i.uv.y * _Fade));
                    pointlights *= alpha;
                #endif

                return float4(pointlights, 1);
            }
            ENDCG
        }

        /*Pass 
        {
            
            Tags
            {
                "LightMode" = "ShadowCaster"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster

            float4 frag(v2f i) : SV_Target
            {

                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }*/


    }
    Fallback "VertexLit"
}
