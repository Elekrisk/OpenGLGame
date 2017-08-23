using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenGLGame
{
    struct ColouredVertex
    {
        public const int Size = (3 + 4) * 4;

        private readonly Vector3 position;
        private readonly Color4 color;

        public ColouredVertex(Vector3 pos, Color4 col)
        {
            position = pos;
            color = col;
        }
    }

    sealed class VertexBuffer<TVertex> where TVertex : struct
    {
        private readonly int vertexSize;
        private TVertex[] vertices = new TVertex[4];

        private int count;

        private readonly int handle;

        public VertexBuffer(int vertexSize)
        {
            this.vertexSize = vertexSize;

            handle = GL.GenBuffer();
        }

        public void AddVertex(TVertex v)
        {
            if (count == vertices.Length)
            {
                Array.Resize(ref vertices, count * 2);
            }

            vertices[count] = v;
            count++;
        }
        
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, handle);
        }

        public void BufferData()
        {
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertexSize * count), vertices, BufferUsageHint.StreamDraw);
        }

        public void Draw()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, count);
        }
    }

    sealed class GameWindow : OpenTK.GameWindow
    {
        public GameWindow() : base(1280, 720, GraphicsMode.Default, "HELLO WURLD", GameWindowFlags.Default, DisplayDevice.Default, 3, 0, GraphicsContextFlags.ForwardCompatible)
        {
            Console.WriteLine("OpenGL version: " + GL.GetString(StringName.Version));
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
        }

        protected override void OnLoad(EventArgs e)
        {

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(Color4.Purple);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            this.SwapBuffers();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow();
            window.Run(60);
        }
    }
}
