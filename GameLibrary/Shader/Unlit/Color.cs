﻿using OpenTK;
using System;

namespace GameLibrary.Shader
{
    public partial class BuildInShader
    {
        public sealed class Color : ShaderBase
        {
            public override string Fragment()
            {
                return
                    VersionInFunc() +
                    @"
out vec4 FragColor;
uniform vec3 Color;

void main(void)
{
    FragColor = vec4(Color, 1.0);
}
";
            }

            public override string Vertex()
            {
                return
                    VersionInFunc() +
                    MeshInFunc() +
                    @"
void main(void)
{
    gl_Position = mvp * aPosition;
}
";
            }
        }
    }

    public class EColorMat : EMaterial
    {
        public EColorMat() : base(ShaderFactory.Build(BuildinShader.Color))
        {
            vec3Input.Add(new Tuple<Vector3, string>(new Vector3(0.8f, 0.8f, 0.8f), "Color"));
        }
    }
}
