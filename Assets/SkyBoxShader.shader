Shader "Skybox/SkyBoxShader"
{
    Properties
    {
        _Tint("Tint Color", Color) = (1,1,1,1)
        _Exposure("Exposure", Range(0,8)) = 1
        _RotationX("Rotation X", Range(-180,180)) = 0
        _RotationY("Rotation Y", Range(-180,180)) = 0
        _RotationZ("Rotation Z", Range(-180,180)) = 0
        [NoScaleOffset] _FrontTex("Front [+Z]", 2D) = "white" {}
        [NoScaleOffset] _BackTex("Back [-Z]", 2D) = "white" {}
        [NoScaleOffset] _LeftTex("Left [+X]", 2D) = "white" {}
        [NoScaleOffset] _RightTex("Right [-X]", 2D) = "white" {}
        [NoScaleOffset] _UpTex("Up [+Y]", 2D) = "white" {}
        [NoScaleOffset] _DownTex("Down [-Y]", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "Queue"="Background" "RenderType"="Background" }
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _FrontTex;
            sampler2D _BackTex;
            sampler2D _LeftTex;
            sampler2D _RightTex;
            sampler2D _UpTex;
            sampler2D _DownTex;

            float4 _Tint;
            float _Exposure;
            float _RotationX;
            float _RotationY;
            float _RotationZ;

            struct appdata { float4 vertex : POSITION; };
            struct v2f { float4 pos : SV_POSITION; float3 dir : TEXCOORD0; };

            float3 RotateX(float3 p, float a)
            {
                float s = sin(a);
                float c = cos(a);
                return float3(p.x, c*p.y - s*p.z, s*p.y + c*p.z);
            }

            float3 RotateY(float3 p, float a)
            {
                float s = sin(a);
                float c = cos(a);
                return float3(c*p.x + s*p.z, p.y, -s*p.x + c*p.z);
            }

            float3 RotateZ(float3 p, float a)
            {
                float s = sin(a);
                float c = cos(a);
                return float3(c*p.x - s*p.y, s*p.x + c*p.y, p.z);
            }

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.dir = normalize(v.vertex.xyz);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 dir = i.dir;
                dir = RotateX(dir, radians(_RotationX));
                dir = RotateY(dir, radians(_RotationY));
                dir = RotateZ(dir, radians(_RotationZ));

                // выбираем правильную текстуру для каждой стороны
                float3 absDir = abs(dir);
                fixed4 col;
                if (absDir.z >= absDir.x && absDir.z >= absDir.y)
                    col = dir.z > 0 ? tex2D(_FrontTex, dir.xy * 0.5 + 0.5) : tex2D(_BackTex, float2(-dir.x, dir.y)*0.5 + 0.5);
                else if (absDir.x >= absDir.y)
                    col = dir.x > 0 ? tex2D(_RightTex, float2(-dir.z, dir.y)*0.5 + 0.5) : tex2D(_LeftTex, float2(dir.z, dir.y)*0.5 + 0.5);
                else
                    col = dir.y > 0 ? tex2D(_UpTex, float2(dir.x, -dir.z)*0.5 + 0.5) : tex2D(_DownTex, float2(dir.x, dir.z)*0.5 + 0.5);

                // Tint + Exposure как в стандартном 6-Sided
                col.rgb = col.rgb * _Tint.rgb;
                col.rgb = col.rgb * _Exposure;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Skybox/SkyBoxShader"
}