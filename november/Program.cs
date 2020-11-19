using System;
using Raylib_cs;


namespace november
{
    class Program
    {
        static void Main(string[] args)
        {
            Texture2D highway = Raylib.LoadTexture("highway.png");

            Raylib.InitWindow(800, 600, "Bil spel");


            string scene = "intro";


            while (!Raylib.WindowShouldClose())
            {


                if (scene == "intro")
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        scene = "game";
                    }
                }
                else if (scene == "game")
                {
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {

                    }
                    else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {

                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
                    {
                        scene = "intro";
                    }
                }

                // DRAWING:
                Raylib.BeginDrawing();

                if (scene == "intro")
                {
                    Raylib.ClearBackground(Color.LIME);
                }
                else if (scene == "game")
                {
                    Raylib.ClearBackground(Color.MAROON);
                    Raylib.DrawTexture(highway, 800, 600, Color.WHITE);
                }

















                Raylib.EndDrawing();
            }

        }
    }
}
