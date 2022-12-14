using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace AnythingWorld.Utilities
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif  
    public static class MaterialCacheUtil
    {
        private const string materialTemplatePath = "MaterialTemplates/";
        public static Dictionary<string, Material> MaterialCacheDict
        {
            get
            {
                if (materialCacheDict == null)
                {
                    if(TryCacheMaterials(out materialCacheDict))
                    {
                        return materialCacheDict;
                    }
                    return null;
                }
                else
                {
                    return materialCacheDict;
                }
            }
        }
        private static Dictionary<string, Material> materialCacheDict;

        public static Dictionary<string, Material> CacheAndGetMaterials()
        {
            //Debug.Log("Loading material templates to cache");
            materialCacheDict = new Dictionary<string, Material>();
            materialCacheDict.Add("SIMPLE_LIT_STANDARD", Resources.Load<Material>($"{materialTemplatePath}SimpleLitStandard"));
            materialCacheDict.Add("SIMPLE_LIT_TRANSPARENT", Resources.Load<Material>($"{materialTemplatePath}SimpleLitTransparent"));
            //Debug.Log($"Cache length:{materialCacheDict.Keys.Count}");
            return materialCacheDict;
        }
        public static bool TryCacheMaterials(out Dictionary<string,Material> outDict)
        {
            try
            {
                outDict = new Dictionary<string, Material>();
                outDict.Add("SIMPLE_LIT_STANDARD", Resources.Load<Material>($"{materialTemplatePath}SimpleLitStandard"));
                outDict.Add("SIMPLE_LIT_TRANSPARENT", Resources.Load<Material>($"{materialTemplatePath}SimpleLitTransparent"));
            }
            catch(System.Exception e)
            {
                outDict = new Dictionary<string, Material>();
                Debug.LogException(e);
                return false;
            }

            if (outDict == null)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }
    }

}
