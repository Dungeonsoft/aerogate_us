Shader "R/Unlit" {
    Properties {
        _AddColor ("Main Color", Color) = (0,0,0,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    Category {
       Lighting Off
       ZWrite On
       Cull Back
       SubShader {
            Pass {
               SetTexture [_MainTex] {
                    constantColor [_AddColor]
                    Combine texture + constant
                 }
            }
        } 
    }
}