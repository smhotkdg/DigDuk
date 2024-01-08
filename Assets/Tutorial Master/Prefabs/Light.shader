
Shader "Sprites/Night" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _AspectRatio ("Screen Aspect Ratio", Float) = 0
        _MechLight1 ("Mech1 Light", Vector) = (0, 0, 0, 0)
        _MechLight2 ("Mech2 Light", Vector) = (0, 0, 0, 0)
        _MechLight3 ("Mech3 Light", Vector) = (0, 0, 0, 0)
        _MechLight4 ("Mech4 Light", Vector) = (0, 0, 0, 0)
        _MechLight5 ("Mech5 Light", Vector) = (0, 0, 0, 0)
        _MechLight6 ("Mech6 Light", Vector) = (0, 0, 0, 0)
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            
            uniform float4 _MechLight1;
            uniform float4 _MechLight2;
            uniform float4 _MechLight3;
            uniform float4 _MechLight4;
            uniform float4 _MechLight5;
            uniform float4 _MechLight6;
            
            uniform float _AspectRatio;
            

            float4 frag(v2f_img i) : COLOR {
                float4 c = tex2D(_MainTex, i.uv);
                float2 ratio = float2(1, 1/_AspectRatio);
                float delta = 0;
                
                float ray = length((_MechLight1.xy - i.uv.xy) * ratio);
                delta += smoothstep(_MechLight1.z, 0, ray) * _MechLight1.w;
                
                ray = length((_MechLight2.xy - i.uv.xy) * ratio);
                delta += smoothstep(_MechLight2.z, 0, ray) * _MechLight2.w;
                
                ray = length((_MechLight3.xy - i.uv.xy) * ratio);
                delta += smoothstep(_MechLight3.z, 0, ray) * _MechLight3.w;
                
                ray = length((_MechLight4.xy - i.uv.xy) * ratio);
                delta += smoothstep(_MechLight4.z, 0, ray) * _MechLight4.w;
                
                ray = length((_MechLight5.xy - i.uv.xy) * ratio);
                delta += smoothstep(_MechLight5.z, 0, ray) * _MechLight5.w;
                
                ray = length((_MechLight6.xy - i.uv.xy) * ratio);
                delta += smoothstep(_MechLight6.z, 0, ray) * _MechLight6.w;
                
                c.rgb *= delta;
                return c;
            }
            ENDCG
        }
    }
}