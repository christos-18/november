using System;
using Raylib_cs;

Raylib.InitWindow(1920, 1080, "Bil spel");
Texture2D background = Raylib.LoadTexture("highway.png");
Texture2D car = Raylib.LoadTexture("car.png");



string scene = "intro";
float backgroundY = 0;
float carX = 400;
float carY = 300;






while (!Raylib.WindowShouldClose())
{




    if (scene == "intro")
    {
        carX = 400;
        carY = 300;

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }


    else if (scene == "game")
    {
        backgroundY += 0.1f;

        if (backgroundY > 1080)
        {
            backgroundY = 0;

        }

        if (carY > Raylib.GetScreenHeight() || carX > Raylib.GetScreenWidth() || carY < 0 || carX < 0)
        {
            scene = "gameover";
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
        {
            scene = "intro";
        }





        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            carX += 0.8f;
        }

        else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            carX -= 0.8f;
        }



    }

    else if (scene == "gameover")
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawText("GAME OVER! Tryck tabb for att starta om", 100, 50, 20, Color.WHITE);


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
        Raylib.DrawTexture(background, 0, (int)backgroundY, Color.WHITE);
        Raylib.DrawTexture(background, 0, (int)backgroundY - 1080, Color.WHITE);
        Raylib.DrawTexture(car, (int)carX, (int)carY, Color.WHITE);


    }
    Raylib.EndDrawing();
}