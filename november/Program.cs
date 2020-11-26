using System;
using Raylib_cs;

Raylib.InitWindow(1920, 1080, "Bil spel");
Texture2D background = Raylib.LoadTexture("highway.png");
Texture2D car = Raylib.LoadTexture("car.png");



string scene = "intro";
float x = 0;
float y = 0;






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
            x += 1.5f;
        }

        else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            x -= 1.5f;
        }

        else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            y += 1.5f;

        }

        else if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            y -= 1.5f;

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
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);
        Raylib.DrawTexture(car, (int)x, (int)y, Color.WHITE);
    
        
    }
    Raylib.EndDrawing();
}