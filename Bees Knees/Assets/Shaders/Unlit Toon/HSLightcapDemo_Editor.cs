using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HSLightcapDemo_Editor : ShaderGUI
{

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties) {
        // Get the shader properties - if any new property, add it here
        MaterialProperty _LightcapTexture = ShaderGUI.FindProperty("_LightcapTexture", properties);
        MaterialProperty _LightcapPower = ShaderGUI.FindProperty("_LightcapPower", properties);
        MaterialProperty _LightcapAngle = ShaderGUI.FindProperty("_LightcapAngle", properties);

        MaterialProperty _Usetexture = ShaderGUI.FindProperty("_Usetexture", properties);
        MaterialProperty _BaseTexture = ShaderGUI.FindProperty("_BaseTexture", properties);

        MaterialProperty _Usetint = ShaderGUI.FindProperty("_Usetint", properties);
        MaterialProperty _TintColor = ShaderGUI.FindProperty("_TintColor", properties);
        MaterialProperty _TintPower = ShaderGUI.FindProperty("_TintPower", properties);

        MaterialProperty _Usenormal = ShaderGUI.FindProperty("_Usenormal", properties);
        MaterialProperty _NormalTexture = ShaderGUI.FindProperty("_NormalTexture", properties);
        MaterialProperty _NormalPower = ShaderGUI.FindProperty("_NormalPower", properties);

        MaterialProperty _Usedetail = ShaderGUI.FindProperty("_Usedetail", properties);
        MaterialProperty _DetailTexture = ShaderGUI.FindProperty("_DetailTexture", properties);
        MaterialProperty _DetailPower = ShaderGUI.FindProperty("_DetailPower", properties);
    
        MaterialProperty _LightcapColors = ShaderGUI.FindProperty("_LightcapColors", properties);

        MaterialProperty _BlackTones = ShaderGUI.FindProperty("_BlackTones", properties);
        MaterialProperty _DarkTones = ShaderGUI.FindProperty("_DarkTones", properties);
        MaterialProperty _MidTones = ShaderGUI.FindProperty("_MidTones", properties);
        MaterialProperty _BrightTones = ShaderGUI.FindProperty("_BrightTones", properties);
        MaterialProperty _WhiteTones = ShaderGUI.FindProperty("_WhiteTones", properties);

        MaterialProperty _TonesBlend = ShaderGUI.FindProperty("_TonesBlend", properties);
        MaterialProperty _Shadows = ShaderGUI.FindProperty("_Shadows", properties);
        MaterialProperty _RealtimeShadows = ShaderGUI.FindProperty("_RealtimeShadows", properties);
        MaterialProperty _ShadowMap = ShaderGUI.FindProperty("_ShadowMap", properties);
        MaterialProperty _ShadowMapColor = ShaderGUI.FindProperty("_ShadowMapColor", properties);

        MaterialProperty _Background = ShaderGUI.FindProperty("_Background", properties);

        
 // FROM HERE TO BOTTOM: TXT TO GRAPHIC
        
     // Always visible values

        // Background
        materialEditor.ShaderProperty(_Background, _Background.displayName);       
        // Background container
        if (_Background.floatValue == 1) {
                    EditorGUILayout.LabelField("       PREMIUM ONLY");
        }
        
        // Spaces
        EditorGUILayout.LabelField("-----------------");
        EditorGUILayout.Space();
        
        // Texture checkbox
        materialEditor.ShaderProperty(_Usetexture, _Usetexture.displayName);
        // Texture container
        if (_Usetexture.floatValue == 1) {
            materialEditor.ShaderProperty(_BaseTexture, _BaseTexture.displayName);
        }

        // Spaces
        EditorGUILayout.LabelField("-----------------");
        EditorGUILayout.Space();
        // Lightcap
        materialEditor.ShaderProperty(_LightcapTexture, _LightcapTexture.displayName);
        materialEditor.ShaderProperty(_LightcapPower, _LightcapPower.displayName);
        materialEditor.ShaderProperty(_LightcapAngle, _LightcapAngle.displayName);
        // Spaces
        EditorGUILayout.LabelField("-----------------");
        EditorGUILayout.Space();

        // Lightcap  Colors checkbox
        materialEditor.ShaderProperty(_LightcapColors, _LightcapColors.displayName);


        // _LightcapColors
            if (_LightcapColors.floatValue == 1) {
        EditorGUILayout.LabelField("       PREMIUM ONLY");
                materialEditor.ShaderProperty(_BlackTones, _BlackTones.displayName);
                materialEditor.ShaderProperty(_DarkTones, _DarkTones.displayName);
                materialEditor.ShaderProperty(_MidTones, _MidTones.displayName);
                materialEditor.ShaderProperty(_BrightTones, _BrightTones.displayName);
                materialEditor.ShaderProperty(_WhiteTones, _WhiteTones.displayName);
                materialEditor.ShaderProperty(_TonesBlend, _TonesBlend.displayName);
                }
                
         // Spaces
        EditorGUILayout.LabelField("-----------------");
        EditorGUILayout.Space();
        
        // Tint checkbox
        materialEditor.ShaderProperty(_Usetint, _Usetint.displayName);
        // Tint container
        if (_Usetint.floatValue == 1) {
        EditorGUILayout.LabelField("       PREMIUM ONLY");
            materialEditor.ShaderProperty(_TintColor, _TintColor.displayName);
            materialEditor.ShaderProperty(_TintPower, _TintPower.displayName);
        }

        // Spaces
        EditorGUILayout.LabelField("-----------------");
        EditorGUILayout.Space();

        // Normal checkbox
        materialEditor.ShaderProperty(_Usenormal, _Usenormal.displayName);
        // Normal container
        if (_Usenormal.floatValue == 1) {
        EditorGUILayout.LabelField("       PREMIUM ONLY");
            materialEditor.ShaderProperty(_NormalTexture, _NormalTexture.displayName);
            materialEditor.ShaderProperty(_NormalPower, _NormalPower.displayName);
        }
        
        // Spaces
        EditorGUILayout.LabelField("-----------------");
        EditorGUILayout.Space();

        // Shadowmap checkbox
        materialEditor.ShaderProperty(_Shadows, _Shadows.displayName); 
        // Shadowmap container
        if (_Shadows.floatValue == 1) {
        EditorGUILayout.LabelField("       PREMIUM ONLY");
                    materialEditor.ShaderProperty(_ShadowMap, _ShadowMap.displayName);
                    materialEditor.ShaderProperty(_RealtimeShadows, _RealtimeShadows.displayName);
                    materialEditor.ShaderProperty(_ShadowMapColor, _ShadowMapColor.displayName);
        }
        
        // Spaces
        EditorGUILayout.LabelField("-----------------");
        EditorGUILayout.Space();
        
        // Detail checkbox
        materialEditor.ShaderProperty(_Usedetail, _Usedetail.displayName);
        // Detail container
        if (_Usedetail.floatValue == 1) {
                    EditorGUILayout.LabelField("       PREMIUM ONLY");
            materialEditor.ShaderProperty(_DetailTexture, _DetailTexture.displayName);
            materialEditor.ShaderProperty(_DetailPower, _DetailPower.displayName);
        }

    }

}
