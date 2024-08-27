﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.IO;
using UnityEngine;

namespace GameFramework.Editor.DataTableTools
{
    public sealed partial class DataTableProcessor
    {
        private sealed class Vector3ArrayProcessor : GenericDataProcessor<Vector3[]>
        {
            public override bool IsSystem
            {
                get
                {
                    return false;
                }
            }

            public override string LanguageKeyword
            {
                get
                {
                    return "Vector3[]";
                }
            }

            public override int PopPriority => 25;

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "vector3[]",
                    "unityengine.vector3[]"
                };
            }

            public override Vector3[] Parse(string value)
            {
                return DataTableExtension.ParseVector3Array(value);
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                Vector3[] vector3Arr = Parse(value);
                for (int i = 0; i < vector3Arr.Length; i++)
                {
                    var vector3 = vector3Arr[i];
                    binaryWriter.Write(vector3.x);
                    binaryWriter.Write(vector3.y);
                    binaryWriter.Write(vector3.z);
                }
                
            }
        }
    }
}
